using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Hero   {

    public string name;

    public float str;
    public float intel;
    public float agi;
    public string MainMagic;

    public float baseHP;
    public float baseMP;

    public int actionPoints;

    public int level;
    public int attack;
    public int curExp;
    public int reqExp;
    public int talentPoints;
    public string statusHero;
    public string elementHero;
    public float armor;
    public List<Skill> SkillList;
    public List<ItemsList> ItemList;


}
