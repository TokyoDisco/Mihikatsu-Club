using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestList : MonoBehaviour {
    public List<Quest> ListOfQuests = new List<Quest>();
    public int ListCount = 0;
    public GameObject Popup;
    public GameObject ding;
    // Use this for initialization
    private void Start()
    {
        ListCount = ListOfQuests.Count;
    }
    void Update () {
	
        if(ListCount != ListOfQuests.Count)
        {
            Popup.SetActive(true);
            ding.GetComponent<AudioSource>().Play();
            ListCount = ListOfQuests.Count;
        }
        
        	
	}
	
	
}
