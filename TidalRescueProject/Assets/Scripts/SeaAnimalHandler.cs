using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AnimalType
{
    FISH = 0,
    TURTLE,

    NUM_ANIMALTYPES
}

public enum AttributeType
{
    SICK,
    TAGGED,

    NUM_ATTRIBUTETYPES
}

public class SeaAnimalHandler : MonoBehaviour
{
    public MainGameHandler main_game_handler;

    public GameObject sickFish;
    public GameObject taggedFish;

    public GameObject sickTurtle;
    public GameObject taggedTurtle;


    private int spawnMod = 30; // every 5 seconds.

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // GameObject[] tagges = GameObject.FindGameObjectsWithTag("TAGGED");
        // GameObject[] sicks = GameObject.FindGameObjectsWithTag("SICK");

        if (main_game_handler.game_timer % spawnMod == 0 && main_game_handler.game_started) {
            Debug.Log("game spawning animals");

            // add new sea animal
            Vector2 random = Random.insideUnitCircle;
            // SeaAnimal temp = new SeaAnimal(); //create new sea animal
            AnimalType animal_ran =(AnimalType) Random.Range(0,(float)AnimalType.NUM_ANIMALTYPES);
            AttributeType attribute_ran =(AttributeType) Random.Range(0,(float)AttributeType.NUM_ATTRIBUTETYPES);

            ////set up sea animal
            // AnimalType animal = (AnimalType)(random.x * (float)AnimalType.NUM_ANIMALTYPES);
            // AttributeType attribute = (AttributeType)(random.x * (float)AttributeType.NUM_ATTRIBUTETYPES);
            
            Debug.Log("r");

            Vector2 random2 = Random.insideUnitCircle;

            switch (animal_ran)
            {
                case AnimalType.FISH:
                    if (attribute_ran == AttributeType.SICK)
                    {
                        //sick fish  
                        Vector3 position = new Vector3(random2.x * 20, 1, random2.y * 20);
                        GameObject fish_sick = Instantiate(sickFish, position, Quaternion.identity);

                        Vector3 relativePos = Vector3.zero - position;
                        fish_sick.transform.rotation = Quaternion.LookRotation(relativePos, Vector3.up);
              
                        fish_sick.gameObject.tag = "SICK";
                    }
                    else if (attribute_ran == AttributeType.TAGGED)
                    {
                        //tagge fish
                        Vector3 position = new Vector3(random2.x * 20, 1, random2.y *20);
                        GameObject fish_tag = Instantiate(taggedFish, position, Quaternion.identity);

                        Vector3 relativePos = Vector3.zero - position;
                        fish_tag.transform.rotation = Quaternion.LookRotation(relativePos, Vector3.up);

                        fish_tag.gameObject.tag = "TAGGED";
                        Debug.Log("TAGGED FISH!!!!!!!!!!");
                    }
                    break;
                case AnimalType.TURTLE:
                    if (attribute_ran == AttributeType.SICK)
                    {
                        //sick turtle  
                        Vector3 position = new Vector3(random2.x * 3, 0, random2.y * 3);
                        GameObject turtle_sick = Instantiate(sickTurtle, position, Quaternion.identity);

                        Vector3 relativePos = Vector3.zero - position;
                        turtle_sick.transform.rotation = Quaternion.LookRotation(relativePos, Vector3.up);

                        turtle_sick.gameObject.tag = "SICK";
                    }
                    else if (attribute_ran == AttributeType.TAGGED)
                    {
                        //tagge turtle
                        Vector3 position = new Vector3(random2.x * 3, 0, random2.y * 3);
                        GameObject turtle_tag = Instantiate(taggedTurtle, position, Quaternion.identity);

                        Vector3 relativePos = Vector3.zero - position;
                        turtle_tag.transform.rotation = Quaternion.LookRotation(relativePos, Vector3.up);

                        turtle_tag.gameObject.tag = "TAGGED";
                    }
                    break;
                default:
                    Debug.Log("Should not reach this case");
                    break;
            }
        }
    }
}
