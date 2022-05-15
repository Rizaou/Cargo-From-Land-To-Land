using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScript : MonoBehaviour
{
    public bool road = false;
    public float time = 5f;
    public float distance = 100f;
    public GameObject player;

    // Start is called before the first frame update
    void Awake()
    {

        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(!road)
        {
            if (transform.position.z < player.transform.position.z + distance)
                Destroy(gameObject);
        }
        else
        {
            if (transform.position.z == player.transform.position.z)
                gameObject.SetActive(false);
            
        }
        



    }
}
