using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorHover : MonoBehaviour
{
    public LayerMask Mask;
    Ray ray;
    RaycastHit hit;
    ParticleSystem rockParticles;
    DestroyObject thisObjectsDestroyScript;

    public ParticleSystem particlesToPlay;


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
            if (Physics.Raycast(ray, out hit, Mask))
            {

                print(hit.collider.name);
                ParticleSystem Particle = Instantiate(particlesToPlay, new Vector3(hit.collider.gameObject.transform.position.x, 
                                                                                            hit.collider.gameObject.transform.position.y, 
                                                                                            hit.collider.gameObject.transform.position.z), Quaternion.identity);





                //particlesToPlay.transform.position = new Vector3(hit.collider.gameObject.transform.position.x,
                //                        hit.collider.gameObject.transform.position.y,
                //                        hit.collider.gameObject.transform.position.z);
                Particle.Play();

                    Destroy(hit.collider.gameObject);
                }


            
            }

        }
}
