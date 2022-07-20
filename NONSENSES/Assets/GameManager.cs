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
    public GameObject gameOverMenu;
    public Boolean pause;
    public Text debuger;
    public Text pointsUI;
    //lista przechowuj¹ca przeszkody by móc je kontrolowaæ 

    private float speedOfObstacleStart;



    void Start()
    {
       
        pause = false;

        Application.targetFrameRate = 60;
        //do zmiany pauza w grze
        Time.timeScale = 1f;

        stages = GameObject.FindGameObjectWithTag("Stages");

        stage = stages.GetComponent<Stage1>();
        points = 0;


        speedOfObstacleStart = speedOfObstacle;

        
        pointsUI.text = points.ToString();
       

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) /*|| stage.endStage==true*/)
        {
            BackMenu();
        }
    }

    void BackMenu()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Menu");
    }


    //koniec gry
    public void EndGame()
    {
        OpenMenu();
        debuger.text =  "GAME OVER";
    }
    //dodanie punktu zostaje tutaj
    public void AddPoint(int value) {
        points += value;
        pointsUI.text = points.ToString();
        speedOfObstacle = speedOfObstacleStart + points*0.1f;
    }
    void OpenMenu()
    {
        FindObjectOfType<AudioManager>().VolumeProcent("Theme", 10);
        gameOverMenu.SetActive(true);
        PauseGame();

    }
    void CloseMenu()
    {
        Debug.LogWarning("tutaj jeszcze dzia³a w closemenu");
        if(gameOverMenu != null)
        gameOverMenu.SetActive(false);
        Debug.LogWarning("tutaj jeszcze dzia³a wy³¹czenie menu");
        FindObjectOfType<AudioManager>().VolumeReset("Theme");
        Debug.LogWarning("tutaj jeszcze dzia³a reset muzyki");
        RetryGame();
    }
    void RetryGame()
    {
        pause = false;
    }
    void PauseGame()
    {
        pause = true;
    }

//player;
    IEnumerator Inviolability()
    {
        Debug.Log("niesmiertelny");
        player.GetComponent<PolygonCollider2D>().enabled = false;
        yield return new WaitForSeconds(5);
        player.GetComponent<PolygonCollider2D>().enabled = true;
        Debug.Log("smiertelny");

    }
    public void NewLive()
    {
        Debug.Log("gracz dostal nowe zycie");

       
        CloseMenu();
        StartCoroutine(Inviolability());
        



    }

}
