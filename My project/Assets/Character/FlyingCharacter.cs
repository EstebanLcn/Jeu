using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FlyingCharacter : MonoBehaviour
{
    Vector3 speed = Vector3.up*8;
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(90,0, 00);
    }
    bool TriggerPressedLastFrame;
    [Range(0.001f,0.009f)]
    public float smooth = 1f;
    float gravity = 9.81f;
    float PreviousAvgTrigger;
    float timeStartFalling;
    Vector3 PreviousSpeed;
    // Update is called once per frame
    void Update()
    {
        // speed = speed * Input.GetAxis("Vertical");

        transform.Translate(speed * Time.deltaTime);       
        float avgTriggers = 1-((Input.GetAxis("RightTrigger") + Input.GetAxis("LeftTrigger")) / 2);
        if (avgTriggers > PreviousAvgTrigger)
        {
            avgTriggers = PreviousAvgTrigger + (avgTriggers - PreviousAvgTrigger)*4f*Time.deltaTime;
        }
        else
        {
            avgTriggers = PreviousAvgTrigger - ( PreviousAvgTrigger - avgTriggers) * 2f*Time.deltaTime;
        }
        PreviousAvgTrigger = avgTriggers;
       // avgTriggers = avgTriggers * 0.9f + 0.05f;
        Vector3 FallingSpeed = Vector3.forward * gravity * Time.deltaTime * avgTriggers;
        transform.Translate(FallingSpeed);
        PreviousSpeed = FallingSpeed;
    }
     
        
       /* if (Input.GetAxis("RightTrigger") <= 0.9999 || Input.GetAxis("LeftTrigger") <= 0.9999)
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
        }*/

    
}
