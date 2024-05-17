using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Camerafollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float MoveSpeed  = 1.5f;
    void Update()
    {
        transform.position = target.position + offset;

        if(Input.GetKey(KeyCode.UpArrow)) {

            transform.Rotate(-MoveSpeed, 0, 0);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Rotate(MoveSpeed, 0, 0);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, -MoveSpeed, 0);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, MoveSpeed, 0);
        }

    }
}
