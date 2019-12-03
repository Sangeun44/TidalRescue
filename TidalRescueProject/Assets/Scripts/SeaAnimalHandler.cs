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
    public GameObject sickTurtle;
    public GameObject sickCrab;
    public GameObject taggedFish;
    public GameObject taggedTurtle;
    public GameObject taggedCrab;

    private int spawnMod = 5; // every 5 seconds.

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (main_game_handler.game_timer % spawnMod == 0)
        {
            // add new sea animal
            Vector2 random = Random.insideUnitCircle;
            SeaAnimal temp = new SeaAnimal();
            temp.Setup(
                (AnimalType)(random.x * (float)AnimalType.NUM_ANIMALTYPES),
                (AttributeType)(random.y * (float)AttributeType.NUM_ATTRIBUTETYPES)
            );

            switch (temp.animal_type)
            {
                case AnimalType.FISH:
                    if (temp.attribute_type == AttributeType.SICK)
                    {
                        temp.visual = GameObject.Instantiate(sickFish, new Vector3(1, 1, 0), Quaternion.identity);
                    }
                    else if (temp.attribute_type == AttributeType.TAGGED)
                    {
                        temp.visual = GameObject.Instantiate(taggedFish, new Vector3(1, 1, 0), Quaternion.identity);
                    }
                    break;
                case AnimalType.TURTLE:
                    if (temp.attribute_type == AttributeType.SICK)
                    {
                        temp.visual = GameObject.Instantiate(sickTurtle, new Vector3(1, 1, 0), Quaternion.identity);
                    }
                    else if (temp.attribute_type == AttributeType.TAGGED)
                    {
                        temp.visual = GameObject.Instantiate(taggedTurtle, new Vector3(1, 1, 0), Quaternion.identity);
                    }
                    break;
                case AnimalType.CRAB:
                    if (temp.attribute_type == AttributeType.SICK)
                    {
                        temp.visual = GameObject.Instantiate(sickCrab, new Vector3(1, 1, 0), Quaternion.identity);
                    }
                    else if (temp.attribute_type == AttributeType.TAGGED)
                    {
                        temp.visual = GameObject.Instantiate(taggedCrab, new Vector3(1, 1, 0), Quaternion.identity);
                    }
                    break;
                default:
                    Debug.Log("Should not reach this case");
                    break;
            }
        }
    }
}
