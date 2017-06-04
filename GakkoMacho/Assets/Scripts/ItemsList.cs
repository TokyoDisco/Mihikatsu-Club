using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class ItemsList : MonoBehaviour {
    public List<Item> ListOfAllItems = new List<Item>();
    public List<Item> ListOfItems = new List<Item>();
    public List<Item> ListOfQuestsItems = new List<Item>();
    public int listCount = 0;
    public int listCountQuest = 0;
    public GameObject popup;
    public GameObject ding;
	//basic item setup for player starting game
	public void Start () {
        ListOfAllItems.Add(new Item("MEGA HP potion", "Heals user for max hp", "Heal", 1000, 1, 1));
        ListOfAllItems.Add(new Item("Mana Potion", "Recovers mana of user", "Mana", 1000, 2, 1));
        ListOfAllItems.Add(new Item("Kill Potion", "Kills Target Enemy", "Damage", 1000, 3, 1));
        ListOfAllItems.Add(new Item("Panda Drink", "Returns character from dead!", "Heal", 9999, 4, 1));
        ListOfAllItems.Add(new Item("Icky Slime", "From Biology class, its really yucky", "Debuff", 20, 5, 1));
        ListOfAllItems.Add(new Item("Magic Sticker", "Its feels warm when sticking on", "Buff", 50, 6, 1));
        ListOfAllItems.Add(new Item("Bento from Fujisama", "Special bento which will make you strong as mountain", "Buff", 50, 7, 1));
        ListOfAllItems.Add(new Item("Tomato Juice", "Yeeky in taste but will cleanse you from every debuff", "Buff", 0, 8, 1));

        ListOfItems.Add(ListOfAllItems[0]);
        ListOfItems[0].quantity = 3;
        listCount = ListOfItems.Count;
        listCountQuest = ListOfQuestsItems.Count;
        
        	
	}
    public void Update()
    {
        if(listCount != ListOfItems.Count)
        {
            popup.SetActive(true);
            ding.GetComponent<AudioSource>().Play();
            listCount = ListOfItems.Count;
        }

        if(listCountQuest != ListOfQuestsItems.Count)
        {
            popup.SetActive(true);
            ding.GetComponent<AudioSource>().Play();
            listCountQuest = ListOfQuestsItems.Count;
        }

        for(int check = 0; check < ListOfItems.Count; check++)
        {
            if(ListOfItems[check].quantity <= 0)
            {
                RemoveItem(ListOfAllItems[check].ItemID);
            }
        }
    }

    public void RemoveItem(int id)
    {
        for (int x = 0; x < ListOfItems.Count; x++)
        {
            if(ListOfItems[x].ItemID == id)
            {
                ListOfItems.RemoveAt(x);
            }
        }
    }


}
