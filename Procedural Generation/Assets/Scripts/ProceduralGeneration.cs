using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralGeneration : MonoBehaviour
{
    //OTHER
    BlockProperties currentBlockproperties;
    public MeshCombine underGroundRock_Combine;
    public GameObject underGroundRock_Object;

    public bool loadGame = true;


    //FLOATS
    public float currentRandomNumber;
    public float maxCells = 6;
    public float currentRow = 0;
    public float maxRows = 6;

    //INTS
    private int maxBlocksPerCell = 100;
    public int MaxHeight = 8;
    public int currentHeight = -1;
    public int i = 0;
    public int currentCell = 0;
    public float maxHeightOffset = 0.2f;
    public float depthPos = 0;
    public float defaultDepthPos = 0;
    public float defaultWidthPos = 0;
    public float widthPos = 0;
    public bool cellSpawned = false;

    //BOOLS
    private bool SelectNewBiome = true;
    public bool Grassland = true;
    public bool MudLand = false;
    public bool Forest = false;

    //UNDERGROUND=======================================
    public GameObject UnderGround_Rock_block1;
    public GameObject UnderGround_Rock_block2;
    public GameObject UnderGround_Rock_block3;
    public GameObject UnderGround_Rock_block4;

    //GRASSLAND=======================================
    public GameObject Grassland_block1;
    public GameObject Grassland_block2;
    public GameObject Grassland_block3;
    public GameObject Grassland_block4;
    public GameObject Grassland_block5;

    //MUDLAND=======================================
    public GameObject MudLand_block1;
    public GameObject MudLand_block2;
    public GameObject MudLand_block3;
    public GameObject MudLand_block4;
    public GameObject MudLand_block5;

    //FOREST=======================================
    public GameObject Forest_block1;
    public GameObject Forest_block2;
    public GameObject Forest_block3;
    public GameObject Forest_block4;
    public GameObject Forest_block5;

    //CURRENTBLOCK
    public GameObject[] CurrentBlock;

    //MESHFILTER
    MeshFilter[] meshFilters;

    //OTHER
    private int BlockCell = 1;
    private List<GameObject> gameObjectsToCombine = new List<GameObject>();


    public int total = 0;


    GameObject Cell;
    public int CurrentCell;


    public bool GenerateNewWorld = false;
    public GameSave Saving;





    // Start is called before the first frame update
    void Start()
    {
        Cell = new GameObject();
        Cell.name = "Cell Number :";
        CurrentBlock = new GameObject[maxBlocksPerCell];
        widthPos = defaultWidthPos;
        depthPos = defaultDepthPos;
    }

    // Update is called once per frame
    void Update()
    {
        var rocksObjects = GameObject.FindGameObjectsWithTag("BedRock");
        for (int f = 0; f < rocksObjects.Length; f++)
        {
            rocksObjects[f].transform.parent = underGroundRock_Object.gameObject.transform;
        }


        //spawn cell
        if (!cellSpawned)
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

                currentBlockproperties = CurrentBlock[i].gameObject.GetComponent<BlockProperties>();
                currentBlockproperties.blockCellLocation = BlockCell;

                if (i % 10 == 0)
                {
                    depthPos++;
                    widthPos = defaultWidthPos;
                }

                float heightToUse = Random.Range(0, maxHeightOffset);

                GameObject test = Instantiate(CurrentBlock[i], new Vector3(widthPos + (currentRow * 10), heightToUse, depthPos), Quaternion.identity);
                currentHeight = -1;

                test.transform.parent = Cell.transform;

                //Saving.blocksToSave[i] = CurrentBlock[i];

                meshFilters = CurrentBlock[i].gameObject.GetComponentsInChildren<MeshFilter>();




                for (int y = 0; y < MaxHeight; y++)
                {
                    float j = Random.Range(0.0f, 10.0f);
                    {

                        if (j < 1)
                        {
                            CurrentBlock[i] = UnderGround_Rock_block1;
                        }

                        else if (j < 2)
                        {
                            CurrentBlock[i] = UnderGround_Rock_block2;
                        }

                        else if (j < 3)
                        {
                            CurrentBlock[i] = UnderGround_Rock_block3;
                        }

                        else
                        {
                            CurrentBlock[i] = UnderGround_Rock_block4;
                            CurrentBlock[i].gameObject.tag = "BedRock";
                        }
                    }


                    test = Instantiate(CurrentBlock[i], new Vector3(widthPos + (currentRow * 10), heightToUse+currentHeight--, depthPos), Quaternion.identity);
                    test.transform.parent = Cell.transform;

                    y++;
                }

                test.name = total.ToString();
                total++;
                widthPos++;
            }


            if (currentRow == maxRows)
            {
                cellSpawned = true;
                underGroundRock_Combine.CombineMeshes(Cell);
            }

            if (i == maxBlocksPerCell)
            {
                BlockCell++;
                currentCell++;
                SelectNewBiome = true;
                i = 0;
                //total = 10 * currentCell;

                if (currentCell == maxCells)
                {
                    widthPos = defaultWidthPos;
                    depthPos = defaultDepthPos;
                    currentCell = 0;
                    currentRow++;
                    i = -1;
                }

                Cell = new GameObject();
                Cell.name = "Cell Number :";
            }
        }


    }
}
