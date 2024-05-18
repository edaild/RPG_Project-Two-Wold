using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Camerafollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float MoveSpeed  = 3f;
    void Update()
    {
        transform.position = target.position + offset;

        if(Input.GetKey(KeyCode.UpArrow)) {

            transform.Rotate(-MoveSpeed*Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Rotate(MoveSpeed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, -MoveSpeed * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, MoveSpeed * Time.deltaTime, 0);
        }

    }
}
