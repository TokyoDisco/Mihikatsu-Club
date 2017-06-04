using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalentPointCheck : MonoBehaviour {

    public GameObject me;
    // Use this for initialization
    void Start()
    {

        if (GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero1.talentPoints > 0)
        {
            me.GetComponent<Button>().Select();
        }



    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero1.talentPoints > 0)
        {
            me.GetComponent<Button>().Select();
        }
    }

}
