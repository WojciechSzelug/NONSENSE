using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets;

public class MoveBox : AbstractObstracle
{
    // Start is called before the first frame update


    void Start()
    {
        OnStart();
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
            OnFixedUpdate();
        }
    }
}
