using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    Animator anim;
    public float jumpForce = 0.5f;
    private float hInputAxis;
    private float vInputAxis;
    public float speed = 5f;
    public LayerMask groundLayer;
    public int Hp;


    Vector3 moveVec;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        Hp = 100;
    }


    void Update()
    {
        MoveInputAxis();
        Jump();
        PlayerHp();
        attack();
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

    void attack()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            print("¿œπ› ∞¯∞› ∏º«");
        }
        if (Input.GetKey(KeyCode.E))
        {
            print("∏∂π˝ Ω∫≈≥");
        }

        if (Input.GetKey(KeyCode.Q))
        {
            print("±√±ÿ±‚");
        }

        
    }

    void Jump()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

    }

    void PlayerHp()
    {
        if (Hp == 0)
        {
            print("?åÎ†à?¥Ïñ¥Í∞Ä ?¨Îßù ?àÏäµ?àÎã§.");
            // Die();

            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Grounded")
        {
            Jump();
        }
    }


}
