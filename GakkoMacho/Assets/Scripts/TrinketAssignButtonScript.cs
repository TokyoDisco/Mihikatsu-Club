using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrinketAssignButtonScript : MonoBehaviour {
    public GameObject Trinket1;
    public GameObject Trinket2;
    public GameObject Trinket3;
    public GameObject[] trinketsbuttons;
    public int PartySize;
    public int TrinketID;
    public bool active;



	// Use this for initialization
	void Start () {

        active = false;
        trinketsbuttons = GameObject.FindGameObjectsWithTag("TrinketAssignButton");

		
	}
	
	// Update is called once per frame
	void Update () {

        trinketsbuttons = GameObject.FindGameObjectsWithTag("TrinketAssignButton");
    }



    public void Check()
    {
        trinketsbuttons = GameObject.FindGameObjectsWithTag("TrinketAssignButton");
        foreach (GameObject i in trinketsbuttons)
        {
            i.SetActive(false);
        }
        if (TrinketID != 0)
        {
            PartySize = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().PartySize;
            if (!active)
            {
                if (PartySize == 1)
                {
                    Trinket1.SetActive(true);
                }
                else
                {
                    if (PartySize == 2)
                    {
                        Trinket1.SetActive(true);
                        Trinket2.SetActive(true);
                    }
                    else
                        if (PartySize >2)
                    {
                        Trinket1.SetActive(true);
                        Trinket2.SetActive(true);
                        Trinket3.SetActive(true);
                    }
                }
                active = true;

            }
            else
            {
                if (PartySize == 1)
                {
                    Trinket1.SetActive(false);
                }
                else
                {
                    if (PartySize == 2)
                    {
                        Trinket1.SetActive(false);
                        Trinket2.SetActive(false);
                    }
                    else
                        if (PartySize >2)
                    {
                        Trinket1.SetActive(false);
                        Trinket2.SetActive(false);
                        Trinket3.SetActive(false);
                    }
                }
                active = false;
            }
        }
    }
   
}
