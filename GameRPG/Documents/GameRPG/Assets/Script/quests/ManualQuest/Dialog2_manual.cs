using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog2_manual : MonoBehaviour {


    public GameObject Text;    

    public short isTextNumber;
    public FirstQuestNpcDialog firstQuestNpcDialog;

    // Use this for initialization
    void Start()
    {
        if (firstQuestNpcDialog.Dialog2 == true)
        {
            isTextNumber = 0;
        }
        firstQuestNpcDialog.EndDialogs2 = false;
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
           
            default:
                Text.SetActive(false);                
                firstQuestNpcDialog.EndDialogs2 = true;
                break;
        }        
    }
}
