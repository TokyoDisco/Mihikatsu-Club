using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Linq;

public class EnemyFSM : MonoBehaviour
{
    public EnemyBase enemy;
    public SBattleStateFSM BSM;
    public IEnumerator waitForAni;
    public float curHp;
    public float curMana;
    public float dmgAtk;
    public string NPCname;
    public string TypeOfEnemy;
    public int BehaviourSet;
    public int level;
    string curHpString;
    string curManaString;
    float speed = 10;
    public List<GameObject> HPLabelList;
    public List<GameObject> ManaLabelList;
    public List<GameObject> NameLabelList;
    public List<GameObject> ListOfAllStatusIcons;
    public List<GameObject> ListOfSingleStatusIcons;
    private List<string> NameList = new List<string>();
    private GameObject HpLabel;
    private GameObject ManaLabel;
    private GameObject NameLabel;
    private Text CurrentHp;
    private Text CurrentMana;
    private bool DoubleAttackTrigger;
    public float armor;
    public string element;
    public string status;
    public GameObject Me;
    public bool elita;
    public bool boss;
    public int actionPoints;
    public  bool attackAnimDone = false;
    public GameObject dmgTakeTxt;
    int statusCounter = 0;
    public float BullyThreshhold;
    public GameObject BullyVictim;
    public float VictimDmg;
    public List<float> Values = new List<float>();
    public int Hero1SupportPoints = 0;
    public int Hero2SupportPoints = 0;
    public int Hero3SupportPoints = 0;

    public float Hero1DmgPoint = 0;
    public float Hero2DmgPoint = 0;
    public float Hero3DmgPoint = 0;

    public List<Item> LootTable1 = new List<Item>();
    public List<Item> LootTable2 = new List<Item>();
    public List<Item> LootTable3 = new List<Item>();

    public enum EnemyStates
    {
        IDLE,
        WAIT,
        CHOOSING,
        ACTION,
        ANIMATION,
        DEAD
    }
    //Variables
    public EnemyStates currentState;
    private bool actionStarted = false;
    public GameObject HeroToAttack;
    public HeroFSM HSM;
    public Vector3 oriPos;
    private Rigidbody2D body;

    public List<string> BuffList = new List<string>();
    public List<int> BuffTimerList = new List<int>();
    public List<string> DebuffList = new List<string>();
    public List<int> DebuffTimerList = new List<int>();
    
    public List<string> ZombieNameList;
    public List<string> RatNameList;
    public List<string> BlobsNameList;

    public List<string> ForestFriendsList;

    // Use this for initialization
    void Start()
    {
        LootTable1.Add(GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfAllItems[0]);
        LootTable1.Add(GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfAllItems[1]);

        LootTable2.Add(GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfAllItems[0]);
        LootTable2.Add(GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfAllItems[1]);
        LootTable2.Add(GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfAllItems[3]);
        LootTable2.Add(GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfAllItems[4]);
        LootTable2.Add(GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfAllItems[5]);
        LootTable2.Add(GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfAllItems[6]);
        LootTable2.Add(GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfAllItems[7]);

        LootTable1 = GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfAllItems;

        ZombieNameList.Add("Zombie Jack");
        ZombieNameList.Add("Zombie Jack");
        ZombieNameList.Add("Zombie Lucky");
        ZombieNameList.Add("Zombie Happy");
        ZombieNameList.Add("Zombie Uza");
        ZombieNameList.Add("Zombie Busu");
        ZombieNameList.Add("Zombie Tokyo");
        ZombieNameList.Add("Zombie Pocky");

        RatNameList.Add("Rattatou");
        RatNameList.Add("King of Sewer");
        RatNameList.Add("Cheese Lord");
        RatNameList.Add("Venoumous Micky");
        RatNameList.Add("Dirty water Guardian");

        BlobsNameList.Add("Bloby");
        BlobsNameList.Add("Blob Things");
        BlobsNameList.Add("Bloberto");
        BlobsNameList.Add("Blobiush");
        BlobsNameList.Add("Bloberina");
        BlobsNameList.Add("Lurking under Sink");

        ForestFriendsList.Add("Leavty");
        ForestFriendsList.Add("Iron Bark");
        ForestFriendsList.Add("Meshi Meshi");
        ForestFriendsList.Add("Bambi");
        ForestFriendsList.Add("Owls Watcher");
        ForestFriendsList.Add("Sunflower");
        
        oriPos = GetComponent<Transform>().position;
        actionPoints = 100;
        
        currentState = EnemyStates.IDLE;
        level = UnityEngine.Random.Range(GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero1.level, GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero1.level + 2);
        dmgAtk = enemy.attack + (level * (0.2f*enemy.attack));
        curHp = enemy.baseHP + (level * (0.2f * enemy.baseHP));
        curMana = enemy.baseMP + (level * (0.2f * enemy.baseMP)); 
        element = enemy.element;
        status = enemy.Status;
        armor = enemy.Armor + (level * (0.2f * enemy.Armor)) ;
        BullyThreshhold = (curHp / 2);
        Hero1SupportPoints = 0;
        Hero2SupportPoints = 0;
        Hero3SupportPoints = 0;
        DoubleAttackTrigger = false;
        switch (gameObject.GetComponent<SpriteRenderer>().sprite.name)
        {
            case "MummyEnemyidle1":
                {
                    TypeOfEnemy = "Zombie";
                    
                    BehaviourSet = Random.Range(0,2);
                    NameList = ZombieNameList;
                }
                break;
            case "mummyenemy_elite":
                {
                    TypeOfEnemy = "Zombie";
                    BehaviourSet = 1;
                    NameList = ZombieNameList;
                }
                break;
            case "BasketElemental":
                {
                    TypeOfEnemy = "Tutorial_1_Boss";
                    BehaviourSet = 01;
                   
                }
                break;
            case "ratConcept1":
                {
                    TypeOfEnemy = "Rat";
                    BehaviourSet = 1;
                    NameList = RatNameList;
                }
                break;
            case "RatWebElite":
                {
                    TypeOfEnemy = "RatWeb";
                    BehaviourSet = 1;
                    NameList = RatNameList;
                }
                break;
            case "RatBloodPoisonElite":
                {
                    TypeOfEnemy = "RatBlood";
                    BehaviourSet = 1;
                    NameList = RatNameList;
                }
                break;

            case "PoisonBlobConcept":
                {
                    TypeOfEnemy = "PoisonBlob";
                    BehaviourSet = 5;
                    NameList = BlobsNameList;
                }
                break;
            case "PoisonBlobEliteConcept":
                {
                    TypeOfEnemy = "PoisonBlob";
                    BehaviourSet = 5;
                    NameList = BlobsNameList;
                }
                break;

            case "rooots2":
                {
                    TypeOfEnemy = "DevilRoots";
                    BehaviourSet = 2;
                    NameList = ForestFriendsList;
                }
                break;
            case "RatHauntedBoss":
                {
                    TypeOfEnemy = "RatBoss";
                    BehaviourSet = 6;
                    NameList = RatNameList;
                }
                break;
          

        }

        switch(TypeOfEnemy)
        {
            case "Rat":
                curHp = curHp - (curHp * 0.25f);
                dmgAtk = dmgAtk + (dmgAtk * 0.5f);
                break;
            case "RatWeb":
                curHp = curHp - (curHp * 0.1f);
                dmgAtk = dmgAtk + (dmgAtk * 0.2f);
                curMana = curMana * 7;
                break;
            case "RatBlood":
                curHp = curHp - (curHp * 0.5f);
                dmgAtk = dmgAtk + (dmgAtk * 0.25f);
                curMana = curMana + (curMana * 5);
                break;
            
            case "PoisonBlob":
                curHp = curHp + (curHp * 3);
                dmgAtk = dmgAtk - (dmgAtk * 0.75f);
                break;
            case "DevilRoots":
                curHp = curHp / 2;
                dmgAtk = dmgAtk + (dmgAtk * 0.25f);
                break;
        }
       
        string name = Me.name;
        if (name == "Enemy1")
        {
            HpLabel = HPLabelList[0];
            ManaLabel = ManaLabelList[0];
            NameLabel = NameLabelList[0];
            ListOfSingleStatusIcons.Add(ListOfAllStatusIcons[0]);
            ListOfSingleStatusIcons.Add(ListOfAllStatusIcons[1]);
            ListOfSingleStatusIcons.Add(ListOfAllStatusIcons[2]);
            ListOfSingleStatusIcons.Add(ListOfAllStatusIcons[3]);
            ListOfSingleStatusIcons.Add(ListOfAllStatusIcons[4]);
        }

        if (name == "Enemy2")
        {
            HpLabel = HPLabelList[1];
            ManaLabel = ManaLabelList[1];
            NameLabel = NameLabelList[1];
            ListOfSingleStatusIcons.Add(ListOfAllStatusIcons[5]);
            ListOfSingleStatusIcons.Add(ListOfAllStatusIcons[6]);
            ListOfSingleStatusIcons.Add(ListOfAllStatusIcons[7]);
            ListOfSingleStatusIcons.Add(ListOfAllStatusIcons[8]);
            ListOfSingleStatusIcons.Add(ListOfAllStatusIcons[9]);
        }


        if (name == "Enemy3")
        {
            HpLabel = HPLabelList[2];
            ManaLabel = ManaLabelList[2];
            NameLabel = NameLabelList[2];
            ListOfSingleStatusIcons.Add(ListOfAllStatusIcons[10]);
            ListOfSingleStatusIcons.Add(ListOfAllStatusIcons[11]);
            ListOfSingleStatusIcons.Add(ListOfAllStatusIcons[12]);
            ListOfSingleStatusIcons.Add(ListOfAllStatusIcons[13]);
            ListOfSingleStatusIcons.Add(ListOfAllStatusIcons[14]);
        }

        if (name == "Enemy4")
        {
            HpLabel = HPLabelList[3];
            ManaLabel = ManaLabelList[3];
            NameLabel = NameLabelList[3];
        }
        if(armor == 0f )
        {
            armor = 1;
        }

        if (elita)
        {
            NPCname = "Elite " + NameList[Random.Range(0, NameList.Count - 1)];
            curHp = curHp * 3;
            dmgAtk = dmgAtk * 7;
            armor = armor * 2;
        }
        else
        {
            if (elita && TypeOfEnemy == "Rat")
            {
                NPCname = "élite " + NameList[Random.Range(0, NameList.Count - 1)];
                curHp = curHp * 3;
                dmgAtk = dmgAtk * 7;
                armor = armor * 2;
                BehaviourSet = 2;
            }
            else
            {
                if (boss)
                {
                   switch(TypeOfEnemy)
                    {
                        case "Tutorial_1_Boss":
                            {
                                NPCname = "Janitor's Pet";
                                curHp = curHp * 10;
                                dmgAtk = dmgAtk * 10;
                                armor = armor * 2.5f;
                                element = "Water";
                            }
                            break;
                        case "RatBoss":
                            NPCname = "Pascal Haunted Prince of Sewers";
                            curHp = curHp - (curHp * 0.75f);
                            dmgAtk = dmgAtk + (dmgAtk * 0.75f);
                            curMana = curMana + (curMana * 10);
                            armor = armor * 2.5f;
                            element = "Neutral";
                            break;
                    }
                }
                else
                {
                    NPCname = NameList[Random.Range(0, NameList.Count - 1)];

                    
                }
            }

        }

      
        
        BSM = GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>();
        HeroToAttack = GameObject.FindGameObjectWithTag("Hero");

    }

    // Update is called once per frame
    void Update()
    {

        string name = Me.name;
        Text Name = NameLabel.GetComponent<Text>();

        Name.text = NPCname;

        //    CurrentHp = HpLabel.GetComponent<Text>();
        //  CurrentMana = ManaLabel.GetComponent<Text>();
        //   curHp = curHp - 
        curHpString = curHp.ToString("0.0");
        curManaString = curMana.ToString("0.0");
        CurrentHp = HpLabel.GetComponent<Text>();
        CurrentHp.text = curHpString;
        //    CurrentHp.text = curHpString;
        //  HpLabel.text = curHpString;
        CurrentMana = ManaLabel.GetComponent<Text>();
        CurrentMana.text = curManaString;
        for (int z1 = 0; z1 < DebuffTimerList.Count; z1++)
        {
            if (DebuffTimerList[z1] == GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().TurnCounter)
            {
                DebuffList.RemoveAt(z1);
                DebuffTimerList.RemoveAt(z1);
                ListOfSingleStatusIcons[z1].GetComponent<SpriteRenderer>().sprite = null;
            }
        }

        Debug.Log(currentState);
        switch (currentState)
        {
            case (EnemyStates.IDLE):

                break;
            case (EnemyStates.WAIT):

                if (curHp == 0 || curHp < 0)
                {
                    currentState = EnemyStates.DEAD;
                }
                else
                {


                    CurrentHp.text = curHpString;
                    //   BSM.currentState = SBattleStateFSM.BattleStates.ACTIONS;
                    currentState = EnemyStates.IDLE;
                }
                break;
            case (EnemyStates.CHOOSING):





                break;
            case (EnemyStates.ACTION):
                if (status == "Stunned")
                {
                    BSM.currentState = SBattleStateFSM.BattleStates.WAIT;
                    currentState = EnemyStates.IDLE;
                    status = "normal";
                }
                else
                {
                    if (curHp <= 0)
                    {
                        currentState = EnemyStates.DEAD;
                    }
                    else
                    {
                        if (status == "Burning")
                        {
                            TakeDmg(50, "neutral");
                            statusCounter = statusCounter + 1;

                        }

                        if (DebuffList.Contains("Icky Slime"))
                        {

                            curHp = curHp - 15;
                            for (int z2 = 0; z2 < ListOfSingleStatusIcons.Count; z2++)
                            {
                                if (ListOfSingleStatusIcons[z2].GetComponent<SpriteRenderer>().sprite == null)
                                {
                                    ListOfSingleStatusIcons[z2].GetComponent<SpriteRenderer>().sprite = GameObject.Find("PoisonDebuff").GetComponent<SpriteRenderer>().sprite;
                                    break;
                                }
                                
                            }

                        }
                        if (boss)
                        {
                            int specialAttack = Random.Range(1, 5);
                            if (specialAttack == 2)
                            {
                                BossAOEdmg();
                                currentState = EnemyStates.ANIMATION;
                            }
                            else
                            {
                                DoDmg();
                                currentState = EnemyStates.ANIMATION;
                            }
                        }
                        else
                        {
                            DoDmg();
                            currentState = EnemyStates.ANIMATION;
                        }


                    }
                }
                break;
            case (EnemyStates.ANIMATION):
               
                body = GetComponent<Rigidbody2D>();
                //float step = speed * Time.deltaTime;
                Vector2 targetpoint = new Vector2(body.position.x, body.position.y);
                Vector3 targetpoint2 = new Vector3(body.position.x - 15, body.position.y, 0);
                Vector3 targetpoint3 = new Vector3(body.position.x + 15, body.position.y, 0);
                //  body.position = new Vector2(body.position.x + 10, body.position.y);
                //    body.MovePosition(body.position * step);

                //   body.position = new Vector2(body.position.x - 10, body.position.y);
                //  body.MovePosition(body.position);


                GameObject.Find("ZombieBite").GetComponent<AudioSource>().Play();
                //  body.velocity = new Vector2(body.position.x * 1, body.position.y);
                if (!attackAnimDone)
                {
                    transform.position = Vector3.MoveTowards(transform.position, HeroToAttack.GetComponent<Transform>().position, 70 * Time.deltaTime);
                }
                if (transform.position == HeroToAttack.GetComponent<Transform>().position)
                {
                    attackAnimDone = true;
                    if (attackAnimDone)
                    {
                        while (transform.position != oriPos)
                        {
                            transform.position = Vector3.MoveTowards(transform.position, oriPos, 7 * Time.deltaTime);
                        }
                            if (transform.position == oriPos)
                        {
                            attackAnimDone = false;
                            //  body.MovePosition(targetpoint);
                            BSM.currentState = SBattleStateFSM.BattleStates.WAIT
                                ;
                            currentState = EnemyStates.IDLE;
                        }
                    }
                }
                GameObject.Find("ZombieBite").GetComponent<AudioSource>().Play();
                 break;
                
            case (EnemyStates.DEAD):
                //  SceneManager.DestroyObject(this);
                if (elita)
                {
                    if (GameObject.Find("PC3"))
                    {
                        GameObject.Find("PC3").GetComponent<HeroFSM>().ExpGain(500 + (level * (0.2f*500)));
                    }
                    if (GameObject.Find("PC2"))
                    {
                        GameObject.Find("PC2").GetComponent<HeroFSM>().ExpGain(500 + (level * (0.2f * 500)));
                    }
                    GameObject.Find("PC").GetComponent<HeroFSM>().ExpGain(500 + (level * (0.2f * 500)));
                }
                else
                {
                    if (GameObject.Find("PC3"))
                    {
                        GameObject.Find("PC3").GetComponent<HeroFSM>().ExpGain(500 + (level * (0.2f * 500)));
                    }
                    if (GameObject.Find("PC2"))
                    {
                        GameObject.Find("PC2").GetComponent<HeroFSM>().ExpGain(200 + (level * (0.2f * 500)));
                    }
                    GameObject.Find("PC").GetComponent<HeroFSM>().ExpGain(200 + (level * (0.2f * 500)));
                }
                BSM.GetComponent<SBattleStateFSM>().EnemyInCombat.Clear();

                BSM.GetComponent<SBattleStateFSM>().KillConf(name);


                currentState = EnemyStates.IDLE;
                HpLabel.SetActive(false);
                NameLabel.SetActive(false);
                ManaLabel.SetActive(false);
                
                switch(level)
                {
                    case 1:
                        {
                            
                            if (UnityEngine.Random.Range(0,4) == 2)
                            {
                                GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().LootItems(LootTable1);
                            }
                        }
                        break;
                    case 2:
                        
                        if (UnityEngine.Random.Range(0, 4) == 2)
                        {
                            GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().LootItems(LootTable1);
                        }
                        break;
                    case 3:
                        
                        if (UnityEngine.Random.Range(0, 4) == 2)
                        {
                            GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().LootItems(LootTable1);
                        }
                        break;
                    case 4:
                        
                        if (UnityEngine.Random.Range(0, 10) % 2 == 0)
                        {
                            GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().LootItems(LootTable2);
                        }
                        break;
                    case 5:
                        if (UnityEngine.Random.Range(0, 10) % 2 == 0)
                        {
                            GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().LootItems(LootTable2);
                        }
                        break;
                    case 6:
                        if (UnityEngine.Random.Range(0, 10) % 2 == 0)
                        {
                            GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().LootItems(LootTable2);
                        }
                        break;
                    default:
                        if (UnityEngine.Random.Range(0, 10) % 2 == 0)
                        {
                            GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().LootItems(LootTable3);
                        }
                        break;
                }
                GameObject.Find("BattleLog").GetComponentInChildren<Text>().text = GameObject.Find("BattleLog").GetComponentInChildren<Text>().text + NPCname + " is dead \n";
                GameObject.Find("BattleLog").GetComponentInChildren<Text>().text = GameObject.Find("BattleLog").GetComponentInChildren<Text>().text + "Janusz gains 100 Experiance points \n";
                Destroy(GetComponent<SpriteRenderer>());
                Destroy(this);


                break;

        }
    }


    public void DoDmg()
    {
        float crit;
        crit = Random.Range(0, 10);
        dmgAtk = dmgAtk + crit;
        switch(BehaviourSet)
        {
            case 0: ZombieMind();
                break;
            case 1: WolfPackMind();
                break;
            case 2: BullyMind();
                break;
            case 3: CalculatorMind();
                break;
            case 4: SupportBaneMind();
                break;
            case 5: ReactMind();
                break;
            default: ZombieMind();
                break;
           
        }
        if (HeroToAttack != null)
        {
            switch(TypeOfEnemy)
            {
                case "Zombie":
                    {
                        int chanceforPoison = Random.Range(0, 10);
                        if(chanceforPoison == 5 || chanceforPoison == 10)
                        {
                            if(curMana >= 10)
                            {
                                curMana = curMana - 10;
                                HeroToAttack.GetComponent<HeroFSM>().EnemyToAttack = HeroToAttack;
                                HeroToAttack.GetComponent<HeroFSM>().UseSpell(0, 0, "Debuff", "Poison", "neutral");
                                
                                HeroToAttack.GetComponent<HeroFSM>().TakeDmg(dmgAtk * 0.25f);
                            }
                            else
                            {
                                HeroToAttack.GetComponent<HeroFSM>().TakeDmg(dmgAtk);
                            }
                        }
                        else
                        {
                            HeroToAttack.GetComponent<HeroFSM>().TakeDmg(dmgAtk);
                        }
                    }
                    break;
                case "Rat":
                    {
                        int chanceforPoison = Random.Range(0, 10);
                        if (chanceforPoison % 2 == 0)
                        {
                            if (curMana >= 10)
                            {
                                curMana = curMana - 10;
                                HeroToAttack.GetComponent<HeroFSM>().EnemyToAttack = HeroToAttack;
                                HeroToAttack.GetComponent<HeroFSM>().UseSpell(0, 0, "Debuff", "Poison", "neutral");
                                
                                HeroToAttack.GetComponent<HeroFSM>().TakeDmg(dmgAtk * 0.25f);
                            }
                            else
                            {
                                HeroToAttack.GetComponent<HeroFSM>().TakeDmg(dmgAtk);
                            }
                        }
                        else
                        {
                            HeroToAttack.GetComponent<HeroFSM>().TakeDmg(dmgAtk);
                        }
                    }
                    break;
                case "RatBlood":
                    {
                        int chanceforPoison = Random.Range(0,1);
                        if (chanceforPoison == 0)
                        {
                            if (curMana >= 10)
                            {
                                curMana = curMana - 10;
                                HeroToAttack.GetComponent<HeroFSM>().EnemyToAttack = HeroToAttack;
                                HeroToAttack.GetComponent<HeroFSM>().UseSpell(0, 0, "Debuff", "Poison", "neutral");

                                HeroToAttack.GetComponent<HeroFSM>().TakeDmg(dmgAtk * 0.5f);
                            }
                            else
                            {
                                HeroToAttack.GetComponent<HeroFSM>().TakeDmg(dmgAtk);
                            }
                        }
                        else
                        {
                            HeroToAttack.GetComponent<HeroFSM>().TakeDmg(dmgAtk);
                        }
                    }
                    break;
                case "RatWeb":
                    {
                        int chanceforPoison = Random.Range(0, 10);
                        if (chanceforPoison == 5 || chanceforPoison == 10)
                        {
                            if (curMana >= 10)
                            {
                                curMana = curMana - 10;
                                HeroToAttack.GetComponent<HeroFSM>().EnemyToAttack = HeroToAttack;
                                HeroToAttack.GetComponent<HeroFSM>().UseSpell(0, 0, "Debuff", "Poison", "neutral");

                                HeroToAttack.GetComponent<HeroFSM>().TakeDmg(dmgAtk * 0.25f);
                            }
                            else
                            {
                                HeroToAttack.GetComponent<HeroFSM>().TakeDmg(dmgAtk);
                            }
                        }
                        else
                        {
                            if (chanceforPoison % 2 == 0 && curMana >=15)
                            {
                                curMana = curMana - 15;
                                HeroToAttack.GetComponent<HeroFSM>().statusHero = "blind";
                            }
                            else
                            {
                                HeroToAttack.GetComponent<HeroFSM>().TakeDmg(dmgAtk);
                            }
                        }
                    }
                    break;
                case "RatBoss":
                    {
                        int chanceforPoison = Random.Range(0, 10);
                        if (chanceforPoison == 5 || chanceforPoison == 10)
                        {
                            if (curMana >= 10)
                            {
                                curMana = curMana - 10;
                                HeroToAttack.GetComponent<HeroFSM>().EnemyToAttack = HeroToAttack;
                                HeroToAttack.GetComponent<HeroFSM>().UseSpell(0, 0, "Debuff", "Poison", "neutral");

                                HeroToAttack.GetComponent<HeroFSM>().TakeDmg(dmgAtk * 0.25f);
                            }
                            else
                            {
                                HeroToAttack.GetComponent<HeroFSM>().TakeDmg(dmgAtk);
                            }
                        }
                        else
                        {
                            if (chanceforPoison % 2 == 0 && curMana >=10)
                            {
                                curMana = curMana - 10;
                                HeroToAttack.GetComponent<HeroFSM>().statusHero = "Fear";
                                HeroToAttack.GetComponent<HeroFSM>().TakeDmg(dmgAtk);
                            }
                            else
                            {
                                HeroToAttack.GetComponent<HeroFSM>().TakeDmg(dmgAtk);
                            }
                        }
                    }
                    break;
                case "PoisonBlob":
                    {
                        int chanceforPoison = Random.Range(0, 10);
                        if (chanceforPoison < 9)
                        {
                            if (curMana >= 10)
                            {
                                curMana = curMana - 10;
                                HeroToAttack.GetComponent<HeroFSM>().EnemyToAttack = HeroToAttack;
                                HeroToAttack.GetComponent<HeroFSM>().UseSpell(0, 0, "Debuff", "Poison", "neutral");
                                
                                HeroToAttack.GetComponent<HeroFSM>().TakeDmg(dmgAtk * 0.25f);
                            }
                            else
                            {
                                HeroToAttack.GetComponent<HeroFSM>().TakeDmg(dmgAtk);
                            }
                        }
                        else
                        {
                            HeroToAttack.GetComponent<HeroFSM>().TakeDmg(dmgAtk);
                        }
                    }
                    break;
                case "DevilRoots":
                    {
                        HeroToAttack.GetComponent<HeroFSM>().TakeDmg(dmgAtk);
                        if(!DoubleAttackTrigger)
                        {
                            ZombieMind();
                            HeroToAttack.GetComponent<HeroFSM>().TakeDmg(dmgAtk);
                            DoubleAttackTrigger = true;
                        }
                    }
                    break;
            }
            HeroToAttack.GetComponent<HeroFSM>().TakeDmg(dmgAtk);
        }
        else
        {
            DoDmg();
            
        }

        HeroToAttack.GetComponent<HeroFSM>().EnemyToAttack = null;
        //GameObject.Find("BattleLog").GetComponentInChildren<Text>().text = GameObject.Find("BattleLog").GetComponentInChildren<Text>().text + NPCname + " melee hits Janusz" + " for " + dmgAtk + " damage\n";
    }
    public void TakeDmg(float getDamageAmount, string SkillElement)
    {
        if (BullyVictim != null)
        {
            if (BSM.OrderList[BSM.OrderList.Count - 2] == BullyVictim.name)
            {
                VictimDmg = VictimDmg + getDamageAmount;
            }
        }

 
        if (status == "normal")
        {
            for (int z2 = 0; z2 < ListOfSingleStatusIcons.Count; z2++)
            {
                if (ListOfSingleStatusIcons[z2].GetComponent<SpriteRenderer>().sprite == GameObject.Find("FireDebuff").GetComponent<SpriteRenderer>().sprite || ListOfSingleStatusIcons[z2].GetComponent<SpriteRenderer>().sprite == GameObject.Find("WaterDebuff").GetComponent<SpriteRenderer>().sprite)
                {
                    ListOfSingleStatusIcons[z2].GetComponent<SpriteRenderer>().sprite = null;
                }
            }
        }
        GameObject.Find("BattleLog").GetComponentInChildren<Text>().text = GameObject.Find("BattleLog").GetComponentInChildren<Text>().text + NPCname + " takes " + getDamageAmount + " damage\n";
        if(status == "Burning" && SkillElement =="Water")
        {
            status = "normal";
        }

        if(status == "Burning" && statusCounter == 3)
        {
            status = "normal";
            statusCounter = 0;
        }
        if (SkillElement == "Water")
        {
            armor = armor - 0.5f;
        }
        getDamageAmount = getDamageAmount - (armor * 2.5f);
        if(element == "Fire" && SkillElement =="Water")
        {
            getDamageAmount = getDamageAmount * 1.5f; 
        }
        else
        {
            if(element == "Water" && SkillElement == "Water")
            {
                getDamageAmount = getDamageAmount * 0.5f;
            }
        }        
        if(status == "Wet")
        {
            getDamageAmount = getDamageAmount * 1.2f;
        }
        else
            if(status == "nearly soaked")
        {
            getDamageAmount = getDamageAmount * 1.5f;
        }
        

        curHp = curHp - getDamageAmount;
        if(status == "Wet")
        {
            status = "nearly soaked";
        }
        if (status == "nearly soaked")
        {
            status = "soaked";
        }
        else
        {
            if (SkillElement == "Water" && element != "Water")
            {
                status = "Wet";
                for (int z2 = 0; z2 < ListOfSingleStatusIcons.Count; z2++)
                {
                    if (ListOfSingleStatusIcons[z2].GetComponent<SpriteRenderer>().sprite == null)
                    {
                        ListOfSingleStatusIcons[z2].GetComponent<SpriteRenderer>().sprite = GameObject.Find("WaterDebuff").GetComponent<SpriteRenderer>().sprite;
                        break;
                    }
                    
                }
            }
        }


        if(SkillElement == "Fire" && element != "Fire")
        {
            int IgniChance = UnityEngine.Random.Range(0, 1);
            if(IgniChance == 0)
                {
                status = "Burning";
                for (int z2 = 0; z2 < ListOfSingleStatusIcons.Count; z2++)
                {
                    if (ListOfSingleStatusIcons[z2].GetComponent<SpriteRenderer>().sprite == null)
                    {
                        ListOfSingleStatusIcons[z2].GetComponent<SpriteRenderer>().sprite = GameObject.Find("FireDebuff").GetComponent<SpriteRenderer>().sprite;
                        break;
                    }
                    
                }
            }
            
        }

        if(SkillElement == "Earth")
        {
            int StunChance = UnityEngine.Random.Range(0, 1);
            if(StunChance == 0)
            {
                status = "Stunned";
                for (int z2 = 0; z2 < ListOfSingleStatusIcons.Count; z2++)
                {
                    if (ListOfSingleStatusIcons[z2].GetComponent<SpriteRenderer>().sprite == null)
                    {
                        ListOfSingleStatusIcons[z2].GetComponent<SpriteRenderer>().sprite = GameObject.Find("StunDebuff").GetComponent<SpriteRenderer>().sprite;
                        break;
                    }
                    
                }
            } 
        }
        switch (BSM.OrderList[BSM.OrderList.Count - 2])
        {
            case "PC":
                Hero1DmgPoint = Hero1DmgPoint + getDamageAmount;
                break;
            case "PC2":
                Hero2DmgPoint = Hero2DmgPoint + getDamageAmount;
                break;
            case "PC3":
                Hero3DmgPoint = Hero3DmgPoint + getDamageAmount;
                break;

        }
        dmgTakeTxt.SetActive(true);
        Vector3 moveUp = new Vector3(0, 6f, 0);
        dmgTakeTxt.GetComponent<Transform>().position = Me.GetComponent<Transform>().position + moveUp;
        dmgTakeTxt.GetComponent<Text>().text = (getDamageAmount * -1).ToString("0.0") + " HP" + "\n" + "Armor " + armor.ToString("0.0");
        StartCoroutine(fadeTime());
        if (curHp <= 0)
        {
            currentState = EnemyStates.DEAD;
        }
    }

    public void BossAOEdmg()
    {
        dmgAtk = 200;
        for (int i = 0; i < BSM.HeroInCombat.Count; i++)
        {
            HeroToAttack = BSM.HeroInCombat[i];
            HeroToAttack.GetComponent<HeroFSM>().TakeDmg(dmgAtk);

        }
        GameObject.Find("BattleLog").GetComponentInChildren<Text>().text = GameObject.Find("BattleLog").GetComponentInChildren<Text>().text + NPCname + " used WHIRPOOL to attacks party " + " for " + dmgAtk + " damage\n";
    }


    private IEnumerator waitForANi(float howMuch)
    {
        float timepass = 0f;
        while (true)
        {
            timepass += Time.deltaTime;
            
            if (transform.position == HeroToAttack.GetComponent<Transform>().position)
            {
               
                yield break;
            }

            yield return null;
        }

    }


    private IEnumerator fadeTime ()
    {
        yield return new WaitForSeconds(5f);
        dmgTakeTxt.SetActive(false);
    }

    public void ZombieMind()
    {
        int random = Random.Range(0, BSM.HeroInCombat.Count);
        HeroToAttack = BSM.HeroInCombat[random];
    }

    public void WolfPackMind()
    {
        HeroToAttack = null;
        for (int wp1 = 0; wp1 < BSM.HeroInCombat.Count; wp1++)
        {
            Values.Add(BSM.HeroInCombat[wp1].GetComponent<HeroFSM>().curHp / BSM.HeroInCombat[wp1].GetComponent<HeroFSM>().maxHp);
        }

        for (int wp2 = 0; wp2 < Values.Count ; wp2++)
        {
            if(Values[wp2] == 0)
            {
                Values[wp2] = 1;
            }
        }

        float lowestValue = Values.Min();

        for(int wp3 = 0; wp3 < Values.Count; wp3++)
        {
            if(Values[wp3] == lowestValue)
            {
                HeroToAttack = BSM.HeroInCombat[wp3];
            }
        }

        if(HeroToAttack == null)
        {
            int random = Random.Range(0, BSM.HeroInCombat.Count);
            HeroToAttack = BSM.HeroInCombat[random];
        }

        Values.Clear();


    }


    public void BullyMind()
    {
        if (BullyVictim == null || BullyThreshhold == VictimDmg)
        {
            int random = Random.Range(0, BSM.HeroInCombat.Count);
            HeroToAttack = BSM.HeroInCombat[random];
            while(HeroToAttack == BullyVictim)
            {
                random = Random.Range(0, BSM.HeroInCombat.Count);
                HeroToAttack = BSM.HeroInCombat[random];
            }
            BullyVictim = HeroToAttack;
        }
        else
        {
            HeroToAttack = BullyVictim;
        }
        

    }


    public void CalculatorMind()
    {
        HeroToAttack = null;
        List<float> Values2 = new List<float>();
        float totalHero1 = 0;
        float totalHero2 = 0;
        float totalHero3 = 0;
        //float totalHero4 = 0;

        for(int c1 = 0; c1<BSM.HeroInCombat.Count; c1++)
        {
            if(c1 == 0)
            {
               for(int c2=0;c2<GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero1.SkillList.Count;c2++)
                {
                    if (GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero1.SkillList[c2].type == "Damage")
                    {
                        totalHero1 = totalHero1 + GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero1.SkillList[c2].baseDmg;
                    }
                }
            }
            else
            {
                if (c1 == 1)
                {
                    for (int c2 = 0; c2 < GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero2.SkillList.Count; c2++)
                    {
                        if (GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero2.SkillList[c2].type == "Damage")
                        {
                            totalHero2 = totalHero2 + GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero2.SkillList[c2].baseDmg;
                        }
                    }
                }
                else
                {
                    if(c1 == 2)
                    {
                        for (int c2 = 0; c2 < GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero3.SkillList.Count; c2++)
                        {
                            if (GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero3.SkillList[c2].type == "Damage")
                            {
                                totalHero3 = totalHero3 + GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero3.SkillList[c2].baseDmg;
                            }
                        }
                    }
                }
            }

        }

        Values2.Add(totalHero1);
        Values2.Add(totalHero2);
        Values2.Add(totalHero3);

        float highestPossibleDmg = Values2.Max();

        if(highestPossibleDmg == totalHero1)
        {
            HeroToAttack = BSM.HeroInCombat[0];
        }
        else
        {
            if(highestPossibleDmg == totalHero2)
            {
                HeroToAttack = BSM.HeroInCombat[1];
            }
            else
            {
                if(highestPossibleDmg == totalHero3)
                {
                    HeroToAttack = BSM.HeroInCombat[2];
                }
            }
        }

        Values2.Clear();
    }

    public void SupportBaneMind()
    {

        List<int> ValuesSupportPoints = new List<int>();
        ValuesSupportPoints.Add(Hero1SupportPoints);
        ValuesSupportPoints.Add(Hero2SupportPoints);
        ValuesSupportPoints.Add(Hero3SupportPoints);

        int HighestSupport = 0;
      HighestSupport = ValuesSupportPoints.Max();

        for(int sp1 = 0; sp1<BSM.HeroInCombat.Count;sp1++)
        {
            if (HighestSupport == ValuesSupportPoints[sp1])
            {
                HeroToAttack = BSM.HeroInCombat[sp1];
            }
        }
        ValuesSupportPoints.Clear();

    }


    public void SupportMoveDetector(GameObject Hero)
    {
        switch(Hero.name)
        {
            case "PC":Hero1SupportPoints = Hero1SupportPoints + 1;
                break;
            case "PC2":
                Hero2SupportPoints = Hero2SupportPoints + 1;
                break;
            case "PC3":
                Hero3SupportPoints = Hero3SupportPoints + 1;
                break;
        }

    }

    public void ReactMind()
    {
        List<float> Values3 = new List<float>();
        Values3.Add(Hero1DmgPoint);
        Values3.Add(Hero2DmgPoint);
        Values3.Add(Hero3DmgPoint);

        float HighestDMGdone = 0;
        HighestDMGdone = Values3.Max();

        for(int r1 = 0; r1<BSM.HeroInCombat.Count;r1++)
        {
            if(HighestDMGdone == Values3[r1])
            {
                HeroToAttack = BSM.HeroInCombat[r1];
            }
        }
        Values3.Clear();

    }


    public void Boss_Tutorial1()
    {

    }
}





