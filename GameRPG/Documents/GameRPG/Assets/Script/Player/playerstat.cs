using UnityEngine;
using System.Collections;
using stats; //Используем пространство stats 

public class playerstat : MonoBehaviour
{
    public int upHP; //восстановление здоровья с банки
    public float upEnerjy = 0.1f; // пассивное восстановление энергии
    public float upPassiveHP = 0.01f; // пассивное восстановление HP
    public int minEnerjyForHit = 5; // минимальная энергия для удара


    public Stats stats = new Stats(10, 600, 20, 20, 20); //Объявляем новый объект Stats 
    public static bool death; //Глобальная переменная отвечающа нам жив ли персонаж 
    int pointstat = 0; //кол-во поинтов дающихся при повышении 
    int showstat = 0; //Отображать ли окно со статами 
    public float curHP; //кол-во жизней персонаж нынешние 
    public float curMP; //кол-во маны персонажа 
    public float curEXP; //кол-во опыта     

    private int lvl = 1;

    void Start()
    {
        stats.HP = 100;
        death = false; //По умолчанию персонаж жив 
        Time.timeScale = 1; //Игра работает 
        curHP = stats.HP; //В начале у персонажа кол-во жизней максимально 
        curMP = stats.MP; //маны тоже 
    }

    void Update()
    {
        if (curHP > stats.HP) //если кол-во жизни будет выше максимального кол-ва жизней 
            curHP = stats.HP; //Уравниваем их 
        if (curHP <= 0) //Если кол-во жизни меньше или равно 0 
        {
            curHP = 0; //Ставим 0 дабы наш бар не рисовался не корректно 
            death = true; //Ставим что персонаж мертв 
            Time.timeScale = 0; //Останавливаем игру 
        }
        if (curMP < 0) //Если кол-во маны ниже 0 
            curMP = 0; //Ставим 0 
        if (curMP > stats.MP) //если кол-во маны больше максимального кол-ва 
            curMP = stats.MP;//уравниваем 
        

        if (curEXP >= stats.EXP) //Если количество опыта у нас рано и ли больше нужного кол-ва опыта 
        {
            lvl++;

            stats.HP += 20;
            curHP = stats.HP;

            stats.MP += 5;
            curMP = stats.MP;

            GameObject.FindGameObjectWithTag("Player").GetComponent<lvl_player>().player_LVL.text = lvl.ToString();

            stats.lvlUP(); //повышаем уровень 
            curEXP = 0; //кол-во опыта ставим 0             
        }

        // бутылки со здоровьем
        if (Input.GetKeyDown(KeyCode.Tab) && hpBottle_player.hp > 0)
        {
            hpBottle_player.hp -= 1;
            GameObject.FindGameObjectWithTag("Player").GetComponent<hpBottle_player>().TextHP.text = hpBottle_player.hp.ToString();

            if (curHP + upHP > stats.HP)
                curHP = stats.HP;
            else
                curHP += upHP;
        }

        // пассивное восстанавливаем энергию
        if (curMP + upEnerjy > stats.MP)
            curMP = stats.MP;
        else
            curMP += upEnerjy;

        // пассивное восстановление HP
        if (curHP + upPassiveHP > stats.HP)
            curHP = stats.HP;
        else
            curHP += upPassiveHP;


        // добавляем значения в UI
        GameObject.FindGameObjectWithTag("Player").GetComponent<UI_hp>().player_HP.text = ((int)curHP).ToString() + '/' + ((int)stats.HP).ToString();
        GameObject.FindGameObjectWithTag("Player").GetComponent<UI_Enerjy>().player_enerjy.text = ((int)(curMP / stats.MP * 100)).ToString() + '%';
        GameObject.FindGameObjectWithTag("Player").GetComponent<UI_EXP>().player_exp.text = ((int)curEXP).ToString() + '/' + ((int)stats.EXP).ToString();

    }
    void OnGUI()
    {
        if (death == true) //Если умерли 
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 150, 200, 200), "You died!");

            if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 100, 100, 25), "Try again"))
            {
                Application.LoadLevel("idontknow");
            }

            //if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 50, 100, 25), "Settings"))
            //{

            //}

            if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2, 100, 25), "Quit"))
            {
                Application.Quit();
            }
        }
    }
}
