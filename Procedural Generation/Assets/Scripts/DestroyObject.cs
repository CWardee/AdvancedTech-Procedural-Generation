using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public bool DestroyThisObject = false;
    public ParticleSystem objectParticles;
    public float timeLeft = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(DestroyThisObject)
        {
            objectParticles.Play();
            Destroy(this.gameObject);
        }
    }
}
