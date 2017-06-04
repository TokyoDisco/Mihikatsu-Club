using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHitPartyAdd : MonoBehaviour {

    public GameObject me;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject.Find("StatsCarrier").GetComponent<PartyStats>().PartyList.Add(me);
        GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().PartyAdded(me.name);
        me.GetComponent<Transform>().position = new Vector3(9999, 9999, -90);
        me.GetComponent<BoxCollider2D>().enabled = false;
    }
}
