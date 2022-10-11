using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    public GameObject gameOverMenu;
    public Text score;
    public Text bestScore;
    public GameObject newLifeMenu;
    public GameObject pausaMenu;
    public GameManager gameManager;

    static bool HALF_PAUSA = true;
    static bool FULL_PAUSA = false;
    // Start is called before the first frame update
    void Start()
    {
        newLifeMenu.SetActive(false);
        pausaMenu.SetActive(false);
        gameOverMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) /*|| stage.endStage==true*/)
        {
            OpenPausaMenu();
        }
    }
    //########### OPEN/CLOSE MENU ##############
    public void OpenPausaMenu()
    {
        PauseGameStatus(FULL_PAUSA);
        FindObjectOfType<AudioManager>().VolumeProcent("Theme", PlayerPrefs.GetFloat("MusicValue")*0.1f);
        pausaMenu.SetActive(true);
    }
   public  void ClosePausaMenu()
    {
        PauseGameStatus(FULL_PAUSA);
        FindObjectOfType<AudioManager>().VolumeProcent("Theme", PlayerPrefs.GetFloat("MusicValue"));
        pausaMenu.SetActive(false);
    }
   public  void OpenNewLifeMenu()
    {
        PauseGameStatus(HALF_PAUSA);
        FindObjectOfType<AudioManager>().VolumeProcent("Theme", PlayerPrefs.GetFloat("MusicValue") * 0.1f);
        newLifeMenu.SetActive(true);
    }
   public void CloseNewLifeMenu()
    {
        PauseGameStatus(HALF_PAUSA);
        FindObjectOfType<AudioManager>().VolumeProcent("Theme", PlayerPrefs.GetFloat("MusicValue"));
        newLifeMenu.SetActive(false);
    }
   public void OpenGameOverMenu()
    {
        PauseGameStatus(FULL_PAUSA);
        gameManager.SaveHighScore();
        FindObjectOfType<AudioManager>().VolumeProcent("Theme", PlayerPrefs.GetFloat("MusicValue") * 0.1f);
        gameOverMenu.SetActive(true);
        gameManager.UploadLeaderboard();
        score.text = gameManager.points.ToString();
        bestScore.text = PlayerPrefs.GetInt("highscore").ToString();

    }
    public void CloseGameOverMenu()
    {
        PauseGameStatus(FULL_PAUSA);
        FindObjectOfType<AudioManager>().VolumeProcent("Theme", PlayerPrefs.GetFloat("MusicValue"));
        gameOverMenu.SetActive(false);
    }

    public void MakeSound()
    {
        FindObjectOfType<AudioManager>().Play("Buttom");
    }
    //########################
    public void BackToMeinMenu()
    {
       // PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Menu");
    }

    public void RetryGameFromPausa()
    {
        ClosePausaMenu();
    }
    public void RestartGameFromPausa()
    {
        ClosePausaMenu();
        SceneManager.LoadScene("Game");
    }
    public void NewGame()
    {
        CloseGameOverMenu();
        SceneManager.LoadScene("Game");
    }

    public void DontShowAd()
    {
        CloseNewLifeMenu();
        OpenGameOverMenu();

    }

    void PauseGameStatus(bool _halfPause)
    {
        gameManager.ChangeStatusOfPauseGame(_halfPause);
    }


}
