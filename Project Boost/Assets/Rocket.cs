using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }

    private void ProcessInput()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Moving Upwards");
            rb.AddRelativeForce(Vector3.up);
        }

        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("Rotating Right.");
            this.transform.Rotate(Vector3.right);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("Rotating Left.");
            this.transform.Rotate(Vector3.left);
        }
    }
}
