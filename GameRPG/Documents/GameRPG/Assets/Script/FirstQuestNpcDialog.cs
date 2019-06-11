using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstQuestNpcDialog : MonoBehaviour {

    public bool EndDialogs1;
    public bool EndDialogs2;
    public GameObject Dialog1;
    public GameObject Dialog2;
    public bool Dialog1isUse = false;
    public bool Dialog2isUse = false;
    public EnemyAI enemiai;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if ( EndDialogs1 == true && (EndDialogs2 == true||  Dialog2isUse == false))
        {
            Time.timeScale = 1;
            Dialog1.SetActive(false);
            Dialog2.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if ( col.tag == "Player" && Dialog1isUse == false)
        {
            Time.timeScale = 0;
            Dialog1.SetActive(true);
            Dialog1isUse = true;
        }

        else if ( col.tag == "Player" && Dialog1isUse == true && enemiai.QuestKillGoblinsInForrest == true)
        {
            Time.timeScale = 0;
            Dialog2.SetActive(true);
            Dialog2isUse = true;
        }
    }

}
