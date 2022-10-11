using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public int points;
    // stage is like a level
    public GameObject stages;
    public Stage1 stage;
    public GameObject player;
    public float speedOfObstacle = 0.01f;
    public MenuManager menuManager;
    public Boolean pause;
    public Text debuger;
    public Text pointsUI;
    public float maxSpeed;
    //lista przechowuj¹ca przeszkody by móc je kontrolowaæ 
    public bool ADLoaded;

    public Leaderboard leaderboard;
    public bool DoPlayerGotNewLife;
    private float speedOfObstacleStart;


    void Start()
    {
        RetryGame();
        Application.targetFrameRate = 60;
        //do zmiany pauza w grze
        Time.timeScale = 1f;
        stages = GameObject.FindGameObjectWithTag("Stages");
        stage = stages.GetComponent<Stage1>();
        leaderboard = GetComponent<Leaderboard>();
        player = GameObject.FindGameObjectWithTag("Player");

        points = 0;
        speedOfObstacleStart = speedOfObstacle;

        pointsUI.text = points.ToString();

        DoPlayerGotNewLife = false;

    }
    void Update()
    {

    }

    void BackMenu()
    {
      //  PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Menu");
    }


    //koniec gry
    public void EndGame()
    {
        
        player.GetComponent<PlayerScript>().Destroy();

        if (!DoPlayerGotNewLife && ADLoaded == true)
            // Invoke("ShowNewLifeMenu", 0.3f);
            ShowNewLifeMenu();
        else
        {
            // Invoke("ShowGameOverMenu", 0.5f);
            ShowGameOverMenu();
        }
    }
    public void UploadLeaderboard()
    {
        leaderboard.DoLeadreboardPost(points);
    }
    void ShowNewLifeMenu()
    {
        menuManager.OpenNewLifeMenu();
    }
    void ShowGameOverMenu()
    {
        menuManager.OpenGameOverMenu();
    }
    //dodanie punktu zostaje tutaj
    public void AddPoint(int value)
    {
        points += value;
        pointsUI.text = points.ToString();
        speedOfObstacle = speedOfObstacleStart + points * 0.1f;
    }

    void AddSpeed()
    {
        if(speedOfObstacle < maxSpeed)
        speedOfObstacle = speedOfObstacleStart + points * 0.1f;
    }

    public void SaveHighScore()
    {
        if (!PlayerPrefs.HasKey("highscore"))
        {
            PlayerPrefs.SetInt("highscore", points);
            return;
        }
        if(points>PlayerPrefs.GetInt("highscore"))
        PlayerPrefs.SetInt("highscore", points);
    }

    public void ChangeStatusOfPauseGame(bool _halfPause)
    {
        if (!pause && _halfPause) PauseGameHalf();
        else if (!pause && !_halfPause) PauseGame();
        else RetryGame();
    }
    void RetryGame()
    {
        pause = false;
        Time.timeScale = 1;
    }
    void PauseGame()
    {
        pause = true;
        Time.timeScale = 0;
    }
    void PauseGameHalf()
    {
        pause = true;
        
    }
    public void NewLive()
    {
        Debug.Log("gracz dostal nowe zycie");
        DoPlayerGotNewLife = true;
        menuManager.CloseNewLifeMenu();
        player.GetComponent<PlayerScript>().NewLive();

    }

    //#####################################################
    //#################### MENU ###########################
    //#####################################################
    /*
    void OpenMenu()
    {
        ShowMenu();
        PauseGame();

    }
    void ShowMenu()
    {
        FindObjectOfType<AudioManager>().VolumeProcent("Theme", 10);
        gameOverMenu.SetActive(true);
    }
    void CloseMenu()
    {
        if (gameOverMenu != null)
            gameOverMenu.SetActive(false);
        FindObjectOfType<AudioManager>().VolumeReset("Theme");
        RetryGame();
    }
    public void NewLive()
    {
        Debug.Log("gracz dostal nowe zycie");
        CloseMenu();
        player.GetComponent<PlayerScript>().NewLive();

    }
    */
}
