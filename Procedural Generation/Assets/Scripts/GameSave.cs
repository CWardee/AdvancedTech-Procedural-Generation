using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameSave : MonoBehaviour
{

    public GameObject GrassBlock;
    public GameObject GrassTall;
    public GameObject Tree;
    public GameObject Rock;
    public GameObject Dirt;

    public ProceduralGeneration GlobalGeneration;
    public GameObject block;
    public GameObject empty;
    public int MaxBlocks = 0;
    public GameObject[] blocksToSave;

    public GameObject[] cellToSave;


    public void DeleteAll()
    {
        foreach (GameObject o in Object.FindObjectsOfType<GameObject>())
        {
            if (o.tag == "Tree" || o.tag == "BedRock" || o.tag == "Empty" || o.tag == "GrassTall" || o.tag == "GrassPlain" || o.tag == "Rock" || o.tag == "Dirt")
            {
                Destroy(o);
            }
        }
    }





    public void RestoreGame()
    {
        string p = PlayerPrefs.GetString("PlayerLocation");
        if (p != null && p.Length > 0)
        {
            SavePosition s = JsonUtility.FromJson<SavePosition>(p);


            if (s != null)
            {
                Vector3 position = new Vector3();
                position.x = s.x;
                position.y = s.y;
                position.z = s.z;
                block.transform.position = position;
            }

        }

        DeleteAll();

        //SavePosition[] blocksPostions = JsonUtility.FromJson<SavePosition>(BlocksLocale);

        for (int i = 0; i < 401; i++)
        {
            Vector3 position = new Vector3();
            string BlocksLocale = PlayerPrefs.GetString("BlocksLocation " + i);
            //SavePosition d = JsonUtility.FromJson<SavePosition>(BlocksLocale);
            SavePosition blocksPostions = JsonUtility.FromJson<SavePosition>(BlocksLocale);

            if (blocksPostions != null && BlocksLocale.Length > 0)
            {


                blocksPostions = JsonUtility.FromJson<SavePosition>(BlocksLocale);
                Instantiate(blocksPostions.currentGameObject);
                blocksPostions.currentGameObject.name = i.ToString();
                position = new Vector3();

                position.x = blocksPostions.x;
                position.y = blocksPostions.y;
                position.z = blocksPostions.z;
                blocksPostions.currentGameObject.transform.position = position;


                //Instantiate(blocksToSave[i], new Vector3(positions[i].x + blocksPostions[i].y, blocksPostions[i].z), Quaternion.identity);
            }
        }

    }

    public void LoadCell()
    {
        for (int i = 0; i < 2; i++)
        {
            Vector3 position = new Vector3();
            string CellLocale = PlayerPrefs.GetString("CellLocation " + i);
            SavePosition cellSave = JsonUtility.FromJson<SavePosition>(CellLocale);


            if (cellSave != null && CellLocale.Length > 0)
            {
                cellSave = JsonUtility.FromJson<SavePosition>(CellLocale);
                Instantiate(cellSave.currentGameObject);
                cellSave.currentGameObject.name = i.ToString();
                position = new Vector3();

                position.x = cellSave.x;
                position.y = cellSave.y;
                position.z = cellSave.z;
                cellSave.currentGameObject.transform.position = position;


                Instantiate(cellToSave[i], new Vector3(position.x + position.y, position.z), Quaternion.identity);
            }
        }
    }


    public void SaveCell()
    {
        for (int i = 0; i < MaxBlocks; i++)
        {
            cellToSave[i] = GameObject.Find("Cell Number: " + i);

            if (cellToSave[i] == null)
            {
                cellToSave[i] = empty;
            }

            SavePosition cellSave = new SavePosition();
            cellSave.currentGameObject = cellToSave[i];
            cellSave.x = cellToSave[i].transform.position.x;
            cellSave.y = cellToSave[i].transform.position.y;
            cellSave.z = cellToSave[i].transform.position.z;


            string CellsToJson = JsonUtility.ToJson(cellSave);
            Debug.Log(CellsToJson);
            PlayerPrefs.SetString("CellLocation " + i, CellsToJson);
        }
    }


        public void SaveGame()
    {


        SavePosition s = new SavePosition();
        s.name = "hi";
        s.x = block.transform.position.x;
        s.y = block.transform.position.y;
        s.z = block.transform.position.z;

        string json = JsonUtility.ToJson(s);
        Debug.Log(json);
        PlayerPrefs.SetString("PlayerLocation", json);

        //string test = JsonUtility.ToJson(s);

        MaxBlocks = GlobalGeneration.total - 1;
        for (int i = 0; i < MaxBlocks; i++)
        {
            blocksToSave[i] = GameObject.Find("" + i);

            if (blocksToSave[i] == null)
            {
                blocksToSave[i] = empty;
            }
        }

        MaxBlocks = GlobalGeneration.total - 1;
        //SavePosition[] blocksPostions = new SavePosition[MaxBlocks];

        for (int i = 1; i < MaxBlocks; i++)
        {
            SavePosition blocksPostions = new SavePosition();
            blocksPostions.name = "Block Number " + i;
            blocksPostions.currentGameObject = blocksToSave[i];

            if (blocksToSave[i].tag == "GrassPlain")
            {
                blocksPostions.currentGameObject = GrassBlock;
            }

            else if(blocksToSave[i].tag == "GrassTall")
            {
                blocksPostions.currentGameObject = GrassTall;
            }

            else if (blocksToSave[i].tag == "Tree")
            {
                blocksPostions.currentGameObject = Tree;
            }

            else if (blocksToSave[i].tag == "Rock")
            {
                blocksPostions.currentGameObject = Rock;
            }

            else if (blocksToSave[i].tag == "Dirt")
            {
                blocksPostions.currentGameObject = Dirt;
            }

            else 
            {
                blocksToSave[i] = empty;
            }

            blocksPostions.x = blocksToSave[i].transform.position.x;
            blocksPostions.y = blocksToSave[i].transform.position.y;
            blocksPostions.z = blocksToSave[i].transform.position.z;

            string BlocksToJson = JsonUtility.ToJson(blocksPostions);
            Debug.Log(BlocksToJson);
            PlayerPrefs.SetString("BlocksLocation " + i, BlocksToJson);

            string ToJsonBlocks = JsonUtility.ToJson(s);

        }

        //for (int i = 0; i < GlobalGeneration.CurrentBlock.Length; i++)
        //{
        //    blocksToSave[i] = GlobalGeneration.CurrentBlock[i].gameObject;
        //    blocksToSave[i] = GameObject.Find("" + i);
        //    blocksPostions[i] = new SavePosition();
        //    blocksPostions[i].name = "Block Number " + i;
        //    blocksPostions[i].currentGameObject = GlobalGeneration.CurrentBlock[i].gameObject;
        //    blocksPostions[i].x = GlobalGeneration.CurrentBlock[i].gameObject.transform.position.x;
        //    blocksPostions[i].y = GlobalGeneration.CurrentBlock[i].gameObject.transform.position.y;
        //    blocksPostions[i].z = GlobalGeneration.CurrentBlock[i].gameObject.transform.position.z;

        //    string BlocksToJson = JsonUtility.ToJson(blocksPostions[i]);
        //    Debug.Log(BlocksToJson);
        //    PlayerPrefs.SetString("BlocksLocation " + i, BlocksToJson);
        //}
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
