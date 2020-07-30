using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    Rigidbody rb;
    AudioSource audioSource;
    [SerializeField] float rcsThrust = 120f;
    [SerializeField] float mainThrust = 100f;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
        Thrust();
    }

    private void Rotate()
    {
        rb.freezeRotation = true; //take manual control of rocket's rotation
        float rotationThisFrame = rcsThrust * Time.deltaTime;

        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Rotate(Vector3.right*rotationThisFrame);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            this.transform.Rotate(Vector3.left*rotationThisFrame);
        }

        rb.freezeRotation = false; //release rotation back to the physics engine
    }

    private void Thrust()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            audioSource.Play();
          }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            audioSource.Stop();
        }

        if (Input.GetKey(KeyCode.Space))
        {
            float thrustThisFrame = Time.deltaTime * mainThrust;
            rb.AddRelativeForce(Vector3.up*thrustThisFrame);
        }
    }
}
