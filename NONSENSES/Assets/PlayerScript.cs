using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Animator animatorPlayer;
    public PolygonCollider2D collider;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Destroy()
    {
        animatorPlayer.SetBool("Explosion",true);

    }
    public void NewLive()
    {
        StartCoroutine(Inviolability());
        animatorPlayer.SetBool("Explosion", false);
    }
    IEnumerator Inviolability()
    {
        animatorPlayer.Play("Player_Shield");
        Debug.Log("niesmiertelny");
        collider.enabled = false;
        yield return new WaitForSeconds(5);
        collider.enabled = true;
        Debug.Log("smiertelny");
        
    }
}
