using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Trash : MonoBehaviour
{
    public TrashType trash_type;
    public int point_value;

    public GameObject visual;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void Setup(TrashType trash)
    {
        trash_type = trash;
    }

    // Update is called once per frame
    void Update()
    {
        // MOVE RANDOMLY
    }
}
