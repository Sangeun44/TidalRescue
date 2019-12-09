using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AnimalType
{
    FISH = 0,
    TURTLE,
    CRAB,

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

    public GameObject sickCrab;
    public GameObject taggedCrab;

    private int spawnMod = 10; // every 5 seconds.

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (main_game_handler.game_timer % spawnMod == 0 && main_game_handler.game_started)
        {
            Debug.Log("game spawning animals");

            // add new sea animal
            Vector2 random = Random.insideUnitCircle;
            Debug.Log(random);
            SeaAnimal temp = new SeaAnimal(); //create new sea animal

            ////set up sea animal
            temp.Setup(
                (AnimalType)(random.x * (float)AnimalType.NUM_ANIMALTYPES),
                (AttributeType)(random.y * (float)AttributeType.NUM_ATTRIBUTETYPES)
            );

            switch (temp.animal_type)
            {
                case AnimalType.FISH:
                    if (temp.attribute_type == AttributeType.SICK)
                    {
                        //sick fish  
                        Vector3 position = new Vector3(random.x * 20, 1, random.y * 20);
                        GameObject fish_sick = Instantiate(sickFish, position, Quaternion.identity);
                        fish_sick.transform.rotation = Quaternion.LookRotation(new Vector3(0,0,0));
                        fish_sick.gameObject.tag = "SICK";
                    }
                    else if (temp.attribute_type == AttributeType.TAGGED)
                    {
                        //tagge fish
                        Vector3 position = new Vector3(random.x * 20, 1, random.y *20);
                        GameObject fish_tag = Instantiate(taggedFish, position, Quaternion.identity);
                        fish_tag.transform.rotation = Quaternion.LookRotation(new Vector3(0,0,0));
                        fish_tag.gameObject.tag = "TAGGED";
                    }
                    break;
                    
                default:
                    Debug.Log("Should not reach this case");
                    break;
            }
        }
    }
}
