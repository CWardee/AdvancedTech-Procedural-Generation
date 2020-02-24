using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generation : MonoBehaviour
{
    public int TotalRows = 0;
    public int TotalColumns = 0;
    public int TotalHeight = 0;
    public int TotalCells;
    public int CurrentCell = 1;
    bool WorldGenerated = false;

    int CurrentRow = 0;
    int CurrentCollum = 0;

    GameObject CellParent;
    Block CurrentBlockScript;
    GameObject[] CellParentArray;
    GameObject[] BlockObjectArray;

    int currentXpos = 0;
    int currentZpos = 0;
    int currentYpos = 1;
    public int MaxBlocksPerCell = 100;

    public int currentBlock = 0;

    //biomes
    public GameObject grassPlain;
    public GameObject grassSheep;
    public GameObject grassTall;
    public GameObject grassRock;
    public GameObject mudPlain;
    public GameObject mudGrass;
    public GameObject grassFlowers;
    public GameObject water;
    public GameObject mudTree;
    public GameObject rock1;
    public GameObject rock2;


    public GameObject playerCamera;


    public GameObject CellObject;
    GameObject Cell;

    string CurrentBiome;

    float CellX = 10;
    float CellZ = 0;

    void SetRandomBiomes()
    {
        int i = Random.Range(0, 3);
        switch (i)
        {
            case 0:
                CurrentBiome = "Grassland";
                break;

            case 1:
                CurrentBiome = "Mudland";
                break;

            case 2:
                CurrentBiome = "Forest";
                break;
        }
    }



    void GenereteBiome(int x)
    {
        int i = Random.Range(1, 4);
        if (CurrentBiome == "Grassland")
        {
            i = Random.Range(1, 6);
            switch (i)
            {
                case 1:
                    BlockObjectArray[x] = grassPlain;
                    break;

                case 2:
                    BlockObjectArray[x] = grassTall;
                    break;

                case 3:
                    BlockObjectArray[x] = grassSheep;
                    break;

                case 4:
                    BlockObjectArray[x] = grassFlowers;
                    break;

                case 5:
                    BlockObjectArray[x] = grassPlain;
                    break;

                default:
                    BlockObjectArray[x] = grassPlain;
                    break;
            }
        }


        else if (CurrentBiome == "Mudland")
        {
            i = Random.Range(1, 6);
            switch (i)
            {
                case 1:
                    BlockObjectArray[x] = mudPlain;
                    break;

                case 2:
                    BlockObjectArray[x] = mudGrass;
                    break;

                case 3:
                    BlockObjectArray[x] = grassPlain;
                    break;

                case 4:
                    BlockObjectArray[x] = grassPlain;
                    break;

                case 5:
                    BlockObjectArray[x] = grassPlain;
                    break;

                default:
                    BlockObjectArray[x] = grassRock;
                    break;
            }
        }

        else if(CurrentBiome == "Forest")
        {
            i = Random.Range(1, 6);
            switch (i)
            {
                case 1:
                    BlockObjectArray[x] = grassFlowers;
                    break;

                case 2:
                    BlockObjectArray[x] = mudPlain;
                    break;

                case 3:
                    BlockObjectArray[x] = mudTree;
                    break;

                case 4:
                    BlockObjectArray[x] = mudPlain;
                    break;

                case 5:
                    BlockObjectArray[x] = mudPlain;
                    break;

                default:
                    BlockObjectArray[x] = mudGrass;
                    break;
            }
        }
    }

  

    public void GenerateFreshCell()
    {
        for (int i = 0; i < MaxBlocksPerCell; i++)
        {
            GenereteBiome(i);
            float height = Random.Range(0.0f, 0.5f);

            if (i % 10 == 0 || i == 0)
            {
                currentZpos++;
                currentXpos = 0;
            }


            GameObject Block = Instantiate(BlockObjectArray[i], new Vector3(currentXpos + (CurrentRow * 10), currentYpos + height, currentZpos), Quaternion.identity);
            Block.transform.parent = Cell.transform;
            Block.name = "" + CurrentCell;

            //BlockObjectArray[i].name = i.ToString();



            //height
            for (int x = 0; x < TotalHeight; x++)
            {
                currentYpos--;
                int z = Random.Range(1, 5);
                if (z < 2)
                {
                    BlockObjectArray[i] = rock1;
                }

                else if (z > 2 && z < 4)
                {
                    BlockObjectArray[i] = rock1;
                }

                else
                {
                    BlockObjectArray[i] = rock2;
                }

                Block = Instantiate(BlockObjectArray[i], new Vector3(currentXpos + (CurrentRow * 10), currentYpos + height, currentZpos), Quaternion.identity);



                Block.transform.parent = Cell.transform;
                Block.name = "Underground" + CurrentCell;
            }


            currentYpos = 1;
            currentXpos++;
        }

        //WorldGenerated = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        TotalCells = TotalRows * TotalColumns;
        BlockObjectArray = new GameObject[MaxBlocksPerCell];
    }

    // Update is called once per frame
    void Update()
    {
            if (currentBlock < TotalCells && !WorldGenerated)
            {

                if (currentBlock % TotalRows == 0)
                {
                    currentZpos = 0;
                    CurrentRow++;
                    CellX += 10;
                    CellZ = 0;
            }


                Cell = Instantiate(CellObject, new Vector3(0,0,0), Quaternion.identity);
                Cell.transform.position = new Vector3(CellX - 5, 0, CellZ + 5);
                Cell.name = "Cell Number: " + CurrentCell;

                CellZ += 10;



                SetRandomBiomes();
                GenerateFreshCell();
                CurrentCell++;
                currentBlock++;
            }  
    }
}
