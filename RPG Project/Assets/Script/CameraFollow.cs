using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Camerafollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float MoveSpeed  = 3f;
    public float ZoomSpeed;         // 줌 스피드.
    public float Distance;          // 카메라와의 거리.
    public float rotateSpeed = 5.0f;
    public float limitAngle = 70.0f;    //리미트 앵글

    private bool isRotate;
    private float mouseX;
    private float mouseY;

    private Vector3 AxisVec;        // 축의 벡터.
    private Transform MainCamera;   // 카메라 컴포넌트.


    void Start()
    {
        MainCamera = Camera.main.transform;
    }

    void Update()
    {
        transform.position = target.position + offset;

        Zoom();
        CameraRotate();
    }

    void Zoom()
    {
        Distance += Input.GetAxis("Mouse ScrollWheel") * ZoomSpeed * -1;
        Distance = Mathf.Clamp(Distance, 1f, 10f);              //Mathf 수학적 함수

        AxisVec = transform.forward * -1;
        AxisVec *= Distance;
        MainCamera.position = transform.position + AxisVec;
    }

    void CameraRotate()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isRotate = true;
        }
        if(Input.GetMouseButtonUp(1))
        {
            isRotate = false;
        }

        if(isRotate)
        {
            Rotation();
        }
    }

    public void Rotation()
    {
        mouseX += Input.GetAxis("Mouse X") * rotateSpeed; // AxisX = Mouse Y
        mouseY = Mathf.Clamp(mouseY + Input.GetAxis("Mouse Y") * rotateSpeed, -limitAngle, limitAngle);
        transform.rotation = Quaternion.Euler(transform.rotation.x - mouseY, transform.rotation.y + mouseX, 0.0f);
    }
}
