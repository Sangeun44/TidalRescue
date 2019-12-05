using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class fish_SICK : MonoBehaviour
{
    public int point_value;

    public int speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 3;
    }

    public void Setup(AnimalType animal, AttributeType attribute)
    {
    }

    // Update is called once per frame
    void Update()
    {
        // MOVE RANDOMLY
        //transform.position += new Vector3(1, 1, 1);
        if (transform.position != new Vector3(0, 0, 0))
        {
            //if fish is far, move it towars the player
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, 0, 0), step);
        }
        else if (transform.position == new Vector3(0, 0, 0))
        {
            //if the fish is at the player, keep it moving
            float step = speed * Time.deltaTime;
            transform.position += transform.forward * Time.deltaTime * speed;
        } else {
            //if fish is out of bouns estroy

        }

        //Debug.Log("A");
        //Debug.Log(transform.position.x + " " + transform.position.y + " " + transform.position.z);
    }
}
