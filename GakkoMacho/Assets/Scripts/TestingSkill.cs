using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
[System.Serializable]
public class TestingSkill : MonoBehaviour {

    public Skill healingPowder;
    public Skill FireBall;
    public Skill MoonlightStream;
    public GameObject TargetOfSpell;
    public HeroFSM HFSM;
    List<string> listofskillsnames;
    public GameObject Btn1;
    public GameObject Btn2;
    public GameObject Btn3;
    public GameObject Btn4;
    public GameObject Btn5;
    public GameObject Btn6;
    public GameObject Btn7;
    public GameObject WaterSpecialBtn;
    
    public GameObject SkillPanel;
    public Vector2 orinPos;
    public Vector2 oriPos2;
    public GameObject Panel;
    public float oldy;
    int lastIndex;
    int LastIndexItem;
    public List<GameObject> ListOfbutton = new List<GameObject>();
    public List<Skill> ListOfSkills = new List<Skill>();
    public List<Item> ListOfItems = new List<Item>();
    public List<GameObject> ListOfbuttonToDestory = new List<GameObject>();
    public string WhichHero;
    public string WhatElement;


    private void Start()
    {

        HFSM = GetComponent<HeroFSM>();
        
        orinPos = new Vector2 (Btn1.transform.position.x,Btn1.transform.position.y);
        oriPos2 = new Vector2(Btn2.transform.position.x, Btn2.transform.position.y);
     



    }


    private void Update()
    {
        WhichHero = GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().OrderList[0];
        if (WhichHero == "PC")
        {
            ListOfSkills = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero1.SkillList;
            ListOfItems = GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems;
            lastIndex = ListOfSkills.Count;
            LastIndexItem = ListOfItems.Count - 1;
            WhatElement = "Water";

        }
        if (WhichHero == "PC2")
        {
            ListOfSkills = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero2.SkillList;
            ListOfItems = GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems;
            lastIndex = ListOfSkills.Count;
            LastIndexItem = ListOfItems.Count - 1;
            WhatElement = "Fire";

        }
        if (WhichHero == "PC3")
        {
            ListOfSkills = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero3.SkillList;
            ListOfItems = GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems;
            lastIndex = ListOfSkills.Count;
            LastIndexItem = ListOfItems.Count - 1;
            WhatElement = "Earth";
        }


    }

    // Each skill and item has own method which then is search by other methords in other scripts

    public void Spell_ID_1()
        //healing powder
    {

        for (int y = 0; y < ListOfSkills.Count; y++)
        {
            if (ListOfSkills[y].spellID == 1)
            {
                string name = ListOfSkills[y].name;
                float dmg = ListOfSkills[y].baseDmg;
                string type = ListOfSkills[y].type;
                float cost = ListOfSkills[y].cost;
                string element = ListOfSkills[y].element;

                TargetOfSpell.GetComponent<HeroFSM>().UseSpell(dmg, cost, type, name,element);





                GameObject.Find("BattleLog").GetComponentInChildren<Text>().text = GameObject.Find("BattleLog").GetComponentInChildren<Text>().text + "Janusz used " + name + " to deals " + dmg + " damage \n";
                Btn1.SetActive(false);
                Btn2.SetActive(false);
                Btn3.SetActive(false);
                Btn4.SetActive(false);
                for (int i = 0; i < ListOfbutton.Count; i++)
                {
                    if (ListOfbutton[i] != null)
                    {
                        ListOfbutton[i].SetActive(false);
                    }
                }
                HFSM.actionPoints = HFSM.actionPoints - 50;
                HFSM.currentState = HeroFSM.HeroStates.ANIMATION;

            }
        }

    }

    

    public void Item_ID_8()
    {
        //Tomato Juice //Cleanse
        // That checks if item is still posseded by Player if not nothing will happend

        for (int y = 0; y < ListOfItems.Count; y++)
        {
            if (ListOfItems[y].ItemID == 8)
            {
                string name = ListOfItems[y].name;
                float dmg = ListOfItems[y].baseDmg;
                string type = ListOfItems[y].type;
                float cost = 0;
                int quantity = ListOfItems[y].quantity;
                string element = "neutral";
                TargetOfSpell.GetComponent<HeroFSM>().UseSpell(dmg, cost, type, name, element);
                //Upon usage item is consumed
                quantity = quantity - 1;
                //Deletes item if players use all of it
                GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems[y].quantity = quantity;
                if (GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems[y].quantity == 0)
                {
                    GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems.RemoveAt(y);
                }


                for (int i = 0; i < ListOfbutton.Count; i++)
                {
                    if (ListOfbutton[i] != null)
                    {
                        ListOfbutton[i].SetActive(false);
                    }
                }
                HFSM.actionPoints = HFSM.actionPoints - 50;
                HFSM.currentState = HeroFSM.HeroStates.ANIMATION;
            }
        }

    }
    //Active Trinkets are spell with 0 before id 
    public void Spell_ID_001()
        {
        //Mystic Eye
        // That checks if item is still posseded by Player if not nothing will happend

        for (int y = 0; y < ListOfSkills.Count; y++)
        {
            if (ListOfSkills[y].spellID == 001)
            {
                string name = ListOfSkills[y].name;
                float dmg = ListOfSkills[y].baseDmg;
                string type = ListOfSkills[y].type;
                float cost = ListOfSkills[y].cost;
                string element = ListOfSkills[y].element;

                TargetOfSpell.GetComponent<HeroFSM>().UseSpell(dmg, cost, type, name, element);





                GameObject.Find("BattleLog").GetComponentInChildren<Text>().text = GameObject.Find("BattleLog").GetComponentInChildren<Text>().text + "Janusz used " + name + " to deals " + dmg + " damage \n";
                Btn1.SetActive(false);
                Btn2.SetActive(false);
                Btn3.SetActive(false);
                Btn4.SetActive(false);
                for (int i = 0; i < ListOfbutton.Count; i++)
                {
                    if (ListOfbutton[i] != null)
                    {
                        ListOfbutton[i].SetActive(false);
                    }
                }
                HFSM.actionPoints = HFSM.actionPoints - 100;
                HFSM.currentState = HeroFSM.HeroStates.ANIMATION;

            }
        }
    }


    public void CastMethod(int id)
    {
        string typeOfUsage;
        if(id < 0)
        {
            typeOfUsage = "Item";
            id = id * (-1);
        }
        else
        {
            typeOfUsage = "Skill";
        }
        switch (typeOfUsage)
        {
            case "Skill":
                {
                    for (int y = 0; y < ListOfSkills.Count; y++)
                    {
                        if (ListOfSkills[y].spellID == id)
                        {
                            string name = ListOfSkills[y].name;
                            float dmg = ListOfSkills[y].baseDmg;
                            string type = ListOfSkills[y].type;
                            float cost = ListOfSkills[y].cost;
                            string element = ListOfSkills[y].element;
                            if(id == 11)
                            {
                                TargetOfSpell = GameObject.Find("PC3");
                            }
                            
                            TargetOfSpell.GetComponent<HeroFSM>().UseSpell(dmg, cost, type, name, element);





                            //GameObject.Find("BattleLog").GetComponentInChildren<Text>().text = GameObject.Find("BattleLog").GetComponentInChildren<Text>().text + "Janusz used " + name + " to deals " + dmg + " damage \n";
                            Btn1.SetActive(false);
                            Btn2.SetActive(false);
                            Btn3.SetActive(false);
                            Btn4.SetActive(false);
                            for (int i = 0; i < ListOfbutton.Count; i++)
                            {
                                if (ListOfbutton[i] != null)
                                {
                                    ListOfbutton[i].SetActive(false);
                                }
                            }
                            HFSM.actionPoints = HFSM.actionPoints - 100;
                            HFSM.currentState = HeroFSM.HeroStates.ANIMATION;

                        }
                    }
                }
                break;
            case "Item":
                {
                    for (int y = 0; y < ListOfItems.Count; y++)
                    {
                        if (ListOfItems[y].ItemID == id)
                        {
                            string name = ListOfItems[y].name;
                            float dmg = ListOfItems[y].baseDmg;
                            string type = ListOfItems[y].type;
                            float cost = 0;
                            int quantity = ListOfItems[y].quantity;
                            string element = "neutral";
                            TargetOfSpell.GetComponent<HeroFSM>().UseSpell(dmg, cost, type, name, element);
                            //Upon usage item is consumed
                            quantity = quantity - 1;
                            //Deletes item if players use all of it
                            GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems[y].quantity = quantity;
                            if (GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems[y].quantity == 0)
                            {
                                GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems.RemoveAt(y);
                            }


                            for (int i = 0; i < ListOfbutton.Count; i++)
                            {
                                if (ListOfbutton[i] != null)
                                {
                                    ListOfbutton[i].SetActive(false);
                                }
                            }
                            HFSM.actionPoints = HFSM.actionPoints - 50;
                            HFSM.currentState = HeroFSM.HeroStates.ANIMATION;
                        }
                    }
                }
                break;
            default:
                {
                    Debug.Log("Skill/Item ID : not found");
                }
                break;
        }
    }

    //spawn number of buttons deteminted by numbers of skills and items posseed by Player
    public void SkillMenu()
    {
        Btn5.SetActive(false);
        Btn6.SetActive(false);
        Btn7.SetActive(false);
        if (GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().OrderList[0] == "PC" || GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().OrderList[0] == "PC2" || GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().OrderList[0] == "PC3")
        { //clearing 
            Btn5.SetActive(false);
            Btn6.SetActive(false);
            Btn7.SetActive(false);
            SkillPanel.SetActive(true);
            if(WhichHero == "PC")
            {
                WaterSpecialBtn.SetActive(true);
            }
            else
            {
                WaterSpecialBtn.SetActive(false);
            }
                for (int i = 0; i < ListOfbuttonToDestory.Count; i++)
            {
                Destroy(ListOfbuttonToDestory[i]);
            }
            ListOfbutton.Clear();
            Btn1.SetActive(true);
            Btn2.SetActive(true);
            Panel = GameObject.Find("SkillPanel");

            //Main For loop
            for (int i = 0; i < ListOfSkills.Count; i++)
            {
                if (i > 4)
                {
                    //adding new object to list
                    ListOfbutton.Add(new GameObject("Bronek"));
                    //transforming it to designeted position
                    ListOfbutton[i] = (GameObject)Instantiate(Btn1, Panel.GetComponent<Transform>().transform, true);
                    ListOfbutton[i].transform.SetParent(Panel.transform, true);
                    //if there is another button with same name it will get destoy its to avoid stacking
                    if (GameObject.Find("btn" + i))
                    {
                        Destroy(GameObject.Find("btn" + i));
                    }
                    //change of name of game object
                    ListOfbutton[i].name = "btn" + i;
                    ListOfbutton[i].GetComponent<Transform>().position = Btn1.GetComponent<Transform>().position;
                    float oldy2 = ListOfbutton[i].GetComponent<Transform>().position.y;
                    float newy2 = oldy2 - 1.1f;
                    //transforming down to panel 
                    Vector3 newpos2 = new Vector3(ListOfbutton[i].GetComponent<Transform>().position.x, newy2, 0);
                    ListOfbutton[i].GetComponent<Transform>().position = new Vector3(ListOfbutton[i].GetComponent<Transform>().position.x, newy2, ListOfbutton[i].GetComponent<Transform>().position.z);

                    ListOfbutton[i].GetComponentInChildren<Text>().text = ListOfSkills[i].name;
                    switch (WhichHero)
                    {
                        case "PC":
                            {
                                if (ListOfSkills[i].cost > GameObject.Find("PC").GetComponent<HeroFSM>().curMana)
                                {
                                    ListOfbutton[i].GetComponent<Button>().interactable = false;
                                    ListOfbutton[i].GetComponentInChildren<Text>().text = ListOfSkills[i].name + GameObject.Find("PC").GetComponent<HeroFSM>().curMana + "/" + ListOfSkills[i].cost;
                                }

                            }
                            break;

                        case "PC2":
                            {
                                if (ListOfSkills[i].cost > GameObject.Find("PC2").GetComponent<HeroFSM>().curMana)
                                {
                                    ListOfbutton[i].GetComponent<Button>().interactable = false;
                                    ListOfbutton[i].GetComponentInChildren<Text>().text = ListOfSkills[i].name + GameObject.Find("PC2").GetComponent<HeroFSM>().curMana + "/" + ListOfSkills[i].cost;
                                }
                            }
                            break;

                        case "PC3":
                            {
                                if (ListOfSkills[i].cost > GameObject.Find("PC3").GetComponent<HeroFSM>().curMana)
                                {
                                    ListOfbutton[i].GetComponent<Button>().interactable = false;
                                    ListOfbutton[i].GetComponentInChildren<Text>().text = ListOfSkills[i].name + GameObject.Find("PC3").GetComponent<HeroFSM>().curMana + "/" + ListOfSkills[i].cost;
                                }
                            }
                            break;
                    }


                    //clearing
                    ListOfbuttonToDestory.Add(ListOfbutton[i]);
                    Btn1.GetComponent<Transform>().position = ListOfbutton[i].GetComponent<Transform>().position;
                    Destroy(GameObject.Find("Bronek"));
                }
                //adding new object to list
                ListOfbutton.Add(new GameObject("Bronek"));
                //transforming it to designeted position
                ListOfbutton[i] = (GameObject)Instantiate(Btn1, Panel.GetComponent<Transform>().transform, true);
                ListOfbutton[i].transform.SetParent(Panel.transform, true);
                //if there is another button with same name it will get destoy its to avoid stacking
                if (GameObject.Find("btn" + i))
                {
                    Destroy(GameObject.Find("btn" + i));
                }
                //change of name of game object
                ListOfbutton[i].name = "btn" + i;
                ListOfbutton[i].GetComponent<Transform>().position = Btn1.GetComponent<Transform>().position;
                float oldy = ListOfbutton[i].GetComponent<Transform>().position.y;
                float newy = oldy - 1.1f;
                //transforming down to panel 
                Vector3 newpos = new Vector3(ListOfbutton[i].GetComponent<Transform>().position.x, newy, 0);
                ListOfbutton[i].GetComponent<Transform>().position = new Vector3(ListOfbutton[i].GetComponent<Transform>().position.x, newy, ListOfbutton[i].GetComponent<Transform>().position.z);

                ListOfbutton[i].GetComponentInChildren<Text>().text = ListOfSkills[i].name;
                switch(WhichHero)
                {
                    case "PC":
                        {
                            if(ListOfSkills[i].cost > GameObject.Find("PC").GetComponent<HeroFSM>().curMana)
                            {
                                ListOfbutton[i].GetComponent<Button>().interactable = false;
                                ListOfbutton[i].GetComponentInChildren<Text>().text = ListOfSkills[i].name + GameObject.Find("PC").GetComponent<HeroFSM>().curMana + "/" + ListOfSkills[i].cost;
                            } 

                        }
                        break;

                    case "PC2":
                        {
                            if (ListOfSkills[i].cost > GameObject.Find("PC2").GetComponent<HeroFSM>().curMana)
                            {
                                ListOfbutton[i].GetComponent<Button>().interactable = false;
                                ListOfbutton[i].GetComponentInChildren<Text>().text = ListOfSkills[i].name + GameObject.Find("PC2").GetComponent<HeroFSM>().curMana + "/" + ListOfSkills[i].cost;
                            }
                        }
                        break;

                    case "PC3":
                        {
                            if (ListOfSkills[i].cost > GameObject.Find("PC3").GetComponent<HeroFSM>().curMana)
                            {
                                ListOfbutton[i].GetComponent<Button>().interactable = false;
                                ListOfbutton[i].GetComponentInChildren<Text>().text = ListOfSkills[i].name + GameObject.Find("PC3").GetComponent<HeroFSM>().curMana + "/" + ListOfSkills[i].cost;
                            }
                        }
                        break;
                }
                

                //clearing
                ListOfbuttonToDestory.Add(ListOfbutton[i]);
                Btn1.GetComponent<Transform>().position = ListOfbutton[i].GetComponent<Transform>().position;
                Destroy(GameObject.Find("Bronek"));

            }

            for (int i = 0; i < ListOfbutton.Count; i++)
            {
                if (ListOfbutton[i] != null)
                {
                    if (ListOfbutton[i].name == "Bronek")
                    {
                        Destroy(ListOfbutton[i]);
                    }
                }
            }
            Btn1.GetComponent<Transform>().position = orinPos;
            Btn1.SetActive(false);
            Btn2.GetComponent<Transform>().position = oriPos2;
            Btn2.SetActive(false);
            
        }
    }




    public void ItemMenu()
    {
        Btn5.SetActive(false);
        Btn6.SetActive(false);
        Btn7.SetActive(false);
        if (GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().OrderList[0] == "PC" || GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().OrderList[0] == "PC2" || GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().OrderList[0] == "PC3")
        {
            SkillPanel.SetActive(true);
            if (GameObject.Find("Target1BtnSkill") == true)
            {
                GameObject.Find("Target1BtnSkill").SetActive(false);
            }

            if (GameObject.Find("Target2BtnSkill") == true)
            {
                GameObject.Find("Target2BtnSkill").SetActive(false);
            }

            if (GameObject.Find("Target3BtnSkill") == true)
            {
                GameObject.Find("Target3BtnSkill").SetActive(false);
            }


            for (int i = 0; i < ListOfbuttonToDestory.Count; i++)
            {
                Destroy(ListOfbuttonToDestory[i]);
            }
            ListOfbutton.Clear();



            Btn1.SetActive(true);
            Btn2.SetActive(true);
            
            Panel = GameObject.Find("SkillPanel");


            for (int i = 0; i < GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems.Count; i++)
            {
                if (GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems[i] != null)  //!=null
                {
                    if (i > 4)
                    {
                        ListOfbutton.Add(new GameObject("Bronek"));
                        ListOfbutton[i] = (GameObject)Instantiate(Btn2, Panel.GetComponent<Transform>().transform, true);
                        ListOfbutton[i].transform.SetParent(Panel.transform, true);
                        if (GameObject.Find("btn" + i))
                        {
                            Destroy(GameObject.Find("btn" + i));
                        }
                        ListOfbutton[i].name = "btn" + i;
                        ListOfbutton[i].GetComponent<Transform>().position = Btn2.GetComponent<Transform>().position;
                        float oldy2 = ListOfbutton[i].GetComponent<Transform>().position.y;
                        float newy2 = oldy2 - 1.1f;

                        Vector3 newpos2 = new Vector3(ListOfbutton[i].GetComponent<Transform>().position.x, newy2, 0);
                        ListOfbutton[i].GetComponent<Transform>().position = new Vector3(ListOfbutton[i].GetComponent<Transform>().position.x, newy2, ListOfbutton[i].GetComponent<Transform>().position.z);

                        ListOfbutton[i].GetComponentInChildren<Text>().text = GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems[i].name + " x" + GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems[i].quantity;

                        ListOfbuttonToDestory.Add(ListOfbutton[i]);
                        Btn2.GetComponent<Transform>().position = ListOfbutton[i].GetComponent<Transform>().position;
                        Destroy(GameObject.Find("Bronek"));
                        if (GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems[i].quantity == 0)
                        {
                            Destroy(GameObject.Find("btn" + i));
                        }
                    }
                    else
                    {
                        ListOfbutton.Add(new GameObject("Bronek"));
                        ListOfbutton[i] = (GameObject)Instantiate(Btn1, Panel.GetComponent<Transform>().transform, true);
                        ListOfbutton[i].transform.SetParent(Panel.transform, true);
                        if (GameObject.Find("btn" + i))
                        {
                            Destroy(GameObject.Find("btn" + i));
                        }
                        ListOfbutton[i].name = "btn" + i;
                        ListOfbutton[i].GetComponent<Transform>().position = Btn1.GetComponent<Transform>().position;
                        float oldy = ListOfbutton[i].GetComponent<Transform>().position.y;
                        float newy = oldy - 1.1f;

                        Vector3 newpos = new Vector3(ListOfbutton[i].GetComponent<Transform>().position.x, newy, 0);
                        ListOfbutton[i].GetComponent<Transform>().position = new Vector3(ListOfbutton[i].GetComponent<Transform>().position.x, newy, ListOfbutton[i].GetComponent<Transform>().position.z);

                        ListOfbutton[i].GetComponentInChildren<Text>().text = GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems[i].name + " x" + GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems[i].quantity;

                        ListOfbuttonToDestory.Add(ListOfbutton[i]);
                        Btn1.GetComponent<Transform>().position = ListOfbutton[i].GetComponent<Transform>().position;
                        Destroy(GameObject.Find("Bronek"));
                        if (GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems[i].quantity == 0)
                        {
                            Destroy(GameObject.Find("btn" + i));
                        }
                    }

                }
            }


            for (int i = 0; i < ListOfbutton.Count; i++)
            {
                if (ListOfbutton[i] != null)
                {
                    if (ListOfbutton[i].name == "Bronek")
                    {
                        Destroy(ListOfbutton[i]);
                    }
                }
            }


            Btn1.GetComponent<Transform>().position = orinPos;
            Btn1.SetActive(false);
            Btn2.GetComponent<Transform>().position = oriPos2;
            Btn2.SetActive(false);


        }

    }

}
