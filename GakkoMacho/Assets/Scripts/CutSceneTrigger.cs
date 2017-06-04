using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneTrigger : MonoBehaviour
{
    public GameObject Canvas3;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        
            switch (gameObject.name)
            {
                case "triggerCutscene01":
                    {
                        Canvas3.GetComponent<CutSceneScript>().cutSceneTrigger(1);
                        GameObject.Find("StatsCarrier").GetComponent<MapSpawnControl>().hitObjectList.Add(name);
                        Destroy(GameObject.Find(name));

                    }
                    break;
                case "triggerCutscene02":

                    {
                        Canvas3.GetComponent<CutSceneScript>().cutSceneTrigger(2);
                        GameObject.Find("StatsCarrier").GetComponent<MapSpawnControl>().hitObjectList.Add(name);
                        Destroy(GameObject.Find(name));

                    }
                    break;
                case "triggerCutscene03":

                    {
                        Canvas3.GetComponent<CutSceneScript>().cutSceneTrigger(3);
                        GameObject.Find("StatsCarrier").GetComponent<MapSpawnControl>().hitObjectList.Add(name);
                        Destroy(GameObject.Find(name));

                    }
                    break;
                case "triggerCutscene04":

                    {
                        Canvas3.GetComponent<CutSceneScript>().cutSceneTrigger(4);
                        GameObject.Find("StatsCarrier").GetComponent<MapSpawnControl>().hitObjectList.Add(name);
                        Destroy(GameObject.Find(name));

                    }
                    break;
                case "triggerCutscene05":

                    {
                        Canvas3.GetComponent<CutSceneScript>().cutSceneTrigger(5);
                        GameObject.Find("StatsCarrier").GetComponent<MapSpawnControl>().hitObjectList.Add(name);
                        Destroy(GameObject.Find(name));

                    }
                    break;
                case "triggerCutscene06":

                    {
                        Canvas3.GetComponent<CutSceneScript>().cutSceneTrigger(6);
                        GameObject.Find("StatsCarrier").GetComponent<MapSpawnControl>().hitObjectList.Add(name);
                        Destroy(GameObject.Find(name));

                    }
                    break;
                case "triggerCutscene07":

                    {
                        Canvas3.GetComponent<CutSceneScript>().cutSceneTrigger(7);
                        GameObject.Find("StatsCarrier").GetComponent<MapSpawnControl>().hitObjectList.Add(name);
                        Destroy(GameObject.Find(name));

                    }
                    break;

            }
        }
    








}