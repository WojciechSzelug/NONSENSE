using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject mainMenu;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Back();
    }
    public void Back()
    {
        FindObjectOfType<AudioManager>().Play("Buttom");
        mainMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
