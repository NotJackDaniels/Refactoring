using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour {

    public int EnemyCoins;

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

            money_player.money += EnemyCoins; // добавляем монеты в указанную ссылку
            GameObject.FindGameObjectWithTag("Player").GetComponent<money_player>().TextMoney.text = money_player.money.ToString(); // вывод количеста монет на экран
            EnemyCoins = 0;
        }
    }
}
