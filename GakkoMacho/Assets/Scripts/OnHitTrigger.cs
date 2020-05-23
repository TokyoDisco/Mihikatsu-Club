using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class OnHitTrigger : MonoBehaviour
{
    private Rigidbody2D body;
    

    void OnTriggerEnter2D(Collider2D body)
    {
        if (name != "EndRoom")
        {
            GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().CameraSave(GameObject.Find("Main Camera").GetComponent<Transform>().position);
            DontDestroyOnLoad(GameObject.Find("StatsCarrier"));
        //    DontDestroyOnLoad(GameObject.Find("Generator"));
        //    DontDestroyOnLoad(GameObject.Find("RoomPackage"));
            GameObject.Find("Player").GetComponent<BasicContolScript>().Scena = 1;
            Scene activ = SceneManager.GetActiveScene();

            GameObject.Find("Player").GetComponent<BasicContolScript>().LastSceneEnter = activ.name;
            DontDestroyOnLoad(GameObject.Find("osahara"));
            DontDestroyOnLoad(GameObject.Find("Inomi"));
            DontDestroyOnLoad(GameObject.Find("Player"));
            DontDestroyOnLoad(GameObject.Find("Canvas2"));
            DontDestroyOnLoad(GameObject.Find("walkSound"));
            DontDestroyOnLoad(GameObject.Find("Ding"));

            if (name == "ExitTo_Level_PathToPool")
            {
                GameObject.Find("Player").GetComponent<BasicContolScript>().Scena = 2;
                SceneManager.LoadScene("level_PathToPool");

                SceneManager.UnloadSceneAsync(GameObject.Find("Player").GetComponent<BasicContolScript>().LastSceneEnter);





                //    GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().LastHit(transform.parent.name);
            }
            else
            {
                if (name == "PD_Test_go")
                {

                    SceneManager.UnloadSceneAsync(GameObject.Find("Player").GetComponent<BasicContolScript>().LastSceneEnter);
                    SceneManager.LoadScene("ProcedularDungeon");

                    GameObject.Find("Player").GetComponent<BasicContolScript>().Scena = 3;
                }

                else
                {
                    if (name == "FinalRoomExit")
                    {
                        int layernumber = GameObject.Find("Generator").GetComponent<LevelGenerationControl>().layer + 1;
                        GameObject.Find("Player").GetComponent<BasicContolScript>().LayerChangeFlag = true;
                        //SceneManager.UnloadSceneAsync("ProcedularDungeon");
                        //SceneManager.LoadSceneAsync("ProcedularDungeon");
                        


                        GameObject.Find("StatsCarrier").GetComponent<MapSpawnControl>().hitObjectList.Clear();
                      //  GameObject.Find("Generator").GetComponent<LevelGenerationControl>().Start();
                        GameObject.Find("Generator").GetComponent<LevelGenerationControl>().ClearingFunction();
                       // GameObject.Find("Generator").GetComponent<LevelGenerationControl>().layer = layernumber;
                       GameObject.Find("Generator").GetComponent<LevelGenerationControl>().LayerChange();
                        GameObject.Find("Player").GetComponent<BasicContolScript>().Scena = 3;

                    }
                    else
                    {



                        SceneManager.LoadScene("BattleSceneProto");
                        SceneManager.UnloadSceneAsync(GameObject.Find("Player").GetComponent<BasicContolScript>().LastSceneEnter);
                        GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().LastHit(transform.parent.name);

                    }
                }

            }
        }
     }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "RoomToCopy") 
        {
            gameObject.transform.position = new Vector3(0, 0, 0);
            GameObject.Find("Generator").GetComponent<LevelGenerationControl>().NewLayerGeneration();
        }
    }
}