using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralGeneration : MonoBehaviour
{
    public float currentRandomNumber;

    private bool SelectNewBiome = true;



    private int maxBlocksPerCell = 100;
    public float maxCells = 6;
    public float currentRow = 0;
    public float maxRows = 6;

    public bool Grassland = true;
    public bool MudLand = false;
    public bool Forest = false;


    public int i = 0;
    public int currentCell = 0;
    public float maxHeight = 0;
    public float depthPos = 0;
    public float defaultDepthPos = 0;
    public float defaultWidthPos = 0;
    public float widthPos = 0;
    public bool cellSpawned = false;


    public GameObject Grassland_block1;
    public GameObject Grassland_block2;
    public GameObject Grassland_block3;
    public GameObject Grassland_block4;
    public GameObject Grassland_block5;



    public GameObject MudLand_block1;
    public GameObject MudLand_block2;
    public GameObject MudLand_block3;
    public GameObject MudLand_block4;
    public GameObject MudLand_block5;



    public GameObject Forest_block1;
    public GameObject Forest_block2;
    public GameObject Forest_block3;
    public GameObject Forest_block4;
    public GameObject Forest_block5;

    public GameObject[] CurrentBlock;




    // Start is called before the first frame update
    void Start()
    {
        CurrentBlock = new GameObject[maxBlocksPerCell];
        widthPos = defaultWidthPos;
        depthPos = defaultDepthPos;
    }

    // Update is called once per frame
    void Update()
    {
        //spawn cell
        if(!cellSpawned)
        {
            for (i = 0; (i < maxBlocksPerCell) && (currentRow != maxRows); i++)
            {
                if(SelectNewBiome)
                {
                    float y = Random.Range(0.0f, 10.0f);

                    currentRandomNumber = y;
                    {
                        if (y < 3.0f)
                        {
                            Grassland = true;
                            MudLand = false;
                            Forest = false;
                            SelectNewBiome = false;
                        }

                        else if (y > 5.0f && y < 7.0f)
                        {
                            MudLand = true;
                            Grassland = false;
                            Forest = false;
                            SelectNewBiome = false;
                        }

                        else if (y > 7.0f)
                        {
                            MudLand = false;
                            Grassland = false;
                            Forest = true;
                            SelectNewBiome = false;
                        }
                    }
                }


                float x = Random.Range(0.0f, 10.0f);
                {
                    if(Grassland)
                    {
                        if (x < 1)
                        {
                            CurrentBlock[i] = Grassland_block1;
                        }

                        else if (x < 2)
                        {
                            CurrentBlock[i] = Grassland_block3;
                        }

                        else if (x < 3)
                        {
                            CurrentBlock[i] = Grassland_block4;
                        }

                        else if (x < 4)
                        {
                            CurrentBlock[i] = Grassland_block5;
                        }

                        else
                        {
                            CurrentBlock[i] = Grassland_block2;
                        }
                    }

                    else if (MudLand)
                    {
                        if (x < 1)
                        {
                            CurrentBlock[i] = MudLand_block1;
                        }

                        else if (x < 2)
                        {
                            CurrentBlock[i] = MudLand_block2;
                        }

                        else if (x < 3)
                        {
                            CurrentBlock[i] = MudLand_block3;
                        }

                        else if (x < 4)
                        {
                            CurrentBlock[i] = MudLand_block4;
                        }

                        else
                        {
                            CurrentBlock[i] = MudLand_block5;
                        }
                    }

                    else if (Forest)
                    {
                        if (x < 1)
                        {
                            CurrentBlock[i] = Forest_block1;
                        }

                        else if (x < 2)
                        {
                            CurrentBlock[i] = Forest_block2;
                        }

                        else if (x < 3)
                        {
                            CurrentBlock[i] = Forest_block3;
                        }

                        else if (x < 4)
                        {
                            CurrentBlock[i] = Forest_block4;
                        }

                        else
                        {
                            CurrentBlock[i] = Forest_block5;
                        }
                    }

                }

     

                if (i % 10 == 0)
                {
                    depthPos++;
                    widthPos = defaultWidthPos;
                }


                GameObject test = Instantiate(CurrentBlock[i], new Vector3(widthPos + (currentRow * 10), Random.Range(0, maxHeight), depthPos), Quaternion.identity);
                test.name = i.ToString();
                widthPos++;
            }

            if (currentRow == maxRows)
            {
                cellSpawned = true;
            }

            if (i == maxBlocksPerCell)
            {
                currentCell++;
                SelectNewBiome = true;

                if (currentCell == maxCells)
                {
                    widthPos = defaultWidthPos;
                    depthPos = defaultDepthPos;
                    currentCell = 0;
                    currentRow++;
                    i = -1;
                }
            }
        }

    }
}
