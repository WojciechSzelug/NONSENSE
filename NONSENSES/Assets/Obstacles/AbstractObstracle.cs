using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Collections;

using UnityEngine;


namespace Assets
{
    public abstract class AbstractObstracle : MonoBehaviour
    {
        public float speed { get; set; }
        public GameManager gameManager;
        public Rigidbody2D rb;
        public virtual void  OnStart()
        {
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();


        }

        public virtual void OnUpdate()
        {
            speed = gameManager.speedOfObstacle;
        }

        public virtual void OnFixedUpdate()
        {


            transform.position += Vector3.down * speed * Time.deltaTime;
            if (transform.position.y < -10f)
            {
                gameManager.stage.DestroyObstacle(gameObject);

            }


        }



    }
}
