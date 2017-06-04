using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckPartyOrder : MonoBehaviour {
    public string WhosTurn;
    public GameObject btn;
   

	// Use this for initialization
	void Start () {
      
        		
	}
	
	// Update is called once per frame
	void Update () {
	
        
	}


    public void PC1()
    {
        if(btn.name == "AttackBtn")
        {
            GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().ScanEnemy();
        }
        if(btn.name == "MagicMainBtn")
        {
            GameObject.Find("PC").GetComponent<TestingSkill>().SkillMenu();
        }

        if(btn.name == "ItemsMainBtn")
        {
            GameObject.Find("PC").GetComponent<TestingSkill>().ItemMenu();
        }
        if(btn.name == "SkipBtn")
        {
            GameObject.Find("PC").GetComponent<HeroFSM>().SkipBtn();
        }

        if(btn.name == "EscapeBtn")
        {
            GameObject.Find("PC").GetComponent<HeroFSM>().EscapeTry();
        }
    }

    public void PC2()
    {
        if (btn.name == "AttackBtn")
        {
            GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().ScanEnemy();
        }
        if (btn.name == "MagicMainBtn")
        {
            GameObject.Find("PC2").GetComponent<TestingSkill>().SkillMenu();
        }

        if (btn.name == "ItemsMainBtn")
        {
            GameObject.Find("PC2").GetComponent<TestingSkill>().ItemMenu();
        }
        if (btn.name == "SkipBtn")
        {
            GameObject.Find("PC2").GetComponent<HeroFSM>().SkipBtn();
        }
        if (btn.name == "EscapeBtn")
        {
            GameObject.Find("PC2").GetComponent<HeroFSM>().EscapeTry();
        }
    }

    public void PC3()
    {
        if (btn.name == "AttackBtn")
        {
            GameObject.Find("BattleManager").GetComponent<SBattleStateFSM>().ScanEnemy();
        }
        if (btn.name == "MagicMainBtn")
        {
            GameObject.Find("PC3").GetComponent<TestingSkill>().SkillMenu();
        }

        if (btn.name == "ItemsMainBtn")
        {
            GameObject.Find("PC3").GetComponent<TestingSkill>().ItemMenu();
        }
        if (btn.name == "SkipBtn")
        {
            GameObject.Find("PC3").GetComponent<HeroFSM>().SkipBtn();
        }

        if (btn.name == "EscapeBtn")
        {
            GameObject.Find("PC3").GetComponent<HeroFSM>().EscapeTry();
        }


    }

    public void BtnChange(string who)
    {

        WhosTurn = who;
        if (WhosTurn == "PC")
        {
            btn.GetComponent<Button>().onClick.AddListener(PC1);
        }

        if (WhosTurn == "PC2")
        {
            btn.GetComponent<Button>().onClick.AddListener(PC2);
        }

        if (WhosTurn == "PC3")
        {
            btn.GetComponent<Button>().onClick.AddListener(PC2);
        }

    }


   






}
