using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcGateDialogsChanger: MonoBehaviour {
    public bool EndDialogs1;
    public bool EndDialogs2;
    public GameObject Dialog1;
    public GameObject Dialog2;
    public bool Dialog1isUse = false;
    public bool Dialog2isUse = false;
    public EnemyAI enemiai;

    // Use this for initialization
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player" && Dialog1isUse == false)
        {
            Dialog1.SetActive(true);
            Dialog1isUse = true;
        }

        else if (col.tag == "Player" && Dialog1isUse == true && Dialog2isUse == false && enemiai.QuestKillGoblins == true)
        {
            Dialog2isUse = true;
            Dialog2.SetActive(true);
        }
    }
}
