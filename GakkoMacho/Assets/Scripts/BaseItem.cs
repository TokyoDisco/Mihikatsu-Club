using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//generic item class
[System.Serializable]
public class Item {
    public string name;
    public string desc;
    public string type;
    public int quantity;
    public float baseDmg;
    public int ItemID;

    // Types : Damage, Heal, Mana, buff, debuff, QUEST, Summon

    public Item(string newName, string newDesc, string newType, float newDmg, int newItemID, int newQuantity)
    {
        name = newName;
        desc = newDesc;
        type = newType;
        baseDmg = newDmg;
        ItemID = newItemID;
        quantity = newQuantity;

    }

    

}
