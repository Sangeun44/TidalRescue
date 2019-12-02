using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ViveInput : MonoBehaviour
{
    public SteamVR_Input_Sources hand_type;

    public SteamVR_Action_Boolean action;
    public SteamVR_Behaviour_Pose controller_pose;

    public GameObject colliding_object;
    public GameObject held_object;

    public void OnCollisionEnter(Collision other)
    {
        SetCollidingObject(other.collider);
    }

    public void OnCollisionStay(Collision other)
    {
        SetCollidingObject(other.collider);
    }

    public void OnCollisionExit(Collision other)
    {
        if (!colliding_object) { return; }

        colliding_object = null;
    }

    private void SetCollidingObject(Collider col)
    {
        colliding_object = col.gameObject;
    }

    private void GrabObject()
    {
        held_object = colliding_object;
        colliding_object = null;
        var joint = AddFixedJoint();
        joint.connectedBody = held_object.GetComponent<Rigidbody>();
    }

    private FixedJoint AddFixedJoint()
    {
        FixedJoint newFixedJoint = gameObject.AddComponent<FixedJoint>();
        newFixedJoint.breakForce = 20000;
        newFixedJoint.breakTorque = 20000;
        return newFixedJoint;
    }

    private void ReleaseObject()
    {
        if (GetComponent<FixedJoint>())
        {
            GetComponent<FixedJoint>().connectedBody = null;
            Destroy(GetComponent<FixedJoint>());

            held_object.GetComponent<Rigidbody>().velocity = controller_pose.GetVelocity();
            held_object.GetComponent<Rigidbody>().angularVelocity = controller_pose.GetAngularVelocity();
        }

        held_object = null;
    }

    public bool CurrentlyGrabbing()
    {
        return action.GetState(hand_type);
    }

    void Update()
    {
        /*if (action.GetLastStateDown(hand_type) && colliding_object)
        {
            Debug.Log("GRABBING OBJECT");
            GrabObject();
        }

        if (action.GetLastStateUp(hand_type) && held_object)
        {
            Debug.Log("RELEASING OBJECT");
            ReleaseObject();
        }*/
    }
}
