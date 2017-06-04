using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUIOverlayScript : MonoBehaviour {
    public GameObject OverLayTextWindow;
    public bool enoughHold;
    public bool tipsOn;

    public void Start()
    {
        tipsOn = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().tipsON;
    }
    public void OnMouseOver()
    {
        if (tipsOn)
        {
            OverLayTextWindow.GetComponentInChildren<Text>().fontSize = 22;
            switch (gameObject.name)
            {
                case "AttackBtn":
                    OverLayTextWindow.GetComponentInChildren<Text>().text = "Basic melee attacks if you ran out of mana<PH>";
                    break;
                case "MagicMainBtn":
                    OverLayTextWindow.GetComponentInChildren<Text>().text = "Show list of this characters abilities";
                    break;
                case "ItemsMainBtn":
                    OverLayTextWindow.GetComponentInChildren<Text>().text = "Show list of comsuable items";
                    break;
                case "EscapeBtn":
                    OverLayTextWindow.GetComponentInChildren<Text>().text = "Try espace tought fight, there is 40% of succese rate";
                    break;
                case "SkipBtn":
                    OverLayTextWindow.GetComponentInChildren<Text>().text = "Skips this character turn";
                    break;
                case "InformationPanel":
                    OverLayTextWindow.GetComponentInChildren<Text>().text = "Shows amount of Names,Points of Health and Mana." + "\n" + "Players party of left, Enemies on right";
                    break;
                case "TurnInfoPanel":
                    OverLayTextWindow.GetComponentInChildren<Text>().text = "Shows count of turns and which character's turn is right now";
                    break;
                case "WaterSpecialPanel":
                    OverLayTextWindow.GetComponentInChildren<Text>().text = "Water Bank : You can spend charges of water to AMP output of your next spell, when you used it you have to wait for refresh of them";
                    break;
                case "FireSpecialPanel":
                    OverLayTextWindow.GetComponentInChildren<Text>().text = "Fire Awakeing: By using damage-type fire spells you increase damage of next spell but after final stage your 5 spell in row will be weaker";
                    break;
                case "EarthSpecialPanel":
                    OverLayTextWindow.GetComponentInChildren<Text>().text = "Call of Nature : Using Damage-type earth spells will increase your damage output but decearse healing, opposite effects happends when you use healing-type spells";
                    break;
                case "AirSpecialPanel":
                    OverLayTextWindow.GetComponentInChildren<Text>().text = "Winds of Change(PH): By using air-based spell you power up dmg of your spells, but there higher the AMP is the less it last";
                    break;
                case "Target1BtnSkill":
                    OverLayTextWindow.GetComponentInChildren<Text>().text = "Target Selection";
                    break;
                case "Target2BtnSkill":
                    OverLayTextWindow.GetComponentInChildren<Text>().text = "Target Selection";
                    break;
                case "Target3BtnSkill":
                    OverLayTextWindow.GetComponentInChildren<Text>().text = "Target Selection";
                    break;
                case "WaterSpecialBtn":
                    OverLayTextWindow.GetComponentInChildren<Text>().text = "Use your Water Bank charges";
                    break;
                case "Target1Btn":
                    OverLayTextWindow.GetComponentInChildren<Text>().text = "Target Selection";
                    break;
                case "Target2Btn":
                    OverLayTextWindow.GetComponentInChildren<Text>().text = "Target Selection";
                    break;
                case "Target3Btn":
                    OverLayTextWindow.GetComponentInChildren<Text>().text = "Target Selection";
                    break;
            }

        }
    }
    //

    public void OnMouseExit()
    {
        OverLayTextWindow.GetComponentInChildren<Text>().fontSize = 22;
        enoughHold = false;
        OverLayTextWindow.GetComponentInChildren<Text>().text = null;
    }

    



    public void Update()
    {
        if(gameObject.name == "OverlayTextPopup")
        {
            Ray Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 point = Ray.origin + new Vector3(5,5);
            gameObject.transform.position = point; 
        }
    }


    public void ChangeTextSkill()
    {
        if (tipsOn)
        {
            OverLayTextWindow.GetComponentInChildren<Text>().fontSize = 16;
            OverLayTextWindow.GetComponentInChildren<Text>().text = gameObject.GetComponent<CheckCastedSpell>().nameText + "\n" + gameObject.GetComponent<CheckCastedSpell>().desc;

        }
    }

    public IEnumerator HoldTime()
    {
        yield return new WaitForSeconds(0.5f);
        enoughHold = true;
    }
}
