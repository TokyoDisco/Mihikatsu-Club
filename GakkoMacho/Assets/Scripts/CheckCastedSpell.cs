using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;

public class CheckCastedSpell : MonoBehaviour {
    //script used to check what skill/item was used//
    public string type;
    public string nameText;
    private Skill Skillname;
    private Item Itemname;
    public string desc;
    public GameObject TargetOfSpell;
    public GameObject btn;
    public HeroFSM HFSM;
    public int SpellId;
    public int ItemId;
    public string namePC;

	// Use this for initialization
	void Start () {

   //searching for right skill name
        nameText = GetComponentInChildren<Text>().text;
        if(GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().OrderList[0]=="PC")
        {
            namePC = "PC";
        }
        if (GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().OrderList[0] == "PC2")
        {
            namePC = "PC2";
        }

        if (GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().OrderList[0] == "PC3")
        {
            namePC = "PC3";
        }

        for (int i = 0; i < GameObject.Find(namePC).GetComponent<TestingSkill>().ListOfSkills.Count; i++)  //GameObject.Find(namePC)
        {
            if (GameObject.Find(namePC).GetComponent<TestingSkill>().ListOfSkills[i].name == nameText)  //(GameObject.Find("TestSkills").GetComponent<TestingSkill>().ListOfSkills[i].name == nameText)
            {
                Skillname = GameObject.Find(namePC).GetComponent<TestingSkill>().ListOfSkills[i];
            //search of its id and type
                SpellId = Skillname.spellID;
                desc = Skillname.description;
                type = Skillname.type;
            }

        }

        if (nameText == "Water Bank")
        {
            type = "WaterSpecial";
        }


        //searching for right item  name
        for (int i = 0; i < GameObject.Find(namePC).GetComponent<TestingSkill>().ListOfItems.Count; i++)
        {
            if (GameObject.Find(namePC).GetComponent<TestingSkill>().ListOfItems[i] != null)
            {


                if (GameObject.Find(namePC).GetComponent<TestingSkill>().ListOfItems[i].name + " x" + GameObject.Find(namePC).GetComponent<TestingSkill>().ListOfItems[i].quantity == nameText)
                {
                    Itemname = GameObject.Find(namePC).GetComponent<TestingSkill>().ListOfItems[i];
                    //search of its id and type
                    ItemId = Itemname.ItemID;
                    desc = Itemname.desc;
                    type = Itemname.type;
                }
            }
        }

        //checks what type of skill/item it is then active 1 of 3 onClick event to button
        if (type == "Damage")
        {
            btn.GetComponent<Button>().onClick.AddListener(Damage);
        }

        if (type == "Heal")
        {
            btn.GetComponent<Button>().onClick.AddListener(Heal);
        }

        if (type == "Mana")
        {
            btn.GetComponent<Button>().onClick.AddListener(Mana);
        }

        if (type == "Buff")
        {
            btn.GetComponent<Button>().onClick.AddListener(Heal);
        }

        if(type == "Summon")
        {
            btn.GetComponent<Button>().onClick.AddListener(Summon);
        }

        if(type == "Debuff")
        {
            btn.GetComponent<Button>().onClick.AddListener(Damage);
        }

        if(type == "WaterSpecial")
        {

        }


        if(type == "FireSpecial")
        {

        }

        if(type == "EarthSpecial")
        {

        }

        if(type == "AirSpecial")
        {

        }

    }

    private void Update()
    {


        nameText = GetComponentInChildren<Text>().text;
        if (GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().OrderList[0] == "PC")
        {
            namePC = "PC";
        }
        if (GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().OrderList[0] == "PC2")
        {
            namePC = "PC2";
        }

        if (GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().OrderList[0] == "PC3")
        {
            namePC = "PC3";
        }
        for (int i = 0; i < GameObject.Find(namePC).GetComponent<TestingSkill>().ListOfSkills.Count; i++)  //GameObject.Find(namePC)
        {
            if (GameObject.Find(namePC).GetComponent<TestingSkill>().ListOfSkills[i].name == nameText)  //(GameObject.Find("TestSkills").GetComponent<TestingSkill>().ListOfSkills[i].name == nameText)
            {
                Skillname = GameObject.Find(namePC).GetComponent<TestingSkill>().ListOfSkills[i];
                //search of its id and type
                SpellId = Skillname.spellID;

                type = Skillname.type;
            }

         
        }
        if (nameText == "Water Bank")
        {
            type = "WaterSpecial";
        }
        //searching for right item  name
        for (int i = 0; i < GameObject.Find(namePC).GetComponent<TestingSkill>().ListOfItems.Count; i++)
        {
            if (GameObject.Find(namePC).GetComponent<TestingSkill>().ListOfItems[i] != null)
            {


                if (GameObject.Find(namePC).GetComponent<TestingSkill>().ListOfItems[i].name + " x" + GameObject.Find(namePC).GetComponent<TestingSkill>().ListOfItems[i].quantity == nameText)
                {
                    Itemname = GameObject.Find(namePC).GetComponent<TestingSkill>().ListOfItems[i];
                    //search of its id and type
                    ItemId = Itemname.ItemID;

                    type = Itemname.type;
                }
            }
        }


    }

    void click()
    {
        
    }

    // onClick events added after setting right type of skill/item

    void Damage () {
        if(SpellId != 0)
        {
            GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().ScanEnemySkillUsage(SpellId);
        }
        else
        {
            ItemId = 0 - ItemId;
            GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().ScanEnemySkillUsage(ItemId);
        }
       
        Skillname = null;
        

    }

	void Heal()
    {

        if (SpellId != 0)
        {
            GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().ScanFriendlySkillUsage(SpellId);
        }
        else
        {
            ItemId = 0 - ItemId;
            GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().ScanFriendlySkillUsage(ItemId);
        }

        Skillname = null;


    }

    void Mana()
    {
        if (SpellId != 0)
        {
            GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().ScanFriendlySkillUsage(SpellId);
        }
        else
        {
            ItemId = 0 - ItemId;
            GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().ScanFriendlySkillUsage(ItemId);
        }

        Skillname = null;




    }


    void Summon()
    {
        if(SpellId !=0)
        {
            switch(SpellId)
            {
                case 11: GameObject.Find(namePC).GetComponent<TestingSkill>().CastMethod(11);
                    break;
            }
        }
        else
        {
          //  switch(ItemId)
        }
        Skillname = null;
    }

    void WaterSpecial()

    {
        GameObject.Find(namePC).GetComponent<HeroFSM>().WaterSpecialUsage();
    }



}
