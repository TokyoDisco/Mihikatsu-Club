using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamHeroStats : MonoBehaviour {
    public Hero hero;
    public float baseHP;
    public float baseMP;
    public float curExp = 0;

    public float str;
    public float intel;
    public float agi ;
    public List<Skill> listofskills = new List<Skill>();
    public List<Skill> listofskillsOsahara = new List<Skill>();
    public List<Skill> listofskillsInomi = new List<Skill>();
    public int level;
    public float reqExp;
    public string nameOfHero;
    public int actionPoints;
    public int attack;
    public string MainMagic;
    public bool UpdateDone;

    // Use this for initialization
    void Start () {
        UpdateDone = false;
        listofskills = GetComponent<SkillList>().listofskills;
       
        StartCoroutine(WaitForUpdate());
        if (UpdateDone)
        {
            listofskillsOsahara.Add(GetComponent<SkillList>().listofAllSkils[4]);
            listofskillsOsahara.Add(GetComponent<SkillList>().listofAllSkils[6]);
           
            listofskillsInomi.Add(GetComponent<SkillList>().listofAllSkils[5]);
            listofskillsInomi.Add(GetComponent<SkillList>().listofAllSkils[0]);
            listofskillsInomi.Add(GetComponent<SkillList>().listofAllSkils[10]);
        }

    }
	
	// Update is called once per frame
	void Update () {

        if (listofskillsOsahara.Count < 1 || listofskillsInomi.Count < 1)
        {
            listofskillsOsahara.Add(GetComponent<SkillList>().listofAllSkils[4]);
            listofskillsOsahara.Add(GetComponent<SkillList>().listofAllSkils[6]);
            listofskillsOsahara.Add(GetComponent<SkillList>().listofAllSkils[12]);

            listofskillsInomi.Add(GetComponent<SkillList>().listofAllSkils[5]);
            listofskillsInomi.Add(GetComponent<SkillList>().listofAllSkils[0]);
            listofskillsInomi.Add(GetComponent<SkillList>().listofAllSkils[10]);
            listofskillsInomi.Add(GetComponent<SkillList>().listofAllSkils[13]);
        }
        




    }


    public IEnumerator WaitForUpdate()
    {
        yield return new WaitForSeconds(1);
        UpdateDone = true;
    }

    
}
