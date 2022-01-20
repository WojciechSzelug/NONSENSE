using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Assets;


//funkcja poruszaj¹ca obiektem
//x to czas
//y to skala prêdkoœci
//co jeœli bêdzie za szybko
//0.436*x^6-2.268*x^5+4.397*x^4-3.431*x^3+0.672*x^2+0.324*x+0.0065


public class MoveTunnel : AbstractObstracle
{
    // Start is called before the first frame update
    float timeOfCreate;

    void Start()
    {
        OnStart();
        timeOfCreate = Time.fixedTime;
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
            //x to czas nie prêdkoœæ
            //zapisz czas podczas tworzenia obiektu fixedTime i odejmij go od fixedTime 
            double x = Time.fixedTime - timeOfCreate;

            float trueSpeed = (float)(0.436 * Math.Pow(x, 6) - 2.268 * Math.Pow(x, 5) + 4.397 * Math.Pow(x, 4) - 3.431 * Math.Pow(x, 3) + 0.672 * Math.Pow(x, 2) + 0.324 * x + 1.0065);
            transform.position += Vector3.down * trueSpeed * Time.deltaTime;
            if (transform.position.y < -6f)
            {
                gameManager.DestroyObstacle(gameObject);

            }
        }
    }
}
