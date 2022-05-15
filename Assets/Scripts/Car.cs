using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Car : MonoBehaviour
{

    public float dist = 5f; // Calculates between start point and car's position.
    public GameObject player;
    public float speed; public float pSpeed;
    public Transform spawnPoint = null;
    public int spawnPointID;
    public GameIntelligence GI = new GameIntelligence();
    public float followDistance = 50f;
    private Rigidbody rigidbody;

    // Start is called before the first frame update
    void Awake()
    {
        pSpeed = speed;
        Debug.LogWarning("Speed " + pSpeed);
        rigidbody = GetComponent<Rigidbody>();
        GI = GameObject.FindGameObjectWithTag("GameAI").GetComponent<GameIntelligence>();
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {



      /*  if(Vector3.Distance(spawnPoint.position,transform.position) >= dist)
        {
            GI.ignoreSPoint = -1;
            GI.canSpawn = true;


        }
      */

        RaycastHit hit;
        /* if(spawnPoint)
         {
             if (Vector3.Distance(spawnPoint.position, transform.position) > dist)
             {
                 print(Vector3.Distance(spawnPoint.position, transform.position));
                 //GI.canSpawn = true;
             }
         }*/

        if (player.transform.position.z > transform.position.z + 100)
            Destroy(gameObject);
        
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        if (Physics.Raycast(transform.position, Vector3.forward, out hit, followDistance))
        {
            //Debug.LogWarning("Raycast worked");
            Debug.DrawRay(transform.position, Vector3.forward * followDistance, Color.red);
            if(hit.collider.tag == "Car")
            {
                

               // Debug.Log("Collided with car");
                //speed = hit.collider.gameObject.GetComponent<Car>().speed;
                speed = hit.collider.gameObject.GetComponentInParent<Car>().speed;

            }


        }
       /* else
        {
            speed = pSpeed;
        }
       */


    }
}
