using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(menuName ="Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public string bonusName;
    public int itemDamage;
    public int itemPrice;
    public int itemHP;
    public Sprite ItemImage;
}
