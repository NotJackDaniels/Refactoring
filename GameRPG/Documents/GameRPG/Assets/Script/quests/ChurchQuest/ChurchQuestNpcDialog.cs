using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChurchQuestNpcDialog : MonoBehaviour {

    public bool EndDialogs1;
    public bool EndDialogs2;
    public GameObject Dialog1;
    public GameObject Dialog2;
    public bool Dialog1isUse = false;
    public bool Dialog2isUse = false;
    public EnemyAI enemiai;
    public EnemyAI enemiai1;
    public EnemyAI enemiai2;
    public EnemyAI enemiai3;
    private bool GoblinsDead = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!GoblinsDead)
        {
            if (enemiai.QuestKillGoblins && enemiai1.QuestKillGoblins &&
                enemiai2.QuestKillGoblins && enemiai3.QuestKillGoblins)
            {
                GoblinsDead = true;
            }
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player" && !Dialog1isUse)
        {
            Time.timeScale = 0;
            Dialog1.SetActive(true);
            Dialog1isUse = true;
        }

        else if (col.tag == "Player" && Dialog1isUse && !Dialog2isUse && GoblinsDead)
        {
            Dialog2isUse = true;
            Dialog2.SetActive(true);
        }
    }
}
