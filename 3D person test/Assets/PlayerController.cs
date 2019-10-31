using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Transform cam;
    CharacterController controller;
    Animator anim;
    Rigidbody rb;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Mouse X");

        controller.Move(cam.forward * speed * vertical);
        transform.Rotate(new Vector3(0, horizontal, 0));

        anim.SetFloat("Speed", rb.velocity.z);
        
    }
}