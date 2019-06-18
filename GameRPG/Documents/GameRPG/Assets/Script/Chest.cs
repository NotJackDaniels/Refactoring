using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour {

    public int EnemyCoins;
    public int EnemyHpBottle = 1;
    public int EXP = 40;

    Animator animator;

    private float RandomMoney;
    private float RandomHpBottle;
    private float RandomEXP;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();

        // для рандомности денег в сундуке
        RandomMoney = Random.Range(EnemyCoins * -0.5f, EnemyCoins * 0.5f);        
        EnemyCoins += (int)RandomMoney;

        // для рандомности хилок в сундуках
        RandomHpBottle = Random.Range(EnemyHpBottle * -0.5f, EnemyHpBottle * 0.5f);        
        EnemyHpBottle += (int)RandomHpBottle;

        // для рандомности опыта в сундуках
        RandomEXP = Random.Range(EXP * -0.5f, EXP * 0.5f);
        EXP += (int)RandomEXP;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            animator.SetBool("openChest", true);

            // добавляем монеты в указанную ссылку
            money_player.money += EnemyCoins; 
            GameObject.FindGameObjectWithTag("Player").GetComponent<money_player>().TextMoney.text = money_player.money.ToString(); // вывод количеста монет на экран
            EnemyCoins = 0;

            // добавляем аптечки в указанную ссылку
            hpBottle_player.hp += EnemyHpBottle;
            GameObject.FindGameObjectWithTag("Player").GetComponent<hpBottle_player>().TextHP.text = hpBottle_player.hp.ToString();
            EnemyHpBottle = 0;

            // добавляем опыт игроку
            GameObject.FindGameObjectWithTag("Player").GetComponent<playerstat>().curEXP += EXP;
            EXP = 0;

        }
    }
}
