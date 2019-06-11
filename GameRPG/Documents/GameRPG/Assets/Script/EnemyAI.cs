using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    public float seeDistance = 5f;
    public float triggerDistance = 5f;
    private float currentTriggerDistance;
    public float attackDistance = 1f;
    private float currentDistance;
    public float rotationSpeed = 1f;
    private Transform target;
    public int healthMonster;
    Animator animator;
    Vector3 heading;
    NavMeshAgent agent;
    CapsuleCollider capsuleCollider;


    void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider>();
        target = GameObject.FindWithTag("Player").transform;
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.isStopped = true;
        currentTriggerDistance = triggerDistance;
    }


    void Update()
    {
        if(healthMonster > 0)
        { 
            currentDistance = Vector3.Distance(transform.position, target.position);

            agent.SetDestination(target.position);

            heading = (transform.position - target.position).normalized;
            heading.y = 0;

            if (currentDistance <= attackDistance) //зона атаки (вплотную к игроку)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(-heading), rotationSpeed);
                animator.SetBool("Run", false);
                animator.SetBool("Attack", true);
            }
            else
            {
                animator.SetBool("Attack", false);
                if (currentDistance <= currentTriggerDistance) //зона триггера (бежит к игроку)
                {
                    currentTriggerDistance = seeDistance;
                    animator.SetBool("Run", true);
                    agent.isStopped = false; //враг начинает бежать
                }
                else
                {
                    agent.isStopped = true; //останавливает врага
                    animator.SetBool("Run", false);
                    if (currentDistance <= seeDistance) //зона видимости (поворачивается к игроку)
                    {
                        animator.SetBool("PrepareForBattle", true);
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(-heading), rotationSpeed);
                    }
                    else //за пределами зоны видимости
                    {
                        animator.SetBool("PrepareForBattle", false);
                        currentTriggerDistance = triggerDistance;
                    }
                }
            }

        }
        else
        {
            animator.SetBool("Attack", false);
            animator.SetBool("Run", false);
            animator.SetBool("Die", true);
            capsuleCollider.enabled = false;
        }
    }
}
