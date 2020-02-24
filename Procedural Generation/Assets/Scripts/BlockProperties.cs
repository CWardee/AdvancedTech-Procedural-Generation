using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockProperties : MonoBehaviour
{
    public int blockCellLocation = 1;
    public GameObject CameraPoint;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      //  if (CameraPoint.transform.position.z > blockCellLocation && CameraPoint.transform.position.z < blockCellLocation * 10 && CameraPoint.transform.position.x > blockCellLocation && CameraPoint.transform.position.x < blockCellLocation * 10)
      //  {
            //this.gameObject.SetActive(true);
            //this.gameObject.GetComponent<Renderer>().enabled = true;
          //  foreach (Renderer r in GetComponentsInChildren<Renderer>())
          //      r.enabled = true;
      //  }

      //  else
      //  {
        //    this.gameObject.GetComponent<Renderer>().enabled = false;
       ////     foreach (Renderer r in GetComponentsInChildren<Renderer>())
         //       r.enabled = false;
            //this.gameObject.SetActive(false);
     //   }
    }
}
