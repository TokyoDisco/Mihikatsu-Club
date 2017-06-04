using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadButtonInfoScript : MonoBehaviour {
    public GameObject SavingSystem;



	// Use this for initialization
	void Start () {
        SavingSystem = GameObject.Find("SavingSystem");

        switch (name)
        {
            case "SaveSlot1":
                gameObject.GetComponentInChildren<Text>().text = SavingSystem.GetComponent<SaveLoadScript>().levelname1 + " " + SavingSystem.GetComponent<SaveLoadScript>().Herolevel;
                if(SavingSystem.GetComponent<SaveLoadScript>().Herolevel == 0)
                {
                    gameObject.GetComponentInChildren<Text>().text = "Empty";
                    gameObject.GetComponent<Button>().interactable = false;
                }
                break;
            case "SaveSlot2":
                gameObject.GetComponentInChildren<Text>().text = SavingSystem.GetComponent<SaveLoadScript>().levelname2 + " " + SavingSystem.GetComponent<SaveLoadScript>().Herolevel2;
                if (SavingSystem.GetComponent<SaveLoadScript>().Herolevel == 0)
                {
                    gameObject.GetComponentInChildren<Text>().text = "Empty";
                    gameObject.GetComponent<Button>().interactable = false;
                }
                break;
            case "SaveSlot3":
                gameObject.GetComponentInChildren<Text>().text = SavingSystem.GetComponent<SaveLoadScript>().levelname3 + " " + SavingSystem.GetComponent<SaveLoadScript>().Herolevel3;
                if (SavingSystem.GetComponent<SaveLoadScript>().Herolevel == 0)
                {
                    gameObject.GetComponentInChildren<Text>().text = "Empty";
                    gameObject.GetComponent<Button>().interactable = false;
                }
                break;
            case "ContinueBtn":
                {
                    switch(SavingSystem.GetComponent<SaveLoadScript>().LastSave)
                    {
                        case 0: gameObject.GetComponent<Button>().interactable = false;
                            break;
                        case 1:
                            {
                                gameObject.GetComponent<Button>().interactable = true;
                                gameObject.GetComponent<Button>().onClick.AddListener(Load1);

                            }
                            break;
                        case 2:
                            {
                                gameObject.GetComponent<Button>().interactable = true;
                                gameObject.GetComponent<Button>().onClick.AddListener(Load2);

                            }
                            break;
                        case 3:
                            {
                                gameObject.GetComponent<Button>().interactable = true;
                                gameObject.GetComponent<Button>().onClick.AddListener(Load3);

                            }
                            break;
                    }
                }
                break;

        }
       

		
	}


    public void Load1()
    {
        SavingSystem.GetComponent<SaveLoadScript>().Load();
    }
    public void Load2()
    {
        SavingSystem.GetComponent<SaveLoadScript>().Load2();
    }
    public void Load3()
    {
        SavingSystem.GetComponent<SaveLoadScript>().Load3();
    }


    public void Update()
    {
        SavingSystem = GameObject.Find("SavingSystem");
        gameObject.GetComponent<Button>().onClick.RemoveAllListeners();
        switch (name)
        {
            case "SaveSlot1":
                gameObject.GetComponentInChildren<Text>().text = SavingSystem.GetComponent<SaveLoadScript>().levelname1 + " " + SavingSystem.GetComponent<SaveLoadScript>().Herolevel;
                if (SavingSystem.GetComponent<SaveLoadScript>().Herolevel == 0)
                {
                    gameObject.GetComponentInChildren<Text>().text = "Empty";
                    gameObject.GetComponent<Button>().interactable = false;
                }
                else
                {
                    gameObject.GetComponent<Button>().onClick.AddListener(Load1);
                }
                break;
            case "SaveSlot2":
                gameObject.GetComponentInChildren<Text>().text = SavingSystem.GetComponent<SaveLoadScript>().levelname2 + " " + SavingSystem.GetComponent<SaveLoadScript>().Herolevel2;
                if (SavingSystem.GetComponent<SaveLoadScript>().Herolevel == 0)
                {
                    gameObject.GetComponentInChildren<Text>().text = "Empty";
                    gameObject.GetComponent<Button>().interactable = false;
                }
                else
                {
                    gameObject.GetComponent<Button>().onClick.AddListener(Load2);
                }
                break;
            case "SaveSlot3":
                gameObject.GetComponentInChildren<Text>().text = SavingSystem.GetComponent<SaveLoadScript>().levelname3 + " " + SavingSystem.GetComponent<SaveLoadScript>().Herolevel3;
                if (SavingSystem.GetComponent<SaveLoadScript>().Herolevel == 0)
                {
                    gameObject.GetComponentInChildren<Text>().text = "Empty";
                    gameObject.GetComponent<Button>().interactable = false;
                }
                else
                {
                    gameObject.GetComponent<Button>().onClick.AddListener(Load3);
                }
                break;
            case "ContinueBtn":
                {
                    gameObject.GetComponent<Button>().onClick.RemoveAllListeners();
                    switch (SavingSystem.GetComponent<SaveLoadScript>().LastSave)
                    {
                        case 0:
                            gameObject.GetComponent<Button>().interactable = false;
                            break;
                        case 1:
                            {
                                gameObject.GetComponent<Button>().interactable = true;
                                gameObject.GetComponent<Button>().onClick.AddListener(Load1);

                            }
                            break;
                        case 2:
                            {
                                gameObject.GetComponent<Button>().interactable = true;
                                gameObject.GetComponent<Button>().onClick.AddListener(Load2);

                            }
                            break;
                        case 3:
                            {
                                gameObject.GetComponent<Button>().interactable = true;
                                gameObject.GetComponent<Button>().onClick.AddListener(Load3);

                            }
                            break;
                    }
                }
                break;

        }

    }


}
