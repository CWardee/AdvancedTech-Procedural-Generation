using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;


//public class GameSaving
//{
//    public string sceneName; // This will be written in the json file
//    public Vector3 serializedPosition; // This will be written in the json file
//    public Quaternion serializedRotation; // This will be written too.
//    public static Vector3 position; // Static fields doesnt write into json
//    public static Quaternion rotation; // Static fields doesnt write into json
//    public static bool loaded = false;
//}

//public static void LoadData()
//{
//    GameSaving gameSaving = JsonUtility.FromJson<GameSaving>(File.ReadAllText(Application.persistentDataPath + "/saveload.json"));

//    GameSaving.position = gameSaving.serializedPosition;
//    GameSaving.rotation = gameSaving.serializedRotation;

//    SceneManager.LoadScene(gameSaving.sceneName);

//    //For testing purposes
//    Debug.Log(transform.position);
//    Debug.Log(transform.rotation);
//    Debug.Log(gameSaving.sceneName);
//    GameSaving.loaded = true;
//}

//public static void SaveData(Player player)
//{
//    //References
//    Scene scene = SceneManager.GetActiveScene();
//    GameSaving gameSaving = new GameSaving();
//    //Scene Name
//    gameSaving.sceneName = scene.name;

//    //Position
//    gameSaving.serializedPosition = player.transform.position;
//    GameSaving.position = gameSaving.serializedPosition;

//    //Rotation
//    gameSaving.serializedRotation = player.transform.rotation;
//    GameSaving.rotation = gameSaving.serializedRotation;

//    string jsonData = JsonUtility.ToJson(gameSaving, true);
//    File.WriteAllText(jsonSavePath, jsonData);

//}

//// In your player script
//private void Start()
//{
//    if (GameSaving.loaded)
//    {
//        transform.position = GameSaving.position;
//        transform.rotation = GameSaving.rotation;
//        GameSaving.loaded = false;
//    }
//}
