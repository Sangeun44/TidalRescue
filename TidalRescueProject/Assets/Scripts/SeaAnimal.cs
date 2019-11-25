using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SeaAnimal : MonoBehaviour
{
    AnimalType animal_type;
    AttributeType attribute_type;

    // Start is called before the first frame update
    void Start()
    {
    }
    
    public void Setup(AnimalType animal, AttributeType attribute)
    {
        animal_type = animal;
        attribute_type = attribute;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
