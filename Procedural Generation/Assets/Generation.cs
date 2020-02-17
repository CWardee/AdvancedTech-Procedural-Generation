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
    int MaxBlocksPerCell = 100;

    //biomes
    public GameObject grassPlain;
    public GameObject grassTall;
    public GameObject mudPlain;
    public GameObject mudGrass;
    public GameObject grassFlowers;
    public GameObject mudTree;
    public GameObject rock1;
    public GameObject rock2;



    GameObject Cell;

    string CurrentBiome;

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
        int i = Random.Range(1, 3);
        if(CurrentBiome == "Grassland")
        {
            i = Random.Range(1, 3);
            if (i < 2)
            {
                BlockObjectArray[x] = grassPlain;
            }

            else
            {
                BlockObjectArray[x] = grassTall;
            }
        }


        else if (CurrentBiome == "Mudland")
        {
            i = Random.Range(1, 3);
            if (i < 2)
            {
                BlockObjectArray[x] = mudPlain;
            }

            else
            {
                BlockObjectArray[x] = mudGrass;
            }
        }

        else if(CurrentBiome == "Forest")
        {
            i = Random.Range(1, 3);
            if (i < 2)
            {
                BlockObjectArray[x] = grassFlowers;
            }

            else
            {
                BlockObjectArray[x] = mudTree;
            }
        }
    }

  

    public void GenerateFreshCell()
    {
        for (int i = 0; i < MaxBlocksPerCell; i++)
        {
            GenereteBiome(i);
            float height = Random.Range(0.0f, 0.2f);

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
                int z = Random.Range(1, 3);
                if (z < 2)
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

        WorldGenerated = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        TotalCells = TotalRows * TotalColumns;
        BlockObjectArray = new GameObject[MaxBlocksPerCell];
        CellParent = new GameObject();
    }

    // Update is called once per frame
    void Update()
    {
        if(!WorldGenerated)
        {
            for (int i = 0; i < TotalRows * TotalColumns; i ++)
            {
                if (i % TotalRows == 0)
                {
                    currentZpos = 0;
                    CurrentRow++;
                }

                Cell = Instantiate(CellParent, new Vector3(), Quaternion.identity);
                Cell.name = "Cell Number: " + CurrentCell;
                SetRandomBiomes();
                GenerateFreshCell();
                CurrentCell++;

            }
        }
    }
}
