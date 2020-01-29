using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorHover : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    ParticleSystem rockParticles;


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
                    rockParticles = hit.collider.gameObject.GetComponent<ParticleSystem>();
                    rockParticles.Play();
                    // hit.collider.gameObject.GetComponent<ParticleSystem>().Play();
                    //hit.collider.gameObject.GetComponent<ParticleSystem>().Play();

                    Destroy(hit.collider.gameObject);
                }

                if (hit.transform.tag == "Tree")
                {
                    Destroy(hit.collider.gameObject);
                }

            }
            }

        }
}
