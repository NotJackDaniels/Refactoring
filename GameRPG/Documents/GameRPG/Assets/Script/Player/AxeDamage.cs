using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeDamage : MonoBehaviour {

    static public int damage = 3;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "MonsterAI")
        {
            col.GetComponent<EnemyAI>().healthMonster -= damage;
        }

        if (col.tag == "MonsterPatrulAI")
        {
            col.GetComponent<GoblinPatrulAndAgro_AI>().healthMonster -= damage;
        }
    }
}
