using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using TMPro;
using Assets;
using System;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public int points;

    
    private Transform leftEdge;
    private Transform rightEdge;
    private Transform spawnPoint;
    private Transform distanceSpawn;
    
    public GameObject player;

    public float speedOfObstacle = 0.01f;
    public List<GameObject> obstacle;
    public GameObject pointsObject;
    public GameObject gameOverMenu;

    public Boolean pause;
   
    public Text debuger;
    public Text pointsUI;
    //lista przechowuj¹ca przeszkody by móc je kontrolowaæ 


    private List<GameObject> obstacles;
    private List<GameObject> pointsList;
    private float speedOfObstacleStart;
    public int numberOfObstacle;
    public int indexOfObstacle;

    

    private void Awake()
    {
        
    }

    void Start()
    {
       
        pause = false;
        Application.targetFrameRate = 60;
        //do zmiany pauza w grze
        Time.timeScale = 1f;
        //ustawienie pozycji obiektów w grze
        PositionsOfObjects positions = GetComponent<PositionsOfObjects>();
        leftEdge = positions.leftWall;
        rightEdge = positions.rightWall;
        spawnPoint = positions.spawnPoint;
        distanceSpawn = positions.distanceSpawn;

        points = 0;

        obstacles = new List<GameObject>();
        pointsList = new List<GameObject>();
        //

        speedOfObstacleStart = speedOfObstacle;
        /*
                randomNumber();
                randomObstacleIndex();

                SpawnObstacle(obstacle.First());
                SpawnPotion(pointsObject);
        */
        Level();
        pointsUI.text = points.ToString();
       

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            BackMenu();
        }
    }

    void FixedUpdate()
    {
        //jeœli przeszkoda dotar³a do distanceSpawn tworzy now¹ przeszkodê

            Level();

   


    }
    void BackMenu()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Menu");
    }
    void randomNumber()
    {

        numberOfObstacle = Random.Range(4, 10);
    }
    void randomObstacleIndex()
    {
        indexOfObstacle = Random.Range(0, obstacle.Count());
    }
    void Level()
    {
        if(obstacles != null)
        if (numberOfObstacle > 0 && obstacles.Last().transform.position.y < distanceSpawn.position.y)
        {
            SpawnObstacle(obstacle[indexOfObstacle]);
            SpawnPotion(pointsObject);
            numberOfObstacle--;
            

        }

        if (numberOfObstacle == 0 && !obstacles.Any())
        {
            randomNumber();
            randomObstacleIndex();

            SpawnObstacle(obstacle[indexOfObstacle]);
            SpawnPotion(pointsObject);
        }
    }

    
    public void SpawnObstacle(GameObject gObject)
    {
        //dodaje przeszkode, pozycjonuje j¹
        obstacles.Add(Instantiate(gObject, new Vector3(0,spawnPoint.position.y,0), gameObject.transform.rotation));
        gObject = obstacles.Last();
        AbstractSetPosition component = (AbstractSetPosition)gObject.GetComponent(typeof(AbstractSetPosition));
        Vector3 position = component.SetPositions();
        gObject.transform.position = position;  
         
 
    }
    public void SpawnPotion(GameObject gObject) {
        //pozycjonuje punkt  zaraz po dodaniu przeszkody
        // niech robi to klasa w obiekcie punkt 
        //klasa pozycjonuj¹ca przeszkodê powinna posiadaæ te¿ informacje o wolnej przestrzeni dla punku
  
        List<Przestrzen> wolnaPrzestrzen = new List<Przestrzen>();
        float widthPoint = gObject.transform.lossyScale.x;
        AbstractSetPosition component = (AbstractSetPosition)obstacles.Last().GetComponent(typeof(AbstractSetPosition));
        //wywolaj SetPrzestrzen()
        component.SetPrzestrzen();
        //Debug.Log("jakaœ wartoœæ z componenta"+component.listaPrzestrzeni[0].right);
        wolnaPrzestrzen = component.listaPrzestrzeni.FindAll(
            delegate (Przestrzen p)
            {
                return p.stan == false;
            }
            );
        wolnaPrzestrzen = wolnaPrzestrzen.Where(przestrzen => przestrzen.Distacne() > widthPoint).ToList();
        
        int rnd = Random.Range(0, wolnaPrzestrzen.Count);
        float leftEdgeX = wolnaPrzestrzen[rnd].left;
        float rightEdgeX = wolnaPrzestrzen[ rnd].right;
        //krawêdzie musz¹ uwzglêdniaæ szerokoœæ punktu
        leftEdgeX = leftEdgeX + Math.Abs(widthPoint/2);
        rightEdgeX = rightEdgeX - Math.Abs(widthPoint / 2);

        float rand = Random.Range(leftEdgeX , rightEdgeX );
        

        Vector3 position = new Vector3(rand, spawnPoint.position.y, 0);
        pointsList.Add(Instantiate(gObject, position, gObject.transform.rotation));
        pointsList.Last().GetComponent<points>().FakeParent = obstacles.Last().transform;
    }
    public void DestroyObstacle(GameObject obstacle)
    {
        Destroy(obstacle);
       
        obstacles.Remove(obstacle);
       
    }
    public void DestroyPoint(GameObject point)
    {
        Destroy(point);

        pointsList.Remove(point);

    }

    public void EndGame()
    {
        OpenMenu();
        debuger.text =  "GAME OVER";
    }
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
    void ClearGame()
    {
        numberOfObstacle = 0;
        if (obstacles.Any())
            for (int i = 0; i < obstacles.Count(); i++)
        {
            
                DestroyObstacle(obstacles[i]);
        }
        if (pointsList.Any())
            for (int i = 0; i < pointsList.Count(); i++)
        {
           
                DestroyObstacle(pointsList[i]);
        }
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
