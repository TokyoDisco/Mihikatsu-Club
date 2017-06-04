using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventTrigger : MonoBehaviour {

    private Rigidbody2D body;
    public GameObject me;

    void OnTriggerEnter2D(Collider2D body)

    {
        if (me.name == "CameraTrigger1")
        {
            if (GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests.Count > 0)
            {
                for (int i = 0; i < GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests.Count; i++)
                {
                    if (GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests[i].questID == 1)
                    {

                    }
                    else
                    {
                        GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests.Add(new Quest("Bathroom Horror!", " Quick go to girl's bathroom someone shouts there!", "Go to Girls Bathroom", 1, false));
                    }

                }
            }
            else
            {
                GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests.Add(new Quest("Bathroom Horror!", " Quick go to girl's bathroom someone shouts there!", "Go to Girls Bathroom", 1, false));
               
            }

        }


        if (me.name == "CameraTrigger6")
        {
            if (GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests[0].isCompleted == false)
            {
                GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero1.curExp = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero1.curExp + 200;
                GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero2.curExp = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero2.curExp + 200;
                GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero3.curExp = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero3.curExp + 200;
            }
            GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests[0].isCompleted = true;
            

            if (GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests.Count > 0)
            {
                int innerCounter = 0;
                for (int i = 0; i < GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests.Count; i++)
                {
                    if (GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests[i].questID == 2)
                    {
                        innerCounter = innerCounter + 1;
                    }
                    else
                    {
                       
                    }

                }
                if(innerCounter == 0)
                {
                    GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests.Add(new Quest("Prison of Toilet", " Someone is stuck in toilet and there is mummy before it, no time to waste fight!", "Defeted Mummy in Bathroom", 2, false));
                    
                }
            }
          

        }



        if (me.name == "Quest_ID_2_completed")
        {
            for (int i = 0; i < GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests.Count; i++)
            {
                if (GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests[i].questID == 2)
                {
                    if (GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests[i].isCompleted == false)
                    {
                        GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero1.curExp = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero1.curExp + 300;
                        GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero2.curExp = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero2.curExp + 300;
                        GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero3.curExp = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero3.curExp + 300;
                        GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfQuestsItems.Add(new Item("Keys to Radio Room", "This are keys to radio room", "QUEST", 0, 1, 1));
                    }
                    GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests[i].isCompleted = true;
                    GameObject.Find("StatsCarrier").GetComponent<MapSpawnControl>().hitObjectList.Add(me.name);

                }
            }



            if (GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests.Count > 0)
            {
                int innerCounter = 0;
                for (int i = 0; i < GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests.Count; i++)
                {
                    
                    if (GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests[i].questID == 3)
                    {
                        innerCounter = innerCounter + 1;
                    }
                    else
                    {
                       
                    }



                }

                if(innerCounter == 0)
                {
                    GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests.Add(new Quest("Radio Room", " With Keys You can check the radio room", "Open doors to Radio Room and go inside", 3, false));
                   
                }
            }
            


        }

        if (me.name == "Quest_ID_3_completed")
        { 
            for (int i = 0; i < GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests.Count; i++)
            {
                if (GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests[i].questID == 3)
                {
                    if (GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests[i].isCompleted == false)
                    {
                        GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero1.curExp = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero1.curExp + 250;
                        GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero2.curExp = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero2.curExp + 250;
                        GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero3.curExp = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero3.curExp + 250;

                    }
                    GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests[i].isCompleted = true;
                    GameObject.Find("StatsCarrier").GetComponent<MapSpawnControl>().hitObjectList.Add(me.name);

                }
            }



        if (GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests.Count > 0)
        {
                int innerCounter = 0;
            for (int i = 0; i < GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests.Count; i++)
            {
                if (GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests[i].questID == 4)
                {
                        innerCounter = innerCounter + 1;
                }
                else
                {
                    
                }




            }


            if(innerCounter == 0)
                {
                    GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests.Add(new Quest("Osahara means troubles", "Osahara is surrounded by mummies you have to help her", "defeate the mummies in radio room", 4, false));
                    
                }

        }
        


    }


        if (me.name == "osahara")
        {
            for (int i = 0; i < GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests.Count; i++)
            {
                if (GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests[i].questID == 4)
                {
                    if (GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests[i].isCompleted == false)
                    {
                        GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero1.curExp = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero1.curExp + 250;
                        GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero2.curExp = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero2.curExp + 250;
                        GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero3.curExp = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero3.curExp + 250;

                    }
                    GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests[i].isCompleted = true;
                    

                }
            }



            if (GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests.Count > 0)
            {
                int innerCounter = 0;
                for (int i = 0; i < GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests.Count; i++)
                {
                    if (GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests[i].questID == 5)
                    {
                        innerCounter = innerCounter + 1;
                    }
                    else
                    {

                    }




                }


                if (innerCounter == 0)
                {
                    GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests.Add(new Quest("Double our powers", "Osahara joined our team now we can face the Janitor", "Go to Janitor's Room", 5, false));
                    
                }

            }
        }

        


        if (me.name == "Quest_ID_5_completed")
        {
            for (int i = 0; i < GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests.Count; i++)
            {
                if (GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests[i].questID == 5)
                {
                    if (GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests[i].isCompleted == false)
                    {
                        GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero1.curExp = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero1.curExp + 250;
                        GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero2.curExp = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero2.curExp + 250;
                        GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero3.curExp = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero3.curExp + 250;
                    }
                    GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests[i].isCompleted = true;
                    GameObject.Find("StatsCarrier").GetComponent<MapSpawnControl>().hitObjectList.Add(me.name);

                }
            }



            if (GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests.Count > 0)
            {
                int innerCounter = 0;
                for (int i = 0; i < GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests.Count; i++)
                {
                    if (GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests[i].questID == 6)
                    {
                        innerCounter = innerCounter + 1;
                    }
                    else
                    {

                    }




                }


                if (innerCounter == 0)
                {
                    GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests.Add(new Quest("Cleasing Evil", "Janitor isnt here, but he left unpleasent suprise for us", "Defeate the monsters", 6, false));
                   
                }

            }
        }

        if (me.name == "Quest_ID_6_completed")
        {
            for (int i = 0; i < GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests.Count; i++)
            {
                if (GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests[i].questID == 6)
                {
                    if (GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests[i].isCompleted == false)
                    {
                        GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero1.curExp = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero1.curExp + 350;
                        GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero2.curExp = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero2.curExp + 350;
                        GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero3.curExp = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero3.curExp + 350;

                    }
                    GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests[i].isCompleted = true;
                    GameObject.Find("StatsCarrier").GetComponent<MapSpawnControl>().hitObjectList.Add(me.name);

                }
            }



            if (GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests.Count > 0)
            {
                int innerCounter = 0;
                for (int i = 0; i < GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests.Count; i++)
                {
                    if (GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests[i].questID == 7)
                    {
                        innerCounter = innerCounter + 1;
                    }
                    else
                    {

                    }




                }


                if (innerCounter == 0)
                {
                    GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests.Add(new Quest("In search of Sound", "School is not yet safe we must check rigth wing", "Go to the Music Room", 7, false));
                   
                }

            }
        }

        if (me.name == "Quest_ID_7_completed")
        {
            for (int i = 0; i < GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests.Count; i++)
            {
                if (GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests[i].questID == 7)
                {
                    if (GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests[i].isCompleted == false)
                    {
                        GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero1.curExp = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero1.curExp + 100;
                        GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero2.curExp = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero2.curExp + 100;
                        GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero3.curExp = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero3.curExp + 100;

                    }
                    GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests[i].isCompleted = true;
                    GameObject.Find("StatsCarrier").GetComponent<MapSpawnControl>().hitObjectList.Add(me.name);

                }
            }



            if (GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests.Count > 0)
            {
                int innerCounter = 0;
                for (int i = 0; i < GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests.Count; i++)
                {
                    if (GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests[i].questID == 8)
                    {
                        innerCounter = innerCounter + 1;
                    }
                    else
                    {

                    }




                }


                if (innerCounter == 0)
                {
                    GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests.Add(new Quest("Choir of Mummies", "Another Student is in Danger quickly go to music room!", "Rescue Inami trapped in Music Room", 8, false));
                    
                }

            }
        }

        if (me.name == "Quest_ID_8_completed")
        {
            for (int i = 0; i < GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests.Count; i++)
            {
                if (GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests[i].questID == 8)
                {
                    if (GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests[i].isCompleted == false)
                    {
                        GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero1.curExp = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero1.curExp + 300;
                        GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero2.curExp = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero2.curExp + 300;
                        GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero3.curExp = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero3.curExp + 300;

                    }
                    GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests[i].isCompleted = true;
                    GameObject.Find("StatsCarrier").GetComponent<MapSpawnControl>().hitObjectList.Add(me.name);

                }
            }



            if (GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests.Count > 0)
            {
                int innerCounter = 0;
                for (int i = 0; i < GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests.Count; i++)
                {
                    if (GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests[i].questID == 9)
                    {
                        innerCounter = innerCounter + 1;
                    }
                    else
                    {

                    }




                }


                if (innerCounter == 0)
                {
                    GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests.Add(new Quest("Summoned", "Evil Janitor leaves his powerfull monster pet in teachers room we must kill it", "Kill Boss", 8, false));
                   
                }

            }
        }

        if (me.name == "Quest_ID_9_completed")
        {
            for (int i = 0; i < GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests.Count; i++)
            {
                if (GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests[i].questID == 9)
                {
                    if (GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests[i].isCompleted == false)
                    {
                        GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero1.curExp = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero1.curExp + 600;
                        GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero2.curExp = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero2.curExp + 600;
                        GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero3.curExp = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero3.curExp + 600;

                    }
                    GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests[i].isCompleted = true;
                   

                }
            }



            if (GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests.Count > 0)
            {
                int innerCounter = 0;
                for (int i = 0; i < GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests.Count; i++)
                {
                    if (GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests[i].questID == 10)
                    {
                        innerCounter = innerCounter + 1;
                    }
                    else
                    {

                    }




                }


                if (innerCounter == 0)
                {
                    GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests.Add(new Quest("Now, we make our move", "Now we secure ground level of school but we must check other places in school", "Choose your path", 10, false));
                }

            }
        }

        if (me.name == "Quest_ID_16_completed")
        {
            int QuestID16StoneCount = 0;
            for (int i = 0; i < GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests.Count; i++)
            {
                if (GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests[i].questID == 16)
                {
                    for(int y = 0; y <GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfQuestsItems.Count;y++)
                    {
                        if(GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfQuestsItems[y].ItemID == 01)
                        {
                            QuestID16StoneCount = QuestID16StoneCount + 1;
                        }
                        else
                        {
                            if (GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfQuestsItems[y].ItemID == 02)
                            {
                                QuestID16StoneCount = QuestID16StoneCount + 1;
                            }
                        }
                    }
                    if (QuestID16StoneCount == 2)
                    {
                        if (GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests[i].isCompleted == false)
                        {

                            GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero1.curExp = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero1.curExp + 600;
                            GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero2.curExp = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero2.curExp + 600;
                            GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero3.curExp = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero3.curExp + 600;

                        }
                        GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests[i].isCompleted = true;

                    }
                }
            }



            if (GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests.Count > 0)
            {
                int innerCounter = 0;
                for (int i = 0; i < GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests.Count; i++)
                {
                    if (GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests[i].questID == 17)
                    {
                        innerCounter = innerCounter + 1;
                    }
                    else
                    {

                    }




                }


                if (innerCounter == 0)
                {
                    GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests.Add(new Quest("Breaching The Front", "We on the first floor we have to check if everyone are safe", "Secure First Floor of School", 16, false));
                }

            }
        }

    }
}
