using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    public float speedMovement = 5f;

    public float smoothTime = 0.1f;
    float smoothVelocity;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    // Update is called once per frame
    void Update()
    {
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        float verticalMovement = Input.GetAxisRaw("Vertical");
        Vector3 playerDirection = new Vector3(horizontalMovement, 0f, verticalMovement).normalized;

        if(playerDirection.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(playerDirection.x, playerDirection.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angleSmooth = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref smoothVelocity, smoothTime);
            transform.rotation = Quaternion.Euler(0f, angleSmooth, 0f);
            Vector3 playerMoveDirection = Quaternion.Euler(0f, angleSmooth, 0f) * Vector3.forward;
            controller.Move(playerMoveDirection.normalized * speedMovement * Time.deltaTime);
        }
    }
}
