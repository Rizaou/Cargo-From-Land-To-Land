using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameIntelligence : MonoBehaviour
{

    public GameObject player;
    
    public GameObject road;
   

    private GameObject lastRoad;

    public int maxRoad = 10;
    public float distance = 100f; // The distance of the road from the car.
    public float x;
    public float y;
    public float z;

    //For creating traffic.
    private GameObject spawnPoint;
    public GameObject[] spawnPoints = new GameObject[4];
    public GameObject[] cars;
    public float carSpeed;
    public float distanceBS = 25f; // Calculates distance between start point and car position.
    public bool canSpawn = true; 
    public  bool[] isSpawned = new bool[4] { false,false,false,false };
    public int pointRandom;
    public int ignoreSPoint = -1;

    private void Awake()
    {

        spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint");
        spawnPoint.transform.position = new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y, player.transform.position.z + 1200);

    }

    // Start is called before the first frame update
    void Start()
    {
        CreateRoadsStart();
        CreateCarsStart();
        
        
       // Instantiate(road, target, transform.rotation);
        //35 +35

    }

    // Update is called once per frame
    void Update()
    {

        CreateRoadsUpdate();
        CreateCarsUpdate2();
      //  CreateCarsUpdate1();
        
        
        
            
    }





    void CreateRoadsUpdate()
    {


        float distance = Vector3.Distance(lastRoad.transform.position, player.transform.position);

        if (distance <= this.distance)
        {
           // print("Yol olusturulmaliii!!!!");
            GameObject lRoad = road;
            Vector3 target = new Vector3(x, y, z);
            Vector3 nowTarget = lastRoad.transform.position;

            for (int i = 1; i <= maxRoad; i++)
            {

                lRoad = Instantiate(lRoad, nowTarget + target, road.transform.rotation);

                nowTarget = lRoad.transform.position;


            }

            lastRoad = lRoad;
        }


    }


    void CreateRoadsStart()
    {
        GameObject lRoad = road;
        Vector3 target = new Vector3(x, y, z);
        Vector3 nowTarget = road.transform.position;

        for (int i = 1; i <= maxRoad; i++)
        {

            lRoad = Instantiate(lRoad, nowTarget + target, road.transform.rotation);

            nowTarget = lRoad.transform.position;


        }

        lastRoad = lRoad;

    }




    void CreateCarsUpdate1()
    {

        spawnPoint.transform.position = new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y, player.transform.position.z + 1200);

        GameObject car;

        //int spawnSamePoint = UnityEngine.Random.Range(0, 2); // 1 true  0 false

       // int[] forRandom = { 0, 0, 0, 0 };

        int pointRandom2 = UnityEngine.Random.Range(0, 4);
       // int pointRandom3 = UnityEngine.Random.Range(0, 4);
        
        pointRandom = UnityEngine.Random.Range(0, 4);

        while(pointRandom2 == pointRandom)
        {
            pointRandom2 = UnityEngine.Random.Range(0, 4);
        }

        
        if(canSpawn)
        {
            int carPos = UnityEngine.Random.Range(0, cars.Length);
            int carPos2 = UnityEngine.Random.Range(0, cars.Length);
           // print("Spawnlanmalı");
            car = Instantiate(cars[carPos], spawnPoints[pointRandom].transform.position, spawnPoints[pointRandom].transform.rotation);
           // car.GetComponent<Car>().spawnPoint = spawnPoints[pointRandom].transform; 
            Instantiate(cars[carPos2], spawnPoints[pointRandom2].transform.position, spawnPoints[pointRandom2].transform.rotation);

            canSpawn = false;

            float wait = UnityEngine.Random.Range(0.8f, 1.3f);
            
            StartCoroutine(Wait(wait));

            //isSpawned[pointRandom] = true;
            

        }

        /*if(spawnSamePoint == 0)
        {
            Instantiate(cars[0], spawnPoints[pointRandom].transform.position, spawnPoints[pointRandom].transform.rotation);
            isSpawned[pointRandom] = true;
        }
        else
        {

            foreach (bool x in isSpawned)
            {
                if(x == true)
                {
                    Instantiate(cars[0], spawnPoints[pointRandom].transform.position, spawnPoints[pointRandom].transform.rotation);

                }
            }

        }
        */
       



    }


    void CreateCarsUpdate2()
    {
        spawnPoint.transform.position = new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y, player.transform.position.z + 1200);
        GameObject car;
        int carPos = UnityEngine.Random.Range(0, cars.Length);
        pointRandom = UnityEngine.Random.Range(0, 4);

        if(canSpawn)
        {
            car = Instantiate(cars[carPos], spawnPoints[pointRandom].transform.position, spawnPoints[pointRandom].transform.rotation);
            car.GetComponent<Car>().spawnPoint = spawnPoints[pointRandom].transform;
            canSpawn = false;
            StartCoroutine(Wait(CalculateTime(car)));
            

        }

           
       



    }

    float CalculateTime(GameObject car)
    {
        float speed = car.GetComponent<Car>().speed;
        float distance = car.GetComponent<Car>().dist;

        Debug.Log("Time: " + distance / speed);

        return distance/speed;
    }


    void CreateCarsStart()
    {
        /* int pointRandom = UnityEngine.Random.Range(0, 4);
         GameObject car;

        car = Instantiate(cars[0], spawnPoints[pointRandom].transform.position, spawnPoints[pointRandom].transform.rotation);

         car.GetComponent<Car>().spawnPoint = spawnPoints[pointRandom].transform;


        
        */

       
    }




    private IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
        canSpawn = true;
    }

   


}
