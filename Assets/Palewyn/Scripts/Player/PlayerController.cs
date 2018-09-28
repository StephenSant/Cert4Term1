using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;

    private CharacterController controller;
    private Animator anim;

    // Use this for initialization
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputH = Input.GetAxis("Horizontal");
        float inputV = Input.GetAxis("Vertical");
        Move(inputH, inputV);
    }
    void Move(float inputH, float inputV)
    {
        Vector3 moveDirection = new Vector3(inputH, 0f, inputV);
        controller.Move(moveDirection * speed * Time.deltaTime);
        anim.SetFloat("MoveDirection", moveDirection.z);
        anim.SetBool("IsWalking", moveDirection.magnitude > 0);
    }
}
