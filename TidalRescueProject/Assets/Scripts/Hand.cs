using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Hand : MonoBehaviour
{
    // checking pick up/drop
    public SteamVR_Action_Boolean grab_action = null;
    public AudioClip heal_sound;
    public AudioClip fail_sound;

    private SteamVR_Behaviour_Pose pose = null;
    private FixedJoint joint = null;
    private Interactable current_interactable = null;
    private List<Interactable> contacted = new List<Interactable>();
    private Interactable held_object = null;

    // timer 
    private int heal_time = 0;
    private bool held = false;
    private GameObject bubble = null;
    private bool heal_complete = false;

    // Start is called before the first frame update
    private void Awake()
    {
        pose = GetComponent<SteamVR_Behaviour_Pose>();
        joint = GetComponent<FixedJoint>();
    }

    // Update is called once per frame
    private void Update()
    {

        // check if the player is currently holding a bubble
        if (held && bubble != null) {
            // wait for player to transform bubble in their entirety
            ++heal_time;
            float t = heal_time / 200.0f;
            t = Mathf.Clamp(t, 0, 1);
            bubble.GetComponent<Renderer>().material.color = Color.Lerp(bubble.GetComponent<Renderer>().material.color, 
                                                                        new Color(0, 0, 3, 0.3f), 
                                                                        t);

            // once bubble is completely blue, healing is complete!
            if (bubble.GetComponent<Renderer>().material.color == new Color(0, 0, 3, 0.3f)) {
                Debug.Log("HEAL COMPLETE!");
                MainGameHandler.score += 100;
                heal_time = 0;
                heal_complete = true;
                held = false;
                AudioSource.PlayClipAtPoint(heal_sound, new Vector3(0, 3, 0));
            }
        }

        // down 
        if (grab_action.GetStateDown(pose.inputSource)) {
            //Debug.Log(pose.inputSource + " Trigger Pressed");
            ++heal_time;
            held = true;
            Pickup();
        }

        // up
        if (grab_action.GetStateUp(pose.inputSource)) {
            //Debug.Log(pose.inputSource + " Trigger Released");
            held = false;
            heal_time = 0;
            bubble = null;

            // if the bubble is released too early
            if (held_object && !heal_complete) {
                AudioSource.PlayClipAtPoint(fail_sound, new Vector3(0, 3, 0));
                MainGameHandler.score -= 50;
            }   

            Drop();
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (!other.gameObject.CompareTag("TAGGED") 
                && !other.gameObject.CompareTag("SICK")) {
            return;
        }
        contacted.Add(other.gameObject.GetComponent<Interactable>());
        held_object = other.gameObject.GetComponent<Interactable>();
    }

    private void OnTriggerExit(Collider other) {
        if (!other.gameObject.CompareTag("TAGGED") 
                && !other.gameObject.CompareTag("SICK")) {
            return;
        }
        contacted.Remove(other.gameObject.GetComponent<Interactable>());
        held_object = null; //other.gameObject.GetComponent<Interactable>();
        heal_complete = false;
    }
 
    public void Pickup() {
        
        // get nearest
        current_interactable = GetNearestInteractable();

        //check for null
        if (!current_interactable) return;
    
        //already held check
        if (current_interactable.active_hand) current_interactable.active_hand.Drop();

        // if left hand touches non-tagged fish, fail and drop fish
        if ((pose.inputSource == SteamVR_Input_Sources.LeftHand) && !current_interactable.gameObject.CompareTag("TAGGED") ) {
            AudioSource.PlayClipAtPoint(fail_sound, new Vector3(0, 3, 0));
            current_interactable.active_hand.Drop();
            MainGameHandler.score -= 5;
            return;
        }

        // if right hand touches non-sick fish, fail and drop fish
        if ((pose.inputSource == SteamVR_Input_Sources.RightHand) && !current_interactable.gameObject.CompareTag("SICK") ) {
            AudioSource.PlayClipAtPoint(fail_sound, new Vector3(0, 3, 0));
            current_interactable.active_hand.Drop();
            MainGameHandler.score -= 5;
            return;
        }

        // position
        current_interactable.transform.position = transform.position;

        // attach
        Rigidbody target = current_interactable.GetComponent<Rigidbody>();
        joint.connectedBody = target;
        bubble = current_interactable.gameObject.transform.GetChild(0).gameObject;

        // set active hand
        current_interactable.active_hand = this;

        print("BOX CAPTURED AND PICKED UP");
    }

    public void Drop() {
        // null check
        if (!current_interactable) return;

        // apply vel
        Rigidbody target = current_interactable.GetComponent<Rigidbody>();
        target.velocity = pose.GetVelocity();
        target.angularVelocity = pose.GetAngularVelocity();

        // detatch
        joint.connectedBody = null;

        // clear
        current_interactable.active_hand = null;
        current_interactable = null;
    }

    private Interactable GetNearestInteractable() {
        Interactable nearest = null;
        float min_dist = float.MaxValue;
        float distance = 0.0f;

        foreach(Interactable interactable in contacted) {
            Vector3 offset = interactable.transform.position - transform.position;
            distance = offset.sqrMagnitude;

            if (distance < min_dist) {
                min_dist = distance;
                nearest = interactable;
            }
        }

        return nearest;
    }


}
