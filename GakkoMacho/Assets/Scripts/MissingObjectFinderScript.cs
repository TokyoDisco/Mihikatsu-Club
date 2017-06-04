using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissingObjectFinderScript : MonoBehaviour {

    // Use this for initialization
    void Start() {

        switch (name)
        {
            case "SaveSlot1":
                {
                    gameObject.GetComponent<Button>().onClick.AddListener(Save1);
                }
                break;
            case "SaveSlot2":
                {
                    gameObject.GetComponent<Button>().onClick.AddListener(Save2);
                }
                break;
            case "SaveSlot3":
                {
                    gameObject.GetComponent<Button>().onClick.AddListener(Save3);
                }
                break;
        }

    }

    // Update is called once per frame
    void Update() {
       
        switch (name)
        {

            case "SaveSlot1":
                {
                    gameObject.GetComponent<Button>().onClick.RemoveAllListeners();
                    gameObject.GetComponent<Button>().onClick.AddListener(Save1);
                }
                break;
            case "SaveSlot2":
                {
                    gameObject.GetComponent<Button>().onClick.RemoveAllListeners();
                    gameObject.GetComponent<Button>().onClick.AddListener(Save2);
                }
                break;
            case "SaveSlot3":
                {
                    gameObject.GetComponent<Button>().onClick.RemoveAllListeners();
                    gameObject.GetComponent<Button>().onClick.AddListener(Save3);
                }
                break;
            case "Canvas2":
                {
                    try
                    {
                        gameObject.GetComponent<Canvas>().worldCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
                    }
                    catch
                    {
                        Debug.Log("Main Camera not found : is this battle mode?");
                    }
                    
                }
                break;
        }
    }


    public void Save1()
    {
        GameObject.Find("SavingSystem").GetComponent<SaveLoadScript>().Save(gameObject);
    }

    public void Save2()
    {
        GameObject.Find("SavingSystem").GetComponent<SaveLoadScript>().Save2(gameObject);
    }
    public void Save3()
    {
        GameObject.Find("SavingSystem").GetComponent<SaveLoadScript>().Save3(gameObject);
    }


}
