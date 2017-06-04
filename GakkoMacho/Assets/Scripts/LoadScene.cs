using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadScene : MonoBehaviour {

    public void LoadSceneRun()
    {
        SceneManager.LoadScene("IntroScene");
    }

    public void LoadProcedularDungeonRun()
    {
        SceneManager.LoadScene("ProcedularDungeon");
    }



    
}
