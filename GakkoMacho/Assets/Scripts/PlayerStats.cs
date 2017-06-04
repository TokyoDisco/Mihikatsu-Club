using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
[System.Serializable]
public class PlayerStats : MonoBehaviour {
    public Hero hero1;
    public Hero hero2;
    public Hero hero3;
    public List<Trinket> ListOfTrinketsPC = new List<Trinket>();
    public List<Trinket> ListOfTrinketsPC2 = new List<Trinket>();
    public List<Trinket> ListOfTrinkestPC3 = new List<Trinket>();
    public GameObject[] trinketsSlotsPC = new GameObject[3];
    public GameObject[] trinketsSlotsPC2 = new GameObject[3];
    public GameObject[] trinketsSlotsPC3 = new GameObject[3];
    public GameObject talentPointPc1;
    public GameObject talentPointPc2;
    public GameObject talentPointPc3;
    public string LevelName;
    public int PartySize;
    public int bonusHp;
    public int bonusMana;
    GameObject track;
    public Vector3 exitpos;
    public string killedEnemyPatrol;
    public Vector3 camerapos;
    public Vector3 camerapos2;
    string control;
    public bool tipsON;
    public GameObject SkillNotification;

    // Use this for initialization

    private void Start()
    {
        tipsON = true;
        LevelName = SceneManager.GetActiveScene().name;
        if (GameObject.Find("StatsCarrier").GetComponent<PartyStats>().PartyList.Count > 0)
        {
            PartySize = GameObject.Find("StatsCarrier").GetComponent<PartyStats>().PartyList.Count + 1;
        }
        //starting camera information//
        Vector3 zerovec = new Vector3(0, 0, 0);
      
        //set camera in places where player enter battle
        control = killedEnemyPatrol;
        camerapos = GameObject.Find("Main Camera").GetComponent<Transform>().position;
        if (camerapos2 != zerovec)
        {
            if (camerapos2 != GameObject.Find("Main Camera").GetComponent<Transform>().position)
            {
                GameObject.Find("Main Camera").GetComponent<Transform>().position = camerapos2;
                camerapos = GameObject.Find("Main Camera").GetComponent<Transform>().position;
                camerapos2 = zerovec;
            }
        }
        
        

        //tracking player position on map
        if (GameObject.Find("Player") != null)
        {
            GameObject track = GameObject.Find("Player");
            exitpos = track.GetComponent<Transform>().position;
        }

        //getting skills for player
        hero1.SkillList = GetComponent<SkillList>().listofskills;
        hero1.name = "Miyagi";
        hero1.curExp = 0;
        hero1.reqExp = 100;
        hero1.level = 1;
        hero1.intel = 5;
        hero1.agi = 5;
        hero1.str = 5;
        hero1.actionPoints = 100;
        hero1.baseHP = 100;
        hero1.baseMP = 100;
        hero1.attack = 10;
        hero1.MainMagic = "Water";
        hero1.talentPoints = 0;
        hero1.armor = hero1.str * 1.5f;
        hero1.statusHero = "normal";
   

    }


    void Update()
    {

        LevelName = SceneManager.GetActiveScene().name;
        if (GameObject.Find("StatsCarrier").GetComponent<PartyStats>().PartyList.Count > 0)
        {
            PartySize = GameObject.Find("StatsCarrier").GetComponent<PartyStats>().PartyList.Count;
        }
      
        //tracking player position on map
        if (GameObject.Find("Player") != null)
        {
            GameObject track = GameObject.Find("Player");
            exitpos = track.GetComponent<Transform>().position;
        }

        //Leveling up if after battle players have enough exp then his level inc by 1
        if (hero1.curExp >= hero1.reqExp)
        {
            hero1.curExp = hero1.curExp - hero1.reqExp;
            hero1.level = hero1.level + 1;
            hero1.baseHP = hero1.baseHP + 100;
            hero1.baseMP = hero1.baseMP + 25;
            hero1.reqExp = hero1.reqExp * hero1.level;
            hero1.str = hero1.str + (2 * hero1.level);
            hero1.intel = hero1.intel + (2 * hero1.level);
            hero1.agi = hero1.agi + (2 * hero1.level);
            hero1.talentPoints = hero1.talentPoints + 1;
            SkillNotification.SetActive(true);
            if(hero1.level == 2)
            {
                hero1.SkillList.Add(GetComponent<SkillList>().listofAllSkils[11]);
            }
          
        }
         if (PartySize > 1)
            {
                if (hero2.curExp >= hero2.reqExp && hero2.reqExp > 0)
                {
                    hero2.curExp = hero2.curExp - hero2.reqExp;
                    hero2.level = hero2.level + 1;
                    hero2.baseHP = hero2.baseHP + 100;
                    hero2.baseMP = hero2.baseMP + 25;
                    hero2.reqExp = hero2.reqExp * hero2.level;
                    hero2.str = hero2.str + (2 * hero2.level);
                    hero2.intel = hero2.intel + (2 * hero2.level);
                    hero2.agi = hero2.agi + (2 * hero2.level);
                    hero2.talentPoints = hero2.talentPoints + 1;
             
                }

            if (hero3.curExp >= hero3.reqExp && hero3.reqExp > 0)
            {
                hero3.curExp = hero3.curExp - hero3.reqExp;
                hero3.level = hero3.level + 1;
                hero3.baseHP = hero3.baseHP + 100;
                hero3.baseMP = hero3.baseMP + 25;
                hero3.reqExp = hero3.reqExp * hero3.level;
                hero3.str = hero3.str + (2 * hero3.level);
                hero3.intel = hero3.intel + (2 * hero3.level);
                hero3.agi = hero3.agi + (2 * hero3.level);
                hero3.talentPoints = hero3.talentPoints + 1;
            
            }
        }
        

        // updating killed enemy to futher despawing
        if (control != killedEnemyPatrol )
        {
            GetComponent<MapSpawnControl>().hitObjectList.Add(killedEnemyPatrol);
            control = killedEnemyPatrol;

        }

        // camera updates
        Vector3 zerovec = new Vector3(0, 0, 0);
        if(GetComponent<MapSpawnControl>().hitObjectList.Count > 0) {
            control = GetComponent<MapSpawnControl>().hitObjectList[GetComponent<MapSpawnControl>().hitObjectList.Count - 1];
        }
        
        if (GameObject.Find("Main Camera") == true)
        {
            camerapos = GameObject.Find("Main Camera").GetComponent<Transform>().position;
            if (camerapos2 != zerovec)
            {
                if (camerapos2 != GameObject.Find("Main Camera").GetComponent<Transform>().position)
                {
                    GameObject.Find("Main Camera").GetComponent<Transform>().position = camerapos2;
                    camerapos = GameObject.Find("Main Camera").GetComponent<Transform>().position;
                    camerapos2 = zerovec;
                }
            }
        }
        // player skill set updates
        hero1.SkillList = GetComponent<SkillList>().listofskills;

            if (GameObject.Find("Player") != null)
            {
                GameObject track = GameObject.Find("Player");
                exitpos = track.GetComponent<Transform>().position;
            }
       
            talentPointPc1.GetComponent<Text>().text = "Talent Points remaing : " +  hero1.talentPoints;
            if(PartySize == 2)
        {
            talentPointPc2.GetComponent<Text>().text = "Talent Points remaing : " + hero2.talentPoints;
        }
            if(PartySize > 2)
        {
            talentPointPc3.GetComponent<Text>().text = "Talent Points remaing : " + hero3.talentPoints;
        }




    }

    //SkillListUpdate off
    void SkillListUpdate()
    {
      //  GetComponent<SkillList>().listofskills = hero1.SkillList;
    }

    
    //track of last enemy that trigger battle mode
    public void LastHit(string name)
    {
        killedEnemyPatrol = name;
    }

    //Track of changing scene exploration -> battle
    public void ChangeofScene()
    {
        GetComponent<MapSpawnControl>().checkScene = 1;
   //     GetComponent<MapSpawnControl>().hitObjectList.Add(killedEnemyPatrol);
    }
    
    //for exiting battle tracks player pos.
    public void CameraSave(Vector3 CameraPos)
    {
        camerapos2 = CameraPos;
    }
 
    public void PartyAdded(string name)
    {
        if (name == "osahara")

            
        {
           


                hero2.SkillList = GameObject.Find("StatsCarrier").GetComponent<PartyStats>().PartyList[0].GetComponent<TeamHeroStats>().listofskillsOsahara;
                hero2.name = GameObject.Find("StatsCarrier").GetComponent<PartyStats>().PartyList[0].GetComponent<TeamHeroStats>().nameOfHero;
          //      hero2.curExp = (int)GameObject.Find("StatsCarrier").GetComponent<PartyStats>().PartyList[0].GetComponent<TeamHeroStats>().curExp;
                hero2.reqExp = (int)GameObject.Find("StatsCarrier").GetComponent<PartyStats>().PartyList[0].GetComponent<TeamHeroStats>().reqExp;
                hero2.level = hero1.level - 1;
                hero2.intel = GameObject.Find("StatsCarrier").GetComponent<PartyStats>().PartyList[0].GetComponent<TeamHeroStats>().intel;
                hero2.agi = GameObject.Find("StatsCarrier").GetComponent<PartyStats>().PartyList[0].GetComponent<TeamHeroStats>().agi;
                hero2.str = GameObject.Find("StatsCarrier").GetComponent<PartyStats>().PartyList[0].GetComponent<TeamHeroStats>().str;
                hero2.actionPoints = GameObject.Find("StatsCarrier").GetComponent<PartyStats>().PartyList[0].GetComponent<TeamHeroStats>().actionPoints;
                hero2.baseHP = GameObject.Find("StatsCarrier").GetComponent<PartyStats>().PartyList[0].GetComponent<TeamHeroStats>().baseHP;
                hero2.baseMP = GameObject.Find("StatsCarrier").GetComponent<PartyStats>().PartyList[0].GetComponent<TeamHeroStats>().baseMP;
                hero2.attack = GameObject.Find("StatsCarrier").GetComponent<PartyStats>().PartyList[0].GetComponent<TeamHeroStats>().attack;
                hero2.MainMagic = GameObject.Find("StatsCarrier").GetComponent<PartyStats>().PartyList[0].GetComponent<TeamHeroStats>().MainMagic;
                hero2.armor = hero2.str * 1.5f;
                hero2.statusHero = "normal";
                hero2.talentPoints = 1 * hero2.level - 1;


        }

        if(name == "Inomi")
        {
            
                hero3.SkillList = GameObject.Find("StatsCarrier").GetComponent<PartyStats>().PartyList[2].GetComponent<TeamHeroStats>().listofskillsInomi;
                hero3.name = "Inomi";
           //     hero3.curExp = (int)GameObject.Find("StatsCarrier").GetComponent<PartyStats>().PartyList[2].GetComponent<TeamHeroStats>().curExp;
                hero3.reqExp = (int)GameObject.Find("StatsCarrier").GetComponent<PartyStats>().PartyList[2].GetComponent<TeamHeroStats>().reqExp;
            //  hero3.level = GameObject.Find("StatsCarrier").GetComponent<PartyStats>().PartyList[2].GetComponent<TeamHeroStats>().level;
                hero3.level = hero1.level - 1;
                hero3.intel = GameObject.Find("StatsCarrier").GetComponent<PartyStats>().PartyList[2].GetComponent<TeamHeroStats>().intel;

                hero3.agi = GameObject.Find("StatsCarrier").GetComponent<PartyStats>().PartyList[2].GetComponent<TeamHeroStats>().agi;
                hero3.str = GameObject.Find("StatsCarrier").GetComponent<PartyStats>().PartyList[2].GetComponent<TeamHeroStats>().str;
                hero3.actionPoints = GameObject.Find("StatsCarrier").GetComponent<PartyStats>().PartyList[2].GetComponent<TeamHeroStats>().actionPoints;
                hero3.baseHP = GameObject.Find("StatsCarrier").GetComponent<PartyStats>().PartyList[2].GetComponent<TeamHeroStats>().baseHP;
                hero3.baseMP = GameObject.Find("StatsCarrier").GetComponent<PartyStats>().PartyList[2].GetComponent<TeamHeroStats>().baseMP;
                hero3.attack = GameObject.Find("StatsCarrier").GetComponent<PartyStats>().PartyList[2].GetComponent<TeamHeroStats>().attack;
                hero3.MainMagic = GameObject.Find("StatsCarrier").GetComponent<PartyStats>().PartyList[2].GetComponent<TeamHeroStats>().MainMagic;
                hero3.armor = hero3.str * 1.5f;
                hero3.talentPoints = 1 * hero3.level - 1;
                hero3.statusHero = "normal";

        }
    }




    public void TalentBonFire1Add()
    {
        if (hero2.talentPoints > 0)
        {
            int innerCounter = 0;

            for (int i = 0; i < hero2.SkillList.Count; i++)
            {
                if (hero2.SkillList[i].spellID == 7)
                {
                    innerCounter = innerCounter + 1;
                    if (hero2.SkillList[i].baseDmg != 350)
                    {
                        hero2.SkillList[i].baseDmg = hero2.SkillList[i].baseDmg + 25;
                        hero2.SkillList[i].cost = hero2.SkillList[i].cost + 25;
                    }
                }
            }
            if (innerCounter == 0)
            {
                hero2.SkillList.Add(GetComponent<SkillList>().listofAllSkils[6]);
            }
            hero2.talentPoints = hero2.talentPoints - 1;
        }
    }

    public void TalentPureFire1Add()
    {
        if (hero2.talentPoints > 0)
        {
            int innerCounter = 0;

            for (int i = 0; i < hero2.SkillList.Count; i++)
            {
                if (hero2.SkillList[i].spellID == 2)
                {
                    innerCounter = innerCounter + 1;
                    if (hero2.SkillList[i].baseDmg != 650)
                    {
                        hero2.SkillList[i].baseDmg = hero2.SkillList[i].baseDmg + 150;
                        hero2.SkillList[i].cost = hero2.SkillList[i].cost + 20;
                    }
                }
            }
            if (innerCounter == 0)
            {
                hero2.SkillList.Add(GetComponent<SkillList>().listofAllSkils[1]);
            }
            hero2.talentPoints = hero2.talentPoints - 1;
        }
    }
    public void TalentHeartOfVolcano1Add()
    {
        if (hero2.talentPoints > 0)
        {
            int innerCounter = 0;

            for (int i = 0; i < hero2.SkillList.Count; i++)
            {
                if (hero2.SkillList[i].spellID == 5)
                {
                    innerCounter = innerCounter + 1;
                    if (hero2.SkillList[i].baseDmg != 1200)
                    {
                        hero2.SkillList[i].baseDmg = hero2.SkillList[i].baseDmg + hero2.SkillList[i].baseDmg;
                        hero2.SkillList[i].cost = hero2.SkillList[i].cost + hero2.SkillList[i].cost;
                    }
                }
            }
            if (innerCounter == 0)
            {
                hero2.SkillList.Add(GetComponent<SkillList>().listofAllSkils[4]);
            }
            hero2.talentPoints = hero2.talentPoints - 1;
        }
    }

    public void TalentRoyalWaters1Add()
    {
        if (hero1.talentPoints > 0)
        {
            int innerCounter = 0;

            for (int i = 0; i < hero1.SkillList.Count; i++)
            {
                if (hero1.SkillList[i].spellID == 8)
                {
                    innerCounter = innerCounter + 1;
                    if (hero1.SkillList[i].baseDmg != 430)
                    {
                        hero1.SkillList[i].baseDmg = hero1.SkillList[i].baseDmg + 110;
                        hero1.SkillList[i].cost = hero1.SkillList[i].cost + 25;
                    }
                }
            }
            if (innerCounter == 0)
            {
                hero1.SkillList.Add(GetComponent<SkillList>().listofAllSkils[7]);
            }
            hero1.talentPoints = hero1.talentPoints - 1;
        }
    }

    public void TalentCalmFlow1Add()
    {
        if (hero1.talentPoints > 0)
        {
            int innerCounter = 0;

            for (int i = 0; i < hero1.SkillList.Count; i++)
            {
                if (hero1.SkillList[i].spellID == 3)
                {
                    innerCounter = innerCounter + 1;
                    if (hero1.SkillList[i].baseDmg != 320)
                    {
                        hero1.SkillList[i].baseDmg = hero1.SkillList[i].baseDmg + 40;
                        hero1.SkillList[i].cost = hero1.SkillList[i].cost + 0;
                    }
                }
            }
            if (innerCounter == 0)
            {
                hero1.SkillList.Add(GetComponent<SkillList>().listofAllSkils[2]);
            }
            hero1.talentPoints = hero1.talentPoints - 1;
        }
    }

    public void TalentDeeps1Add()
    {
        if (hero1.talentPoints > 0)
        {
            int innerCounter = 0;

            for (int i = 0; i < hero1.SkillList.Count; i++)
            {
                if (hero1.SkillList[i].spellID == 9)
                {
                    innerCounter = innerCounter + 1;
                    if (hero1.SkillList[i].baseDmg != 500)
                    {
                        hero1.SkillList[i].baseDmg = hero1.SkillList[i].baseDmg + 150;
                        hero1.SkillList[i].cost = hero1.SkillList[i].cost + 80;
                    }
                }
            }
            if (innerCounter == 0)
            {
                hero1.SkillList.Add(GetComponent<SkillList>().listofAllSkils[8]);
            }
            hero1.talentPoints = hero1.talentPoints - 1;
        }
    }

    public void TalentFlourish1Add()
    {
        if (hero3.talentPoints > 0)
        {
            int innerCounter = 0;

            for (int i = 0; i < hero3.SkillList.Count; i++)
            {
                if (hero3.SkillList[i].spellID == 1)
                {
                    innerCounter = innerCounter + 1;
                    if (hero3.SkillList[i].baseDmg != 80)
                    {
                        hero3.SkillList[i].baseDmg = hero3.SkillList[i].baseDmg + 20;
                        hero3.SkillList[i].cost = hero3.SkillList[i].cost + 10;
                    }
                }
            }
            if (innerCounter == 0)
            {
                hero3.SkillList.Add(GetComponent<SkillList>().listofAllSkils[0]);
            }
            hero3.talentPoints = hero3.talentPoints - 1;
        }
    }

    public void TalentForestCall1Add()
    {
        if (hero3.talentPoints > 0)
        {
            int innerCounter = 0;

            for (int i = 0; i < hero3.SkillList.Count; i++)
            {
                if (hero3.SkillList[i].spellID == 10)
                {
                    innerCounter = innerCounter + 1;
                    if (hero3.SkillList[i].baseDmg != 270)
                    {
                        hero3.SkillList[i].baseDmg = hero3.SkillList[i].baseDmg + 30;
                        hero3.SkillList[i].cost = hero3.SkillList[i].cost + 15;
                    }
                }
            }
            if (innerCounter == 0)
            {
                hero3.SkillList.Add(GetComponent<SkillList>().listofAllSkils[9]);
            }
            hero3.talentPoints = hero3.talentPoints - 1;
        }
    }

    public void TalentMountain1Add()
    {
        if (hero3.talentPoints > 0)
        {
            int innerCounter = 0;

            for (int i = 0; i < hero3.SkillList.Count; i++)
            {
                if (hero3.SkillList[i].spellID == 6)
                {
                    innerCounter = innerCounter + 1;
                    if (hero3.SkillList[i].baseDmg != 240)
                    {
                        hero3.SkillList[i].baseDmg = hero3.SkillList[i].baseDmg + 35;
                        hero3.SkillList[i].cost = hero3.SkillList[i].cost + 20;
                    }
                }
            }
            if (innerCounter == 0)
            {
                hero3.SkillList.Add(GetComponent<SkillList>().listofAllSkils[5]);
            }
            hero3.talentPoints = hero3.talentPoints - 1;
        }
    }

    public void EscapeBattle()
    {
        GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().currentState = SBattleStateFSM.BattleStates.WIN;
        
        for (int y = 0; y < GetComponent<MapSpawnControl>().hitObjectList.Count;y++)
        {
            
           
            if (GetComponent<MapSpawnControl>().hitObjectList[y] == killedEnemyPatrol)
            {
                GetComponent<MapSpawnControl>().hitObjectList.RemoveAt(y);
             //   GetComponent<SBattleStateFSM>().currentState = SBattleStateFSM.BattleStates.WIN;
            }

        }
        killedEnemyPatrol = null;
    }
    public void TrinketAddPC(int TrinketID)
    {
        if (ListOfTrinketsPC.Count <3)
        {
            Trinket trinket;
            for (int i = 0; i < GameObject.Find("StatsCarrier").GetComponent<TrinketsList>().ListOfTrinkets.Count; i++)
            {
                if (TrinketID == GameObject.Find("StatsCarrier").GetComponent<TrinketsList>().ListOfTrinkets[i].id)
                {
                    trinket = GameObject.Find("StatsCarrier").GetComponent<TrinketsList>().ListOfTrinkets[i];
                    ListOfTrinketsPC.Add(trinket);
                    Sprite spritetrinket = GameObject.Find("StatsCarrier").GetComponent<TrinketsList>().ListOfTrinketsSprite[i];
                    for (int y = 0; y < ListOfTrinketsPC.Count; y++)
                    {
                        if (trinket == ListOfTrinketsPC[y])
                        {
                            trinketsSlotsPC[y].GetComponent<Image>().sprite = spritetrinket;
                        }

                    }
                    if (trinket.type == 1)
                    {
                        if (trinket.id == 1)
                        {
                            hero1.SkillList.Add(GetComponent<SkillList>().listofTrinketsSkills[0]);

                        }
                    }
                    else
                    {
                        if (trinket.type == 0)
                        {
                            if (trinket.id == 2)
                            {
                                bonusHp = (int)hero1.baseHP * 2;
                                bonusMana = (int)hero1.baseMP * 3;
                                hero1.baseHP = hero1.baseHP + (bonusHp);
                                hero1.baseMP = hero1.baseMP + (bonusMana);
                            }
                        }
                    }
                    GameObject.Find("StatsCarrier").GetComponent<TrinketsList>().ListOfTrinkets.RemoveAt(i);
                    GameObject.Find("StatsCarrier").GetComponent<TrinketsList>().ListOfTrinketsSprite.RemoveAt(i);
                    GameObject.Find("Player").GetComponent<BasicContolScript>().Backpackrefresh();
                }

            }
        }
        else
        {
            Debug.Log("TrinketSlots FULL!");
        }
      
    }
    public void TrinketAddPC2(int TrinketID)
    {
        if (ListOfTrinketsPC2.Count <3)
        {
            Trinket trinket;
            for (int i = 0; i < GameObject.Find("StatsCarrier").GetComponent<TrinketsList>().ListOfTrinkets.Count; i++)
            {
                if (TrinketID == GameObject.Find("StatsCarrier").GetComponent<TrinketsList>().ListOfTrinkets[i].id)
                {
                    trinket = GameObject.Find("StatsCarrier").GetComponent<TrinketsList>().ListOfTrinkets[i];
                    ListOfTrinketsPC2.Add(trinket);
                    Sprite spritetrinket = GameObject.Find("StatsCarrier").GetComponent<TrinketsList>().ListOfTrinketsSprite[i];
                    for (int y = 0; y < ListOfTrinketsPC2.Count; y++)
                    {
                        if (trinket == ListOfTrinketsPC2[y])
                        {
                            trinketsSlotsPC2[y].GetComponent<Image>().sprite = spritetrinket;
                        }

                    }
                    if (trinket.type == 1)
                    {
                        if (trinket.id == 1)
                        {
                            hero2.SkillList.Add(GetComponent<SkillList>().listofTrinketsSkills[0]);

                        }
                    }
                    else
                    {
                        if (trinket.type == 0)
                        {
                            if (trinket.id == 2)
                            {
                                bonusHp = (int)hero2.baseHP * 2;
                                bonusMana = (int)hero2.baseMP * 3;
                                hero2.baseHP = hero2.baseHP + (bonusHp);
                                hero2.baseMP = hero2.baseMP + (bonusMana);
                            }
                        }
                    }
                    GameObject.Find("StatsCarrier").GetComponent<TrinketsList>().ListOfTrinkets.RemoveAt(i);
                    GameObject.Find("StatsCarrier").GetComponent<TrinketsList>().ListOfTrinketsSprite.RemoveAt(i);
                    GameObject.Find("Player").GetComponent<BasicContolScript>().Backpackrefresh();
                }

            }
        }
        else
        {
            Debug.Log("TrinketSlots FULL!");
        }

    }
    public void TrinketAddPC3(int TrinketID)
    {
        if (ListOfTrinkestPC3.Count < 3)
        {
            Trinket trinket;
            for (int i = 0; i < GameObject.Find("StatsCarrier").GetComponent<TrinketsList>().ListOfTrinkets.Count; i++)
            {
                if (TrinketID == GameObject.Find("StatsCarrier").GetComponent<TrinketsList>().ListOfTrinkets[i].id)
                {
                    trinket = GameObject.Find("StatsCarrier").GetComponent<TrinketsList>().ListOfTrinkets[i];
                    ListOfTrinkestPC3.Add(trinket);
                    Sprite spritetrinket = GameObject.Find("StatsCarrier").GetComponent<TrinketsList>().ListOfTrinketsSprite[i];
                    for (int y = 0; y <ListOfTrinkestPC3.Count;y++)
                    {
                        if(trinket == ListOfTrinkestPC3[y])
                        {
                            trinketsSlotsPC3[y].GetComponent<Image>().sprite = spritetrinket;
                        }

                    }
                    if (trinket.type == 1)
                    {
                        if (trinket.id == 1)
                        {
                            hero3.SkillList.Add(GetComponent<SkillList>().listofTrinketsSkills[0]);
                            
                        }
                    }
                    else
                    {
                        if(trinket.type == 0)
                        {
                            if(trinket.id == 2)
                            {
                                bonusHp = (int)hero2.baseHP * 2;
                                bonusMana = (int)hero2.baseMP * 3;
                                hero3.baseHP = hero3.baseHP + (bonusHp);
                                hero3.baseMP = hero3.baseMP + (bonusMana);
                            }
                        }
                    }
                    GameObject.Find("StatsCarrier").GetComponent<TrinketsList>().ListOfTrinkets.RemoveAt(i);
                    GameObject.Find("StatsCarrier").GetComponent<TrinketsList>().ListOfTrinketsSprite.RemoveAt(i);
                    GameObject.Find("Player").GetComponent<BasicContolScript>().Backpackrefresh();
                }

            }

        }
        else
        {
            Debug.Log("TrinketSlots FULL!");
        }

    }


    public void TrinketRemovePC(int value)
    {
        if (ListOfTrinketsPC[value] != null)
        {
            GameObject.Find("StatsCarrier").GetComponent<TrinketsList>().ListOfTrinkets.Add(ListOfTrinketsPC[value]);
            if (ListOfTrinketsPC[value].type == 0)
            {
                if (ListOfTrinketsPC[value].id == 2)
                {
                    hero1.baseHP = hero1.baseHP - (bonusHp);
                    hero1.baseMP = hero1.baseMP - (bonusMana);
                }
            }
            else
            {
                if(ListOfTrinketsPC[value].id == 1)
                {
                   for(int i = 0; i < hero1.SkillList.Count; i++)
                    {
                        if(hero1.SkillList[i].spellID == 001)
                        {
                            hero1.SkillList.RemoveAt(i);
                        }
                    }
                }
            }
            ListOfTrinketsPC.RemoveAt(value);
            Sprite sprite;
            sprite = trinketsSlotsPC[value].GetComponent<Image>().sprite;
            trinketsSlotsPC[value].GetComponent<Image>().sprite = null;
            GameObject.Find("StatsCarrier").GetComponent<TrinketsList>().ListOfTrinketsSprite.Add(sprite);
            GameObject.Find("Player").GetComponent<BasicContolScript>().Backpackrefresh();
        }

    }

    public void TrinketRemovePC2(int value)
    {
        if (ListOfTrinketsPC2[value] != null)
        {
            GameObject.Find("StatsCarrier").GetComponent<TrinketsList>().ListOfTrinkets.Add(ListOfTrinketsPC2[value]);
            if (ListOfTrinketsPC2[value].type == 0)
            {
                if (ListOfTrinketsPC2[value].id == 2)
                {
                    hero2.baseHP = hero2.baseHP - (bonusHp);
                    hero2.baseMP = hero2.baseMP - (bonusMana);
                }
            }
            else
            {
                if (ListOfTrinketsPC2[value].id == 1)
                {
                    for (int i = 0; i < hero2.SkillList.Count; i++)
                    {
                        if (hero2.SkillList[i].spellID == 001)
                        {
                            hero2.SkillList.RemoveAt(i);
                        }
                    }
                }
            }
            ListOfTrinketsPC2.RemoveAt(value);
            Sprite sprite;
            sprite = trinketsSlotsPC2[value].GetComponent<Image>().sprite;
            trinketsSlotsPC2[value].GetComponent<Image>().sprite = null;
            GameObject.Find("StatsCarrier").GetComponent<TrinketsList>().ListOfTrinketsSprite.Add(sprite);
            GameObject.Find("Player").GetComponent<BasicContolScript>().Backpackrefresh();
        }
    }

    public void TrinketRemovePC3(int value)
    {
        if (ListOfTrinkestPC3[value] != null)
        {
            GameObject.Find("StatsCarrier").GetComponent<TrinketsList>().ListOfTrinkets.Add(ListOfTrinkestPC3[value]);
            if (ListOfTrinkestPC3[value].type == 0)
            {
                if (ListOfTrinkestPC3[value].id == 2)
                {
                    hero3.baseHP = hero3.baseHP - (bonusHp);
                    hero3.baseMP = hero3.baseMP - (bonusMana);
                }
            }
            else
            {
                if (ListOfTrinkestPC3[value].id == 1)
                {
                    for (int i = 0; i < hero3.SkillList.Count; i++)
                    {
                        if (hero3.SkillList[i].spellID == 001)
                        {
                            hero3.SkillList.RemoveAt(i);
                        }
                    }
                }
            }
            ListOfTrinkestPC3.RemoveAt(value);
            Sprite sprite;
            sprite = trinketsSlotsPC3[value].GetComponent<Image>().sprite;
            trinketsSlotsPC3[value].GetComponent<Image>().sprite = null;
            GameObject.Find("StatsCarrier").GetComponent<TrinketsList>().ListOfTrinketsSprite.Add(sprite);
            GameObject.Find("Player").GetComponent<BasicContolScript>().Backpackrefresh();
        }
    }

    public void TipsSwitch()
    {
        if(tipsON)
        {
            tipsON = false;
        }
        else
        {
            if(!tipsON)
            {
                tipsON = true;
            }
        }
    }


    public void LoadFromData()
    {
        hero1 = GameObject.Find("SavingSystem").GetComponent<SaveLoadScript>().hero1;
        hero2 = GameObject.Find("SavingSystem").GetComponent<SaveLoadScript>().hero2;
        hero3 = GameObject.Find("SavingSystem").GetComponent<SaveLoadScript>().hero3;
        PartySize = GameObject.Find("SavingSyster").GetComponent<SaveLoadScript>().PartySize;
        exitpos = GameObject.Find("SavingSyster").GetComponent<SaveLoadScript>().ExitPos;
        camerapos = GameObject.Find("SavingSyster").GetComponent<SaveLoadScript>().CameraPos;
        LevelName= GameObject.Find("SavingSyster").GetComponent<SaveLoadScript>().levelname;
        tipsON = false;
    }

    public void LootItems(List<Item> LootTable)
    {
        List<string> NameList = new List<string>();
        string NameItem;
        for (int i = 0; i < LootTable.Count; i++)
        {
            NameList.Add(LootTable[i].name);
        }

       

        NameItem = NameList[Random.Range(0, NameList.Count)];

        if (GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems.Count > 0)
        {
            bool wasAdded = false;
            for (int i = 0; i < GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems.Count; i++)
            {

                if (NameItem == GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems[i].name)
                {
                    GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems[i].quantity = GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems[i].quantity + 1;

                    wasAdded = true;



                }


            }
            if (!wasAdded && GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems[GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems.Count - 1].name != NameItem)
            {
                switch (NameItem)
                {
                    /* case "NameItem.name":
                     * {
                     *  GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems.Add(new Item(Name,desc,type,numbers,id,quantity));  
                     * }
                     * break;
                     * do kopiowania wzorek mam hihi

                     * */
                    case "MEGA HP potion":
                        {
                            GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems.Add(GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfAllItems[0]);
                        }
                        break;
                    case "Mana Potion":
                        {
                            GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems.Add(GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfAllItems[1]);
                        }
                        break;
                    case "Kill Potion":
                        {
                            GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems.Add(GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfAllItems[2]);
                        }
                        break;
                    case "Panda Drink":
                        {
                            GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems.Add(GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfAllItems[3]);
                        }
                        break;
                    case "Icky Slime":
                        {
                            GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems.Add(GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfAllItems[4]);
                        }
                        break;
                    case "Magic Sticker":
                        {
                            GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems.Add(GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfAllItems[5]);
                        }
                        break;
                    case "Bento from Fujisama":
                        {
                            GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems.Add(GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfAllItems[6]);
                        }
                        break;
                    case "Tomato Juice":
                        {
                            GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems.Add(GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfAllItems[7]);
                        }
                        break;
                    default:
                        Debug.Log("Item doesnt exist in database...");
                        break;
                }
            }
        }
        else
        {
            switch (NameItem)
            {
                /* case "NameItem.name":
                 * {
                 *  GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems.Add(new Item(Name,desc,type,numbers,id,quantity));  
                 * }
                 * break;
                 * do kopiowania wzorek mam hihi

                 * */
                case "MEGA HP potion":
                    {
                        GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems.Add(GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfAllItems[0]);
                    }
                    break;
                case "Mana Potion":
                    {
                        GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems.Add(GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfAllItems[1]);
                    }
                    break;
                case "Kill Potion":
                    {
                        GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems.Add(GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfAllItems[2]);
                    }
                    break;
                case "Panda Drink":
                    {
                        GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems.Add(GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfAllItems[3]);
                    }
                    break;
                case "Icky Slime":
                    {
                        GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems.Add(GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfAllItems[4]);
                    }
                    break;
                case "Magic Sticker":
                    {
                        GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems.Add(GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfAllItems[5]);
                    }
                    break;
                case "Bento from Fujisama":
                    {
                        GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems.Add(GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfAllItems[6]);
                    }
                    break;
                case "Tomato Juice":
                    {
                        GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems.Add(GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfAllItems[7]);
                    }
                    break;
                default:
                    Debug.Log("Item doesnt exist in database...");
                    break;
            }
        }
    }

}
