using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour {


    private Rigidbody2D body;
    public string NameItem;
    public GameObject me;
    public List<string> NameList = new List<string>();



    void OnTriggerEnter2D(Collider2D body)
    {
        if (me.name == "ItemID1")
        {
            NameItem = "MEGA HP potion";

            if (GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems.Count > 0)
            {
                int innerCounter = 0;
                for (int i = 0; i < GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems.Count; i++)
                {
                    if (NameItem == GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems[i].name)
                    {
                        GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems[i].quantity = GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems[i].quantity + 1;
                        innerCounter = innerCounter +  1;
                    }

                    else
                    {
                        if (innerCounter == 0)
                        {
                            GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems.Add(GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfAllItems[0]);
                        }
                    }
                }
            }

            else
            {
                GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems.Add(GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfAllItems[0]);
            }
        }


        if (me.tag == "ItemPickUp")
        {
            for (int i = 0; i < GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems.Count; i++)
            {
                NameList.Add(GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems[i].name);
            }

            NameList.Add("Mana Potion");
            NameList.Add("Kill Potion");
            NameList.Add("Panda Drink");
            NameList.Add("Icky Slimen");
            NameList.Add("Magic Sticker");
            NameList.Add("Bento from Fujisama");
            NameList.Add("Tomato Juice");
            NameList.Add("Random");

            NameItem = NameList[Random.Range(0, NameList.Count-1)];

            if (GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems.Count > 0)
            {
                bool wasAdded = false;
                for (int i = 0; i < GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems.Count; i++)
                {
                   
                    if (NameItem == GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems[i].name)
                    {
                        GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems[i].quantity = GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems[i].quantity + 1;

                        wasAdded = true;
                        


                    }

                 
                }
                if(!wasAdded && GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems[GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems.Count-1].name != NameItem)
                {
                    switch (NameItem)
                    {
                        /* case "NameItem.name":
                         * {
                         *  GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems.Add(new Item(Name,desc,type,numbers,id,quantity));  
                         * }
                         * break;
                         * do kopiowania wzorek mam hihi

                         * */
                        case "MEGA HP potion":
                            {
                                GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems.Add(GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfAllItems[0]);
                            }
                            break;
                        case "Mana Potion":
                            {
                                GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems.Add(GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfAllItems[1]);
                            }
                            break;
                        case "Kill Potion":
                            {
                                GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems.Add(GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfAllItems[2]);
                            }
                            break;
                        case "Panda Drink":
                            {
                                GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems.Add(GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfAllItems[3]);
                            }
                            break;
                        case "Icky Slime":
                            {
                                GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems.Add(GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfAllItems[4]);
                            }
                            break;
                        case "Magic Sticker":
                            {
                                GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems.Add(GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfAllItems[5]);
                            }
                            break;
                        case "Bento from Fujisama":
                            {
                                GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems.Add(GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfAllItems[6]);
                            }
                            break;
                        case "Tomato Juice":
                            {
                                GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems.Add(GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfAllItems[7]);
                            }
                            break;
                        case "Random":
                            {
                                proceduralItem();
                            }
                            break;
                        default: Debug.Log("Item doesnt exist in database...");
                            break;
                    }
                }
            }
            else
            {
                switch (NameItem)
                {
                    /* case "NameItem.name":
                     * {
                     *  GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems.Add(new Item(Name,desc,type,numbers,id,quantity));  
                     * }
                     * break;
                     * do kopiowania wzorek mam hihi

                     * */
                    case "MEGA HP potion":
                        {
                            GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems.Add(GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfAllItems[0]);
                        }
                        break;
                    case "Mana Potion":
                        {
                            GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems.Add(GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfAllItems[1]);
                        }
                        break;
                    case "Kill Potion":
                        {
                            GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems.Add(GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfAllItems[2]);
                        }
                        break;
                    case "Panda Drink":
                        {
                            GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems.Add(GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfAllItems[3]);
                        }
                        break;
                    case "Icky Slime":
                        {
                            GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems.Add(GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfAllItems[4]);
                        }
                        break;
                    case "Magic Sticker":
                        {
                            GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems.Add(GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfAllItems[5]);
                        }
                        break;
                    case "Bento from Fujisama":
                        {
                            GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems.Add(GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfAllItems[6]);
                        }
                        break;
                    case "Tomato Juice":
                        {
                            GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems.Add(GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfAllItems[7]);
                        }
                        break;
                    case "Random":
                        {
                            proceduralItem();
                        }
                        break;
                    default:
                        Debug.Log("Item doesnt exist in database...");
                        break;
                }
            }




        }
        else
        {

            if (me.tag == "RandomTrinket")
            {
                int randomTrinketId = Random.Range(1, 10);
                trinketItemPickUp(randomTrinketId);
            }
            else
            {
                if(me.tag == "ProceduralItemText")
                {
                    proceduralItem();
                }
            }
        }




        if (me.name != "MysticEye")
        {
            if(me.name == "ItemRandomSpawn")
            {
                GetComponent<BoxCollider2D>().isTrigger = false;
            }
            else {
                GameObject.Find("StatsCarrier").GetComponent<MapSpawnControl>().hitObjectList.Add(me.name);
            }
            
        }
        else
        {
            trinketItemPickUp(1);
            GameObject.Find("StatsCarrier").GetComponent<TrinketsList>().ListOfTrinketsSprite.Add(me.GetComponent<SpriteRenderer>().sprite);
            GameObject.Find("StatsCarrier").GetComponent<MapSpawnControl>().hitObjectList.Add(me.name);
        }
    }





    public void trinketItemPickUp(int TrinketId)
    {
      
                    for(int s1 = 0; s1 < GameObject.Find("StatsCarrier").GetComponent<TrinketsList>().ListOfAllGameTrinkets.Count;s1++)
                {
                    if (GameObject.Find("StatsCarrier").GetComponent<TrinketsList>().ListOfAllGameTrinkets[s1].id == TrinketId) 
                    {
                        GameObject.Find("StatsCarrier").GetComponent<TrinketsList>().ListOfTrinkets.Add(GameObject.Find("StatsCarrier").GetComponent<TrinketsList>().ListOfAllGameTrinkets[s1]);
                    }
                }


                
             


        

       

    }


    public void proceduralItem()
    {
        List<string> DamageDebuffTypeNamesList = new List<string>();
        List<string> HealManaBuffTypeNamesList = new List<string>();
        List<string> ItemNameList = new List<string>();

        ItemNameList.Add("Potion");
        ItemNameList.Add("Elixir");
        ItemNameList.Add("Snack");
        ItemNameList.Add("Liquid");
        ItemNameList.Add("Food");


        DamageDebuffTypeNamesList.Add("Toxic");
        DamageDebuffTypeNamesList.Add("Burning");
        DamageDebuffTypeNamesList.Add("Very Hot");
        DamageDebuffTypeNamesList.Add("Icky");
        DamageDebuffTypeNamesList.Add("Frozen");
        DamageDebuffTypeNamesList.Add("Destroctive");
        DamageDebuffTypeNamesList.Add("Breaking");
        DamageDebuffTypeNamesList.Add("Deadly");

        HealManaBuffTypeNamesList.Add("Refreshing");
        HealManaBuffTypeNamesList.Add("Calming");
        HealManaBuffTypeNamesList.Add("Fresh");
        HealManaBuffTypeNamesList.Add("Healing");
        HealManaBuffTypeNamesList.Add("Regenerating");
        HealManaBuffTypeNamesList.Add("Vigor");
        HealManaBuffTypeNamesList.Add("Recharging");






        int randType = UnityEngine.Random.Range(0, 5);
        int randEffectValue = UnityEngine.Random.Range(0, 500);
        int randItemId = GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfAllItems.Count;
        string firstNamePart = " ";
        string secondNamePart = " ";
        string thirdnamePart = " ";
        string itemType = " ";


        if (randEffectValue <= 50)
        {
            firstNamePart = "Small";
        }
        else
        {
            if (randEffectValue > 50 && randEffectValue <= 200)
            {
                firstNamePart = "Medium";
            }
            else
            {
                if (randEffectValue > 200)
                {
                    firstNamePart = "Large";
                }
            }

        }

        switch (randType)
        {
            case 0:
                secondNamePart = DamageDebuffTypeNamesList[Random.Range(0, DamageDebuffTypeNamesList.Count - 1)];
                itemType = "Damage";
                break;
            case 1:
                secondNamePart = HealManaBuffTypeNamesList[Random.Range(0, HealManaBuffTypeNamesList.Count - 1)];
                itemType = "Heal";
                break;
            case 2:
                secondNamePart = HealManaBuffTypeNamesList[Random.Range(0, HealManaBuffTypeNamesList.Count - 1)];
                itemType = "Mana";
                break;
            case 3:
                secondNamePart = HealManaBuffTypeNamesList[Random.Range(0, HealManaBuffTypeNamesList.Count - 1)];
                itemType = "Buff";
                break;
            case 4:
                secondNamePart = DamageDebuffTypeNamesList[Random.Range(0, DamageDebuffTypeNamesList.Count - 1)];
                itemType = "Debuff";
                break;
            default:
                Debug.Log("Error during item generation");
                break;
        }

        GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems.Add(new Item(firstNamePart + " " + secondNamePart + " " + thirdnamePart, "Randomized ", itemType, randEffectValue, randItemId, 1));

    }
}
