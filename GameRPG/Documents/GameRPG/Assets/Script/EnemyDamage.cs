using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damage = 3;
    public GameObject damageCapsule;
    private float currentTime = 0;
    public float timeOfEachAttack = 1f;
    Animator animator;


    void Start()
    {
        animator = GetComponent<Animator>();
    }

	void Update ()
    {
        damageCapsule.SetActive(false);
        if (animator.GetBool("Attack"))
        {
            if (currentTime < timeOfEachAttack)
            {
                currentTime += Time.deltaTime;
            }
            else
            {
                currentTime = 0;
                damageCapsule.SetActive(true);
            }
        }
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            collider.GetComponent<playerstat>().curHP -= damage;
        }
    }
}
