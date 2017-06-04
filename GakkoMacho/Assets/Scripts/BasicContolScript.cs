using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BasicContolScript : MonoBehaviour {
    private Rigidbody2D body;
    public float maxspeed = 10f;
   
    public GameObject CharaPanel;
    public GameObject MainMenuPanel;
    public GameObject QuestLogPanel;
    public GameObject ItemsPanel;
    public GameObject SkillTreePanel;
    public GameObject ExActionBar;
    public GameObject OptionPanel;
    public GameObject AlarmText;
    public GameObject IndicatorPrompt1;
    public GameObject IndicatorPrompt2;
    public GameObject IndicatorPrompt3;
    public GameObject TalentParty2;
    public GameObject TalentParty3;
    public GameObject panelHero1;
    public GameObject CharaPanel2;
    public GameObject CharaPanel3;
    public GameObject TeamParty2Btn;
    public GameObject TeamParty3Btn;
    public GameObject walkingSound;
    public GameObject SaveSubPanel;
    public GameObject LoadSubPanel;
    public GameObject[] BackpackSlots = new GameObject[15];
    public GameObject[] PlayersSpawns = new GameObject[1];
    public bool UpdateTimerDone = false;
    public bool LayerChangeFlag = false;


    public string LastSceneEnter;
    int partyMember = 1;
    public int Scena;
    bool animationPlay;
    public bool wasLevel;
    private void Awake()
  
    {
        body = GetComponent<Rigidbody2D>();
    }

	// Use this for initialization
	void Start () {
        Scena = 0;
        CharaPanel = GameObject.Find("HeroStatsPanel");
        if ( Scena == 0)
            {
                CharaPanel.SetActive(false);
                MainMenuPanel.SetActive(false);
                QuestLogPanel.SetActive(false);
                ItemsPanel.SetActive(false);
                SkillTreePanel.SetActive(false);



        }

        wasLevel = false;
    }
	
	// Update is called once per frame
	void Update () {
        
        //PlayersSpawns = GameObject.FindGameObjectsWithTag("PlayerSpawns");
        if (Scena == 1)
        {
            ExActionBar.SetActive(false);

        }
        else
        {
            ExActionBar.SetActive(true);
        }

        if(Scena == 2)
        {

            PlayersSpawns = GameObject.FindGameObjectsWithTag("PlayerSpawns");
            if (PlayersSpawns.Length > 0 && PlayersSpawns[PlayersSpawns.Length -1] != null)
            {
                UpdateTimerDone = true;
            }

            if (UpdateTimerDone)
            {

                GameObject.Find("Player").GetComponent<Transform>().position = PlayersSpawns[PlayersSpawns.Length - 1].GetComponent<Transform>().position;
               // UpdateTimerDone = false;
                if (GameObject.Find("Player").GetComponent<Transform>().position == PlayersSpawns[PlayersSpawns.Length - 1].GetComponent<Transform>().position)
                {
                    Scena = 0;
                    PlayersSpawns[PlayersSpawns.Length - 1] = null;
                    UpdateTimerDone = false;
                }
              
               
            }
        }


        if(Scena == 3)
        {
            if(GameObject.Find("PlayerSpawn_Procedural_Basement"))
            {
                GameObject.Find("Player").GetComponent<Transform>().position = GameObject.Find("PlayerSpawn_Procedural_Basement").GetComponent<Transform>().position;
                if (GameObject.Find("Player").GetComponent<Transform>().position == GameObject.Find("PlayerSpawn_Procedural_Basement").GetComponent<Transform>().position)
                {
                    Scena = 0;
                }
            }
            
        }
       
      
      //  AlarmText.GetComponent<Transform>().position = resetAlarm;
     //   canvas = GameObject.Find("Canvas1");
     //   Panel = canvas.transform.Find("HeroStatsPanel").gameObject;
        float moveX = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            
           // GetComponent<SpriteRenderer>().sprite =  Resources.Load <Sprite> ("Characters/MainCharacters/Miyagi/chibi2");
            GetComponent<Animator>().SetTrigger("GoingLeft");
            walkingSound.GetComponent<AudioSource>().Play();
          
        }
        else
        {
            
            GetComponent<Animator>().ResetTrigger("GoingLeft");
            
            GetComponent<Animator>().SetTrigger("End");
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
           
            walkingSound.GetComponent<AudioSource>().Play();
           // GetComponent<SpriteRenderer>().sprite = Resources.Load <Sprite>("Characters/MainCharacters/Miyagi/chibi");
            GetComponent<Animator>().SetTrigger("GoingRight");
           
        }
        else
        {
            
            GetComponent<Animator>().ResetTrigger("GoingRight");

            GetComponent<Animator>().SetTrigger("End");
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            walkingSound.GetComponent<AudioSource>().Play();
          // GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Characters/MainCharacters/Miyagi/chibi3");
            GetComponent<Animator>().SetTrigger("GoingDown");
            

        }
        else
        {
            
            GetComponent<Animator>().ResetTrigger("GoingDown");
            GetComponent<Animator>().SetTrigger("End");
        }

        if (Scena == 0) {
            if (Input.GetKeyDown(KeyCode.C))
            {

                CharaPanelRun();


            }

        }

        if (Scena == 0)
        {
            if (Input.GetKeyDown(KeyCode.B))
            {

                ItemsPanelRun();



            }

        }

        if (Scena == 0)
        {
            if (Input.GetKeyDown(KeyCode.L))
            {

                QuestLogRun(); 

            }

        }

        if (Scena == 0 || Scena == 1)
        {
            if (Input.GetKeyDown(KeyCode.M))
            {

                MainMenuPanelRun();

            }

        }

        if (Scena == 0)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {

                SkillsPanelRun();

            }

        }




        float moveY = Input.GetAxis("Vertical");

      

        body.velocity = new Vector2(moveX * maxspeed, moveY*maxspeed);
      //  walkingSound.GetComponent<AudioSource>().Stop();
        if (GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().PartySize > 1 && CharaPanel2.activeSelf)
        {

            //    GameObject.Find("PartyPanel2").GetComponent<Transform>().position = GameObject.Find("PartyPanel1").GetComponent<Transform>().position;
            GameObject.Find("surname2").GetComponent<Text>().text = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero2.name.ToString();
            GameObject.Find("Level2").GetComponent<Text>().text = "Level " + GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero2.level.ToString();
            GameObject.Find("HpMax2").GetComponent<Text>().text = "Max Health " + GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero2.baseHP.ToString();
            GameObject.Find("ManaMax2").GetComponent<Text>().text = "Max Mana " + GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero2.baseMP.ToString();
            GameObject.Find("HeroSpriteView2").GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphics/Characters/MainCharacters/Osahara/osahara");
         



        }

        if (GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().PartySize > 2 && CharaPanel3.activeSelf)
        {

            //  GameObject.Find("PartyPanel3").GetComponent<Transform>().position = GameObject.Find("PartyPanel1").GetComponent<Transform>().position;
            GameObject.Find("surname3").GetComponent<Text>().text = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero3.name.ToString();
            GameObject.Find("Level3").GetComponent<Text>().text = "Level " + GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero3.level.ToString();
            GameObject.Find("HpMax3").GetComponent<Text>().text = "Max Health " + GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero3.baseHP.ToString();
            GameObject.Find("ManaMax3").GetComponent<Text>().text = "Max Mana " + GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero3.baseMP.ToString();
            GameObject.Find("HeroSpriteView3").GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphics/Characters/MainCharacters/Inomi/Inomi");
        }

    }

    IEnumerator waitForUpdate()
    {
        yield return new WaitForSeconds(1);
        UpdateTimerDone = true;

    }




    public void CharaPanelRun()
    {
       
        MainMenuPanel.SetActive(false);
        QuestLogPanel.SetActive(false);
        ItemsPanel.SetActive(false);
        SkillTreePanel.SetActive(false);
        TeamParty2Btn.SetActive(true);
        TeamParty3Btn.SetActive(true);
        CharaPanel2.SetActive(false);
        CharaPanel3.SetActive(false);
        if (GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().PartySize == 1)
        {
            TeamParty2Btn.SetActive(false);

            TeamParty3Btn.SetActive(false);
        }
        if (GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().PartySize == 2)
        {
           
            TeamParty3Btn.SetActive(false);
        }
        if (CharaPanel.activeSelf == false)
        {
            CharaPanel.SetActive(true);
            panelHero1.SetActive(true);
           

            if (GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().PartySize > 1 && CharaPanel2.activeSelf)
            {

                //    GameObject.Find("PartyPanel2").GetComponent<Transform>().position = GameObject.Find("PartyPanel1").GetComponent<Transform>().position;
                GameObject.Find("surname2").GetComponent<Text>().text = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero2.name.ToString();
                GameObject.Find("Level2").GetComponent<Text>().text = "Level " + GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero2.level.ToString();
                GameObject.Find("HpMax2").GetComponent<Text>().text = "Max Health " + GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero2.baseHP.ToString();
                GameObject.Find("ManaMax2").GetComponent<Text>().text = "Max Mana " + GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero2.baseMP.ToString();
                GameObject.Find("HeroSpriteView2").GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphics/Characters/Inomi");

            }
            if (GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().PartySize > 2 && CharaPanel3.activeSelf)
            {

                 //GameObject.Find("PartyPanel3").GetComponent<Transform>().position = GameObject.Find("PartyPanel1").GetComponent<Transform>().position;
                GameObject.Find("surname3").GetComponent<Text>().text = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero3.name.ToString();
                GameObject.Find("Level3").GetComponent<Text>().text = "Level " + GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero3.level.ToString();
                GameObject.Find("HpMax3").GetComponent<Text>().text = "Max Health " + GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero3.baseHP.ToString();
                GameObject.Find("ManaMax3").GetComponent<Text>().text = "Max Mana " + GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero3.baseMP.ToString();
                GameObject.Find("HeroSpriteView3").GetComponent<Image>().sprite = Resources.Load<Sprite>("Graphics/Characters/Inomi");
               

            }


            GameObject.Find("Level").GetComponent<Text>().text = "Level " + GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero1.level.ToString();
            GameObject.Find("HpMax").GetComponent<Text>().text = "Max Health " + GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero1.baseHP.ToString();
            GameObject.Find("ManaMax").GetComponent<Text>().text = "Max Mana " + GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero1.baseMP.ToString();
            BackpackSlots = GameObject.FindGameObjectsWithTag("BackPackUISlots");
            if (GameObject.Find("StatsCarrier").GetComponent<TrinketsList>().ListOfTrinkets.Count > 0)
            {
                for (int i = 0; i < GameObject.Find("StatsCarrier").GetComponent<TrinketsList>().ListOfTrinkets.Count; i++)
                {
                    BackpackSlots[i].GetComponent<Image>().sprite = GameObject.Find("StatsCarrier").GetComponent<TrinketsList>().ListOfTrinketsSprite[i];
                    BackpackSlots[i].GetComponent<TrinketAssignButtonScript>().TrinketID = GameObject.Find("StatsCarrier").GetComponent<TrinketsList>().ListOfTrinkets[i].id;

                }
            }
                
        }
        else
        {
          
            CharaPanel.SetActive(false);
        }
    }


    public void ItemsPanelRun()
    {
        IndicatorPrompt1.SetActive(false);
        IndicatorPrompt2.SetActive(false);
        CharaPanel.SetActive(false);
        MainMenuPanel.SetActive(false);
        QuestLogPanel.SetActive(false);
       
        SkillTreePanel.SetActive(false);
        if (ItemsPanel.activeSelf == false)
        {
            ItemsPanel.SetActive(true);
            GameObject.Find("ItemText").GetComponent<Text>().text = null;
            GameObject.Find("QuestItemsText").GetComponent<Text>().text = null;
            for (int i = 0; i < GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems.Count; i++)
            {

                GameObject.Find("ItemText").GetComponent<Text>().text = GameObject.Find("ItemText").GetComponent<Text>().text + GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems[i].name + " " + GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems[i].quantity + "\n";
            }
            for (int i = 0; i < GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfQuestsItems.Count; i++)
            {

                GameObject.Find("QuestItemsText").GetComponent<Text>().text = GameObject.Find("QuestItemsText").GetComponent<Text>().text + GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfQuestsItems[i].name + "\n";
            }

        }
        else
        {
            ItemsPanel.SetActive(false);

        }
    }


    public void QuestLogRun()
    {
        IndicatorPrompt1.SetActive(false);
        IndicatorPrompt2.SetActive(false);
        CharaPanel.SetActive(false);
        MainMenuPanel.SetActive(false);
       
        ItemsPanel.SetActive(false);
        SkillTreePanel.SetActive(false);
        if (QuestLogPanel.activeSelf == false)
        {
            QuestLogPanel.SetActive(true);


            GameObject.Find("QuestLogText").GetComponent<Text>().text = null;

            for (int i = 0; i < GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests.Count; i++)
            {
                if (GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests[i].isCompleted == false)
                {
                    GameObject.Find("QuestLogText").GetComponent<Text>().text = GameObject.Find("QuestLogText").GetComponent<Text>().text + GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests[i].name + "\n" + GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests[i].mainDesc + "\n" +
                    " Objective : \n" + GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests[i].objectiveDesc + "\n";
                }
            }


        }
        else
        {
            QuestLogPanel.SetActive(false);
        }
    }


    public void SkillsPanelRun()
    {
        if(IndicatorPrompt3.activeSelf)
        {
            IndicatorPrompt3.SetActive(false);
            wasLevel = false;
        }
        GameObject[] TalentCleanList;
        TalentCleanList = GameObject.FindGameObjectsWithTag("TalentTreeChoices");
        for(int i = 0; i < TalentCleanList.Length; i++)
        {
            TalentCleanList[i].SetActive(false);
        }
         
        CharaPanel.SetActive(false);
        MainMenuPanel.SetActive(false);
        QuestLogPanel.SetActive(false);
        ItemsPanel.SetActive(false);
        TalentParty2.SetActive(true);
        TalentParty3.SetActive(true);
        if(GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().PartySize == 1)
        {
            TalentParty2.SetActive(false);
            TalentParty3.SetActive(false);
        }
        if (GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().PartySize == 2)
        {
            TalentParty3.SetActive(false);
            
        }

        if (SkillTreePanel.activeSelf == false)
        {
            SkillTreePanel.SetActive(true);
          //  GameObject.Find("SkillText").GetComponent<Text>().text = null;
            if (partyMember == 1)
            {
                GameObject.Find("InfoText").GetComponent<Text>().text = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero1.MainMagic + " Choose your path";
              //  GameObject.Find("TalenPointsInfo").GetComponent<Text>().text = "Talent Points remaing : " + GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero1.talentPoints;
               

            }
            if (partyMember == 2)
            {
                GameObject.Find("InfoText").GetComponent<Text>().text = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero2.MainMagic + " Choose your path";
            //    GameObject.Find("TalenPointsInfo").GetComponent<Text>().text = "Talent Points remaing : " + GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero2.talentPoints;
               

            }
            if (partyMember == 3)
            {
               GameObject.Find("InfoText").GetComponent<Text>().text = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero3.MainMagic + " Choose your path";
               // GameObject.Find("TalenPointsInfo").GetComponent<Text>().text = "Talent Points remaing : " + GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero3.talentPoints;
           /*     for (int i = 0; i < GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero3.SkillList.Count; i++)
                {

                    GameObject.Find("SkillText").GetComponent<Text>().text = GameObject.Find("SkillText").GetComponent<Text>().text + GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero3.SkillList[i].name + " cost : " + GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero3.SkillList[i].cost + "\n";
                }*/

            }

        }
        else
        {
            SkillTreePanel.SetActive(false);
        }
    }


    public void MainMenuPanelRun()
    {
        CharaPanel.SetActive(false);
        OptionPanel.SetActive(false);
        QuestLogPanel.SetActive(false);
        ItemsPanel.SetActive(false);
        SkillTreePanel.SetActive(false);
        //SaveSubPanel.SetActive(false);
        //LoadSubPanel.SetActive(false);
        if (MainMenuPanel.activeSelf == false)
        {
            MainMenuPanel.SetActive(true);
            //   GameObject.Find("SaveBtnMainMenu").GetComponent<Button>().onClick.AddListener(SaveScript);
            SaveSubPanel.SetActive(false);
            LoadSubPanel.SetActive(false);
        }
        else
        {
            MainMenuPanel.SetActive(false);
         
        }
    }
    public void TalentTreeMemberChange1()
    {
        partyMember = 1;
        
    }

    public void TalentTreeMemberChange2()
    {
        partyMember = 2;
        
    }

    public void TalentTreeMemberChange3()
    {
        partyMember = 3;
        
    }

    public void SaveScript()
    {
       // GameObject.Find("SavingSystem").GetComponent<SaveLoadScript>().Save(gameObject);
    }

    public void Backpackrefresh()
    {
        BackpackSlots = GameObject.FindGameObjectsWithTag("BackPackUISlots");
        if (GameObject.Find("StatsCarrier").GetComponent<TrinketsList>().ListOfTrinkets.Count > 0)
        {
            for (int i = 0; i < GameObject.Find("StatsCarrier").GetComponent<TrinketsList>().ListOfTrinkets.Count; i++)
            {
                BackpackSlots[i].GetComponent<Image>().sprite = GameObject.Find("StatsCarrier").GetComponent<TrinketsList>().ListOfTrinketsSprite[i];
                BackpackSlots[i].GetComponent<TrinketAssignButtonScript>().TrinketID = GameObject.Find("StatsCarrier").GetComponent<TrinketsList>().ListOfTrinkets[i].id;

            }
        }
        else
        {
           foreach(GameObject i in BackpackSlots)
            {
                i.GetComponent<Image>().sprite = null;
                i.GetComponent<TrinketAssignButtonScript>().TrinketID = 0;
            }
        }
    }
    
}
