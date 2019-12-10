using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Turtle : MonoBehaviour
{
    public int point_value;
    public float speed;
    public bool came_close;
    public Vector3 end_pos;
    public Vector3 dir;
    public int rotationSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        speed = 0.4f;
        came_close = false;
        float ran_x = Random.Range(-1, 1);
        float ran_y = Random.Range(-1, 1);
        dir = new Vector3(0, 0, 0);

        if (ran_x == 0)
            ran_x = 1;
        if (ran_y == 0)
            ran_y = 0;
        end_pos = new Vector3(ran_x * 50, 1.0f, ran_y * 40);

    }


    void collisionEnter(Collision collision)
    {

    }


    // Update is called once per frame
    void Update()
    {

        if (dir != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(
            transform.rotation,
            Quaternion.LookRotation(dir),
            Time.deltaTime * rotationSpeed);
        }

        //random location
        float step = speed * Time.deltaTime;

        if (transform.position.x > 0.1 && !came_close)
        {
            //if fish is far, move it towars the player
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, 0.01f, 0), step);
        }
        else if (transform.position.x <= 0.1 && !came_close)
        {
            //if the fish is at the player, keep it moving
            //Debug.Log("I AM HERE!");
            came_close = true;
            dir = end_pos;
        }
        else if (came_close)
        {
            transform.position = Vector3.MoveTowards(transform.position, end_pos, step);
        }

        if (transform.position.x >= 3
            || transform.position.x <= -3
            || transform.position.z >= 3
            || transform.position.z <= -3)
        {
            Destroy(gameObject);
        }
    }
}
