using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class TrinketsList : MonoBehaviour {
    [SerializeField]
    public List<Trinket> ListOfTrinkets = new List<Trinket>();
    public List<Sprite> ListOfTrinketsSprite = new List<Sprite>();
    public List<Trinket> ListOfAllGameTrinkets = new List<Trinket>();
    public int TrinketsCount;

   

    public void Start()
    {
        TrinketsCount = ListOfTrinkets.Count;
        ListOfAllGameTrinkets.Add(new Trinket("MysticEye", "beware of its deadly power", 1, false, "", "none", 1));
        ListOfAllGameTrinkets.Add(new Trinket("Blue Sweater", "Old blue sweater bearing signs of flying time,who is owner of this?", 0, false, "neutral", "none", 2));
    }

    public void Update()
    {
        TrinketsCount = ListOfTrinkets.Count;
    }



}
