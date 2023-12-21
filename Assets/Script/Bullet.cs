using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    float speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        transform.Translate(Vector3.forward*Time.deltaTime*speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
