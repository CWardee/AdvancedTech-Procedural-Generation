using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Saving : MonoBehaviour
{
    Generation GlobalGeneration;
    public GameObject[] cellToSave;
    public GameObject CellToLoad;

    string filename = "data.json";
    string path;

    void Destory()
    {
        for (int i = 0; i < GlobalGeneration.TotalCells; i++)
        {
            GameObject OldCells = GameObject.Find("Cell Number: " + i);
            Destroy(OldCells);
        }
    }

    public void LoadCell()
    {

        Destory();

        for (int i = 0; i < GlobalGeneration.TotalCells; i++)
        {
            Vector3 position = new Vector3();
            string CellLocale = PlayerPrefs.GetString("CellLocation " + i);
            SavePosition cellSave = JsonUtility.FromJson<SavePosition>(CellLocale);


            if (cellSave != null && CellLocale.Length > 0)
            {
                cellSave = JsonUtility.FromJson<SavePosition>(CellLocale);
                if (cellSave != null)
                {
                    GameObject cellToLoad = (GameObject)Instantiate(cellSave.currentGameObject);
                    cellToLoad.name = cellSave.currentGameObject.name;

                    position.x = cellSave.x;
                    position.y = cellSave.y;
                    position.z = cellSave.z;
                    cellToLoad.transform.position = position;

                }
                //GameObject test = Instantiate(cellToSave[i].gameObject, new Vector3(position.x + position.y, position.z), Quaternion.identity);
            }
        }
    }


    public void SaveCell()
    {
        for (int i = 0; i < GlobalGeneration.TotalCells; i++)
        {
            string dataToSave = "";
            List<string> blockDataList = new List<string>();

            cellToSave[i] = GameObject.Find("Cell Number: " + i);


            foreach (Transform child in cellToSave[i].transform)
            {
                Transform CurrentChildFound = child;
                SavePosition blockData = new SavePosition();
                blockData.name = CurrentChildFound.name;
                blockData.currentGameObject = CurrentChildFound.gameObject;
                blockData.x = CurrentChildFound.transform.position.x;
                blockData.y = CurrentChildFound.transform.position.y;
                blockData.z = CurrentChildFound.transform.position.z;


               dataToSave += JsonUtility.ToJson(blockData);

                System.IO.File.WriteAllText(path, dataToSave);
                Debug.Log(dataToSave);

                PlayerPrefs.SetString("CellLocation " + i, dataToSave);
            }

            //SavePosition cellSave = new SavePosition();
            //cellSave.name = cellToSave[i].name;
            //cellSave.currentGameObject = cellToSave[i];
            //CellToLoad = cellSave.currentGameObject;
            //cellSave.x = cellToSave[i].transform.position.x;
            //cellSave.y = cellToSave[i].transform.position.y;
            //cellSave.z = cellToSave[i].transform.position.z;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        GlobalGeneration = this.gameObject.GetComponent<Generation>();
        path = Application.dataPath + "/Resources/LevelData.json";
        Debug.Log(path);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
