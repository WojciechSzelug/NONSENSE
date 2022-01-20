using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
    public abstract class AbstractSetPosition : MonoBehaviour
    {
        public Transform leftEdge;
        public Transform rightEdge;
        public Transform spawnPoint;
        public Transform distanceSpawn;

        public Vector3 position;

        //zmienna przechowująca obszar zajęty przez abstract
        //zmienna przechowująca obszar wolny
        //musi to być pewnie lista tablic[3] gdzie zapisany jest przedział wolnej przestrzeni i zajętej przestrzeni
        //ostatni index tablicy mówiłby nam czy obszar jest zajęty czy nie
        //tablica jednak będzie klasą mającą trzy zmienne: początek, koniec, stan

        public List<Przestrzen> listaPrzestrzeni;


        public void OnStart()
        {
            PositionsOfObjects positions = GameObject.Find("GameManager").GetComponent<PositionsOfObjects>();
            leftEdge = positions.leftWall;
            rightEdge = positions.rightWall;
            spawnPoint = positions.spawnPoint;
            distanceSpawn = positions.distanceSpawn;

            listaPrzestrzeni = new List<Przestrzen>();

        }

        public abstract Vector3 SetPositions();

        public abstract void SetPrzestrzen();
    }
}
