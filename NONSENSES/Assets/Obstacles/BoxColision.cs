using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime;
using Assets;
public class BoxColision : MonoBehaviour
{
    //trzeba stworzyæ klasê abstrakcyjn¹ dla przeszkód 
    public GameManager gameManager;
    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("colision :"+collision.gameObject.name+"with :"+gameObject.name);
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("colision");
            gameManager.EndGame();
        } 

    }


}
