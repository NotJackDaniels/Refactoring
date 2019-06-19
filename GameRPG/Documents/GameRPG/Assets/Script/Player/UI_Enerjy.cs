using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Enerjy : MonoBehaviour {

    static public int enerjy;

    [SerializeField]
    public Text player_enerjy; //в данную ссылку будем переносить текстовую информацию о монетах


    void Start()
    {
        enerjy = 1;
    }
}
