using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    public float seeDistance = 5f;
    public float triggerDistance = 5f;
    public float attackDistance = 1f;
    private float currentDistance;
    public float speed = 1f, rotationSpeed = 1f;
    private Transform target;
    public int healthMonster;
    Animator animator;
    Vector3 heading;


    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        currentDistance = Vector3.Distance(transform.position, target.position);
        if (currentDistance < seeDistance)
        {
            heading = (transform.position - target.position).normalized;
            heading.y = 0;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(-heading), rotationSpeed);
            if (currentDistance < triggerDistance && currentDistance > attackDistance)
            {
                animator.SetBool("Attack", false);
                animator.SetBool("Run", true);
                transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
            }
            else
            {
                animator.SetBool("Run", false);
                if (currentDistance <= attackDistance)
                {
                    animator.SetBool("Attack", true);
                }
            }
        }
        else
        {
            animator.SetBool("Run", false);
        }
    }
}
