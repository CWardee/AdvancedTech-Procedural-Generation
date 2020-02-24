using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour
{
    Rigidbody rb;
    public float randomRotation;

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "Sheep")
        {
            //rb.velocity = new Vector3(0, 5, 0);
            //rb.velocity = Vector3.up * 4;
            randomRotation = Random.Range(-5.0f, 5.0f);
            rb.velocity = new Vector3(0,4,0);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
        transform.rotation = Quaternion.Euler(0, Random.Range(0.0f, 360f), 0);
        transform.position += new Vector3(0, Random.Range(0.0f, 5f), 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * 1;
        transform.Rotate(0.0f, randomRotation, 0.0f, Space.Self);
    }
}
