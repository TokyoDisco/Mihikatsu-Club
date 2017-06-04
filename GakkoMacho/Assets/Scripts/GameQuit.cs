using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameQuit : MonoBehaviour {

    public void GameQuitRun()
    {
        Application.Quit();
    }

    public void Mainmenu()
    {
        SceneManager.UnloadSceneAsync("EndingScene");
        SceneManager.LoadSceneAsync("MainMenu");
    }

}
