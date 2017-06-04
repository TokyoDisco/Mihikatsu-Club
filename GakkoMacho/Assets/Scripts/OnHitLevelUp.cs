using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OnHitLevelUp : MonoBehaviour
{
    public GameObject textmessage;
    private Rigidbody2D body;
    public GameObject trinketSlot;
    public GameObject trinekoffSlot;

    private void Start()
    {
        textmessage.SetActive(false);
    }

    void OnTriggerStay2D(Collider2D body)
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (name == "okoJeziera")
            {
                textmessage.SetActive(true);
                // GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems.Add(new Item("Oko Jeziera", "Nie rob tego", "Damage", 10000, 99, 99999));
              //  GetComponent<ItemPickUp>().trinketItemPickUp(99);
               trinketSlot.GetComponent<Image>().sprite = GameObject.Find("okoJeziera").GetComponent<SpriteRenderer>().sprite;
                trinekoffSlot.GetComponent<Image>().sprite = GameObject.Find("okoJeziera").GetComponent<SpriteRenderer>().sprite;
                trinekoffSlot.GetComponent<Button>().onClick.AddListener(() => GetComponent<ItemPickUp>().trinketItemPickUp(99) );
            }
        GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero1.curExp = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero1.curExp + 100;
            textmessage.SetActive(true);
        }


        
    }


}