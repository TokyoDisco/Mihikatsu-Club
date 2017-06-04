using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[System.Serializable]
public class Skill {

    public string name;
    public string description;
    public string type;
    public string element;

    public float cost;
    public float baseDmg;
    public int spellID;
    

    public Skill (string newName, string newDesc, string newType,string newElement, float newCost,float newDmg,int newSpellID)
    {
        name = newName;
        element = newElement;
        description = newDesc;
        type = newType;
        cost = newCost;
        baseDmg = newDmg;
        spellID = newSpellID;
    }


}
