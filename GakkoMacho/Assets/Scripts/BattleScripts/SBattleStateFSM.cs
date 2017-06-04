using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
[SerializeField]
public class SBattleStateFSM : MonoBehaviour
{

    public enum BattleStates
    {
        WAIT,
        ACTIONS,
        TURN,
        WIN,
        LOSE,
        IDLE,
    }
    //variables
    float startturn;
    public HeroFSM HFSM;
    public EnemyFSM EFSM;
    public EnemyFSM EFSM2;
    public EnemyFSM EFSM3;
    public EnemyFSM EFSM4;
    public string theme;
    public GameObject InfoPanel1;
    public GameObject InfoPanel2;
    public GameObject InfoPanel3;
    public int InnerTurnCounter;
    public int TurnCounter;
    private Rigidbody2D body;
    public List<GameObject> HeroInCombat;
    public GameObject[] HeroInCombatArray;
    public GameObject[] EnemyInCombatArray;
    public List<GameObject> DeadHeroes;
    public List<GameObject> DeadEnemies;
    public List<GameObject> EnemyInCombat;
    public List<string> OrderList = new List<string>(4);
    private GameObject PC;
    private GameObject PC2;
    private GameObject PC3;
    public List<GameObject> SpawnLocationEnemy;
    public List<GameObject> SpawnLocationHero;
    public GameObject enemyToClone;
    public GameObject TeamNpcToClone1;
    public GameObject TeamNpcToClone2;
    private GameObject enemy1;
    private GameObject enemy2;
    private GameObject enemy3;
    private GameObject enemy4;
    GameObject Target;
    public int SpellId;
    public GameObject Btn1;
    public GameObject Btn2;
    public GameObject Btn3;
    public GameObject Btn4;
    public GameObject Btn5;
    public GameObject Btn6;
    public GameObject menu1;
    public GameObject menu2;
    public GameObject menu3;
    public GameObject menu4;
    public GameObject menu5;
    public GameObject indicatorTurn1;
    public GameObject indicatorTurn2;
    public GameObject EnemySelection;
    public GameObject SkillPanel;
    public GameObject Battlelog;
    public GameObject Enemy1Text;
    public GameObject Enemy2Text;
    public GameObject Enemy3Text;
    public GameObject Enemy4Text;
    public GameObject Hero2Text;
    public GameObject Hero3Text;
    public string PlayerTurn;
    List<string> EnemyNameList = new List<string>(4);
    int EnemyToSpawn;
    public int HeroToSpawn;
    public bool friendlySkillFlag;
    GameObject[] SchoolThemeBackgrounds;
    GameObject[] PoolBasementThemeBackgrounds;
    GameObject[] ForestThemeBackgrounds;
    GameObject[] SchoolFieldThemeBackgrounds;
    GameObject[] RooftopsThemeBackgrounds;
    public GameObject[] SchoolThemeEnemies;
    GameObject[] SchoolThemeElites;
    GameObject[] SchoolThemeBosses;
    public GameObject[] PoolBasementThemeEnemies;
    GameObject[] PoolBasementThemeElites;
    GameObject[] PoolBasementThemeBosses;
    GameObject[] ForestThemeEnemies;
    GameObject[] ForestThemeElites;
    GameObject[] ForestThemeBosses;
    GameObject[] SchoolFieldThemeEnemies;
    GameObject[] SchoolFieldThemeElites;
    GameObject[] SchoolFieldThemeBosses;
    GameObject[] RooftopsThemeEnemies;
    GameObject[] RooftopsThemeElites;
    GameObject[] RooftopsThemeBosses;
    public GameObject[] SelectedEnemyArray;
    public GameObject[] SelectedEliteArray;
    GameObject[] SelectedBossArray;
    bool YouWonFlag;
    
    public GameObject BattleBackground;

    public BattleStates currentState;

    private void Start()
    {
        YouWonFlag = false;
        switch(GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().LevelName)
        {
            case "ExplorerSceneProto":
                {
                    theme = "School";

                }
                break;
            case "ProcedularDungeon":
                {
                    theme = "PoolBasement";
                }
                break;
        }
        SchoolThemeBackgrounds = GameObject.FindGameObjectsWithTag("SchoolThemeBacks");
        SchoolThemeEnemies = GameObject.FindGameObjectsWithTag("SchoolThemeEnemy");
        SchoolThemeElites = GameObject.FindGameObjectsWithTag("SchoolThemeElites");
        SchoolThemeBosses = GameObject.FindGameObjectsWithTag("SchoolThemeBoss");
        PoolBasementThemeBackgrounds = GameObject.FindGameObjectsWithTag("PoolBasementThemeBacks");
        PoolBasementThemeEnemies = GameObject.FindGameObjectsWithTag("PoolBasementThemeEnemy");
        PoolBasementThemeElites = GameObject.FindGameObjectsWithTag("PoolBasementThemeElites");
        PoolBasementThemeBosses = GameObject.FindGameObjectsWithTag("PoolBasementThemeBoss");
        ForestThemeBackgrounds = GameObject.FindGameObjectsWithTag("ForestThemeBacks");
        ForestThemeEnemies = GameObject.FindGameObjectsWithTag("ForestThemeEnemy");
        ForestThemeElites = GameObject.FindGameObjectsWithTag("ForestThemeElites");
        ForestThemeBosses = GameObject.FindGameObjectsWithTag("ForestThemeBoss");
        RooftopsThemeBackgrounds = GameObject.FindGameObjectsWithTag("RoofTopsThemeBacks");
        RooftopsThemeEnemies = GameObject.FindGameObjectsWithTag("RoofTopsThemeEnemy");
        RooftopsThemeElites = GameObject.FindGameObjectsWithTag("RoofTopsThemeElites");
        RooftopsThemeBosses = GameObject.FindGameObjectsWithTag("RoofTopsThemeBoss");
        SchoolFieldThemeBackgrounds = GameObject.FindGameObjectsWithTag("SchoolFieldThemeBacks");
        SchoolFieldThemeEnemies = GameObject.FindGameObjectsWithTag("SchoolFieldThemeEnemy");
        SchoolFieldThemeElites = GameObject.FindGameObjectsWithTag("SchoolFieldThemeElites");
        SchoolFieldThemeBosses = GameObject.FindGameObjectsWithTag("SchoolFieldThemeBoss");

        switch (theme)
        {
            case "School":
                {
                    BattleBackground = SchoolThemeBackgrounds[Random.Range(0, SchoolThemeBackgrounds.Length)];
                    SelectedEnemyArray = SchoolThemeEnemies;
                    SelectedEliteArray = SchoolThemeElites;
                    BattleBackground.GetComponent<Transform>().position = GameObject.Find("BackgroundPlacer").GetComponent<Transform>().position;
                }
                break;
            case "PoolBasement":
                {
                    BattleBackground = PoolBasementThemeBackgrounds[Random.Range(0, PoolBasementThemeBackgrounds.Length)];
                    SelectedEnemyArray = PoolBasementThemeEnemies;
                    SelectedEliteArray = PoolBasementThemeElites;
                    BattleBackground.GetComponent<Transform>().position = GameObject.Find("BackgroundPlacer").GetComponent<Transform>().position;
                }
                break;

        }
        EnemyToSpawn = (int)Random.Range(1, 4);
        HeroToSpawn = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().PartySize;
        EnemyNameList.Add("Enemy1");
        EnemyNameList.Add("Enemy2");
        EnemyNameList.Add("Enemy3");
        EnemyNameList.Add("Enemy4");

        TurnCounter = 0;
        GameObject.Find("Player").GetComponent<SpriteRenderer>().enabled = false;
        if (GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().killedEnemyPatrol.Contains("FinalBoss"))
            {
            EnemyToSpawn = 1;
            }
        int randomElita;


        if (EnemyToSpawn >= 1)
        {
            enemy1 = (GameObject)Instantiate(enemyToClone, SpawnLocationEnemy[0].GetComponent<Transform>().transform, true);
            enemy1.name = EnemyNameList[0];
            enemy1.tag = "Enemy";
            enemy1.GetComponent<SpriteRenderer>().sprite = SelectedEnemyArray[Random.Range(0, SelectedEnemyArray.Length)].GetComponent<SpriteRenderer>().sprite;

            if (GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().killedEnemyPatrol.Contains("FinalBoss"))
            {

                enemy1.GetComponent<EnemyFSM>().boss = true;
                switch(GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().killedEnemyPatrol)
                {
                    case "FinalBoss_tutorial1": enemy1.GetComponent<SpriteRenderer>().sprite = GameObject.Find("CopyBossTutorial").GetComponent<SpriteRenderer>().sprite;
                        break;
                    case "FinalBoss_poolBasement":
                        YouWonFlag = true;
                        enemy1.GetComponent<SpriteRenderer>().sprite = GameObject.Find("RatHauntedBoss").GetComponent<SpriteRenderer>().sprite;
                        break;
                    default: enemy1.GetComponent<SpriteRenderer>().sprite = GameObject.Find("PC").GetComponent<SpriteRenderer>().sprite;
                        break;

                }
                
            }
            else
            {
                if (GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().killedEnemyPatrol.Contains("EnemySpawn_special"))
                {
                    randomElita = 200;
                    enemy1.GetComponent<EnemyFSM>().elita = true;
                    enemy1.GetComponent<SpriteRenderer>().sprite = SelectedEliteArray[Random.Range(0, SelectedEliteArray.Length)].GetComponent<SpriteRenderer>().sprite;
                }
                else
                {
                    randomElita = Random.Range(0, 100);

                    if (randomElita % 5 == 0)
                    {
                        enemy1.GetComponent<EnemyFSM>().elita = true;
                        enemy1.GetComponent<SpriteRenderer>().sprite = SelectedEliteArray[Random.Range(0, SelectedEliteArray.Length)].GetComponent<SpriteRenderer>().sprite;
                    }
                }
            }






            enemy1.GetComponent<Transform>().position = SpawnLocationEnemy[0].GetComponent<Transform>().position;



            if (EnemyToSpawn >= 2)
            {

                enemy2 = (GameObject)Instantiate(enemyToClone, SpawnLocationEnemy[1].GetComponent<Transform>().transform, false);
                enemy2.name = EnemyNameList[1];
                enemy2.tag = "Enemy";
                enemy2.GetComponent<SpriteRenderer>().sprite = SelectedEnemyArray[Random.Range(0, SelectedEnemyArray.Length)].GetComponent<SpriteRenderer>().sprite;
                if (GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().killedEnemyPatrol.Contains("EnemySpawn_special"))
                {
                    randomElita = 200;
                    enemy2.GetComponent<EnemyFSM>().elita = true;
                    enemy2.GetComponent<SpriteRenderer>().sprite = SelectedEliteArray[Random.Range(0, SelectedEliteArray.Length)].GetComponent<SpriteRenderer>().sprite;
                }
                else
                {
                    randomElita = Random.Range(0, 100);

                    if (randomElita % 5 == 0)
                    {
                        enemy2.GetComponent<EnemyFSM>().elita = true;
                        enemy2.GetComponent<SpriteRenderer>().sprite = SelectedEliteArray[Random.Range(0, SelectedEliteArray.Length)].GetComponent<SpriteRenderer>().sprite;
                    }
                }
                enemy2.GetComponent<Transform>().position = SpawnLocationEnemy[1].GetComponent<Transform>().position;
                if (EnemyToSpawn >= 3)
                {
                    enemy3 = (GameObject)Instantiate(enemyToClone, SpawnLocationEnemy[2].GetComponent<Transform>().transform, false);
                    enemy3.name = EnemyNameList[2];
                    enemy3.tag = "Enemy";
                    enemy3.GetComponent<SpriteRenderer>().sprite = SelectedEnemyArray[Random.Range(0, SelectedEnemyArray.Length)].GetComponent<SpriteRenderer>().sprite;
                    if (GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().killedEnemyPatrol.Contains("EnemySpawn_special"))
                    {
                        randomElita = 200;
                        enemy3.GetComponent<EnemyFSM>().elita = true;
                        enemy3.GetComponent<SpriteRenderer>().sprite = SelectedEliteArray[Random.Range(0, SelectedEliteArray.Length)].GetComponent<SpriteRenderer>().sprite;
                    }
                    else
                    {
                        randomElita = Random.Range(0, 100);

                        if (randomElita % 5 == 0)
                        {
                            enemy3.GetComponent<EnemyFSM>().elita = true;
                            enemy3.GetComponent<SpriteRenderer>().sprite = SelectedEliteArray[Random.Range(0, SelectedEliteArray.Length)].GetComponent<SpriteRenderer>().sprite;
                        }
                    }
                    enemy3.GetComponent<Transform>().position = SpawnLocationEnemy[2].GetComponent<Transform>().position;
                }
            }
        }


        if (HeroToSpawn > 1)
        {
            // Hero2Text.SetActive(true);
            Hero2Text.GetComponent<Transform>().localScale = new Vector3(1.45f, 1, 0);
            PC2 = (GameObject)Instantiate(TeamNpcToClone1, SpawnLocationHero[0].GetComponent<Transform>().transform, false);
            PC2.name = "PC2";
            PC2.tag = "Hero";
            PC2.GetComponent<Transform>().position = SpawnLocationHero[0].GetComponent<Transform>().position;
            if (HeroToSpawn > 2)
            {
                Hero3Text.GetComponent<Transform>().localScale = new Vector3(1.45f, 1, 0);
                PC3 = (GameObject)Instantiate(TeamNpcToClone2, SpawnLocationHero[1].GetComponent<Transform>().transform, false);
                PC3.name = "PC3";
                PC3.tag = "Hero";
                PC3.GetComponent<Transform>().position = SpawnLocationHero[1].GetComponent<Transform>().position;
            }
        }
        
        enemyToClone.tag = "clone";
        Destroy(enemyToClone);
        Destroy(TeamNpcToClone1);
        Destroy(TeamNpcToClone2);



        currentState = BattleStates.WAIT;
        HeroInCombatArray = GameObject.FindGameObjectsWithTag("Hero");
        HeroInCombat = HeroInCombatArray.ToList();
        EnemyInCombatArray = GameObject.FindGameObjectsWithTag("Enemy");
        EnemyInCombat = EnemyInCombatArray.ToList();

        PC = GameObject.Find("PC");
        int MaxArray = EnemyInCombat.Count;
        if (EnemyInCombat.Count >= 1)
        {

            Enemy1Text.SetActive(true);
            EFSM = EnemyInCombat[MaxArray - 1].GetComponent<EnemyFSM>();
            if (EnemyInCombat.Count >= 2)
            {
                Enemy2Text.SetActive(true);
                EFSM2 = EnemyInCombat[MaxArray - 2].GetComponent<EnemyFSM>();
                if (EnemyInCombat.Count >= 3)
                {
                    Enemy3Text.SetActive(true);
                    EFSM3 = EnemyInCombat[MaxArray - 3].GetComponent<EnemyFSM>();
                    if (EnemyInCombat.Count >= 4)
                    {
                        Enemy1Text.SetActive(true);
                        EFSM4 = EnemyInCombat[MaxArray - 4].GetComponent<EnemyFSM>();
                    }
                }
            }
        }



        for (int i = 0; i < HeroInCombat.Count; i++)
        {
            OrderList.Add(HeroInCombat[i].name);
        }


        for (int i = 0; i < EnemyInCombat.Count; i++)
        {
            OrderList.Add(EnemyInCombat[i].name);
        }
        OrderList.Add("Buffer");

        Btn1.SetActive(false);
        Btn2.SetActive(false);
        Btn3.SetActive(false);
        Btn4.SetActive(false);
        Btn5.SetActive(false);
        Btn6.SetActive(false);

        menu1.GetComponent<CheckPartyOrder>().BtnChange(OrderList[0]);
        menu2.GetComponent<CheckPartyOrder>().BtnChange(OrderList[0]);
        menu3.GetComponent<CheckPartyOrder>().BtnChange(OrderList[0]);
        menu4.GetComponent<CheckPartyOrder>().BtnChange(OrderList[0]);
        menu5.GetComponent<CheckPartyOrder>().BtnChange(OrderList[0]);
    }

    private void Update()
    {
        if (HeroToSpawn > 1)
        {
            Hero2Text.SetActive(true);
            Hero2Text.GetComponent<Transform>().localScale = new Vector3(1.45f, 1, 0);
            
            if (HeroToSpawn > 2)
            {
                Hero3Text.SetActive(true);
                Hero3Text.GetComponent<Transform>().localScale = new Vector3(1.45f, 1, 0);
             
            }
        }

        if (HeroInCombat.Count == 0)
        {

            Destroy(GameObject.Find("StatsCarrier"));
            Destroy(GameObject.Find("osahara"));
            Destroy(GameObject.Find("Player"));
            Destroy(GameObject.Find("Inomi"));
            Destroy(GameObject.Find("Canvas2"));
            SceneManager.LoadScene("MainMenu");
        }

        if (EnemyInCombatArray.Length == 0)
        {
            currentState = BattleStates.WIN;
        }


        switch (currentState)
        {
            case (BattleStates.IDLE):
                if (EnemyInCombatArray.Length == 0)
                {
                    currentState = BattleStates.WIN;
                }

                break;
            case (BattleStates.WAIT):
                currentState = BattleStates.TURN;
                Btn1.SetActive(false);
                Btn2.SetActive(false);
                Btn3.SetActive(false);
                Btn4.SetActive(false);
                Btn5.SetActive(false);
                Btn6.SetActive(false);

                break;
            case (BattleStates.TURN):

                int OrderListCount = OrderList.Count;

                if (OrderListCount == 3)
                {
                    OrderList[2] = OrderList[0];
                    OrderList[0] = OrderList[1];
                    OrderList[1] = OrderList[2];
                    currentState = BattleStates.ACTIONS;

                }

                if (OrderListCount == 4)
                {
                    OrderList[3] = OrderList[0];
                    OrderList[0] = OrderList[1];
                    OrderList[1] = OrderList[2];
                    OrderList[2] = OrderList[3];
                    currentState = BattleStates.ACTIONS;

                }

                if (OrderListCount == 5)
                {
                    OrderList[4] = OrderList[0];
                    OrderList[0] = OrderList[1];
                    OrderList[1] = OrderList[2];
                    OrderList[2] = OrderList[3];
                    OrderList[3] = OrderList[4];
                    currentState = BattleStates.ACTIONS;


                }

                if (OrderListCount == 6)
                {
                    OrderList[5] = OrderList[0];
                    OrderList[0] = OrderList[1];
                    OrderList[1] = OrderList[2];
                    OrderList[2] = OrderList[3];
                    OrderList[3] = OrderList[4];
                    OrderList[4] = OrderList[5];
                    currentState = BattleStates.ACTIONS;


                }

                if (OrderListCount == 7)
                {
                    OrderList[6] = OrderList[0];
                    OrderList[0] = OrderList[1];
                    OrderList[1] = OrderList[2];
                    OrderList[2] = OrderList[3];
                    OrderList[3] = OrderList[4];
                    OrderList[4] = OrderList[5];
                    OrderList[5] = OrderList[6];
                    currentState = BattleStates.ACTIONS;


                }

                menu1.GetComponent<CheckPartyOrder>().BtnChange(OrderList[0]);
                menu2.GetComponent<CheckPartyOrder>().BtnChange(OrderList[0]);
                menu3.GetComponent<CheckPartyOrder>().BtnChange(OrderList[0]);
                menu4.GetComponent<CheckPartyOrder>().BtnChange(OrderList[0]);
                menu5.GetComponent<CheckPartyOrder>().BtnChange(OrderList[0]);

                break;
            case (BattleStates.ACTIONS):
                if (OrderList[0] == "Enemy1")
                {

                    enemy1.GetComponent<EnemyFSM>().currentState = EnemyFSM.EnemyStates.ACTION;



                }
                if (OrderList[0] == "Enemy2")
                {

                    enemy2.GetComponent<EnemyFSM>().currentState = EnemyFSM.EnemyStates.ACTION;

                }
                if (OrderList[0] == "Enemy3")
                {

                    enemy3.GetComponent<EnemyFSM>().currentState = EnemyFSM.EnemyStates.ACTION;

                }
                if (OrderList[0] == "Enemy4")
                {

                    enemy4.GetComponent<EnemyFSM>().currentState = EnemyFSM.EnemyStates.ACTION;

                }


                if (OrderList[0] == "PC2")
                {
                    indicatorTurn1.SetActive(true);
                    PlayerTurn = "PC2";
                    InfoPanel2.GetComponent<Text>().text = "Osahara";
                    InfoPanel3.GetComponent<Text>().text = "Osahara";
                    if (HeroInCombat[0].name == "PC2")
                    {
                        HeroInCombat[0].GetComponent<HeroFSM>().currentState = HeroFSM.HeroStates.CHOOSING;
                    }
                    else
                    {
                        HeroInCombat[1].GetComponent<HeroFSM>().currentState = HeroFSM.HeroStates.CHOOSING;
                    }
                    currentState = BattleStates.IDLE;
                    Vector3 moveUp = new Vector3(0, 7f, 0);
                    indicatorTurn1.GetComponent<Transform>().position = SpawnLocationHero[0].GetComponent<Transform>().position + moveUp;
                }
                else
                {
                    if (OrderList[0] == "PC3")
                    {
                        indicatorTurn1.SetActive(true);
                        PlayerTurn = "PC3";
                        InfoPanel2.GetComponent<Text>().text = "Inomi";
                        InfoPanel3.GetComponent<Text>().text = "Inomi";
                        if (HeroInCombat[0].name == "PC3")
                        {
                            HeroInCombat[0].GetComponent<HeroFSM>().currentState = HeroFSM.HeroStates.CHOOSING;
                        }
                        else
                        {
                            HeroInCombat[2].GetComponent<HeroFSM>().currentState = HeroFSM.HeroStates.CHOOSING;
                        }
                        currentState = BattleStates.IDLE;
                        Vector3 moveUp = new Vector3(0, 7f, 0);
                        indicatorTurn1.GetComponent<Transform>().position = SpawnLocationHero[1].GetComponent<Transform>().position + moveUp;

                    }
                    else
                    {
                        


                            indicatorTurn1.SetActive(true);
                            PlayerTurn = "PC";
                            InfoPanel2.GetComponent<Text>().text = "Miyagi";
                            InfoPanel3.GetComponent<Text>().text = "Miyagi";
                          
                            HeroInCombat[0].GetComponent<HeroFSM>().currentState = HeroFSM.HeroStates.CHOOSING;
                            currentState = BattleStates.IDLE;
                            Vector3 moveUp = new Vector3(0, 7f, 0);
                            indicatorTurn1.GetComponent<Transform>().position = PC.GetComponent<Transform>().position + moveUp;

                    }
                }
                InnerTurnCounter = InnerTurnCounter + 1;
                TurnCounter = InnerTurnCounter / (OrderList.Count - 1);
                InfoPanel1.GetComponent<Text>().text = TurnCounter.ToString();

                break;


            case (BattleStates.WIN):
                if(YouWonFlag)
                {
                    SceneManager.UnloadSceneAsync("BattleSceneProto");
                    SceneManager.LoadScene("EndingScene");
                }
              for(int exp = 0; exp < HeroInCombatArray.Length;exp++)
                {
                    HeroInCombatArray[exp].GetComponent<HeroFSM>().SaveGains();
                }
              for(int exp2 = 0; exp2 <DeadHeroes.Count;exp2++)
                {
                    DeadHeroes[exp2].GetComponent<HeroFSM>().SaveGains();
                }

               
                    BossTrinketLoot();
              
                DontDestroyOnLoad(GameObject.Find("StatsCarrier"));
                DontDestroyOnLoad(GameObject.Find("osahara"));
                DontDestroyOnLoad(GameObject.Find("Player"));
                DontDestroyOnLoad(GameObject.Find("Inomi"));
                Vector3 feedback = new Vector3(-2, 2, 0);
                GameObject.Find("Player").GetComponent<Transform>().position = GameObject.Find("Player").GetComponent<Transform>().position + feedback;
                GameObject.Find("Player").GetComponent<SpriteRenderer>().enabled = true;
                GameObject.Find("Player").GetComponent<BoxCollider2D>().enabled = false;
                GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().ChangeofScene();
                DontDestroyOnLoad(GameObject.Find("Canvas2"));
                GameObject.Find("Player").GetComponent<BasicContolScript>().Scena = 0;
                SceneManager.UnloadSceneAsync("BattleSceneProto");

                SceneManager.LoadScene(GameObject.Find("Player").GetComponent<BasicContolScript>().LastSceneEnter);

                break;
            case (BattleStates.LOSE):
                SceneManager.UnloadSceneAsync("BattleSceneProto");
                SceneManager.LoadScene("MainMenu");
                break;


        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(10);
    }

    public void ScanEnemy()
    {

        int howManyEnemy = EnemyInCombat.Count;
        if (howManyEnemy == 1)
        {
            GameObject Enemy1 = EnemyInCombat[0];
            string name = Enemy1.GetComponent<EnemyFSM>().NPCname;
            Btn1.SetActive(true);
            Btn1.GetComponentInChildren<Text>().text = name;


        }
        if (howManyEnemy == 2)
        {

            GameObject Enemy2 = EnemyInCombat[0];
            GameObject Enemy1 = EnemyInCombat[1];
            string name2 = Enemy2.GetComponent<EnemyFSM>().NPCname;
            string name1 = Enemy1.GetComponent<EnemyFSM>().NPCname;
            Btn1.SetActive(true);
            Btn1.GetComponentInChildren<Text>().text = name1;


            Btn2.SetActive(true);
            Btn2.GetComponentInChildren<Text>().text = name2;
        }
        if (howManyEnemy == 3)
        {
            GameObject Enemy1 = EnemyInCombat[2];
            GameObject Enemy2 = EnemyInCombat[1];
            GameObject Enemy3 = EnemyInCombat[0];

            string name3 = Enemy3.GetComponent<EnemyFSM>().NPCname;
            string name2 = Enemy2.GetComponent<EnemyFSM>().NPCname;
            string name1 = Enemy1.GetComponent<EnemyFSM>().NPCname;

            Btn1.SetActive(true);
            Btn1.GetComponentInChildren<Text>().text = name1;

            Btn2.SetActive(true);
            Btn2.GetComponentInChildren<Text>().text = name2;

            Btn3.SetActive(true);
            Btn3.GetComponentInChildren<Text>().text = name3;
        }

    }

    public void ScanEnemySkillUsage(int spellId)
    {
        Btn4.SetActive(false);
        Btn5.SetActive(false);
        Btn6.SetActive(false);
        friendlySkillFlag = false;
        SpellId = spellId;
        int howManyEnemy = EnemyInCombat.Count;
        if (howManyEnemy == 1)
        {
            GameObject Enemy1 = EnemyInCombat[0];
            string name = Enemy1.GetComponent<EnemyFSM>().NPCname;
            Btn4.SetActive(true);
            Btn4.GetComponentInChildren<Text>().text = name;
          
            int spell = SpellId;
            Vector3 moveUp = new Vector3(0, 7f, 0);
            Btn4.GetComponent<OnMouseTrigger>().MoveTo = EnemyInCombat[0].GetComponent<Transform>().position + moveUp;
            Btn4.GetComponent<OnMouseTrigger>().Selector.GetComponent<SpriteRenderer>().color = Color.red;


        }
        if (howManyEnemy == 2)
        {

            GameObject Enemy2 = EnemyInCombat[0];
            GameObject Enemy1 = EnemyInCombat[1];
            string name2 = Enemy2.GetComponent<EnemyFSM>().NPCname;
            string name1 = Enemy1.GetComponent<EnemyFSM>().NPCname;
            Btn4.SetActive(true);
            Btn4.GetComponentInChildren<Text>().text = name1;
            Vector3 moveUp = new Vector3(0, 7f, 0);
            Btn4.GetComponent<OnMouseTrigger>().MoveTo = EnemyInCombat[1].GetComponent<Transform>().position + moveUp;
            Btn4.GetComponent<OnMouseTrigger>().Selector.GetComponent<SpriteRenderer>().color = Color.red;
            Btn5.SetActive(true);
            Btn5.GetComponentInChildren<Text>().text = name2;
            Btn5.GetComponent<OnMouseTrigger>().MoveTo = EnemyInCombat[0].GetComponent<Transform>().position + moveUp;
            Btn5.GetComponent<OnMouseTrigger>().Selector.GetComponent<SpriteRenderer>().color = Color.red;
        }
        if (howManyEnemy == 3)
        {
            GameObject Enemy1 = EnemyInCombat[2];
            GameObject Enemy2 = EnemyInCombat[1];
            GameObject Enemy3 = EnemyInCombat[0];


            string name3 = Enemy3.GetComponent<EnemyFSM>().NPCname;
            string name2 = Enemy2.GetComponent<EnemyFSM>().NPCname;
            string name1 = Enemy1.GetComponent<EnemyFSM>().NPCname;
            Btn4.SetActive(true);
            Btn4.GetComponentInChildren<Text>().text = name1;
            Vector3 moveUp = new Vector3(0, 7f, 0);
            Btn4.GetComponent<OnMouseTrigger>().MoveTo = EnemyInCombat[2].GetComponent<Transform>().position + moveUp;
            Btn4.GetComponent<OnMouseTrigger>().Selector.GetComponent<SpriteRenderer>().color = Color.red;

            Btn5.SetActive(true);
            Btn5.GetComponentInChildren<Text>().text = name2;
            Btn5.GetComponent<OnMouseTrigger>().MoveTo = EnemyInCombat[1].GetComponent<Transform>().position + moveUp;
            Btn5.GetComponent<OnMouseTrigger>().Selector.GetComponent<SpriteRenderer>().color = Color.red;

            Btn6.SetActive(true);
            Btn6.GetComponentInChildren<Text>().text = name3;
            Btn6.GetComponent<OnMouseTrigger>().MoveTo = EnemyInCombat[0].GetComponent<Transform>().position + moveUp;
            Btn6.GetComponent<OnMouseTrigger>().Selector.GetComponent<SpriteRenderer>().color = Color.red;
        }






    }

    public void ScanFriendlySkillUsage(int spellId)
    {
        Btn4.SetActive(false);
        Btn5.SetActive(false);
        Btn6.SetActive(false);
        SpellId = spellId;
        int howManyHeroes = HeroInCombat.Count;
        if (howManyHeroes == 1)
        {
            GameObject Hero1 = HeroInCombat[0];
            string name = Hero1.GetComponent<HeroFSM>().name;
            if (name == "PC")
            {
                name = "Miyagi";


            }
            Btn4.SetActive(true);
            Btn4.GetComponentInChildren<Text>().text = name;
            Vector3 moveUp = new Vector3(0, 70f, 0);
            Btn4.GetComponent<OnMouseTrigger>().MoveTo = HeroInCombat[0].GetComponent<Transform>().position + moveUp;
            int spell = SpellId;




        }
        if (howManyHeroes == 2)
        {

            GameObject Hero2 = HeroInCombat[0];
            GameObject Hero1 = HeroInCombat[1];
            string name2 = Hero2.GetComponent<HeroFSM>().name;
            string name1 = Hero1.GetComponent<HeroFSM>().name;
            if (name1 == "PC")
            {
                name1 = "Miyagi";
               
               
            }

            if (name2 == "PC2")
            {
               
                name2 = "Osahara";
                
            }


            Btn4.SetActive(true);
            //Btn4.GetComponentInChildren<Text>().text = name1;
            Btn4.GetComponentInChildren<Text>().text = "Osahara";
            Vector3 moveUp = new Vector3(0, 7f, 0);
            Btn4.GetComponent<OnMouseTrigger>().MoveTo = HeroInCombat[1].GetComponent<Transform>().position + moveUp;
            Btn4.GetComponent<OnMouseTrigger>().Selector.GetComponent<SpriteRenderer>().color = Color.green;
            Btn5.SetActive(true);
            //Btn5.GetComponentInChildren<Text>().text = name2;
            Btn5.GetComponentInChildren<Text>().text = "Miyagi";
            Btn5.GetComponent<OnMouseTrigger>().MoveTo = HeroInCombat[0].GetComponent<Transform>().position + moveUp;
            Btn5.GetComponent<OnMouseTrigger>().Selector.GetComponent<SpriteRenderer>().color = Color.green;

        }
        if (howManyHeroes == 3)
        {
            GameObject Hero1 = HeroInCombat[2];
            GameObject Hero2 = HeroInCombat[1];
            GameObject Hero3 = HeroInCombat[0];

          
            string name3 = Hero3.GetComponent<HeroFSM>().name;
            string name2 = Hero2.GetComponent<HeroFSM>().name;
            string name1 = Hero1.GetComponent<HeroFSM>().name;
            if (name1 == "PC")
            {
                name1 = "Miyagi";


            }

            if (name2 == "PC2")
            {

                name2 = "Osahara";

            }

            if (name3 == "PC3")
            {
             
                name3 = "Inomi";
            }
            Btn4.SetActive(true);
            //Btn4.GetComponentInChildren<Text>().text = name1;
            Btn4.GetComponentInChildren<Text>().text = "Inomi";
            Vector3 moveUp = new Vector3(0, 7f, 0);
            Btn4.GetComponent<OnMouseTrigger>().MoveTo = HeroInCombat[2].GetComponent<Transform>().position + moveUp;
            Btn4.GetComponent<OnMouseTrigger>().Selector.GetComponent<SpriteRenderer>().color = Color.green;

            Btn5.SetActive(true);
            //Btn5.GetComponentInChildren<Text>().text = name2;
            Btn5.GetComponentInChildren<Text>().text = "Osahara";
            Btn5.GetComponent<OnMouseTrigger>().MoveTo = HeroInCombat[1].GetComponent<Transform>().position + moveUp;
            Btn5.GetComponent<OnMouseTrigger>().Selector.GetComponent<SpriteRenderer>().color = Color.green;

            Btn6.SetActive(true);
            //Btn6.GetComponentInChildren<Text>().text = name3;
            Btn6.GetComponentInChildren<Text>().text = "Miyagi";
            Btn6.GetComponent<OnMouseTrigger>().MoveTo = HeroInCombat[0].GetComponent<Transform>().position + moveUp;
            Btn6.GetComponent<OnMouseTrigger>().Selector.GetComponent<SpriteRenderer>().color = Color.green;
        }

        friendlySkillFlag = true;
    }

    public void Target1()
    {


        if (!friendlySkillFlag)
        {
            int max = EnemyInCombat.Count;

            Target = EnemyInCombat[max - 1];
            string name = Target.name;

            GameObject.Find(PlayerTurn).GetComponent<HeroFSM>().SelectTarget(name);


            GameObject.Find(PlayerTurn).GetComponent<TestingSkill>().CastMethod(SpellId);
          
        }

        else
        {
            if(friendlySkillFlag)
            {
                int max = HeroInCombat.Count;

                Target = HeroInCombat[max - 1];
                string name = Target.name;

                GameObject.Find(PlayerTurn).GetComponent<HeroFSM>().SelectTarget(name);

                GameObject.Find(PlayerTurn).GetComponent<TestingSkill>().CastMethod(SpellId);
            }
        }

        EnemySelection.SetActive(false);
        SkillPanel.SetActive(false);
        Btn4.SetActive(false);
        Btn5.SetActive(false);
        Btn6.SetActive(false);
    }

    public void Target2()
    {
        if (!friendlySkillFlag)
        {
            int max = EnemyInCombat.Count;

            Target = EnemyInCombat[max - 2];
            string name = Target.name;

            GameObject.Find(PlayerTurn).GetComponent<HeroFSM>().SelectTarget(name);

            GameObject.Find(PlayerTurn).GetComponent<TestingSkill>().CastMethod(SpellId);
        }

        else
        {
            if (friendlySkillFlag)
            {
                int max = HeroInCombat.Count;

                Target = HeroInCombat[max - 2];
                string name = Target.name;

                GameObject.Find(PlayerTurn).GetComponent<HeroFSM>().SelectTarget(name);

                GameObject.Find(PlayerTurn).GetComponent<TestingSkill>().CastMethod(SpellId);


            }
        }
        EnemySelection.SetActive(false);
        SkillPanel.SetActive(false);
        Btn4.SetActive(false);
        Btn5.SetActive(false);
        Btn6.SetActive(false);
    }
    public void Target3()
    {
        if (!friendlySkillFlag)
        {
            int max = EnemyInCombat.Count;

            Target = EnemyInCombat[max - 3];
            string name = Target.name;

            GameObject.Find(PlayerTurn).GetComponent<HeroFSM>().SelectTarget(name);


            GameObject.Find(PlayerTurn).GetComponent<TestingSkill>().CastMethod(SpellId);

        }

        else
        {
            if (friendlySkillFlag)
            {
                int max = HeroInCombat.Count;

                Target = HeroInCombat[max - 3];
                string name = Target.name;

                GameObject.Find(PlayerTurn).GetComponent<HeroFSM>().SelectTarget(name);

                GameObject.Find(PlayerTurn).GetComponent<TestingSkill>().CastMethod(SpellId);

            }
        }
        EnemySelection.SetActive(false);
        SkillPanel.SetActive(false);
        Btn4.SetActive(false);
        Btn5.SetActive(false);
        Btn6.SetActive(false);
    }

    public void Target4()
    {
        int max = EnemyInCombat.Count;
        Target = EnemyInCombat[max - 4];
        string name = Target.name;
        PC.GetComponent<HeroFSM>().SelectTarget(name);
        if (SpellId == 2)
        {
         //   GameObject.Find("TestSkills").GetComponent<TestingSkill>().Spell_ID_2();
        }
    }

    public void KillConf(string name)
    {
        for (int i = 0; i < EnemyInCombatArray.Length; i++)
        {
            if (EnemyInCombatArray[i].name == name)
            {
                EnemyInCombatArray[i] = EnemyInCombatArray[EnemyInCombatArray.Length - 1];
                System.Array.Resize<GameObject>(ref EnemyInCombatArray, EnemyInCombatArray.Length - 1);

            }
        }
        EnemyInCombat.AddRange(EnemyInCombatArray);
        OrderList.Clear();
        for (int i = 0; i < HeroInCombat.Count; i++)
        {
            OrderList.Add(HeroInCombat[i].name);
        }


        for (int i = 0; i < EnemyInCombat.Count; i++)
        {
            OrderList.Add(EnemyInCombat[i].name);
        }
        OrderList.Add("Buffer");

        currentState = BattleStates.WAIT;
    }


    public void KillConfHero(string name)
    {
        if (HeroInCombatArray.Length == 1)
        {
            currentState = BattleStates.LOSE;
        }
        else
        {
            for (int i = 0; i < HeroInCombatArray.Length; i++)
            {
                if (HeroInCombatArray[i].name == name)
                {
                    if (HeroInCombatArray.Length > 1)
                    {
                        HeroInCombatArray[i] = HeroInCombatArray[HeroInCombatArray.Length - 1];
                        System.Array.Resize<GameObject>(ref HeroInCombatArray, HeroInCombatArray.Length - 1);
                    }
                    else
                    {
                        HeroInCombatArray[i] = null;
                    }
                }
            }
            HeroInCombat.AddRange(HeroInCombatArray);
            OrderList.Clear();
            for (int i = 0; i < HeroInCombat.Count; i++)
            {
                OrderList.Add(HeroInCombat[i].name);
            }


            for (int i = 0; i < EnemyInCombat.Count; i++)
            {
                OrderList.Add(EnemyInCombat[i].name);
            }
            OrderList.Add("Buffer");

            DeadHeroes.Add(GameObject.Find(name));
            currentState = BattleStates.WAIT;
        }
    }

    public void HeroRess()
    {
        if (DeadHeroes.Count > 0)
        {
            int newSlot = HeroInCombatArray.Length;
            System.Array.Resize<GameObject>(ref HeroInCombatArray, HeroInCombatArray.Length + 1);
            if (DeadHeroes[0] != null)
            {
                HeroInCombatArray[newSlot] = DeadHeroes[0];
                HeroInCombatArray[newSlot].GetComponent<HeroFSM>().curHp = 200;
                switch(DeadHeroes[0].name)
                {
                    case "PC2":
                        {
                            HeroInCombatArray[newSlot].AddComponent<SpriteRenderer>().sprite = GameObject.Find("osahara").GetComponent<SpriteRenderer>().sprite;
                            HeroInCombatArray[newSlot].GetComponent<SpriteRenderer>().sortingOrder = 11;
                            HeroInCombatArray[newSlot].GetComponent<SpriteRenderer>().flipX = true;
                        }
                        break;
                    case "PC3":
                        {
                            HeroInCombatArray[newSlot].AddComponent<SpriteRenderer>().sprite = GameObject.Find("Inomi").GetComponent<SpriteRenderer>().sprite;
                            HeroInCombatArray[newSlot].GetComponent<SpriteRenderer>().sortingOrder = 11;
                            HeroInCombatArray[newSlot].GetComponent<SpriteRenderer>().flipX = true;
                        }
                        break;
                }
            }
            else
            {
                if(DeadHeroes[1] !=null)
                {
                    HeroInCombatArray[newSlot] = DeadHeroes[1];
                }
            }
        }
        else
        {
            Debug.Log("No heroes to ress");
        }

        HeroInCombat.AddRange(HeroInCombatArray);
        OrderList.Clear();
        for (int i = 0; i < HeroInCombat.Count; i++)
        {
            OrderList.Add(HeroInCombat[i].name);
        }


        for (int i = 0; i < EnemyInCombat.Count; i++)
        {
            OrderList.Add(EnemyInCombat[i].name);
        }
        OrderList.Add("Buffer");
        currentState = BattleStates.WAIT;
    }


    public void BossTrinketLoot()
    {
        switch((GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().killedEnemyPatrol))
        {
            case "EnemySpawn_boss_tutorial1":
                {
                    GameObject.Find("StatsCarrier").GetComponent<TrinketsList>().ListOfTrinkets.Add(GameObject.Find("StatsCarrier").GetComponent<TrinketsList>().ListOfAllGameTrinkets[1]);
                    GameObject.Find("StatsCarrier").GetComponent<TrinketsList>().ListOfTrinketsSprite.Add(GameObject.Find("trinketId_002").GetComponent<SpriteRenderer>().sprite);
                    
                }
                break;
        }
    }

}

