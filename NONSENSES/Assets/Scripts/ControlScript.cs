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

            KeyboardMove();
            if (Input.touchCount == 0 && Input.GetAxis("Horizontal") == 0)
            {
                // if no touch just reset
                
                MoveForward();
                
            }
            else if (Input.touchCount == 1)
            {

                Touch _touch = Input.GetTouch(0);
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(_touch.position);
                Vector3 direction = touchPosition - transform.position;

       
                if (direction.x < -0.4)
                {
                    MoveLeft();
                   
                }
                else if (direction.x > 0.4)
                {
                    MoveRight();
                    
                }
                else
                {
                    
                    MoveForward();
                }
                

                //transform.position = new Vector2(Mathf.Lerp(transform.position.x, touchPosition.x, moveSpeed), transform.position.y);

            }
            else if (Input.touchCount == 2)
            {
                MoveForward();
               

            }
        }
    

        // animator.SetFloat("Speed", Mathf.Abs(rigidbody2D.velocity.x));
      
        animator.SetFloat("Speed", Mathf.Abs(rigidbody2D.velocity.x));
    }

    void KeyboardMove()
    {
        if (Input.GetAxisRaw("Horizontal") >0)
        {
            MoveRight();

        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            MoveLeft();
            
        }
    }
    public void MoveLeft()
    {
        rigidbody2D.velocity = new Vector2(-1 * velocityOfPlayer,0);
        sprite.flipX = false;
        
       
    }
    public void MoveRight()
    {
        rigidbody2D.velocity = new Vector2(1 * velocityOfPlayer, 0);
        sprite.flipX = true;
        
        
    }
    public void MoveForward()
    {
        rigidbody2D.velocity = new Vector2(0, 0);
        
       
    }

}
