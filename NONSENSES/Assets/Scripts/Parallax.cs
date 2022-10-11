using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Parallax : MonoBehaviour
{

    public float speed;
    GameManager gameManager;

    Vector3 startPosition;
    void Start()
    {
         gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>(); 
        
        startPosition = transform.position;
    }

    
    void Update()
    {
        if (!gameManager)
        {
            transform.position += new Vector3(0, -1 * speed * Time.deltaTime, 0);

            if (transform.position.y < -16)
            {
                transform.position = startPosition;
            }
        }
        else
        {
            transform.position += new Vector3(0, -1 * speed * gameManager.speedOfObstacle * Time.deltaTime, 0);

            if (transform.position.y < -16)
            {
                transform.position = startPosition;
            }
        }
    }

}
