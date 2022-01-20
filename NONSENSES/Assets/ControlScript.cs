using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlScript : MonoBehaviour
{

    public GameManager gameManager;
   
    public virtual void OnStart()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();


    }
    void Update()
    {


        if ( Input.touchCount > 0)
        {
           
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0f; touchPosition.y = transform.position.y;
            if (touchPosition.x > 2.535f) touchPosition.x = 2.535f;
            else if (touchPosition.x < -2.555f) touchPosition.x = -2.555f;
            transform.position = touchPosition;

            

        }

    }
}
