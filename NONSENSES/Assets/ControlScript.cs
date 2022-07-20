using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlScript : MonoBehaviour
{

    public GameManager gameManager;
    public float velocityOfPlayer;
    public float maxSpeed;
    public Rigidbody2D rigidbody2D;

    
    public virtual void OnStart()
    {
       gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();


    }
    void FixedUpdate()
    {

        if (Input.touchCount == 0)
        {

        }
        else if ( Input.touchCount == 1)
        {
            if (!gameManager.pause)
            {
                Touch _touch = Input.GetTouch(0);
                Vector3 _touchPosition = Camera.main.ScreenToWorldPoint(_touch.position);
               /*
                touchPosition.z = 0f; 
                touchPosition.y = transform.position.y;
                transform.position = new Vector3(touchPosition.x,0 ,0);
               
                */
                if (_touchPosition.x>0)
                {
                    Vector2 _force = new Vector2(1 * velocityOfPlayer , 0)*Time.deltaTime;
                    if (rigidbody2D.velocity.x < maxSpeed)
                        rigidbody2D.AddForce(_force);
                    print("Mouse moved right");
                }
                if (_touchPosition.x < 0)
                {
                     
                    Vector2 _force = new Vector2(-1 * velocityOfPlayer , 0) * Time.deltaTime;
                    if (rigidbody2D.velocity.x > -1*maxSpeed)
                        rigidbody2D.AddForce(_force);

                    print("Mouse moved left");
                }
            }

        }
        else if (Input.touchCount == 2)
        {
            rigidbody2D.velocity = new Vector2(0, 0);
            print("Move forward");
        }

    }

    public void MoveLeft()
    {
        rigidbody2D.velocity = new Vector2(-1 * velocityOfPlayer * Time.deltaTime, Input.GetAxis("Mouse X") * velocityOfPlayer);
        print("Mouse moved right");
    }
    public void MoveRight()
    {
        rigidbody2D.velocity = new Vector2(1 * velocityOfPlayer * Time.deltaTime, Input.GetAxis("Mouse X") * velocityOfPlayer);
        print("Mouse moved right");
    }

}
