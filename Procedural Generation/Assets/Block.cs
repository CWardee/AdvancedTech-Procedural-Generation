using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public GameObject grass_Plain;
    public GameObject grass_Tall;


    public bool grass_Plain_Bool = false;
    public bool grass_Tall_Bool = false;

    public float xPos;
    public float yPos;
    public float zPos;


    void resetBools()
    {
        grass_Plain_Bool = false;
        grass_Tall_Bool = false;
    }
    public void SetBlockType(string input)
    {
        switch(input)
        {
            case "GrassPlain":

                break;

            case "GrassTall":


               break;


        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
