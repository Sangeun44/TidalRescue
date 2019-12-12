using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TrashType
{
    CAN1 = 0,
    CAN2,
    SMALL,
    TALL1,
    TALL2,
    MEAT1,
    MEAT2,
    MEAT3,
    SODA,
    SPAM,

    NUM_TRASHTYPE
}


public class TrashSpawner : MonoBehaviour
{
    public MainGameHandler main_game_handler;

    public GameObject can1;
    public GameObject can2;
    public GameObject can_small;
    public GameObject can_tall1;
    public GameObject can_tall2;
    public GameObject meat_can1;
    public GameObject meat_can2;
    public GameObject meat_can3;
    public GameObject can_soda;
    public GameObject can_spam;

    private int spawnMod = 5; // every 5 seconds.

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] respawns = GameObject.FindGameObjectsWithTag("TRASH");
        if (main_game_handler.game_timer % spawnMod == 0 && main_game_handler.game_started
            && respawns.Length < 20)
        {
            Debug.Log("game spawning animals");

            // add new sea animal
            Vector2 random = Random.insideUnitCircle;
            //Debug.Log(random);
            // Trash temp = new Trash(); //create new sea animal

            ////set up sea animal
            TrashType trash = (TrashType)(random.x * (float)TrashType.NUM_TRASHTYPE);
            Vector3 position = new Vector3(random.x * 2, 0, random.y * 2);

            float EPSILON = 0;
            if (System.Math.Abs(position.x) < EPSILON)
            {
                position.x = 1;
            }
            else if (System.Math.Abs(position.y) < EPSILON) {
                position.z = 1;
            }

            switch (trash)
            {
                case TrashType.CAN1:                    
                     GameObject can_go = Instantiate(can1, position, Quaternion.identity);
                    can_go.gameObject.tag = "TRASH";                                        
                    break;
                case TrashType.CAN2:
                    GameObject can_go2 = Instantiate(can2, position, Quaternion.identity);
                    can_go2.gameObject.tag = "TRASH";
                    break;
                case TrashType.SMALL:
                    GameObject can_go3 = Instantiate(can_small, position, Quaternion.identity);
                    can_go3.gameObject.tag = "TRASH";
                    break;
                case TrashType.TALL1:
                    GameObject can_go4 = Instantiate(can_tall1, position, Quaternion.identity);
                    can_go4.gameObject.tag = "TRASH";
                    break;
                case TrashType.TALL2:
                    GameObject can_go5 = Instantiate(can_tall2, position, Quaternion.identity);
                    can_go5.gameObject.tag = "TRASH";
                    break;
                case TrashType.MEAT1:
                    GameObject can_go6 = Instantiate(meat_can1, position, Quaternion.identity);
                    can_go6.gameObject.tag = "TRASH";
                    break;
                case TrashType.MEAT2:
                    GameObject can_go7 = Instantiate(meat_can2, position, Quaternion.identity);
                    can_go7.gameObject.tag = "TRASH";
                    break;
                case TrashType.MEAT3:
                    GameObject can_go8 = Instantiate(meat_can3, position, Quaternion.identity);
                    can_go8.gameObject.tag = "TRASH";
                    break;
                case TrashType.SODA:
                    GameObject can_go9 = Instantiate(can_soda, position, Quaternion.identity);
                    can_go9.gameObject.tag = "TRASH";
                    break;
                case TrashType.SPAM:
                    GameObject can_go10 = Instantiate(can_spam, position, Quaternion.identity);
                    can_go10.gameObject.tag = "TRASH";
                    break;
                default:
                    Debug.Log("Should not reach this case");
                    break;
            }
        }
    }
}
