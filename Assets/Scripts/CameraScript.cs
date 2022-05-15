using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform player;
    public float followSpeed;
    public float rotationSpeed;

    public float distanceX;
    public float distanceY;
    public float distanceZ;
    public float rotateX;
    public float rotateY;
    public float rotateZ;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RotateQSpeed());
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotationTarget = new Vector3(player.position.x + rotateX, player.position.y + rotateY, player.position.z + rotateZ);

        Quaternion lookTarget = Quaternion.LookRotation(rotationTarget - transform.position);
       

        Vector3 distanceTarget = new Vector3(player.position.x + this.distanceX, player.position.y + this.distanceY, player.position.z + this.distanceZ);

        transform.rotation = Quaternion.RotateTowards(transform.rotation,lookTarget,Time.deltaTime* rotationSpeed);


        transform.position = Vector3.Lerp(transform.position, distanceTarget, Time.deltaTime * followSpeed);
        
    }

    IEnumerator RotateQSpeed()
    {
        yield return new WaitForSeconds(5);
        rotationSpeed = followSpeed;
    }
}
