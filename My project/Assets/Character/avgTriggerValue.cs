using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class avgTriggerValue : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    
    }
    float avgTriggers;
    public Text txt;
    // Update is called once per frame
    void Update()
    {


        avgTriggers = 1f - ((Input.GetAxis("RightTrigger") + Input.GetAxis("LeftTrigger")) / 2f);
        
    }
}
