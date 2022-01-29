using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public Transform TargetTransform;
    private Vector3 CameraOffset;
    [Range (0.01f, 1.0f)]
    public float Smooth = 0.5f;
    void Start()
    {
        CameraOffset = transform.position - TargetTransform.position;
    }

     void LateUpdate()
    {
        Vector3 newPos = TargetTransform.position + CameraOffset;
        transform.position = Vector3.Slerp(transform.position, newPos, Smooth);
    }

}

