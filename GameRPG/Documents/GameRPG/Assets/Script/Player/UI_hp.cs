using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_hp : MonoBehaviour {

    static public int hp;

    [SerializeField]
    public Text player_HP; //в данную ссылку будем переносить текстовую информацию о монетах


    void Start()
    {
        hp = 1;
    }
}
