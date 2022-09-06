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
    //lista przechowuj¹ca przeszkody by móc je kontrolowaæ 
    public Leaderboard leaderboard;
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


    }
    void Update()
    {

    }

    void BackMenu()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Menu");
    }


    //koniec gry
    public void EndGame()
    {
        leaderboard.DoLeadreboardPost(points);
        player.GetComponent<PlayerScript>().Destroy();
        debuger.text = "GAME OVER";
        PauseGameHalf();
        Invoke("ShowMenu", 0.3f);
    }
    //dodanie punktu zostaje tutaj
    public void AddPoint(int value)
    {
        points += value;
        pointsUI.text = points.ToString();
        speedOfObstacle = speedOfObstacleStart + points * 0.1f;
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
