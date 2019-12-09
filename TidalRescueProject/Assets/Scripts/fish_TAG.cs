using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class fish_TAGGED : MonoBehaviour
{
    public int point_value;
    public int speed;
    public bool came_close;
    public Vector3 end_pos;
    public Vector3 dir;
    public int rotationSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        speed = 1;
        came_close = false;
        float ran_x = Random.Range(-1,1);
        float ran_y = Random.Range(-1,1);
        dir =  new Vector3(0, 0, 0);

        if (ran_x == 0) 
            ran_x = 1;
        if(ran_y == 0)
            ran_y = 0;
        end_pos = new Vector3(ran_x * 50, 1, ran_y * 40);

    }

    public void Setup(AnimalType animal, AttributeType attribute)
    {
    }

    void collisionEnter (Collision collision) {

    }


    // Update is called once per frame
    void Update()
    {
        
        if (dir != Vector3.zero) {
            transform.rotation = Quaternion.Slerp(
            transform.rotation,
            Quaternion.LookRotation(dir),
            Time.deltaTime * rotationSpeed);
        }
        //random location

        //float step = speed * Time.deltaTime;
        //transform.position = Vector3.MoveTowards(transform.position, new Vector3(random_int1, random_int2, random_int3), step);
        //random location
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
            dir = end_pos;
        }
        else if (came_close)
        {
            transform.position = Vector3.MoveTowards(transform.position, end_pos, step);

            //if fish is out of bouns estroy
        }
    }
}
