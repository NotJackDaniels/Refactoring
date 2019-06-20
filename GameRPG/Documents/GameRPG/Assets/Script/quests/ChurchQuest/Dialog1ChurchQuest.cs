using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog1ChurchQuest : MonoBehaviour {

    public GameObject Text;
    public GameObject Text1;

    public short isTextNumber;
    public ChurchQuestNpcDialog churchQuestNpcDialog;

    // Use this for initialization
    void Start()
    {
        if (churchQuestNpcDialog.Dialog1 == true)
        {
            isTextNumber = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isTextNumber++;
        }

        switch (isTextNumber)
        {
            case 0:
                Text.SetActive(true);
                break;
            case 1:
                Text1.SetActive(true);
                Text.SetActive(false);
                break;
            default:
                Text1.SetActive(false);
                churchQuestNpcDialog.EndDialogs1 = true;
                Time.timeScale = 1;
                churchQuestNpcDialog.Dialog1.SetActive(false);
                break;
        }
    }
}
