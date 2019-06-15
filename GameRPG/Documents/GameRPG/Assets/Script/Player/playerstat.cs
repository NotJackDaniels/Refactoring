using UnityEngine;
using System.Collections;
using stats; //Используем пространство stats 

public class playerstat : MonoBehaviour
{
    public int upHP; //восстановление здоровья с банки
    public float upEnerjy = 0.1f; // пассивное восстановление энергии
    public float upPassiveHP = 0.01f; // пассивное восстановление HP
    public int minEnerjyForHit = 5; // минимальная энергия для удара


    public Stats stats = new Stats(1, 600, 20, 20, 20); //Объявляем новый объект Stats 
    public static bool death; //Глобальная переменная отвечающа нам жив ли персонаж 
    int pointstat = 0; //кол-во поинтов дающихся при повышении 
    int showstat = 0; //Отображать ли окно со статами 
    public float curHP; //кол-во жизней персонаж нынешние 
    public float curMP; //кол-во маны персонажа 
    public float curEXP; //кол-во опыта 

    void Start()
    {        
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

        if (showstat == 0) //Если окно со статами не отображается 
        {
            if (Input.GetKeyDown(KeyCode.P)) //Принажатии на клавишу P 
                showstat = 1; //окно со статами будет отображаться 
        }
        else if (showstat == 1) //если окно со статами отображается 
        {
            if (Input.GetKeyDown(KeyCode.P)) //При нажатии на клавишу P 
                showstat = 0; //Окно исчезнет 
        }

        if (true)//movePlayer.IsDrawWeapon == true) //Проверяем вытащено ли у нас оружие, и если вытащено 
        {
            stats.minATKweapon = weaponstat.minATKweapon; //Устанавливаем значение минимальной атаки оружия 
            stats.maxATKweapon = weaponstat.maxATKweapon; //Максимальной атаки оружия 
            stats.newdmg(); //Пересчитываем урон согласно оружию 
        }
        else //если не одето 
        {
            stats.minATKweapon = 0; //ставим значения в 0 
            stats.maxATKweapon = 0;
            stats.newdmg(); //соответственно атака у нас 0 
        }

        if (curEXP >= stats.EXP) //Если количество опыта у нас рано и ли больше нужного кол-ва опыта 
        {
            stats.lvlUP(); //повышаем уровень 
            curEXP = 0; //кол-во опыта ставим 0 
            pointstat += 5; //Добавляем очки статов 
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

    }
    void OnGUI()
    {
        if (showstat == 1) //если статы отображаются 
        {
            //Рисуем наши статы 
            GUI.Box(new Rect(10, 70, 300, 300), "stats");
            GUI.Label(new Rect(10, 95, 300, 300), "LvL: " + stats.lvl);
            GUI.Label(new Rect(10, 110, 300, 300), "hp: " + stats.HP);
            GUI.Label(new Rect(10, 125, 300, 300), "mp: " + stats.MP);
            GUI.Label(new Rect(10, 140, 300, 300), "exp: " + stats.EXP);
            GUI.Label(new Rect(10, 155, 300, 300), "str: " + stats.STR);
            GUI.Label(new Rect(10, 170, 300, 300), "vitality: " + stats.vitality);
            GUI.Label(new Rect(10, 185, 300, 300), "energy: " + stats.energy);
            GUI.Label(new Rect(10, 200, 300, 300), "minDMG: " + stats.minDMG);
            GUI.Label(new Rect(10, 215, 300, 300), "maxDMG: " + stats.maxDMG);

            if (pointstat > 0) //если очков статов больше 0 делаем кнопки для повышения статов 
            {
                GUI.Label(new Rect(10, 250, 300, 20), "points " + pointstat.ToString());
                if (GUI.Button(new Rect(150, 155, 20, 20), "+")) //Для силы 
                {
                    if (pointstat > 0)
                    {
                        pointstat -= 1;
                        stats.STR += 1;
                        stats.newdmg();
                    }
                }
                if (GUI.Button(new Rect(150, 170, 20, 20), "+")) //Для живучести 
                {
                    if (pointstat > 0)
                    {
                        pointstat -= 1;
                        stats.vitality += 1;
                        stats.newhp();
                    }
                }
                if (GUI.Button(new Rect(150, 185, 20, 20), "+")) //Для маны 
                {
                    if (pointstat > 0)
                    {
                        pointstat -= 1;
                        stats.energy += 1;
                        stats.newmp();
                    }
                }
            }
        }
        else if (showstat == 0)
            useGUILayout = false; //Скрываем окно статов 
        if (death == true) //Если умерли 
        {
            if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2, 100, 50), "Переиграть")) //Ресуем кнопку переиграть 
            {
                Application.LoadLevel(0);
            }
        }
    }
}
