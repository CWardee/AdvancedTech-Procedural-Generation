using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class SavePosition
{
    public int totalNumOfBlocks;
    public string name;
    public GameObject currentGameObject;
    public MeshFilter currentMesh;
    public float x;
    public float y;
    public float z;
}
