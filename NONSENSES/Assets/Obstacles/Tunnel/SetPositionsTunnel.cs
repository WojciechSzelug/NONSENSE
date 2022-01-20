using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Assets;
using Random = UnityEngine.Random;
public class SetPositionsTunnel : AbstractSetPosition
{
    // Start is called before the first frame update

    float widthObjectLeft;
    float widthObjectRight;
    float positionOfObjectLeft;
    float positionOfObjectRight;
    float positionOfMainObject;
    float positionOfLeftEdgeFreeSpace;
    float positionOfRightEdgeFreeSpace;
    float distanceBetweenEdgeAndCenter;
    void Start()
    {

    }

    public override Vector3 SetPositions()
    {

        
        OnStart();
        position = new Vector3();

        //weŸ szerokoœæ dziecka jednego i drugiego i ich pozycje
        // lewa pozycja i szerokoœæ i prawa pozycja i szerokoœæ
        //
        //szerokoœæ
        widthObjectLeft = gameObject.transform.Find("LeftObstacle").lossyScale.x;
        widthObjectRight = gameObject.transform.Find("RightObstacle").lossyScale.x;
      //  Debug.Log("szerokoœæ powinna wynosiæ 6:"+widthObjectLeft);
        //pozycja
        positionOfObjectLeft = gameObject.transform.Find("LeftObstacle").transform.position.x;
        positionOfObjectRight = gameObject.transform.Find("RightObstacle").transform.position.x;
        //pozycja obiektu
       // Debug.Log("pozycja powinna wynisiæ-3,5:"+positionOfObjectLeft);
        positionOfMainObject = transform.position.x;
        //teraz obliczy gdzie jest lewa i prawa krawêdŸ wolnej przestrzeni by umieœciæ obiekt na planszy i by wystawa³ choæ trochê
        //a po co mi to?
        //a no tak
        //do ustawienia pozycji przeszkody
        positionOfLeftEdgeFreeSpace = positionOfObjectLeft +  widthObjectLeft/2;
        positionOfRightEdgeFreeSpace = positionOfObjectRight - widthObjectRight/2;
        
        distanceBetweenEdgeAndCenter = Math.Abs(positionOfMainObject - positionOfLeftEdgeFreeSpace);
       // Debug.Log("dystans powinien wynosic chyba 0,5:"+distanceBetweenEdgeAndCenter);

        float leftEdgeX = leftEdge.position.x;
        float rightEdgeX = rightEdge.position.x;
        //
        float rand = Random.Range(leftEdgeX + distanceBetweenEdgeAndCenter, rightEdgeX - distanceBetweenEdgeAndCenter);
        position = new Vector3(rand, spawnPoint.position.y, 0);

        return position;

    }
    public override void SetPrzestrzen()
    {
        listaPrzestrzeni = new List<Przestrzen>();

        float positionX = position.x;
        float widthOfBox = gameObject.transform.lossyScale.x;
        float halfOfWidth = widthOfBox / 2;

        float leftEdgeOfLeftBox = positionOfObjectLeft - positionOfLeftEdgeFreeSpace;
        float rightEdgesOfLeftBox = positionOfObjectLeft + positionOfLeftEdgeFreeSpace;

        float leftEdgeOfRightBox = positionOfObjectRight - positionOfRightEdgeFreeSpace;
        float rightEdgesOfRightBox = positionOfObjectRight + positionOfRightEdgeFreeSpace;

      

        Przestrzen przestrzen = new Przestrzen(transform.position.x-0.5f, transform.position.x+0.5f, false);
        listaPrzestrzeni.Add(przestrzen);

        /*
        //ustawia przestrzeñ która informuje nas gdzie jest wolne miejsce na punkty
        Przestrzen przestrzen = new Przestrzen(leftEdgeOfLeftBox, rightEdgesOfLeftBox, true);
        listaPrzestrzeni.Add(przestrzen);

        przestrzen = new Przestrzen(rightEdgesOfLeftBox, leftEdgeOfRightBox, false);
        listaPrzestrzeni.Add(przestrzen);

        przestrzen = new Przestrzen(leftEdgeOfRightBox, rightEdgesOfRightBox, true);
        listaPrzestrzeni.Add(przestrzen);
        */

    }
}
