using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
public class FPSInput : MonoBehaviour
{
    public float speed = 20.0f;
    CharacterController playerController;
    public float jumpForce = 5f;
    float Yspeed;
    float originolStepOffset;


    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<CharacterController>();
        originolStepOffset = playerController.stepOffset;
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = speed * Input.GetAxis("Horizontal") ;
        float deltaZ= speed * Input.GetAxis("Vertical") ;
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);
        
        movement*=Time.deltaTime;
        movement =transform.TransformDirection(movement);
        movement.y = -9.18f;
        playerController.Move(movement);

    }
}
