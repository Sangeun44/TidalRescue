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
    NORMAL,

    NUM_ATTRIBUTETYPES
}

public class SeaAnimalHandler : MonoBehaviour
{
    public List<SeaAnimal> all_animals;
    public MainGameHandler main_game_handler;

    private int spawnMod = 5; // every 5 seconds.

    void Start()
    {
        all_animals = new List<SeaAnimal>();
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
            all_animals.Add(temp);
        }
    }
}
