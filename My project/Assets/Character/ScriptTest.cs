using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * 3 * Time.deltaTime);
        transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * 3 * Time.deltaTime);
        transform.Rotate(Vector3.up * Input.GetAxis("RightTrigger") * 750 * Time.deltaTime);
        transform.Rotate(Vector3.down * Input.GetAxis("LeftTrigger") * 750 * Time.deltaTime);
        WingFlapping();
    }
  
    public void WingFlapping()
    {


    }
}
