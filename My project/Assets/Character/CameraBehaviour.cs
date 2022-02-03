using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField]  Transform TargetTransform;
    Vector3 OffsetCamera;
   

    void Start()
    {
        OffsetCamera = transform.position - TargetTransform.position;
    }

    void Update()
    {
        Vector3 CameraPosition = TargetTransform.position + OffsetCamera;
        transform.position = CameraPosition;
    }
}

