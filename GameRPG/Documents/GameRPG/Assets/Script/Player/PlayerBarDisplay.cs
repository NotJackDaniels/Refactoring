using UnityEngine;
using System.Collections;

public class PlayerBarDisplay : MonoBehaviour
{
    public GUISkin mySkin; // Скин где хранятся текстуры баров, В инспекторе назначить наш новый созданный скин 
    public playerstat Char; // Объект на котором висят статы 
    public bool Visible = true; //Видимость бара 

    // Use this for initialization 
    void Start()
    {

    }

    void OnGUI()
    {
        if (Visible)
        {
            //назначаем mySkin текущим скином для GUI 
            GUI.skin = mySkin;
            //получаем переменную PlayerSt компонент PlayerStats 
            //В инспекторе в Unity нужно указать на игрока 
            playerstat PlayerSt = (playerstat)Char.GetComponent("playerstat");
            //получаем значения 
            float MaxHealth = PlayerSt.stats.HP;
            float CurHealth = PlayerSt.curHP;
            float MaxMana = PlayerSt.stats.MP;
            float CurMana = PlayerSt.curMP;
            float needExp = PlayerSt.stats.EXP;
            float curExp = PlayerSt.curEXP;
            //расчитываем коэффицент длинны полосы здоровья 
            float HealthBarLen = CurHealth / MaxHealth; //если умножить на сто то будут проценты 
                                                        //расчитываем коэффицент длинны полосы маны 
            float ManaBarLen = CurMana / MaxMana; //если умножить на сто то будут проценты 
                                                  //расчитываем коэффицент длинны полосы опыта 
            float ExpBarLen = curExp / needExp; //если умножить на сто то будут проценты 



            //полоса здоровья игрока 
            GUI.Box(new Rect(10, 15, 254 * HealthBarLen, 15), " ", GUI.skin.GetStyle("HPbar"));
            //полоса маны игрока 
            GUI.Box(new Rect(10, 30, 254 * ManaBarLen, 15), " ", GUI.skin.GetStyle("MPbar"));
            //полоса опыта 
            GUI.Box(new Rect(10, 55, 254 * ExpBarLen, 15), " ", GUI.skin.GetStyle("EXPbar"));

            //рисуем сам бар 
            GUI.Box(new Rect(10, 10, 254, 64), " ", GUI.skin.GetStyle("PlayerBar"));

        }
    }

    // Update is called once per frame 
    void Update()
    {

    }
}