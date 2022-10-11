using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverMenu : MonoBehaviour
{
    // Start is called before the first frame update


 
    public void ExitGame()
    {
        FindObjectOfType<AudioManager>().Play("Buttom");
      //  PlayerPrefs.DeleteAll();
        
            SceneManager.LoadScene("Menu");

        
    }
    public void ExtraLife()
    {
        FindObjectOfType<AudioManager>().Play("Buttom");
        Debug.Log("watch advertisment to get extra live");
    }
    public void Retry()
    {
        FindObjectOfType<AudioManager>().Play("Buttom");
        //PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Game");
        FindObjectOfType<AudioManager>().VolumeReset("Theme");
    }
}
