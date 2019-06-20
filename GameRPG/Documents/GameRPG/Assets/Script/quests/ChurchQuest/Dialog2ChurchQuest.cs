using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog2ChurchQuest : MonoBehaviour {

    public GameObject Text;

    public short isTextNumber;
    public ChurchQuestNpcDialog churchQuestNpcDialog;

    // Use this for initialization
    void Start()
    {
        Text.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Text.SetActive(false);
            churchQuestNpcDialog.EndDialogs2 = true;
            churchQuestNpcDialog.Dialog2.SetActive(false);
        }   
    }        
}
