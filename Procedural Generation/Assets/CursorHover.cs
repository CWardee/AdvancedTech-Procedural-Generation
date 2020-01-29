using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorHover : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    ParticleSystem rockParticles;
    DestroyObject thisObjectsDestroyScript;


    void OnMouseOver()
    {
        print(gameObject.name);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {

                print(hit.collider.name);
                if (hit.transform.tag == "Rock")
                {
                    thisObjectsDestroyScript = hit.collider.gameObject.GetComponent<DestroyObject>();
                    thisObjectsDestroyScript.DestroyThisObject = true;

                    //Destroy(hit.collider.gameObject);
                }

                if (hit.transform.tag == "Tree")
                {
                    Destroy(hit.collider.gameObject);
                }

            }
            }

        }
}
