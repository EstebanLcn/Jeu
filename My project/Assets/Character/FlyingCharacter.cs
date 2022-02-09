using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class FlyingCharacter : MonoBehaviour
{
    Vector3 speed = Vector3.up*4;
    // Start is called before the first frame update
    void Start()
    {
    
        transform.rotation = Quaternion.Euler(90,0, 00);
    }
    public Text avgTriggerDisplay;
    public Text FallingSpeedDisplay;
    bool TriggerPressedLastFrame;
    [Range(0.001f,0.009f)]
    public float smooth = 1f;
    float gravity = 00.04f;
    float PreviousAvgTrigger;
    float timeStartFalling;
    float PreviousSpeed;
    // Update is called once per frame
    void Update()
    {
        // speed = speed * Input.GetAxis("Vertical");
     
        transform.Translate(speed * Time.deltaTime);       
        float avgTriggers = 1f-(Input.GetAxis("RightTrigger") + Input.GetAxis("LeftTrigger")) / 2f;
        avgTriggerDisplay.text = avgTriggers.ToString();
        /*
        if (avgTriggers > PreviousAvgTrigger)
            {
                //avgTriggers = PreviousAvgTrigger + (avgTriggers - PreviousAvgTrigger) * 4f * Time.deltaTime;
            }
            else
            {
       
                    avgTriggers = PreviousAvgTrigger - (PreviousAvgTrigger - avgTriggers) * 0.01f * Time.deltaTime;
               
            }
            if (avgTriggers > 1)
        {
            avgTriggers = 1;
        }*/
        float speedValue = PreviousSpeed + (gravity * Time.deltaTime * avgTriggers);
        PreviousAvgTrigger = avgTriggers;
        
        
        // avgTriggers = avgTriggers * 0.9f + 0.05f;
        //Vector3 FallingSpeed = Vector3.forward * gravity * Time.deltaTime * avgTriggers + (PreviousSpeed* 0.9);
        
     
        //
        transform.Translate(Vector3.forward * speedValue);
        FallingSpeedDisplay.text = speedValue.ToString();
        PreviousSpeed = speedValue;
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
