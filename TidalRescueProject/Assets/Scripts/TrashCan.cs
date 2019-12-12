using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour
{
    public MainGameHandler main_game_handler;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "TRASH")
        {
            //If the GameObject's name matches the one you suggest, output this message in the console
            Debug.Log("trash tecte");
            main_game_handler.points += 10; //increase points
            main_game_handler.IncreaseBubble();
            Destroy(collision.gameObject);

        }


    }

}
