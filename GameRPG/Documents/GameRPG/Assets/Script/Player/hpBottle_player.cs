using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpBottle_player : MonoBehaviour {

    static public int hp;

    [SerializeField]
    public Text TextHP; //в данную ссылку будем переносить текстовую информацию о монетах


    void Start()
    {
        hp = 0;
    }
}
