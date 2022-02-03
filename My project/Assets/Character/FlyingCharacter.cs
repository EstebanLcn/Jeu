using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FlyingCharacter : MonoBehaviour
{
    Vector3 speed = Vector3.up*3;
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(90,0, 00);
    }
    bool TriggerPressedLastFrame;
    float gravity = 9.81f;
    float timeStartFalling;
    // Update is called once per frame
    void Update()
    {
       // speed = speed * Input.GetAxis("Vertical");

        transform.Translate(speed * Time.deltaTime);
        if (Input.GetAxis("RightTrigger") <= 0.9999 || Input.GetAxis("LeftTrigger") <= 0.9999)
        {
            if (!TriggerPressedLastFrame)
            {
                timeStartFalling = Time.time;
                TriggerPressedLastFrame = true;
            }
            float FallingTime = Time.time - timeStartFalling;
            float avgTriggers = 1-((Input.GetAxis("RightTrigger") + Input.GetAxis("LeftTrigger"))/2);
            transform.Translate(Vector3.forward * gravity * Time.deltaTime * FallingTime * avgTriggers);
        }
        else
        {
            TriggerPressedLastFrame = false;
        }

    }
}
