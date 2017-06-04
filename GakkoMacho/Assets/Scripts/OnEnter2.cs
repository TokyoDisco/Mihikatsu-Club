using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class OnEnter2 : MonoBehaviour
{
    private Rigidbody2D body;


    void OnTriggerEnter2D(Collider2D body)
    {
         SceneManager.UnloadScene("BattleSceneProto");
       
      SceneManager.LoadScene("ExplorerSceneProto");
    }
}