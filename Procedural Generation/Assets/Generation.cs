using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generation : MonoBehaviour
{
    public int TotalRows = 0;
    public int TotalColumns = 0;
    public int TotalHeight = 0;
    public int TotalCells;
    public int CurrentCell = 0;
    bool WorldGenerated = false;

    int CurrentRow = 0;
    int CurrentCollum = 0;

    public GameObject BlockToSpawn;
    public GameObject CellParent;
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
    public GameObject rockPlain;

    void GenereteBiome(int x)
    {
        float i = Random.Range(0.0f, 3.0f);
        if (i < 1)
        {
            BlockObjectArray[x] = grassPlain;
        }

        else
        {
            BlockObjectArray[x] = grassTall;
        }
    }

    public void GenerateFreshCell()
    {
        for (int i = 0; i < MaxBlocksPerCell; i++)
        {
            BlockObjectArray[i] = BlockToSpawn;
            GenereteBiome(i);
            BlockObjectArray[i].name = i.ToString();

            if (i % 10 == 0)
            {
                currentZpos++;
                currentXpos = 0;
            }

            if (i % 100 == 0)
            {
                Instantiate(CellParentArray[CurrentCell], new Vector3(), Quaternion.identity);
                CellParentArray[CurrentCell].name = "Cell Number: " + CurrentCell;
            }

            Instantiate(BlockObjectArray[i], new Vector3(currentXpos + (CurrentRow * 10), currentYpos, currentZpos), Quaternion.identity);

            //height
            for(int x = 0; x < TotalHeight; x++)
            {
                currentYpos++;
                Instantiate(BlockObjectArray[i], new Vector3(currentXpos + (CurrentRow * 10), currentYpos, currentZpos), Quaternion.identity);
            }

            currentYpos = 1;
            currentXpos++;
        }

        CurrentCell++;
        WorldGenerated = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        TotalCells = TotalRows * TotalColumns;
        BlockObjectArray = new GameObject[MaxBlocksPerCell];
        CellParentArray = new GameObject[TotalRows * TotalColumns];
    }

    // Update is called once per frame
    void Update()
    {
        if(!WorldGenerated)
        {
            for (int i = 0; i < TotalRows * TotalColumns; i ++)
            {
                CellParentArray[i] = CellParent;
                if (i % TotalRows == 0)
                {
                    currentZpos = 0;
                    CurrentRow++;
                }
                GenerateFreshCell();
            }
        }
    }
}
