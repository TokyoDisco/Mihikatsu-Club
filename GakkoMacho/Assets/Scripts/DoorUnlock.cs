using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DoorUnlock : MonoBehaviour {
    private Rigidbody2D body;
    public GameObject me;
    public GameObject alarmBtn;

    private void Start()
    {
        if(alarmBtn == null)
        {
            alarmBtn = GameObject.Find("PopupObject");
            
        }

    }
    private void OnTriggerEnter2D(Collider2D body)
    {
        alarmBtn.SetActive(true);
        alarmBtn.GetComponentInChildren<Text>().fontSize = 22;
        me = GameObject.Find(name);
        if (me.name == "RadioRoomDoor")
        {
            if (GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfQuestsItems.Count > 0)
            {
                if (GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfQuestsItems[0].ItemID == 1)
                {
                    me.GetComponent<BoxCollider2D>().enabled = false;
                    //   alarmBtn.SetActive(true);
                    alarmBtn.GetComponent<Transform>().position = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().exitpos;
                    Vector3 newPos = new Vector3(alarmBtn.GetComponent<Transform>().position.x + 1, alarmBtn.GetComponent<Transform>().position.y + 1, alarmBtn.GetComponent<Transform>().position.z);

                    alarmBtn.GetComponent<Transform>().position = newPos;
                    alarmBtn.GetComponentInChildren<Text>().text = "Used: Keys";
                }
            }
            else
            {
                alarmBtn.SetActive(true);
                alarmBtn.GetComponent<Transform>().position = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().exitpos;
                Vector3 newPos = new Vector3(alarmBtn.GetComponent<Transform>().position.x + 1, alarmBtn.GetComponent<Transform>().position.y + 1, alarmBtn.GetComponent<Transform>().position.z);

                alarmBtn.GetComponent<Transform>().position = newPos;
                alarmBtn.GetComponentInChildren<Text>().text = "It's locked";
            }

        }

        if (me.name.Contains("bathroomExtra") || me.name.Contains("toilet"))
        {
            alarmBtn.GetComponentInChildren<Text>().fontSize = 22;
            alarmBtn.SetActive(true);
            alarmBtn.GetComponent<Transform>().position = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().exitpos;
            Vector3 newPos = new Vector3(alarmBtn.GetComponent<Transform>().position.x + 1, alarmBtn.GetComponent<Transform>().position.y + 1, alarmBtn.GetComponent<Transform>().position.z);

            alarmBtn.GetComponent<Transform>().position = newPos;
            alarmBtn.GetComponentInChildren<Text>().text = "Not need for that";
        }

        if (me.name == "ItemRandomSpawn")
        {
            alarmBtn.GetComponentInChildren<Text>().fontSize = 22;
            alarmBtn.SetActive(true);
            alarmBtn.GetComponent<Transform>().position = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().exitpos;
            Vector3 newPos = new Vector3(alarmBtn.GetComponent<Transform>().position.x + 1, alarmBtn.GetComponent<Transform>().position.y + 1, alarmBtn.GetComponent<Transform>().position.z);

            alarmBtn.GetComponent<Transform>().position = newPos;
            alarmBtn.GetComponentInChildren<Text>().text = "Oh, an what is that?";
        }

        if (me.name == "ItemID1")
        {
            alarmBtn.GetComponentInChildren<Text>().fontSize = 22;
            alarmBtn.SetActive(true);
            alarmBtn.GetComponent<Transform>().position = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().exitpos;
            Vector3 newPos = new Vector3(alarmBtn.GetComponent<Transform>().position.x + 1, alarmBtn.GetComponent<Transform>().position.y + 1, alarmBtn.GetComponent<Transform>().position.z);

            alarmBtn.GetComponent<Transform>().position = newPos;
            alarmBtn.GetComponentInChildren<Text>().text = "That will help a lot";
        }

        if (me.name == "QuestCheck_ID6")
        {
            alarmBtn.GetComponentInChildren<Text>().fontSize = 22;
            if(GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests.Count < 4)
            {
                alarmBtn.SetActive(true);
                alarmBtn.GetComponent<Transform>().position = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().exitpos;
                Vector3 newPos = new Vector3(alarmBtn.GetComponent<Transform>().position.x + 1, alarmBtn.GetComponent<Transform>().position.y + 1, alarmBtn.GetComponent<Transform>().position.z);

                alarmBtn.GetComponent<Transform>().position = newPos;
                alarmBtn.GetComponentInChildren<Text>().text = "I need to find Osahara first and secure east wing";
            }
            for (int i = 0; i < GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests.Count; i++)
            {
                if(GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests[i].questID == 6)
                {
                    if(GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests[i].isCompleted)
                    {
                        me.GetComponent<BoxCollider2D>().enabled = false;
                    }
                    else
                    {
                        alarmBtn.SetActive(true);
                        alarmBtn.GetComponent<Transform>().position = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().exitpos;
                        Vector3 newPos = new Vector3(alarmBtn.GetComponent<Transform>().position.x + 1, alarmBtn.GetComponent<Transform>().position.y + 1, alarmBtn.GetComponent<Transform>().position.z);

                        alarmBtn.GetComponent<Transform>().position = newPos;
                        alarmBtn.GetComponentInChildren<Text>().text = "I need to secure west wing first!";
                    }
                }
            }
            
            
        }

        if(me.name == "QuestCheck_ID16" && (GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests.Count < 15))
        {
            alarmBtn.GetComponentInChildren<Text>().fontSize = 18;
            alarmBtn.SetActive(true);
            alarmBtn.GetComponent<Transform>().position = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().exitpos;
            Vector3 newPos = new Vector3(alarmBtn.GetComponent<Transform>().position.x + 1, alarmBtn.GetComponent<Transform>().position.y + 1, alarmBtn.GetComponent<Transform>().position.z);

            alarmBtn.GetComponent<Transform>().position = newPos;
            alarmBtn.GetComponentInChildren<Text>().text = "We cannot pass barrier without stones.";
        }
        else
        {
            if(me.name == "QuestCheck_ID16" && (GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests[16].isCompleted))
            {
                me.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        alarmBtn.SetActive(false);
        //   alarmBtn.SetActive(false);
        alarmBtn.GetComponentInChildren<Text>().fontSize = 1; 
    }
}
