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

public class Stage1 : AbstractStages
{

    public GameObject obstacle;
    public GameObject pointsObject;

    private Transform leftEdge;
    private Transform rightEdge;
    private Transform spawnPoint;
    private Transform distanceSpawn;


    public PositionsOfObjects positions;

    public int numberOfObstacle;
    public int indexOfObstacle;


    private List<GameObject> obstacles;
    private List<GameObject> pointsList;
    private float speedOfObstacleStart;

    public Boolean endStage;

    // Start is called before the first frame update
    void Start()
    {
        endStage = false;
        positions = GetComponent<PositionsOfObjects>();

        leftEdge = positions.leftWall;
        rightEdge = positions.rightWall;
        spawnPoint = positions.spawnPoint;
        distanceSpawn = positions.distanceSpawn;


        NewListOfObstacles();
        NewListOfPoints();
        randomNumber();
       
        //trzeba spawnowa� co� jako pierwsze ale mo�e da si� to naprawi�
        SpawnObstacle(obstacle);
        SpawnPotion(pointsObject);


    }


    /* Poziom generuje w niesko�czono�� przeszkody kt�re trzeba omija�
     * u�ywa� tego stage tylko do gry bez zmniany stejdz�w :)

     */


    // Update is called once per frame
    void Update()
    {
        Level();
    }

    void NewListOfObstacles()
    {
        obstacles = new List<GameObject>();
    }

    void NewListOfPoints()
    {
        pointsList = new List<GameObject>();
    }
    void randomNumber()
    {

        numberOfObstacle = 1;
    }

 


    /*Generowaie przeszk�d dzia�a w taki spos�b �e losuj� kt�ra przeszkoda ma si� pojawi� a nast�pnie losuje ile razy
     * Gdy liczba przeszk�d dojdzie do 0  to losuje nowy rodzaj przeszk�d i now� liczb� tych przeszk�d
     */
    public void Level()
    {
        if (obstacles != null)
            //
            if (numberOfObstacle > 0 && obstacles.Last().transform.position.y < distanceSpawn.position.y)
            {

                SpawnObstacle(obstacle);
                SpawnPotion(pointsObject);
                numberOfObstacle--;

            }
            if(numberOfObstacle == 0)
            {
                randomNumber();
            }



    }

    public void SpawnObstacle(GameObject gObject)
    {
        //dodaje przeszkode, pozycjonuje j�
        obstacles.Add(Instantiate(gObject, new Vector3(0, spawnPoint.position.y, 0), gameObject.transform.rotation));
        gObject = obstacles.Last();
        AbstractSetPosition component = (AbstractSetPosition)gObject.GetComponent(typeof(AbstractSetPosition));
        Vector3 position = component.SetPositions();
        gObject.transform.position = position;


    }


    public void SpawnPotion(GameObject gObject)
    {
        //pozycjonuje punkt  zaraz po dodaniu przeszkody
        // niech robi to klasa w obiekcie punkt 
        //klasa pozycjonuj�ca przeszkod� powinna posiada� te� informacje o wolnej przestrzeni dla punku

        List<Przestrzen> wolnaPrzestrzen = new List<Przestrzen>();
        float widthPoint = gObject.transform.lossyScale.x;
        AbstractSetPosition component = (AbstractSetPosition)obstacles.Last().GetComponent(typeof(AbstractSetPosition));
        //wywolaj SetPrzestrzen()
        component.SetPrzestrzen();
        //Debug.Log("jaka� warto�� z componenta"+component.listaPrzestrzeni[0].right);
        wolnaPrzestrzen = component.listaPrzestrzeni.FindAll(
            delegate (Przestrzen p)
            {
                return p.stan == false;
            }
            );
        wolnaPrzestrzen = wolnaPrzestrzen.Where(przestrzen => przestrzen.Distacne() > widthPoint).ToList();

        int rnd = Random.Range(0, wolnaPrzestrzen.Count);
        float leftEdgeX = wolnaPrzestrzen[rnd].left;
        float rightEdgeX = wolnaPrzestrzen[rnd].right;
        //kraw�dzie musz� uwzgl�dnia� szeroko�� punktu
        leftEdgeX = leftEdgeX + Math.Abs(widthPoint / 2);
        rightEdgeX = rightEdgeX - Math.Abs(widthPoint / 2);

        float rand = Random.Range(leftEdgeX, rightEdgeX);


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

}
