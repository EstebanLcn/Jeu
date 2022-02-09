using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class FlyingCharacter : MonoBehaviour
{
    Vector3 speed = Vector3.forward*4;
    // Start is called before the first frame update
    void Start()
    {
    
       
    }
    public Text AngleDisplay;
    public Text avgTriggerDisplay;
    public Text FallingSpeedDisplay;
    [Range(0.001f,0.009f)]
    public float smooth = 1f;
    float gravity = 00.04f;
    float PreviousSpeed;
    // Update is called once per frame
    void Update()
    {
        Quaternion rotationStick = Quaternion.Euler(Input.GetAxis("Vertical") * 90, 0, 0);
        transform.rotation = rotationStick;
        AngleDisplay.text = rotationStick.normalized.x.ToString();
;        transform.Translate(speed * Time.deltaTime);       
        float avgTriggers = (Input.GetAxis("RightTrigger") + Input.GetAxis("LeftTrigger") ) / 2f;
        avgTriggerDisplay.text = avgTriggers.ToString();
        
        avgTriggers = 1f - avgTriggers;
        avgTriggers += rotationStick.normalized.x * (1f - avgTriggers);


        float speedValue = PreviousSpeed + (gravity * Time.deltaTime * avgTriggers);
        
        transform.Translate(Vector3.down * speedValue, Space.World);
        FallingSpeedDisplay.text = speedValue.ToString();
        PreviousSpeed = speedValue;
    }




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
}
