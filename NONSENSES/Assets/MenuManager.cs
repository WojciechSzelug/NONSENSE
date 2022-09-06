using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    public GameObject gameOverMenu;
    public GameObject newLifeMenu;
    public GameObject pausaMenu;
    public GameManager gameManager;

    static bool HALF_PAUSA = true;
    static bool FULL_PAUSA = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) /*|| stage.endStage==true*/)
        {
            OpenPausaMenu();
        }
    }
    public void OpenPausaMenu()
    {
        PauseGameStatus(FULL_PAUSA);
        FindObjectOfType<AudioManager>().VolumeProcent("Theme", 10);
        pausaMenu.SetActive(true);
    }
   public  void ClosePausaMenu()
    {
        PauseGameStatus(FULL_PAUSA);
        FindObjectOfType<AudioManager>().VolumeProcent("Theme", 10);
        pausaMenu.SetActive(true);
    }
   public  void OpenNewLifeMenu()
    {
        PauseGameStatus(HALF_PAUSA);
        FindObjectOfType<AudioManager>().VolumeProcent("Theme", 10);
        newLifeMenu.SetActive(true);
    }
   public void CloseNewLifeMenu()
    {
        PauseGameStatus(HALF_PAUSA);
        FindObjectOfType<AudioManager>().VolumeProcent("Theme", 10);
        newLifeMenu.SetActive(true);
    }
   public void OpenGameOverMenu()
    {
        PauseGameStatus(FULL_PAUSA);
        FindObjectOfType<AudioManager>().VolumeProcent("Theme", 10);
        gameOverMenu.SetActive(true);
    }
    public void CloseGameOverMenu()
    {
        PauseGameStatus(FULL_PAUSA);
        FindObjectOfType<AudioManager>().VolumeProcent("Theme", 100);
        gameOverMenu.SetActive(false);
    }
    public void BackMenu()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Menu");
    }
    void PauseGameStatus(bool _halfPause)
    {
        gameManager.ChangeStatusOfPauseGame(_halfPause);
    }


}
