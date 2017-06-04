using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitButton : MonoBehaviour {
   
    public void ExitClick()

    {
        foreach (GameObject o in Object.FindObjectsOfType<GameObject>())
        {
            if (o.name != "SavingSystem")
            {
                Destroy(o);
            }
            else
            {
                DontDestroyOnLoad(o);
            }
        }
        SceneManager.LoadScene("MainMenu");
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene("MainMenu");
    }

}
