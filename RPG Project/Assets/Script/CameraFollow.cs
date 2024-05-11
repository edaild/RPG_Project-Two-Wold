using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class Camerafollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    void Update()
    {
        transform.position = target.position + offset;
    }
}
