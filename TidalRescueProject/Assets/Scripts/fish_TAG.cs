using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class fish_TAG : MonoBehaviour
{
    public int point_value;

    public int speed;
    public bool came_close;

    // Start is called before the first frame update
    void Start()
    {
        speed = 2;
        came_close = false;

    }
    public void Setup(AnimalType animal, AttributeType attribute)
    {
    }

    // Update is called once per frame
    void Update()
    {
        // MOVE RANDOMLY

        //random location
        float step = speed * Time.deltaTime;

        // MOVE RANDOMLY
        //transform.position += new Vector3(1, 1, 1);

        // MOVE RANDOMLY
        //transform.position += new Vector3(1, 1, 1);
        if (transform.position.y > 0.5 && !came_close)
        {
            //if fish is far, move it towars the player
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(Random.Range(-1, 1), Random.Range(0, 1), Random.Range(-1, 1)), step);
        }
        else if (transform.position.y <= 0.5 && !came_close)
        {
            //if the fish is at the player, keep it moving
            Debug.Log("I AM HERE!");
            came_close = true;
        }
        else if (came_close)
        {
            //if fish is out of bouns estroy
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(Random.Range(-50, 50), Random.Range(10, 50), Random.Range(-50, 50)), step);
        }
        //Debug.Log("A");
        //Debug.Log(transform.position.x + " " + transform.position.y + " " + transform.position.z);
    }
}
