using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    public float seeDistance = 5f;
    public float attackDistance = 5f;
    public float speed;
    private Transform target;
    public int healthMonster;
    Animator animator;


    void Start()
    {
        animator = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
    }


    void Update()
    {
        if (Vector3.Distance(transform.position, target.transform.position) < seeDistance)
        {
            transform.LookAt(target.transform);
            if (Vector3.Distance(transform.position, target.transform.position) < attackDistance)
            {
                animator.SetBool("Walk", true);
                transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
            }
            else
            {
                animator.SetBool("Walk", false);
            }
        }
        else
        {
            animator.SetBool("Walk", false);
        }
    }
}
