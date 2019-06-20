using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoblinPatrulAndAgro_AI : MonoBehaviour {

    public int EnemyCoins = 20;
    public int EXP = 20;

    
    public float seeDistance = 5f;
    public float triggerDistance = 5f;
    private float currentTriggerDistance;
    public float attackDistance = 1f;
    private float currentDistance;
    private float currentDistanceFromStart;
    public float rotationSpeed = 8f;
    private Transform target;
    private Transform targetStart;
    public int healthMonster;
    Animator animator;
    Vector3 heading;
    NavMeshAgent agent;
    CapsuleCollider capsuleCollider;

    private float RandomMoney;

    public float speed;
    private float waitTime;    
    public float startWaitTime;
    public float stopDistanse;    

    public Transform[] moveSpots;
    private int k = 0; // обход по порядку
    private bool startWay = false; // для обхода маршрута  

    private int chouse = 1; 
    // Use this for initialization
    void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider>();
        target = GameObject.FindWithTag("Player").transform;
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.isStopped = true;
        currentTriggerDistance = triggerDistance;

        waitTime = startWaitTime;
        animator = GetComponent<Animator>();
        animator.SetBool("PrepareForBattle", true);
        animator.SetBool("Run", true);

        // для рандомности денег у противника
        RandomMoney = Random.Range(EnemyCoins * -0.5f, EnemyCoins * 0.5f);
        EnemyCoins += (int)RandomMoney;
    }

    // Update is called once per frame
    void Update()
    {   

        if(chouse == 1)
        {
            currentDistanceFromStart = Vector3.Distance(transform.position, moveSpots[k].position);
            targetStart = moveSpots[k].transform;

            if (currentDistanceFromStart >= stopDistanse)
            {
                heading = (transform.position - moveSpots[k].position).normalized;
                heading.y = 0;
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(-heading), rotationSpeed);

                transform.position = Vector3.MoveTowards(transform.position, moveSpots[k].position, speed * Time.deltaTime);
            }



            if (currentDistanceFromStart < stopDistanse)
            {
                if (waitTime <= 0)
                {
                    animator.SetBool("PrepareForBattle", true);
                    animator.SetBool("Run", true);

                    if (k < moveSpots.Length - 1 && startWay == false)
                    {
                        k++;
                        if (k == moveSpots.Length - 1)
                        {
                            startWay = true;
                        }
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
                    animator.SetBool("PrepareForBattle", false);
                    animator.SetBool("Run", false);
                    waitTime -= Time.deltaTime;
                }
            }

            // проверка на близость игрока
            currentDistance = Vector3.Distance(transform.position, target.position);

            if (currentDistance < seeDistance)
            {
                chouse = 0;
            }
        }
        else
        {
            if (healthMonster > 0)
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
                animator.SetBool("PrepareForBattle", false);
                animator.SetBool("Attack", false);
                animator.SetBool("Run", false);
                animator.SetBool("Die", true);
                capsuleCollider.enabled = false;                

                // добавляем монеты в указанную ссылку
                money_player.money += EnemyCoins;
                GameObject.FindGameObjectWithTag("Player").GetComponent<money_player>().TextMoney.text = money_player.money.ToString(); // вывод количеста монет на экран
                EnemyCoins = 0;

                GameObject.FindGameObjectWithTag("Player").GetComponent<playerstat>().curEXP += EXP;
                EXP = 0;
            }
        }    
      
    }

}
