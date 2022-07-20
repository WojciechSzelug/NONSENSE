using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlScript : MonoBehaviour
{

    public GameManager gameManager;
    public float velocityOfPlayer;
    public float moveSpeed;
    public Rigidbody2D rigidbody2D;

    public float lerpTime = 1f;
    private float currentLerpTime;

    public virtual void OnStart()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        currentLerpTime = 0;

    }
    void FixedUpdate()
    {
        if (!gameManager.pause)
        {
            if (Input.touchCount == 0)
            {
                // if no touch just reset
                currentLerpTime = 0f;
            }
            else if (Input.touchCount == 1)
            {

                Touch _touch = Input.GetTouch(0);
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(_touch.position);
                transform.position = new Vector2(Mathf.Lerp(transform.position.x, touchPosition.x, moveSpeed), transform.position.y);

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
