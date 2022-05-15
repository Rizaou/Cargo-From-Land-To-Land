using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForAnimations : MonoBehaviour
{

    public GameObject truck;
    public GameObject camera;
    public PlayerContr playerContr;


    public void Awake()
    {
        playerContr = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContr>();
        truck = GameObject.FindGameObjectWithTag("Player");
        camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    public void TruckStartCheck()
    {

        truck.GetComponent<PlayerContr>().enabled = true;
        camera.GetComponent<CameraScript>().enabled = true;
    }

    public void DriveToUp()
    {
        playerContr.isDriving = false;
    }


    public void UpToDrive()
    {
        playerContr.isDriving = true;
    }

}
