using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlScript : MonoBehaviour
{

    public GameManager gameManager;
    public float velocityOfPlayer;
   
    public Rigidbody2D rigidbody2D;

    public Animator animator;
    public SpriteRenderer sprite;

    public float lerpTime = 1f;
  
    public virtual void OnStart()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        animator = GetComponent<Animator>();
        

    }
    void FixedUpdate()
    {
        if (!gameManager.pause)
        {
            if (Input.touchCount == 0)
            {
                // if no touch just reset

                MoveForward();
                
            }
            else if (Input.touchCount == 1)
            {

                Touch _touch = Input.GetTouch(0);
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(_touch.position);
                Vector3 direction = touchPosition - transform.position;
                if (direction.x < -0.1)
                {
                    MoveLeft();
                    
                }
                else if (direction.x > 0.1)
                {
                    MoveRight();
                    
                }
                else
                {
                    MoveForward();
                }

                animator.SetFloat("Speed",Mathf.Abs( rigidbody2D.velocity.x));
                if (rigidbody2D.velocity.x <= 0) 
                {
                    sprite.flipX = false;
                }
                else
                {
                    sprite.flipX = true;
                }
                //transform.position = new Vector2(Mathf.Lerp(transform.position.x, touchPosition.x, moveSpeed), transform.position.y);

            }

        }
        else if (Input.touchCount == 2)
        {
            MoveForward();
            print("Move forward");
        }

    }

    public void MoveLeft()
    {
        rigidbody2D.velocity = new Vector2(-1 * velocityOfPlayer * Time.deltaTime,0);
        
        

    }
    public void MoveRight()
    {
        rigidbody2D.velocity = new Vector2(1 * velocityOfPlayer * Time.deltaTime, 0);
       
        
    }
    public void MoveForward()
    {
        rigidbody2D.velocity = new Vector2(0, 0);
        
    }

}
