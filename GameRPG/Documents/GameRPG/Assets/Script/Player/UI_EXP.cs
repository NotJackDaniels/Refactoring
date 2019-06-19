using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_EXP : MonoBehaviour
{

    static public int exp;

    [SerializeField]
    public Text player_exp; //в данную ссылку будем переносить текстовую информацию о монетах


    void Start()
    {
        exp = 1;

    }
}
