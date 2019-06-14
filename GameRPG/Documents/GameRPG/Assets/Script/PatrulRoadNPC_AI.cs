using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrulRoadNPC_AI : MonoBehaviour {
    public float speed;
    private float waitTime;
    private float currentDistance;
    public float startWaitTime;
    public float stopDistanse;
    private float rotationSpeed = 8f;

    public Transform[] moveSpots;
    private int k = 0; // обход по порядку
    private bool startWay = false; // для обхода маршрута

    Animator animator;
    Vector3 heading;


    // Use this for initialization
    void Start()
    {       
        waitTime = startWaitTime;
        animator = GetComponent<Animator>();
        animator.SetBool("Walk", true);
    }

    // Update is called once per frame
    void Update()
    {
        
        currentDistance = Vector3.Distance(transform.position, moveSpots[k].position);

        if (currentDistance >= stopDistanse)
        {
            heading = (transform.position - moveSpots[k].position).normalized;
            heading.y = 0;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(-heading), rotationSpeed);

            transform.position = Vector3.MoveTowards(transform.position, moveSpots[k].position, speed * Time.deltaTime);
        }



        if (currentDistance < stopDistanse)
        {
            if (waitTime <= 0)
            {
                animator.SetBool("Walk", true);
                if (k < moveSpots.Length - 1 && startWay == false)
                {
                    k++;
                    if (k == moveSpots.Length - 1) startWay = true;
                }                    
                else
                {
                    k--;
                    if (k == 0) startWay = false;
                }                    

                waitTime = startWaitTime;
            }
            else
            {                
                animator.SetBool("Walk", false);
                waitTime -= Time.deltaTime;
            }
        }
    }
}
