using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;

public class HeroFSM : MonoBehaviour
{
    public Hero hero;
    public SBattleStateFSM BSM;
    public float curHp;
    public float maxHp;
    float curExp;
    public float curMana;
    float maxMana;
    float dmgAtk;
    float reqExp;
    int level;
    string curHpString;
    string curManaString;
    float speed = 10;
    GameObject Stats;
    public GameObject HPLabel;
    public GameObject ManaLabel;
    public GameObject DmgTxt;
    public GameObject Me;
    public GameObject SkillPanel;
    public GameObject ActionPointsCounter;
    public int actionPoints;
    public float armorHero;
    public string statusHero;
    public int WaterBankStatus;
    public int FlameAwekingStatus;
    public int CallOfNatureStatus;
    public int WindsOfChangeStatus;
    public GameObject WaterSpecialPanel;
    public GameObject WaterSpecialStage1;
    public GameObject WaterSpecialStage2;
    public GameObject WaterSpecialStage3;
    public GameObject WaterSpecialStage4;
    
    public GameObject FireSpecialPanel;
    public GameObject FireSpecialStage0;
    public GameObject FireSpecialStage1;
    public GameObject FireSpecialStage2;
    public GameObject FireSpecialStage3;
    public GameObject FireSpecialStage4;

    public GameObject EarthSpecialPanel;
    public GameObject EarthSpecialStage_2;
    public GameObject EarthSpecialStage_1;
    public GameObject EarthSpecialStage0;
    public GameObject EarthSpecialStage1;
    public GameObject EarthSpecialStage2;

    public GameObject AirSpecialPanel;
    public GameObject AirSpecialStage1;
    public GameObject AirSpecialStage2;
    public GameObject AirSpecialStage3;
    public GameObject AirSpecialStage4;

    public GameObject target1;
    public GameObject target2;
    public GameObject target3;

    public List<GameObject> ListOfStatusIcons = new List<GameObject>(5);

    public int WaterBankUsageFlag;
    public int FireAweFlag;
    public int NatureSwingFlag;
    public int WindsChangeFlag;
    public int TurnCounter = 0;
    public float SpellAmp;
    public List<string> BuffList = new List<string>();
    public List<int> BuffTimersList = new List<int>();
    public List<string> DebuffList = new List<string>();
    public List<int> DebuffTimerList = new List<int>();
    public enum HeroStates
    {
        IDLE,
        WAIT,
        CHOOSING,
        ACTION,
        ANIMATION,
        DEAD,
        WIN
    }
    public HeroStates currentState;
    private bool actionStarted = false;
    private Rigidbody2D body;
    public GameObject EnemyToAttack;


    // Use this for initialization
    void Start()
    {
       
        Stats = GameObject.Find("StatsCarrier");
        currentState = HeroStates.IDLE;
        
        if (name == "PC")
        {
            maxHp = Stats.GetComponent<PlayerStats>().hero1.baseHP;
            maxMana = Stats.GetComponent<PlayerStats>().hero1.baseMP;
            curHp = maxHp;
            dmgAtk = Stats.GetComponent<PlayerStats>().hero1.attack;
            curExp = Stats.GetComponent<PlayerStats>().hero1.curExp;
            reqExp = Stats.GetComponent<PlayerStats>().hero1.reqExp;
            level = Stats.GetComponent<PlayerStats>().hero1.level;
            armorHero = Stats.GetComponent<PlayerStats>().hero1.armor;
            statusHero = Stats.GetComponent<PlayerStats>().hero1.statusHero;
            curMana = maxMana;
            actionPoints = 100;
            WaterBankStatus = 4;
        }
        if (name == "PC2")

        {
            maxHp = Stats.GetComponent<PlayerStats>().hero2.baseHP;
            maxMana = Stats.GetComponent<PlayerStats>().hero2.baseMP;
            curHp = maxHp;
            dmgAtk = Stats.GetComponent<PlayerStats>().hero2.attack;
            curExp = Stats.GetComponent<PlayerStats>().hero2.curExp;
            reqExp = Stats.GetComponent<PlayerStats>().hero2.reqExp;
            level = Stats.GetComponent<PlayerStats>().hero2.level;
            armorHero = Stats.GetComponent<PlayerStats>().hero2.armor;
            statusHero = Stats.GetComponent<PlayerStats>().hero2.statusHero;
            curMana = maxMana;
            actionPoints = 100;
            FlameAwekingStatus = 1;
        }
        if (name == "PC3")
        {
            maxHp = Stats.GetComponent<PlayerStats>().hero3.baseHP;
            maxMana = Stats.GetComponent<PlayerStats>().hero3.baseMP;
            curHp = maxHp;
            dmgAtk = Stats.GetComponent<PlayerStats>().hero3.attack;
            curExp = Stats.GetComponent<PlayerStats>().hero3.curExp;
            reqExp = Stats.GetComponent<PlayerStats>().hero3.reqExp;
            level = Stats.GetComponent<PlayerStats>().hero3.level;
            armorHero = Stats.GetComponent<PlayerStats>().hero3.armor;
            statusHero = Stats.GetComponent<PlayerStats>().hero3.statusHero;
            curMana = maxMana;
            actionPoints = 100;
            CallOfNatureStatus = 0;
        }

        SpellAmp = 0;


    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().OrderList[0] == "PC")
        {
            WaterSpecialPanel.SetActive(true);
            FireSpecialPanel.SetActive(false);
            EarthSpecialPanel.SetActive(false);
            if (GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().TurnCounter - TurnCounter >= 2)
            {
                WaterBankStatus = 1;
                if (GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().TurnCounter - TurnCounter >= 4)
                {
                    WaterBankStatus = 2;
                    if (GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().TurnCounter - TurnCounter >= 6)
                    {
                        WaterBankStatus = 3;
                        if (GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().TurnCounter - TurnCounter >= 8)
                        {
                            WaterBankStatus = 4;
                        }
                    }
                }
            }

            if (WaterBankStatus == 4)
            {
                WaterSpecialStage4.GetComponent<Button>().interactable = false;
                WaterSpecialStage3.GetComponent<Button>().interactable = false;
                WaterSpecialStage2.GetComponent<Button>().interactable = false;
                WaterSpecialStage1.GetComponent<Button>().interactable = false;
            }
            if (WaterBankStatus == 3)
            {
                Color usedStage = new Color(237, 52, 248);
                WaterSpecialStage4.GetComponent<Button>().interactable = true;
                WaterSpecialStage3.GetComponent<Button>().interactable = false;
                WaterSpecialStage2.GetComponent<Button>().interactable = false;
                WaterSpecialStage1.GetComponent<Button>().interactable = false;
            }
            if (WaterBankStatus == 2)
            {
                WaterSpecialStage4.GetComponent<Button>().interactable = true;
                WaterSpecialStage3.GetComponent<Button>().interactable = true;
                WaterSpecialStage2.GetComponent<Button>().interactable = false;
                WaterSpecialStage1.GetComponent<Button>().interactable = false;
            }
            if (WaterBankStatus == 1)
            {
                WaterSpecialStage4.GetComponent<Button>().interactable = true;
                WaterSpecialStage3.GetComponent<Button>().interactable = true;
                WaterSpecialStage2.GetComponent<Button>().interactable = true;
                WaterSpecialStage1.GetComponent<Button>().interactable = false;
            }
            if (WaterBankStatus == 0)
            {
                WaterSpecialStage4.GetComponent<Button>().interactable = true;
                WaterSpecialStage3.GetComponent<Button>().interactable = true;
                WaterSpecialStage2.GetComponent<Button>().interactable = true;
                WaterSpecialStage1.GetComponent<Button>().interactable = true;
            }
        }
        else
        {


            if (GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().OrderList[0] == "PC2")
            {
                WaterSpecialPanel.SetActive(false);
                FireSpecialPanel.SetActive(true);
                EarthSpecialPanel.SetActive(false);


                switch (FlameAwekingStatus)
                {
                    case 0:
                        {
                            FireSpecialStage0.GetComponent<Button>().interactable = true;
                            FireSpecialStage1.GetComponent<Button>().interactable = false;
                            FireSpecialStage2.GetComponent<Button>().interactable = false;
                            FireSpecialStage3.GetComponent<Button>().interactable = false;
                            FireSpecialStage4.GetComponent<Button>().interactable = false;
                        }
                        break;
                    case 1:
                        {
                            FireSpecialStage0.GetComponent<Button>().interactable = false;
                            FireSpecialStage1.GetComponent<Button>().interactable = true;
                            FireSpecialStage2.GetComponent<Button>().interactable = false;
                            FireSpecialStage3.GetComponent<Button>().interactable = false;
                            FireSpecialStage4.GetComponent<Button>().interactable = false;
                        }
                        break;
                    case 2:
                        {
                            FireSpecialStage0.GetComponent<Button>().interactable = false;
                            FireSpecialStage1.GetComponent<Button>().interactable = true;
                            FireSpecialStage2.GetComponent<Button>().interactable = true;
                            FireSpecialStage3.GetComponent<Button>().interactable = false;
                            FireSpecialStage4.GetComponent<Button>().interactable = false;
                        }
                        break;
                    case 3:
                        {
                            FireSpecialStage0.GetComponent<Button>().interactable = false;
                            FireSpecialStage1.GetComponent<Button>().interactable = true;
                            FireSpecialStage2.GetComponent<Button>().interactable = true;
                            FireSpecialStage3.GetComponent<Button>().interactable = true;
                            FireSpecialStage4.GetComponent<Button>().interactable = false;
                        }
                        break;
                    case 4:
                        {
                            FireSpecialStage0.GetComponent<Button>().interactable = false;
                            FireSpecialStage1.GetComponent<Button>().interactable = true;
                            FireSpecialStage2.GetComponent<Button>().interactable = true;
                            FireSpecialStage3.GetComponent<Button>().interactable = true;
                            FireSpecialStage4.GetComponent<Button>().interactable = true;
                        }
                        break;
                }
            }
            else
            {

                if (GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().OrderList[0] == "PC3")
                {
                    WaterSpecialPanel.SetActive(false);
                    FireSpecialPanel.SetActive(false);
                    EarthSpecialPanel.SetActive(true);



                    switch (CallOfNatureStatus)
                    {
                        case -2:
                            {
                                EarthSpecialStage0.GetComponent<Button>().interactable = true;
                                EarthSpecialStage_2.GetComponent<Button>().interactable = true;
                                EarthSpecialStage_1.GetComponent<Button>().interactable = true;
                                EarthSpecialStage1.GetComponent<Button>().interactable = false;
                                EarthSpecialStage2.GetComponent<Button>().interactable = false;
                            }
                            break;
                        case -1:
                            {
                                EarthSpecialStage0.GetComponent<Button>().interactable = true;
                                EarthSpecialStage_2.GetComponent<Button>().interactable = true;
                                EarthSpecialStage_1.GetComponent<Button>().interactable = false;
                                EarthSpecialStage1.GetComponent<Button>().interactable = false;
                                EarthSpecialStage2.GetComponent<Button>().interactable = false;
                            }
                            break;
                        case 0:
                            {
                                EarthSpecialStage0.GetComponent<Button>().interactable = true;
                                EarthSpecialStage_2.GetComponent<Button>().interactable = false;
                                EarthSpecialStage_1.GetComponent<Button>().interactable = false;
                                EarthSpecialStage1.GetComponent<Button>().interactable = false;
                                EarthSpecialStage2.GetComponent<Button>().interactable = false;
                            }
                            break;
                        case 1:
                            {
                                EarthSpecialStage0.GetComponent<Button>().interactable = true;
                                EarthSpecialStage_2.GetComponent<Button>().interactable = false;
                                EarthSpecialStage_1.GetComponent<Button>().interactable = false;
                                EarthSpecialStage1.GetComponent<Button>().interactable = true;
                                EarthSpecialStage2.GetComponent<Button>().interactable = false;
                            }
                            break;
                        case 2:
                            {
                                EarthSpecialStage0.GetComponent<Button>().interactable = true;
                                EarthSpecialStage_2.GetComponent<Button>().interactable = false;
                                EarthSpecialStage_1.GetComponent<Button>().interactable = false;
                                EarthSpecialStage1.GetComponent<Button>().interactable = true;
                                EarthSpecialStage2.GetComponent<Button>().interactable = true;
                            }
                            break;
                    }
                }
            }
        }
        //Buff Removal
        for(int z1 = 0; z1 < BuffTimersList.Count; z1++)
        {
            if(BuffTimersList[z1] == GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().TurnCounter)
            {
                if(BuffList[z1] == "Bento from Fujisama")
                {
                    armorHero = armorHero - 20;
                
                }
                if(BuffList[z1] == "Magic Sticker")
                {
                    SpellAmp = SpellAmp - 0.2f;
                }
                if(BuffList[z1] == "Haku")
                {
                    GameObject.Find("HeroSummonSpawnPoint").GetComponent<SpriteRenderer>().sprite = null; 
                    switch (CallOfNatureStatus)
                    {
                        case 0:
                            {
                                for (int b1 = 0; b1 < GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().HeroInCombat.Count; b1++)
                                {
                                    GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().HeroInCombat[b1].GetComponent<HeroFSM>().armorHero = GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().HeroInCombat[b1].GetComponent<HeroFSM>().armorHero - 5;

                                }
                            }
                            break;

                        case -1:
                            {
                                for (int b1 = 0; b1 < GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().HeroInCombat.Count; b1++)
                                {
                                    GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().HeroInCombat[b1].GetComponent<HeroFSM>().curHp = GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().HeroInCombat[b1].GetComponent<HeroFSM>().curHp - 50;
                                    GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().HeroInCombat[b1].GetComponent<HeroFSM>().maxHp = GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().HeroInCombat[b1].GetComponent<HeroFSM>().maxHp - 50;

                                }
                            }
                            break;
                        case -2:
                            {
                                for (int b1 = 0; b1 < GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().HeroInCombat.Count; b1++)
                                {
                                    GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().HeroInCombat[b1].GetComponent<HeroFSM>().curHp = GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().HeroInCombat[b1].GetComponent<HeroFSM>().curHp - 75;
                                    GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().HeroInCombat[b1].GetComponent<HeroFSM>().maxHp = GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().HeroInCombat[b1].GetComponent<HeroFSM>().maxHp - 75;

                                }
                            }
                            break;
                        case 1:
                            {
                                for (int b1 = 0; b1 < GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().HeroInCombat.Count; b1++)
                                {
                                    GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().HeroInCombat[b1].GetComponent<HeroFSM>().curHp = GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().HeroInCombat[b1].GetComponent<HeroFSM>().curHp - 50;
                                    GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().HeroInCombat[b1].GetComponent<HeroFSM>().maxHp = GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().HeroInCombat[b1].GetComponent<HeroFSM>().maxHp - 50;

                                }
                            }
                            break;
                        case 2:
                            {
                                for (int b1 = 0; b1 < GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().HeroInCombat.Count; b1++)
                                {
                                    GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().HeroInCombat[b1].GetComponent<HeroFSM>().curHp = GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().HeroInCombat[b1].GetComponent<HeroFSM>().curHp - 50;
                                    GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().HeroInCombat[b1].GetComponent<HeroFSM>().maxHp = GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().HeroInCombat[b1].GetComponent<HeroFSM>().maxHp - 50;

                                }
                            }
                            break;
                    }
                }
                BuffList.RemoveAt(z1);
                BuffTimersList.RemoveAt(z1);
                ListOfStatusIcons[z1].GetComponent<SpriteRenderer>().sprite = null;
            }
        }

        if(BuffList.Count>0)
        {
            //Resevred for time based buffs
         
        }

        Text CurrentHp = HPLabel.GetComponent<Text>();
        Text CurrentMana = ManaLabel.GetComponent<Text>();
        Text CurrentActionPonts = ActionPointsCounter.GetComponent<Text>();
        curHpString = curHp.ToString("0.0");
        curManaString = curMana.ToString("0.0");
        string curActionString = actionPoints.ToString("0.0");
        CurrentHp.text = curHpString;
        CurrentMana.text = curManaString;
        CurrentActionPonts.text = curActionString;
        /*      if (curExp >= reqExp)
              {
                  level = level + 1;
                  curExp = curExp - reqExp;
                  curHp = maxHp;
                  curMana = maxMana; 
              } */
        Debug.Log(currentState);
        switch (currentState)
        {
            case (HeroStates.IDLE):
             

                    CurrentHp.text = curHpString;
                //    BSM.currentState = SBattleStateFSM.BattleStates.ACTIONS;
                    currentState = HeroStates.IDLE;
                
                break;
            case (HeroStates.WAIT):
              

                    CurrentHp.text = curHpString;
                    BSM.currentState = SBattleStateFSM.BattleStates.ACTIONS;
                    currentState = HeroStates.IDLE;
               
                break;
            case (HeroStates.CHOOSING):
                // ChooseAction();
                if(statusHero == "Fear")
                {
                    actionPoints = 0;
                    currentState = HeroStates.ANIMATION;
                    statusHero = "normal";
                }
                if (Input.GetKeyDown(KeyCode.Space))
                {


                    currentState = HeroStates.ACTION;

                }


                //       curHp = curHp - 1;
                break;
            case (HeroStates.ACTION):

                doDmg();
                currentState = HeroStates.ANIMATION;
                break;




            case (HeroStates.ANIMATION):
                body = GetComponent<Rigidbody2D>();
                float step = speed * Time.deltaTime;

                Vector2 targetpoint = new Vector2(body.position.x, body.position.y);
                Vector2 targetpoint2 = new Vector2(body.position.x + 25, body.position.y);
                //  body.position = new Vector2(body.position.x + 10, body.position.y);
                //    body.MovePosition(body.position * step);

                //   body.position = new Vector2(body.position.x - 10, body.position.y);
                //  body.MovePosition(body.position);



                //  body.velocity = new Vector2(body.position.x * 1, body.position.y);
                transform.position = Vector2.MoveTowards(targetpoint, targetpoint2, 250 * Time.deltaTime);

                body.MovePosition(targetpoint);

                for(int b2 = 0; b2 < DebuffList.Count;b2++)
                {
                    switch(DebuffList[b2])
                    {
                        case "Poison": TakeDmg(curHp * 0.2f);
                            break;
                    }

                }

                if (actionPoints <= 0)
                {
                    BSM.currentState = SBattleStateFSM.BattleStates.WAIT;
                    currentState = HeroStates.IDLE;
                    actionPoints = 100;
                    TurnCounter = 0;
               }
                else
               {
                   currentState = HeroStates.CHOOSING;
               }




                break;
            case (HeroStates.DEAD):
                BSM.GetComponent<SBattleStateFSM>().HeroInCombat.Clear();
                BSM.KillConfHero(name);
                HPLabel.GetComponent<Text>().text = "unconsious";
                //   NameLabel.SetActive(false);
                ManaLabel.GetComponent<Text>().text = "unconsious";
                //     BSM.currentState = SBattleStateFSM.BattleStates.LOSE;
                currentState = HeroStates.IDLE;
                Destroy(GetComponent<SpriteRenderer>());
             //   Destroy(this);
               
                break;

        }
    }

    public void SkipBtn()
    {
        BSM.currentState = SBattleStateFSM.BattleStates.WAIT;
        currentState = HeroStates.IDLE;
        SkillPanel.SetActive(false);
    }

    public void AttackBtn()
    {

        currentState = HeroStates.ACTION;
    }


    public void doDmg()
    {
        dmgAtk = hero.attack * 1;
        EnemyToAttack.GetComponent<EnemyFSM>().TakeDmg(dmgAtk,"neutral");
        GetComponent<SBattleStateFSM>().Battlelog.GetComponentInChildren<Text>().text = "Janusz melee hits " + EnemyToAttack.GetComponent<EnemyFSM>().NPCname + " for " + dmgAtk + " damage ";
        actionPoints = actionPoints - 100;
        BSM.InfoPanel2.GetComponent<Text>().text = "Melee";
        currentState = HeroStates.ANIMATION;
    }

    public void TakeHeal(float getHealAmount)
    {

        curHp = curHp + getHealAmount;

        if (curHp > maxHp)
        {
            curHp = maxHp;
        }
    }

    public void TakeMana(float getManaAmount)
    {
        curMana = curMana + getManaAmount;
        if(curMana > maxMana)
        {
            curMana = maxMana;
        }
    }

    public void TakeBuff()
    {
        //placeholder
    }

    public void CostInMana(float getCost)
    {
        if (curMana > getCost)
        {


            curMana = curMana - getCost;

        }

    }


    public void UseSpell(float getDamageAmoumt, float getCost, string getType, string name,string element)
    {
        if(statusHero == "blind")
        {
            getDamageAmoumt = 0;
            statusHero = "normal";
        }
        Resources.LoadAll("Graphics/SpellEffects/");
        if (element == "Water")
        {
            if (WaterBankUsageFlag == 4)
            {
                getDamageAmoumt = getDamageAmoumt * 2;
            }
            if (WaterBankUsageFlag == 3)
            {
                getDamageAmoumt = getDamageAmoumt * 1.75f;
            }
            if (WaterBankUsageFlag == 2)
            {
                getDamageAmoumt = getDamageAmoumt * 1.5f;
            }
            if (WaterBankUsageFlag == 1)
            {
                getDamageAmoumt = getDamageAmoumt * 1.25f;
            }
        }
        if(element == "Fire"  && getType =="Damage")
        {
            if (FlameAwekingStatus < 4)
            {

                FlameAwekingStatus = FlameAwekingStatus + 1;
            }
            else
            {
                FlameAwekingStatus = 0;
            }


            switch(FlameAwekingStatus)
            {
                case 0: getDamageAmoumt = getDamageAmoumt * 0.9f;
                    break;
                case 1: getDamageAmoumt = getDamageAmoumt + (getDamageAmoumt * 0.1f);
                    break;
                case 2: getDamageAmoumt = getDamageAmoumt + (getDamageAmoumt * 0.2f);
                    break;
                case 3: getDamageAmoumt = getDamageAmoumt + (getDamageAmoumt * 0.3f);
                    break;
                case 4: getDamageAmoumt = getDamageAmoumt + (getDamageAmoumt * 0.4f);
                    break;
            }
        }

        if(element == "Earth")
        {
            switch(CallOfNatureStatus)
            {
                case -2:
                    {
                        if(getType == "Heal")
                        {
                            getDamageAmoumt = getDamageAmoumt + (getDamageAmoumt * 0.3f);
                        }
                        else
                        {
                            if(getType == "Damage")
                            {
                                getDamageAmoumt = getDamageAmoumt * 0.5f;
                            }
                        }
                    }
                    break;
                case -1:
                    {
                        if (getType == "Heal")
                        {
                            getDamageAmoumt = getDamageAmoumt + (getDamageAmoumt * 0.1f);
                        }
                        else
                        {
                            if (getType == "Damage")
                            {
                                getDamageAmoumt = getDamageAmoumt * 0.8f;
                            }
                        }
                    }
                    break;
                case 1:
                    {
                        if (getType == "Heal")
                        {
                            getDamageAmoumt = getDamageAmoumt  * 0.8f;
                        }
                        else
                        {
                            if (getType == "Damage")
                            {
                                getDamageAmoumt = getDamageAmoumt +(getDamageAmoumt * 0.1f);
                            }
                        }
                    }
                    break;
                case 2:
                    {
                        if (getType == "Heal")
                        {
                            getDamageAmoumt = getDamageAmoumt * 0.5f;
                        }
                        else
                        {
                            if (getType == "Damage")
                            {
                                getDamageAmoumt = getDamageAmoumt + (getDamageAmoumt * 0.3f);
                            }
                        }
                    }
                    break;

            }
        }
       
        if (getType == "Mana")
        {
            if (element == "Earth")
            {
                if (CallOfNatureStatus != -2)
                {
                    CallOfNatureStatus = CallOfNatureStatus - 1;
                }
                else
                {
                    CallOfNatureStatus = -2;
                }
            }
            curMana = curMana - getCost;
            for (int b2 = 0; b2 < GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().EnemyInCombat.Count; b2++)
            {
                GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().EnemyInCombat[b2].GetComponent<EnemyFSM>().SupportMoveDetector(gameObject);
            }

            //curMana = curMana + getDamageAmoumt;
            EnemyToAttack.GetComponent<HeroFSM>().TakeMana(getDamageAmoumt);
            DmgTxt.SetActive(true);
            Vector3 moveUp = new Vector3(0, 9f, 0);
            DmgTxt.GetComponent<Transform>().position = Me.GetComponent<Transform>().position + moveUp;
            DmgTxt.GetComponent<Text>().text = (getDamageAmoumt).ToString("0.0") + " Mana";
           
            SkillPanel.SetActive(false);
            StartCoroutine(FadeTime());

           
        }

        if (getType == "Heal")
        {
            if (curMana > getCost && name != "Panda Drink")
            {
            
                if (element == "Earth")
                {
                    if (CallOfNatureStatus != -2)
                    {
                        CallOfNatureStatus = CallOfNatureStatus - 1;
                    }
                    else
                    {
                        CallOfNatureStatus = -2;
                    }
                }
                curMana = curMana - getCost;
                /* curHp = curHp + getDamageAmoumt;
                if (curHp > maxHp)
                {
                    curHp = maxHp;
                } */
                
                EnemyToAttack.GetComponent<HeroFSM>().TakeHeal(getDamageAmoumt);
                DmgTxt.SetActive(true);
                Vector3 moveUp = new Vector3(0, 9f, 0);
                DmgTxt.GetComponent<Transform>().position = Me.GetComponent<Transform>().position + moveUp;
                DmgTxt.GetComponent<Text>().text = "+" + (getDamageAmoumt).ToString("0.0") + " HP";
               
              
                SkillPanel.SetActive(false);
                StartCoroutine(FadeTime());

            }
            else
            {
                if(name == "Panda Drink ")
                {
                    if (name == "Panda Drink")
                    {
                        GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().HeroRess();
                    }
                }
            }
            for (int b2 = 0; b2 < GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().EnemyInCombat.Count; b2++)
            {
                GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().EnemyInCombat[b2].GetComponent<EnemyFSM>().SupportMoveDetector(gameObject);
            }
        }
        if (getType == "Damage")
        {
            if (element == "Earth")
            {
                if (CallOfNatureStatus != 2)
                {
                    CallOfNatureStatus = CallOfNatureStatus + 1;
                }
                else
                {
                    CallOfNatureStatus = 2;
                }
            }
            if (curMana > getCost)
            {
                curMana = curMana - getCost;
                EnemyToAttack.GetComponent<EnemyFSM>().TakeDmg(getDamageAmoumt + (getDamageAmoumt + (getDamageAmoumt * SpellAmp)),element);
            }

            if(name == "Mad Man Dinner")
            {
                curHp = curHp + getDamageAmoumt/2;
                if (curHp > maxHp)
                {
                    curHp = maxHp;
                }
            }
            if (name == "Morning Wave")
            {
                for(int mw = 0; mw<GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().EnemyInCombat.Count;mw++)
                {
                    if (GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().EnemyInCombat[mw] != EnemyToAttack)
                    {
                        GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().EnemyInCombat[mw].GetComponent<EnemyFSM>().TakeDmg((getDamageAmoumt + (getDamageAmoumt + (getDamageAmoumt * SpellAmp)) / 3), element);

                    }
                }
            }

            if(name == "Fading Embers")
            {
                if (EnemyToAttack.GetComponent<EnemyFSM>().status == "Burning")
                {
                    curMana = curMana + 100;
                    if(curMana > maxMana)
                    {
                        curMana = maxMana;
                    }
                    EnemyToAttack.GetComponent<EnemyFSM>().status = "normal";
                }
               
            }

            if(name == "Leafs dash")
            {
                armorHero = armorHero + 15;
                if(armorHero > 20)
                {
                    armorHero = 20;
                }
            }



            if (name == "Mystic Eye" && curMana >= 1)
            {
                for (int x = 0; x < BSM.EnemyInCombatArray.Length;x++) 
                {
                    SelectTarget(BSM.EnemyInCombatArray[x].name);
                    EnemyToAttack.GetComponent<EnemyFSM>().TakeDmg(getDamageAmoumt,element);
                }
                curMana = (float)(curMana - (curMana * 0.75));
            }

            WaterBankUsageFlag = 0;

        }
        if (getType == "Buff")
        {
            Debug.Log(name + " test testy");
            switch (name)
            {
                case "Magic Sticker":
                    {

                        for (int z2 = 0; z2 < BuffList.Count; z2++)
                        {
                            if (BuffList[z2] == name)
                            {
                                BuffList.RemoveAt(z2);
                            }
                        }
                        EnemyToAttack.GetComponent<HeroFSM>().SpellAmp = EnemyToAttack.GetComponent<HeroFSM>().SpellAmp + 0.2f;
                        BuffList.Add(name);
                        BuffTimersList.Add(GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().TurnCounter + 5);
                        for (int z2 = 0; z2 < ListOfStatusIcons.Count; z2++)
                        {
                            if (ListOfStatusIcons[z2].GetComponent<SpriteRenderer>().sprite == null)
                            {
                                ListOfStatusIcons[z2].GetComponent<SpriteRenderer>().sprite = GameObject.Find("SpellAmpBuff").GetComponent<SpriteRenderer>().sprite;
                                break;
                            }
                            
                        }

                    }
                    break;
                case "Bento from Fujisama":
                    {
                        for (int z2 = 0; z2 < BuffList.Count; z2++)
                        {
                            if (BuffList[z2] == name)
                            {
                                BuffList.RemoveAt(z2);
                            }
                        }
                        EnemyToAttack.GetComponent<HeroFSM>().armorHero = EnemyToAttack.GetComponent<HeroFSM>().armorHero + 20;
                        BuffList.Add(name);
                        BuffTimersList.Add(GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().TurnCounter + 10);
                        for (int z2 = 0; z2 < ListOfStatusIcons.Count; z2++)
                        {
                            if (ListOfStatusIcons[z2].GetComponent<SpriteRenderer>().sprite == null)
                            {
                                ListOfStatusIcons[z2].GetComponent<SpriteRenderer>().sprite = GameObject.Find("DefenseBuff").GetComponent<SpriteRenderer>().sprite;
                                break;
                            }
                            
                        }
                    }
                    break;
                case "Tomato Juice":
                    {
                        for (int z2 = 0; z2 < BuffList.Count; z2++)
                        {
                            if (BuffList[z2] == name)
                            {
                                BuffList.RemoveAt(z2);
                            }
                        }
                        
                        BuffList.Add(name);
                        BuffTimersList.Add(GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().TurnCounter + 0);
                        for (int z2 = 0; z2 < ListOfStatusIcons.Count; z2++)
                        {
                            if (ListOfStatusIcons[z2].GetComponent<SpriteRenderer>().sprite == null)
                            {
                                ListOfStatusIcons[z2].GetComponent<SpriteRenderer>().sprite = GameObject.Find("DefenseBuff").GetComponent<SpriteRenderer>().sprite;
                                break;
                            }

                        }
                        DebuffList.Clear();
                        DebuffTimerList.Clear();
                        for(int z3 = 0; z3 < ListOfStatusIcons.Count; z3++)
                        {
                            ListOfStatusIcons[z3].GetComponent<SpriteRenderer>().sprite = null;
                        }
                    }
                    break;
                default:
                    {
                        Debug.Log("Buff ID : not found");
                    }
                    break;
            }
            for (int b2 = 0; b2 < GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().EnemyInCombat.Count; b2++)
            {
                GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().EnemyInCombat[b2].GetComponent<EnemyFSM>().SupportMoveDetector(gameObject);
            }
        }


        if (getType == "Debuff")
        {
            Debug.Log(name + " test testy");
            if (name == "Icky Slime")
                    {
                for (int z2 = 0; z2 < BuffList.Count; z2++)
                {
                    if (DebuffList[z2] == name)
                    {
                        DebuffList.RemoveAt(z2);
                    }
                }

                EnemyToAttack.GetComponent<EnemyFSM>().DebuffList.Add(name);
                EnemyToAttack.GetComponent<EnemyFSM>().DebuffTimerList.Add((GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().TurnCounter + 5));



                    }
            if(name =="Poison" && EnemyToAttack == gameObject)
            {
                for (int z2 = 0; z2 < BuffList.Count; z2++)
                {
                    if (DebuffList[z2] == name)
                    {
                        DebuffList.RemoveAt(z2);
                    }
                }

                EnemyToAttack.GetComponent<HeroFSM>().DebuffList.Add(name);
                EnemyToAttack.GetComponent<HeroFSM>().DebuffTimerList.Add((GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().TurnCounter + 3));
                for (int z2 = 0; z2 < ListOfStatusIcons.Count; z2++)
                {
                    if (ListOfStatusIcons[z2].GetComponent<SpriteRenderer>().sprite == null)
                    {
                        ListOfStatusIcons[z2].GetComponent<SpriteRenderer>().sprite = GameObject.Find("PoisonDebuff").GetComponent<SpriteRenderer>().sprite;
                        break;
                    }

                }
            }
                  
            
        }

        if(getType == "Summon")
        {
            Debug.Log("Summoning ");
            if(name == "Haku")
            {   if (BuffList.Contains("Haku"))
                {
                    GameObject.Find("HeroSummonSpawnPoint").GetComponent<SpriteRenderer>().sprite = GameObject.Find("summonEarth1Concept1").GetComponent<SpriteRenderer>().sprite;
                }
            
                else
                {
                    GameObject.Find("HeroSummonSpawnPoint").AddComponent<SpriteRenderer>().sprite = GameObject.Find("summonEarth1Concept1").GetComponent<SpriteRenderer>().sprite;
                }
                    for (int z2 = 0; z2 < BuffList.Count; z2++)
                {
                    if (BuffList[z2] == name)
                    {
                        BuffList.RemoveAt(z2);
                    }
                }
               
                BuffList.Add(name);
                BuffTimersList.Add(GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().TurnCounter + 5);
             
                switch (CallOfNatureStatus)
                {
                    case 0:
                        {
                            for(int b1 = 0; b1< GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().HeroInCombat.Count; b1++)
                            {
                                GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().HeroInCombat[b1].GetComponent<HeroFSM>().armorHero = GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().HeroInCombat[b1].GetComponent<HeroFSM>().armorHero + 5;

                            }
                            for(int b2 = 0; b2<GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().EnemyInCombat.Count; b2++)
                            {
                                GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().EnemyInCombat[b2].GetComponent<EnemyFSM>().SupportMoveDetector(gameObject);
                            }
                        }
                    break;

                    case -1:
                        {
                            for (int b1 = 0; b1 < GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().HeroInCombat.Count; b1++)
                            {
                                GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().HeroInCombat[b1].GetComponent<HeroFSM>().curHp = GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().HeroInCombat[b1].GetComponent<HeroFSM>().curHp + 50;
                                GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().HeroInCombat[b1].GetComponent<HeroFSM>().maxHp = GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().HeroInCombat[b1].GetComponent<HeroFSM>().maxHp + 50;
                                for (int z2 = 0; z2 < ListOfStatusIcons.Count; z2++)
                                {
                                    if (ListOfStatusIcons[z2].GetComponent<SpriteRenderer>().sprite == null)
                                    {
                                        ListOfStatusIcons[z2].GetComponent<SpriteRenderer>().sprite = GameObject.Find("HpBuff").GetComponent<SpriteRenderer>().sprite;
                                        break;
                                    }
                                    
                                }

                            }
                            for (int b2 = 0; b2 < GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().EnemyInCombat.Count; b2++)
                            {
                                GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().EnemyInCombat[b2].GetComponent<EnemyFSM>().SupportMoveDetector(gameObject);
                            }
                        }
                        break;
                    case -2:
                        {
                            for (int b1 = 0; b1 < GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().HeroInCombat.Count; b1++)
                            {
                                GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().HeroInCombat[b1].GetComponent<HeroFSM>().curHp = GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().HeroInCombat[b1].GetComponent<HeroFSM>().curHp + 75;
                                GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().HeroInCombat[b1].GetComponent<HeroFSM>().maxHp = GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().HeroInCombat[b1].GetComponent<HeroFSM>().maxHp + 75;
                                for (int z2 = 0; z2 < ListOfStatusIcons.Count; z2++)
                                {
                                    if (ListOfStatusIcons[z2].GetComponent<SpriteRenderer>().sprite == null)
                                    {
                                        ListOfStatusIcons[z2].GetComponent<SpriteRenderer>().sprite = GameObject.Find("HpBuff").GetComponent<SpriteRenderer>().sprite;
                                        break;
                                    }
                                    
                                }
                            }
                            for (int b2 = 0; b2 < GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().EnemyInCombat.Count; b2++)
                            {
                                GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().EnemyInCombat[b2].GetComponent<EnemyFSM>().SupportMoveDetector(gameObject);
                            }
                        }
                        break;
                    case 1:
                        {
                            for (int b1 = 0; b1 < GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().HeroInCombat.Count; b1++)
                            {
                                GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().HeroInCombat[b1].GetComponent<HeroFSM>().curHp = GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().HeroInCombat[b1].GetComponent<HeroFSM>().curHp + 10;
                                GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().HeroInCombat[b1].GetComponent<HeroFSM>().maxHp = GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().HeroInCombat[b1].GetComponent<HeroFSM>().maxHp + 10;
                                GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().EnemyInCombat[Random.Range(0, GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().EnemyInCombat.Count - 1)].GetComponent<EnemyFSM>().TakeDmg(50,"Earth");
                                

                            }
                        }
                        break;
                    case 2:
                        {
                            for (int b1 = 0; b1 < GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().HeroInCombat.Count; b1++)
                            {
                                GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().HeroInCombat[b1].GetComponent<HeroFSM>().curHp = GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().HeroInCombat[b1].GetComponent<HeroFSM>().curHp + 10;
                                GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().HeroInCombat[b1].GetComponent<HeroFSM>().maxHp = GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().HeroInCombat[b1].GetComponent<HeroFSM>().maxHp + 10;
                                GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().EnemyInCombat[Random.Range(0, GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().EnemyInCombat.Count - 1)].GetComponent<EnemyFSM>().TakeDmg(100, "Earth");
                             
                            }
                        }
                        break;
                }
            }
        }
        BSM.InfoPanel2.GetComponent<Text>().text = BSM.InfoPanel2.GetComponent<Text>().text + name;
        SkillPanel.SetActive(false);

    }


    public void WaterSpecialUsage()
    {
        if (TurnCounter == 0)
        {
            switch (WaterBankStatus)
            {
                case 4:
                    WaterBankUsageFlag = 4;
                    break;
                case 3:
                    WaterBankUsageFlag = 3;
                    break;
                case 2:
                    WaterBankUsageFlag = 2;
                    break;
                case 1:
                    WaterBankUsageFlag = 1;
                    break;

            }
            WaterBankStatus = 0;
            TurnCounter = GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().TurnCounter;
        }


    }
    public void TakeDmg(float getDamageAmount)
    {
        getDamageAmount = getDamageAmount - armorHero;
        curHp = curHp - getDamageAmount;
        DmgTxt.SetActive(true);
        Vector3 moveUp = new Vector3(0, 9f, 0);
        DmgTxt.GetComponent<Transform>().position = Me.GetComponent<Transform>().position + moveUp;
        DmgTxt.GetComponent<Text>().text = (getDamageAmount * -1).ToString("0.0") + " HP";
        StartCoroutine(FadeTime());
        if (curHp <= 0)
        {
            currentState = HeroStates.DEAD;
        }
    }

   
    public void SelectTarget(string TargetName)
    {
        EnemyToAttack = GameObject.Find(TargetName);
        //  currentState = HeroStates.CHOOSING;
    }

    public void ExpGain(float getExpAmount)
    {
        curExp = curExp + getExpAmount;
    }

    public void EscapeTry()
    {
        int Chance = Random.Range(1,10);
        if(Chance % 3 == 0)
        {
            Stats.GetComponent<PlayerStats>().EscapeBattle();
        }
        else
        {
            BSM.currentState = SBattleStateFSM.BattleStates.WAIT;
            currentState = HeroStates.IDLE;
        }
        SkillPanel.SetActive(false);
        
    }

    public void SaveGains()
    {
        if (name == "PC")
        {
            Stats.GetComponent<PlayerStats>().hero1.curExp = (int)curExp;
            Stats.GetComponent<PlayerStats>().hero1.level = level;
        }

        if (name == "PC2")
        {
            Stats.GetComponent<PlayerStats>().hero2.curExp = (int)curExp;
            Stats.GetComponent<PlayerStats>().hero2.level = level;
        }

        if (name == "PC3")

        {
            Stats.GetComponent<PlayerStats>().hero2.curExp = (int)curExp;
            Stats.GetComponent<PlayerStats>().hero2.level = level;
        }

    }
    IEnumerator Timer()
    {
        yield return 0;
    }

    IEnumerator FadeTime()
    {
        yield return new WaitForSeconds(5f);
        DmgTxt.SetActive(false);
    }
}
