using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public int EnemyCoins = 20;
    public int EXP = 20;

    public GameObject pointStart;
    public bool QuestKillGoblinsInForrest = false;
    public float seeDistance = 5f;
    public float triggerDistance = 5f;
    private float currentTriggerDistance;
    public float attackDistance = 1f;
    private float currentDistance;
    private float currentDistanceFromStart;
    public float rotationSpeed = 1f;
    private Transform target;
    private Transform targetStart;
    public int healthMonster;
    Animator animator;
    Vector3 heading;
    NavMeshAgent agent;
    CapsuleCollider capsuleCollider;

    private float RandomMoney;

    void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider>();
        target = GameObject.FindWithTag("Player").transform;
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.isStopped = true;
        currentTriggerDistance = triggerDistance;

        // запоминаем начальное положение        
        targetStart = pointStart.transform;

        // для рандомности денег у противника
        RandomMoney = Random.Range(EnemyCoins * -0.5f, EnemyCoins * 0.5f);
        EnemyCoins += (int)RandomMoney;
    }


    void Update()
    {
        if (healthMonster > 0)
        {
            target = GameObject.FindWithTag("Player").transform;
            currentDistance = Vector3.Distance(transform.position, target.position);

            // Enemy возвращается в начальную позицию, если от него убежать далеко
            if (currentDistance >= seeDistance)
            {
                currentDistanceFromStart = Vector3.Distance(transform.position, targetStart.position);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(-heading), rotationSpeed);

                if (currentDistanceFromStart <= 3) animator.SetBool("Run", false);
                if (currentDistanceFromStart > 3)
                {
                    agent.SetDestination(targetStart.position);

                    heading = (transform.position - targetStart.position).normalized;
                    heading.y = 0;
                }


            }
            else
            {
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


        }
        else
        {
            animator.SetBool("Attack", false);
            animator.SetBool("Run", false);
            animator.SetBool("Die", true);
            capsuleCollider.enabled = false;

            QuestKillGoblinsInForrest = true;
            //GameObject.FindGameObjectWithTag("firstQuest").GetComponent<FirstQuestNpcDialog>().Dialog1isUse = true;

            // добавляем монеты в указанную ссылку
            money_player.money += EnemyCoins;
            GameObject.FindGameObjectWithTag("Player").GetComponent<money_player>().TextMoney.text = money_player.money.ToString(); // вывод количеста монет на экран
            EnemyCoins = 0;

            GameObject.FindGameObjectWithTag("Player").GetComponent<playerstat>().curEXP += EXP;
            EXP = 0;
        }
    }
}