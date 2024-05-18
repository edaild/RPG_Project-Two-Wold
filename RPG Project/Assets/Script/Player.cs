using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    Animator anim;
    public float jumpForce = 5f;
    private float hInputAxis;
    private float vInputAxis;
    public float speed = 5f;
    public LayerMask groundLayer;
    public int Hp;
    public GameObject Lille;
    public GameObject LilleText;
    bool jump_anim;


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
        Manager();
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
            print("일반 공격 모션");
        }
        if (Input.GetKey(KeyCode.E))
        {
            print("마법 스킬");
        }

        if (Input.GetKey(KeyCode.Q))
        {
            print("궁극기");
        }

        
    }

    void Jump() // 점프
    {
        if (Input.GetButtonDown("Jump")) // ! 부정문 bool 값만 가능
        {
            anim.SetTrigger("isJump");

            StartCoroutine(Jump_anim());
        }

    }
    IEnumerator Jump_anim()
    {
        yield return null;
        while (!jump_anim)
        {
            if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.2f)
            {
                jump_anim = true;
                rb.velocity = Vector3.zero;
                rb.AddForce(Vector3.up * 5, ForceMode.Impulse);
            }
            yield return null;
        }
        yield return null;
    }

    void PlayerHp()
    {
        if (Hp == 0)
        {
            print("플레이어 사망.");
            // Die();

            gameObject.SetActive(false);
        }
    }

    void Manager()
    {
        if (Input.GetMouseButton(0))
        {
  
         //   공격 스크립트 false
            Lille.SetActive(false);
            LilleText.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Grounded")
        {
            jump_anim = false;
        }

        if(collision.gameObject.tag == "Lille")
        {
            print("릴리에와 충돌");
            Lille.SetActive(true);
            LilleText.SetActive(true);

        }
    }

  


}
