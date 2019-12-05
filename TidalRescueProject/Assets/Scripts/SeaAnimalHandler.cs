﻿using System.Collections;
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

            SeaAnimal temp = new SeaAnimal(); //create new sea animal

            //set up sea animal
            temp.Setup(
                (AnimalType)(random.x * (float)AnimalType.NUM_ANIMALTYPES), 
                (AttributeType)(random.y * (float)AttributeType.NUM_ATTRIBUTETYPES)
            );

            //random location
            int random_int1 = Random.Range(0, 5);
            int random_int2 = Random.Range(0, 5);
            int random_int3 = Random.Range(0, 5);
            //Debug.Log(random_int1 + " " + random_int2 + " " + random_int3);

            switch (temp.animal_type)
            {
                case AnimalType.FISH:
                    if (temp.attribute_type == AttributeType.SICK)
                    {
                        Vector3 position = new Vector3(random_int1, random_int2, random_int3);
                        temp.visual = Instantiate(sickFish, position, Quaternion.identity);
                        temp.visual.gameObject.tag = "SICK";
                    }
                    else if (temp.attribute_type == AttributeType.TAGGED)
                    {
                        Vector3 position = new Vector3(random_int1, random_int2, random_int3);
                        temp.visual = Instantiate(taggedFish, position, Quaternion.identity);
                        temp.visual.gameObject.tag = "TAGGED";
                    }
                    break;
                case AnimalType.TURTLE:
                    if (temp.attribute_type == AttributeType.SICK)
                    {
                        Vector3 position = new Vector3(random_int1, random_int2, random_int3);
                        temp.visual = Instantiate(sickTurtle, position, Quaternion.identity);
                        temp.visual.gameObject.tag = "SICK";
                    }
                    else if (temp.attribute_type == AttributeType.TAGGED)
                    {
                        Vector3 position = new Vector3(random_int1, random_int2, random_int3);
                        temp.visual = Instantiate(taggedTurtle, position, Quaternion.identity);
                        temp.visual.gameObject.tag = "TAGGED";
                    }
                    break;
                case AnimalType.CRAB:
                    if (temp.attribute_type == AttributeType.SICK)
                    {
                        Vector3 position = new Vector3(random_int1, 0, random_int3);
                        temp.visual = Instantiate(sickCrab, position, Quaternion.identity);
                        temp.visual.gameObject.tag = "SICK";
                    }
                    else if (temp.attribute_type == AttributeType.TAGGED)
                    {
                        Vector3 position = new Vector3(random_int1, 0, random_int3);
                        temp.visual = Instantiate(taggedCrab, position, Quaternion.identity);
                        temp.visual.gameObject.tag = "TAGGED";
                    }
                    break;
                default:
                    Debug.Log("Should not reach this case");
                    break;
            }
        }
    }
}
