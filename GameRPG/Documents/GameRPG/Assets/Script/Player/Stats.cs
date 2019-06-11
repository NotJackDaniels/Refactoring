using UnityEngine;
using System.Collections;

namespace stats
{ //Пространство имен stats 
    public class Stats //Объявляем новый класс Stats 
    {
        public int lvl = 1; //Уровень (по умолчанию 1) 
        public float HP; //Максимальное кол-во жизней(Высчитывается по формуле) 
        public float MP; //Максимальное кол-во маны(Высчитывается по формуле) 
        public float EXP = 1000; //Необходимое кол-во опыта на следующий уровень(По достижению считается заново) 
        public int STR = 20; //Начальное кол-во силы 
        public int vitality = 20; //Начальное кол-во живучести 
        public int energy = 20; //Начальное кол-во энергии 
        public int minATKweapon = 10; //Минимальная атака оружия 
        public int maxATKweapon = 10; //максимальная атака оружия 
        public int minDMG; //Минимальный наносимый урон(Высчитывается по формуле) 
        public int maxDMG; //Максимальный наносимый урон (Высчитывается по формуле) 

        public Stats() //конструктор класса со стандартными значениями 
        {
            this.newdmg(); //Считаем урон 
            this.newhp(); //считаем кол-во жизни 
            this.newmp(); //считаем кол-во маны 
        }

        public Stats(int lvl, int EXP, int STR, int vitality, int energy) //конструктор класса с о всеми значениями 
        {
            this.lvl = lvl; //начальный уровень 
            this.EXP = EXP; //необходимое кол-во опыта для следующего уровня 
            this.STR = STR; //начальное кол-во силы 
            this.vitality = vitality; //начальное кол-во живучисти 
            this.energy = energy; //начальное кол-во энергии 
            this.newdmg(); //Считаем урон 
            this.newhp(); //считаем кол-во жизни 
            this.newmp(); //счтаем кол-во маны 
        }

        public void lvlUP() //функция вызываемая при повышении уровня 
        {
            this.lvl += 1; //уровень устанавливаем +1 
            this.EXP += Mathf.Floor(this.EXP / 2.5f); //Высчитываем необходимое кол-во опыта для следующего уровня 
        }
        public void newdmg() //функция пересчета урона 
        {
            this.minDMG = minATKweapon * (this.STR + 100) / 100; //минимальный урон 
            this.maxDMG = maxATKweapon * (this.STR + 100) / 100; //максимальный урон 
        }
        public void newhp() //Пересчет кол-ва жизней 
        {
            this.HP = Mathf.Floor(this.vitality * 3.6f);
        }
        public void newmp() //Пересчет кол-ва маны 
        {
            this.MP = Mathf.Floor(this.energy * 1.1f);
        }

    }
}