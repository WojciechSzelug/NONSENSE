using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject options;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    public void PlayGame()
    {
        FindObjectOfType<AudioManager>().Play("Buttom");
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Game");
    }
    public void OpitonsGame()
    {
        FindObjectOfType<AudioManager>().Play("Buttom");
        options.SetActive(true);
        gameObject.SetActive(false);
    }
    public void QuitGame()
    {
        FindObjectOfType<AudioManager>().Play("Buttom");
        Debug.Log("Quit");
        Application.Quit();
    }
}
