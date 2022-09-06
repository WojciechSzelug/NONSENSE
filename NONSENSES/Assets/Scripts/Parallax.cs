using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        transform.position += new Vector3(0, -1* speed * gameManager.speedOfObstacle*Time.deltaTime, 0);

        if(transform.position.y < -16)
        {
            transform.position = startPosition;
        }
    }
}
