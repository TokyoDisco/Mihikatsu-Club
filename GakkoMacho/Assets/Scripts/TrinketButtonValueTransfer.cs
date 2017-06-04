using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrinketButtonValueTransfer : MonoBehaviour {
    public int trinketID;
    public GameObject[] trinketButtons;

	// Use this for initialization
	void Start () {
        if (GetComponentInParent<TrinketAssignButtonScript>().TrinketID != 0)
        {
            trinketID = GetComponentInParent<TrinketAssignButtonScript>().TrinketID;
        }

        if(name == "TrinketPCadd")
        {
            gameObject.GetComponent<Button>().onClick.AddListener(TransferPC);
        }

        if(name == "TrinketPC2add")
        {
            gameObject.GetComponent<Button>().onClick.AddListener(TransferPC2);
        }

        if(name == "TrinketPC3add")
        {
            gameObject.GetComponent<Button>().onClick.AddListener(TransferPC3);
        }
	}

    private void Update()
    {
        if (GetComponentInParent<TrinketAssignButtonScript>().TrinketID != 0)
        {
            trinketID = GetComponentInParent<TrinketAssignButtonScript>().TrinketID;
        }
    }

    public void CloseOthers()
    {
        trinketButtons = GameObject.FindGameObjectsWithTag("TrinketAssignButton");
        foreach(GameObject i in trinketButtons)
        {
            i.SetActive(false);
        }
    }

    public void TransferPC()
    {
        GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().TrinketAddPC(trinketID);
    }

    public void TransferPC2()
    {
        GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().TrinketAddPC2(trinketID);
    }
    public void TransferPC3()
    {
        GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().TrinketAddPC3(trinketID);
    }

}
