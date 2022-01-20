using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets;

public class SetPositionsBox : AbstractSetPosition
{

    void Start()
    {
        
    }
   public override Vector3 SetPositions()
    {
        OnStart();
        position = new Vector3(); 
        float widthObject = gameObject.transform.lossyScale.x;

    
        float leftEdgeX = leftEdge.position.x;
      
        float rightEdgeX = rightEdge.position.x;
        float rand = Random.Range(leftEdgeX + (widthObject / 2), rightEdgeX - (widthObject / 2));
        position = new Vector3(rand, spawnPoint.position.y, 0);

        return position;

}
    public override void SetPrzestrzen()
    {
        float positionX = position.x;
        float widthOfBox = gameObject.transform.lossyScale.x;
        float halfOfWidth = widthOfBox / 2;

        float leftEdgeOfBox = positionX - halfOfWidth;
        float rightEdgesOfBox = positionX + halfOfWidth;

        //ustawia przestrzeñ która informuje nas gdzie jest wolne miejsce na punkty
        Przestrzen przestrzen = new Przestrzen(leftEdge.position.x, leftEdgeOfBox, false);
        listaPrzestrzeni.Add(przestrzen);
       
        przestrzen = new Przestrzen(leftEdgeOfBox, rightEdgesOfBox, true);
        listaPrzestrzeni.Add(przestrzen);
        
        przestrzen = new Przestrzen(rightEdgesOfBox, rightEdge.position.x, false);
        listaPrzestrzeni.Add(przestrzen);
        

    }


}
