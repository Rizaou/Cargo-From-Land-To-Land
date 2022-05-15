using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{


    public bool startGame = false;
    public GameObject truck;
    public Animator animatorCharacter;
    public Animator animatorTruck;
    public GameObject playButton;
   
    public int animationCondition = 0;  //  0 = idle animation  , 1 = start animation;



    // Start is called before the first frame update
    void Awake()
    {
        truck = GameObject.FindGameObjectWithTag("Player");
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void StartGame()
    {
        startGame = true;
        playButton.SetActive(false);
        animatorCharacter.SetInteger("Condition", 1);
        animatorTruck.SetInteger("Condition", 1);
        
        Debug.Log("Game started");
    }



    
}
