using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //Grassland Blocks
    public GameObject grass_Plain;
    public GameObject grass_Tall;
    //Mudland Blocks
    public GameObject mud_Plain;
    public GameObject mud_Grass;
   
    public float xPos;
    public float yPos;
    public float zPos;

    public float test;

    public string CurrentBiome;

    public void RandomBiome()
    {
        float x = Random.Range(0.0f, 3.0f);
        {
            test = x;

            if(x < 2)
            {
                SetBiome("Grassland");
            }

            else
            {
                SetBiome("Mudland");
            }
        }
    }

    public void SetBiome(string biome)
    {
        GameObject thisBlock;
        switch (biome)
        {
            //Grassland
            case "Grassland":
                {
                    float x = Random.Range(0.0f, 3.0f);
                    if (x < 1)
                    {
                        thisBlock = grass_Plain;
                        CurrentBiome = "Grassland";
                    }

                    else
                    {
                        thisBlock = grass_Tall;
                        CurrentBiome = "Grassland";
                    }
                }
                break;

            //Mudland
            default:
                {
                    float x = Random.Range(0.0f, 3.0f);
                    if (x < 1)
                    {
                        thisBlock = mud_Grass;
                        CurrentBiome = "Mudland";
                    }

                    else
                    {
                        thisBlock = mud_Plain;
                        CurrentBiome = "Mudland";
                    }
                }

                break;

        }

    }

    // Start is called before the first frame update
    void Start()
    {
        RandomBiome();
        xPos = this.gameObject.transform.position.x;
        yPos = this.gameObject.transform.position.y;
        zPos = this.gameObject.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {

    }
}

