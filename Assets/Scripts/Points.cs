using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{

    private GameObject player;
    public bool right;
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target;

        if(right)
        {
             target = new Vector3(player.transform.position.x + 10, transform.position.y, player.transform.position.z );
        }
        else
             target = new Vector3(player.transform.position.x - 10, transform.position.y, player.transform.position.z );

        transform.position = target;
        
    }
}
