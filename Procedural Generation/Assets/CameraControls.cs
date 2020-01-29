using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    public float Speed = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //forward/backward
        if (Input.GetKey("w"))
        {
            transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        }

        if (Input.GetKey("s"))
        {
            transform.Translate(Vector3.back * Speed * Time.deltaTime);
        }

        //left/right
        if (Input.GetKey("a"))
        {
            transform.Translate(Vector3.left * Speed * Time.deltaTime);
        }

        if (Input.GetKey("d"))
        {
            transform.Translate(Vector3.right * Speed * Time.deltaTime);
        }

        //rotation
        if (Input.GetKey("e"))
        {
            transform.Rotate(Vector3.up * Speed * 12 * Time.deltaTime);
        }

        if (Input.GetKey("q"))
        {
            transform.Rotate(Vector3.down * Speed * 12 * Time.deltaTime);
        }



        //sprint speed
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Speed = Speed * 2;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Speed = Speed / 2;
        }

        //zoom in

        if (this.gameObject.transform.position.y > -10)
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0f) // forward
            {
                transform.Translate(Vector3.down * Speed * 2 * Time.deltaTime);
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f) // backwards
        {
            transform.Translate(Vector3.up * Speed * 2 * Time.deltaTime);
        }
    }
}
