using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour {

    public int EnemyCoins;
    public int EnemyHpBottle = 1;

    Animator animator;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
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

        }
    }
}
