using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SeaAnimal : MonoBehaviour
{
    public AnimalType animal_type;
    public AttributeType attribute_type;
    public int point_value;

    public GameObject visual;

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
        // MOVE RANDOMLY
        visual.transform.position += new Vector3(1, 1, 1);
        Debug.Log("A");
        Debug.Log(visual.transform.position.x + " " + visual.transform.position.y + " " + visual.transform.position.z);
    }
}
