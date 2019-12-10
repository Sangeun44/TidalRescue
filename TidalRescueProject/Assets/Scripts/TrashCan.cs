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
            MainGameHandler.score += 10; //increase points
            Destroy(collision.gameObject);

        }


    }

}
