using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog2_manual : MonoBehaviour {


    public GameObject Text;    

    public short isTextNumber;
    public NpcGateDialogsChanger npcgatedialogschanger;

    // Use this for initialization
    void Start()
    {
        if (npcgatedialogschanger.Dialog2 == true)
        {
            isTextNumber = 0;
        }
        npcgatedialogschanger.EndDialogs2 = false;
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
                npcgatedialogschanger.EndDialogs2 = true;
                npcgatedialogschanger.Dialog2.SetActive(false);
                break;
        }        
    }
}
