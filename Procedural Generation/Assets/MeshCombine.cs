using UnityEngine;
using System.Collections;

// Copy meshes from children into the parent's Mesh.
// CombineInstance stores the list of meshes.  These are combined
// and assigned to the attached Mesh.

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]

public class MeshCombine : MonoBehaviour
{
    public bool fired = false;
    public int length = 0;
    GameObject[] rocksObjects;

    void Start()
    {

    }

    public void CombineMeshes(GameObject ParentCell)
    {
        fired = true;
        MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
        CombineInstance[] combine = new CombineInstance[meshFilters.Length];

        int i = 0;
        while (i < meshFilters.Length)
        {
            combine[i].mesh = meshFilters[i].sharedMesh;
            combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
            meshFilters[i].gameObject.SetActive(false);

            i++;
        }
        transform.GetComponent<MeshFilter>().mesh = new Mesh();
        transform.GetComponent<MeshFilter>().mesh.CombineMeshes(combine);
        transform.gameObject.SetActive(true);

        this.gameObject.transform.parent = ParentCell.transform;
    }


    void Update()
    {
        //rocksObjects = GameObject.FindGameObjectsWithTag("BedRock");

        //var rocksObjects = GameObject.FindGameObjectsWithTag("BedRock");

        //for (int i = 0; i < rocksObjects.Length; i++)
        //{
        //    rocksObjects[i].transform.parent = this.gameObject.transform;
        //}



        //if (rocksObjects.Length > 9000)
        //{ 
        //    Debug.Log("No game objects are tagged with 'BedRock'");
        //    CombineMeshes();
        //}


        //length = rocksObjects.Length;

    }

}