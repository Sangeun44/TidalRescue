using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class fish_TAG : MonoBehaviour
{
    public int point_value;
    public Vector3 end_pos;
    public int speed;
    public bool came_close;

    // Start is called before the first frame update
    void Start()
    {
        float ran_x = Random.Range(-1,1);
        float ran_y = Random.Range(-1,1);
        if (ran_x == 0) 
            ran_x = 1;
        if(ran_y == 0)
            ran_y = 0;
        end_pos = new Vector3(ran_x * 50, 1, ran_y * 40);        
        
        speed = 1;
        came_close = false;

    }
    public void Setup(AnimalType animal, AttributeType attribute)
    {
    }

    void collisionEnter (Collision collision) {
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
        if (transform.position.x > 0.1 && !came_close)
        {
            //if fish is far, move it towars the player
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, 1, 0), step);
        }
        else if (transform.position.x <= 0.1 && !came_close)
        {
            //if the fish is at the player, keep it moving
            //Debug.Log("I AM HERE!");s
            came_close = true;
        }
        else if (came_close)
        {
            //if fish is out of bouns estroy
            transform.position = Vector3.MoveTowards(transform.position, end_pos, step);
        }
        //Debug.Log("A");
        //Debug.Log(transform.position.x + " " + transform.position.y + " " + transform.position.z);
    }
}
