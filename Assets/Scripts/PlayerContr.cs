using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class PlayerContr : MonoBehaviour
{

    public GameObject[] points = new GameObject[2]; // 0 : right   1 : left
    public Animator animatorCharacter;
    public Animator animatorTruck;
    public int animationCondition = 0;  //  0 = idle animation  , 1 = start animation , 2 = turnLeft , 3  = turnRight  , 4 = driveToUp
    [HideInInspector] public bool animIsPlaying = false;
    [HideInInspector] public bool isDriving = true; // Is the player driving the car ?


    // Start is called before the first frame update
    void Awake()
    {

        button.SetActive(false);

    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        transform.Translate(Vector3.forward * Time.deltaTime * speed,Space.World);

        

        Swap();
        
    }

    public GameObject button;

    public float rotateSpeed;
    public float speed;

    public float maxSwipeTime;
    public float minSwipeLenght;

    public float swipeTime ;
    public float swipeLenght ;


    public float touchStartTime;
    public float touchEndTime;

    public Vector2 touchStartPos;
    public Vector2 touchEndPos;

    private void Swap()
    {
        if (Input.touchCount > 0)
        {


            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {


                //button.transform.position = touch.position;
                //button.SetActive(true);
                touchStartTime = Time.time;
                touchStartPos = touch.position;

            }
            else if (touch.phase == TouchPhase.Stationary)
            {

                button.transform.position = touch.position;

                button.SetActive(true);
                if (button.transform.localScale.magnitude < new Vector3(3, 3, 0).magnitude)
                {
                    Vector3 scaleChange = new Vector3(0.3f, 0.3f, 0);
                    button.transform.localScale += scaleChange;

                }
                else if (button.transform.localScale.magnitude >= new Vector3(3, 3, 0).magnitude)
                {
                    if(animationCondition == 4)
                    {
                        //animIsPlaying = true;
                       // isDriving = false;
                        animatorCharacter.SetInteger("Condition", 0);
                        animationCondition = 0;
                    }
                    else
                    {
                       // animIsPlaying = true;
                        //isDriving = true;
                        animatorCharacter.SetInteger("Condition", 4);
                        animationCondition = 4;
                    }
                   

                }



            }
            else if (touch.phase == TouchPhase.Ended)
            {


                button.transform.localScale = new Vector3(1, 1, 0);

                button.SetActive(false);




                touchEndPos = touch.position;
                touchEndTime = Time.time;

                swipeTime = touchEndTime - touchStartTime;
                swipeLenght = (touchEndPos - touchStartPos).magnitude;

                if (swipeLenght >= minSwipeLenght && swipeTime <= maxSwipeTime && isDriving == true)
                {
                    Move();
                    // print("Movda");
                }

            }
        }
        else
        {
            animatorCharacter.SetInteger("Condition", 1);
            animatorTruck.SetInteger("Condition", 1);
        }

    }



    private void Move()
    {
        Vector2 Distance = touchEndPos - touchStartPos;

        if(Mathf.Abs(Distance.x) >= Mathf.Abs(Distance.y) )
        {
            //print("x buyuk");

            if(Distance.x > 0)
            {
               // button.SetActive(false);
                //print("Towards");
                //Vector3 temp = new Vector3(points[1].transform.position.x, transform.position.y, transform.position.z);
                //transform.Translate(new Vector3(rotateSpeed * Time.deltaTime,0,0)  ,Space.World);
                //transform.LookAt(points[1].transform.position);
                animatorCharacter.SetInteger("Condition", 3);
                transform.position = Vector3.Lerp(transform.position, points[1].transform.position, Time.deltaTime * rotateSpeed);
                //transform.LookAt(Vector3.forward);
                //transform.position = Vector3.MoveTowards(transform.position, points[0].transform.position, Time.deltaTime * rotateSpeed);

            }
            else if(Distance.x <0)
            {
                //Vector3 temp = new Vector3(points[0].transform.position.x, transform.position.y, transform.position.z);
                //  print("Saga");
                // transform.Translate(new Vector3(-rotateSpeed * Time.deltaTime, 0, 0)  ,Space.World);

                //transform.LookAt(points[0].transform.position);
               // button.SetActive(false);

                animatorCharacter.SetInteger("Condition", 2);
                animatorTruck.SetInteger("Condition", 2);
                transform.position = Vector3.Lerp(transform.position, points[0].transform.position, Time.deltaTime * rotateSpeed);
                //transform.LookAt(Vector3.forward);
            }
           



        }
        else if(Mathf.Abs(Distance.x) < Mathf.Abs(Distance.y) )
        {
           // print("y buyuk");
            if (Distance.y > 0)
            {
                //Yukarı Gidecek
            }
            else if (Distance.x < 0)
            {
                // Aşağı gidecek.
            }

        }
    }


}
