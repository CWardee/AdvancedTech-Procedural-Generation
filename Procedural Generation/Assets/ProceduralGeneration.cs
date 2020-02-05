using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralGeneration : MonoBehaviour
{
    public float currentRandomNumber;

    private bool SelectNewBiome = true;

    BlockProperties currentBlockproperties;

    private int maxBlocksPerCell = 100;
    public float maxCells = 6;
    public float currentRow = 0;
    public float maxRows = 6;

    public int MaxHeight = 8;
    public int currentHeight = -1;
    public bool Grassland = true;
    public bool MudLand = false;
    public bool Forest = false;


    public int i = 0;
    public int currentCell = 0;
    public float maxHeightOffset = 0.2f;
    public float depthPos = 0;
    public float defaultDepthPos = 0;
    public float defaultWidthPos = 0;
    public float widthPos = 0;
    public bool cellSpawned = false;

    public GameObject UnderGround_Rock_block1;
    public GameObject UnderGround_Rock_block2;
    public GameObject UnderGround_Rock_block3;
    public GameObject UnderGround_Rock_block4;

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

    MeshFilter[] meshFilters;


    private int BlockCell = 1;
    private List<GameObject> gameObjectsToCombine = new List<GameObject>();

    public void CombineMeshes(GameObject obj)
    {
        Vector3 position = obj.transform.position;
        obj.transform.position = Vector3.zero;

        MeshFilter[] meshFilters = obj.GetComponentsInChildren<MeshFilter>();
        CombineInstance[] combine = new CombineInstance[meshFilters.Length];

        int p = 1;
        while (p < meshFilters.Length)
        {
            combine[p].mesh = meshFilters[p].sharedMesh;
            combine[p].transform = meshFilters[p].transform.localToWorldMatrix;
            meshFilters[p].gameObject.SetActive(false);
            p++;
        }

        obj.transform.GetComponent<MeshFilter>().mesh = new Mesh();
        obj.transform.GetComponent<MeshFilter>().mesh.CombineMeshes(combine, true, true);
        obj.transform.gameObject.SetActive(true);

        obj.transform.position = position;
    }

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



                    Instantiate(CurrentBlock[i], new Vector3(widthPos + (currentRow * 10), heightToUse+currentHeight--, depthPos), Quaternion.identity);
                    y++;
                }

                

                test.name = i.ToString();
                widthPos++;
            }

            if (currentRow == maxRows)
            {
                cellSpawned = true;
            }

            if (i == maxBlocksPerCell)
            {


                BlockCell++;
                currentCell++;
                SelectNewBiome = true;
                i = 0;

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
