using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lvl_player : MonoBehaviour {

    static public int lvl;

    [SerializeField]
    public Text player_LVL; //в данную ссылку будем переносить текстовую информацию о монетах


    void Start()
    {
        lvl = 1;
    }
}
