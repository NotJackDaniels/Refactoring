﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog_1NextClick : MonoBehaviour {

    public GameObject Text;
    public GameObject Text1;
    public GameObject Text2;
    public GameObject Text3;
    public GameObject Text4;
    public GameObject Text5;
    public GameObject Text6;

    public short isTextNumber;
    public FirstQuestNpcDialog firstQuestNpcDialog;

	// Use this for initialization
	void Start () {
		if (firstQuestNpcDialog.Dialog1 == true)
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
                case 2:
                    Text2.SetActive(true);
                    Text1.SetActive(false);
                    break;
                case 3:
                    Text3.SetActive(true);
                    Text2.SetActive(false);
                    break;
                case 4:
                    Text4.SetActive(true);
                    Text3.SetActive(false);
                    break;
                case 5:
                    Text5.SetActive(true);
                    Text4.SetActive(false);
                    break;
                case 6:
                    Text6.SetActive(true);
                    Text5.SetActive(false);
                    break;
                default:
                    Text6.SetActive(false);
                    firstQuestNpcDialog.EndDialogs1 = true;
                    Time.timeScale = 1;
                    firstQuestNpcDialog.Dialog1.SetActive(false);
                break;    
        }
    }
}
