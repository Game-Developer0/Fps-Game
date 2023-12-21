using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public enum AngleAxies
    {
        angleX=0,
        angleY=1,
        bothXY=2,
    }
    float horizontalSens = 9.0f;
    float verticalSens = 9.0f;
    public AngleAxies axes=AngleAxies.bothXY;
    float verticalRot = 0;
    float verticalmin = -45;
    float verticalmax = 45;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody body=GetComponent<Rigidbody>();
        if(body!= null)
        {
            body.freezeRotation = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (axes == AngleAxies.angleX)
        {
            transform.Rotate(0,Input.GetAxis("Mouse X")*horizontalSens,0);
        }
        else if(axes == AngleAxies.angleY)
        {
            verticalRot -= verticalSens * Input.GetAxis("Mouse Y");
            verticalRot = Mathf.Clamp(verticalRot, verticalmin, verticalmax);
            float horizontalRot = transform.localEulerAngles.y;
            transform.localEulerAngles = new Vector3(verticalRot, horizontalRot, 0);
        }
        else if(axes==AngleAxies.bothXY) 
        {
            verticalRot -= verticalSens * Input.GetAxis("Mouse Y");
            verticalRot=Mathf.Clamp(verticalRot, verticalmin,verticalmax);
            float delta = horizontalSens * Input.GetAxis("Mouse X");
            float horizontalRot = transform.localEulerAngles.y + delta;
            transform.localEulerAngles = new Vector3(verticalRot, horizontalRot, 0);
        }
    }
}
