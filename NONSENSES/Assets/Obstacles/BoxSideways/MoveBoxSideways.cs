using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets;

public class MoveBoxSideways : AbstractObstracle
{
    // Start is called before the first frame update

    int way;

    void Start()
    {
        OnStart();
        FirstWay(); 

    }

    // Update is called once per frame
    void Update()
    {
        OnUpdate();
    }
    private void FixedUpdate()
    {
        if (!gameManager.pause)
        {
            Sideway();

            OnFixedUpdate();

        }
    }

    void FirstWay()
    {
        int rand = Random.Range(0, 2); // da 0 albo 1
        if (rand == 0) way = -1;
        else way = 1;


    }
    void SwapWay()
    {
        if (way == 1) way = -1;
        else way = 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("colision :"+collision.gameObject.name+"with :"+gameObject.name);
        if (collision.gameObject.tag == "Wall")
        {
            SwapWay();
        }

    }

    private void Sideway()
    {
        transform.position += Vector3.left * way * 3 * Time.deltaTime;

    }
}
