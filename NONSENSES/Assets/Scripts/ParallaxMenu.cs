using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ParallaxMenu : MonoBehaviour
{

    public float speed;
   

    Vector3 startPosition;
    void Start()
    {
    
        startPosition = transform.position;
    }

    
    void Update()
    {
 
            transform.position += new Vector3(0, -1 * speed * Time.deltaTime, 0);

            if (transform.position.y < -16)
            {
                transform.position = startPosition;
            }
       
    }

}
