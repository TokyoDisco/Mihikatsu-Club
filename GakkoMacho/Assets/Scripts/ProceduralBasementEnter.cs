using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ProceduralBasementEnter : MonoBehaviour {

        


       private void OnTriggerEnter2D(Collider2D collision)
        {
       
        GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().CameraSave(GameObject.Find("Main Camera").GetComponent<Transform>().position);
            DontDestroyOnLoad(GameObject.Find("StatsCarrier"));
         //   GameObject.Find("Player").GetComponent<BasicContolScript>().Scena = 1;
            DontDestroyOnLoad(GameObject.Find("osahara"));
            DontDestroyOnLoad(GameObject.Find("Inomi"));
            DontDestroyOnLoad(GameObject.Find("Player"));
            DontDestroyOnLoad(GameObject.Find("Canvas2"));
            DontDestroyOnLoad(GameObject.Find("walkSound"));
            DontDestroyOnLoad(GameObject.Find("Ding"));
            DontDestroyOnLoad(GameObject.Find("okoJeziera"));
        Scene activ = SceneManager.GetActiveScene();
        GameObject.Find("Player").GetComponent<BasicContolScript>().Scena = 2;
        GameObject.Find("Player").GetComponent<BasicContolScript>().LastSceneEnter = activ.name;
        
        SceneManager.LoadScene("ProcedularDungeon");
        
        SceneManager.UnloadSceneAsync(GameObject.Find("Player").GetComponent<BasicContolScript>().LastSceneEnter);
       

        // GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().LastHit(transform.parent.name);
       
        
        
        }
    
}
