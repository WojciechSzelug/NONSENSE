using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject options;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Back();
    }
    public void Back()
    {
        FindObjectOfType<AudioManager>().Play("Buttom");
        options.SetActive(true);
        
        gameObject.SetActive(false);
    }
}
