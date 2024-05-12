using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    Animator anim;
    private float hInputAxis;
    private float vInputAxis;

    public float speed = 5f;

    Vector3 moveVec;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        MoveInputAxis();

    }

    void MoveInputAxis()
    {
        hInputAxis = Input.GetAxisRaw("Horizontal");
        vInputAxis = Input.GetAxisRaw("Vertical");
        moveVec = new Vector3(hInputAxis,0, vInputAxis).normalized;
        transform.position += moveVec * speed * Time.deltaTime;
        transform.LookAt(transform.position + moveVec);

        anim.SetBool("isRun", moveVec != Vector3.zero);
    }
}
