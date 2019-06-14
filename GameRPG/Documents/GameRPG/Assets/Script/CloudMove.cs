using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMove : MonoBehaviour {

    public float speed;
    private float waitTime;
    private float currentDistance;
    public float startWaitTime;
    public float stopDistanse;
    private float rotationSpeed = 8f;

    public Transform[] moveSpots;
    private int randomSpot;
    Animator animator;
    Vector3 heading;


    // Use this for initialization
    void Start()
    {
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        currentDistance = Vector3.Distance(transform.position, moveSpots[randomSpot].position);

        if (currentDistance >= stopDistanse)
        {
            heading = (transform.position - moveSpots[randomSpot].position).normalized;
            heading.y = 0;            

            transform.position = Vector3.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);
        }



        if (currentDistance < stopDistanse)
        {
            if (waitTime <= 0)
            {               
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
            }
            else
            {                
                waitTime -= Time.deltaTime;
            }
        }
    }
}
