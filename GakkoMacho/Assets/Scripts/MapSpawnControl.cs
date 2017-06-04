using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
[System.Serializable]
public class MapSpawnControl : MonoBehaviour {
    public List<GameObject> EnemySpawns = new List<GameObject>();
    public List<GameObject> EnemySpawn_special = new List<GameObject>();
    public List<GameObject> PlayerSpawns = new List<GameObject>();
    public GameObject[] EnemySpawnList;
    public GameObject[] EnemySpawn_specialList;
    public GameObject enemy;
    public GameObject[] HeroList;
    public GameObject[] TeamNpcList;
    public GameObject[] SystemStuffList;
    public GameObject[] GeneratorCleanList;
    public GameObject[] UICleanList;
    public List<string> hitObjectList = new List<string>();
    public int checkScene;
    void Start()
    {
     // Check if scene was changed to avoid problems in BattleMode
        checkScene = 0;
        if (checkScene == 1)
        {
            for (int i = 0; i < hitObjectList.Count; i++) //For that will delete every hitted target only trigger if player wins battle
            {
                Destroy(GameObject.Find(hitObjectList[i]));

            }

        }

        EnemySpawn_specialList = GameObject.FindGameObjectsWithTag("EnemySpawns_special");
        
            for(int i = 0; i<EnemySpawn_specialList.Length;i++)
        {
            EnemySpawn_special.Add(EnemySpawn_specialList[i]);
        }


        for (int i = 0; i < EnemySpawn_special.Count; i++)
        {
            enemy = (GameObject)Instantiate(GameObject.Find("ELITEtoCopy"), EnemySpawn_special[i].GetComponent<Transform>().transform, true);
            if(EnemySpawn_special[i].name == "FinalBoss_tutorial1")
            {
                enemy.GetComponent<Transform>().position = GameObject.Find("BossTutorial1toCopy").GetComponent<Transform>().position;
                string nameBoss = enemy.transform.parent.name;
                enemy.GetComponent<SpriteRenderer>().sprite = GameObject.Find("BossTutorial1toCopy").GetComponent<SpriteRenderer>().sprite;
                enemy.name = "boss_tutorial" + i;
                if (nameBoss == GetComponent<PlayerStats>().killedEnemyPatrol)
                {
                    Destroy(GameObject.Find(nameBoss));
                }
                else
                {
                    enemy.GetComponent<Transform>().position = EnemySpawn_special[i].GetComponent<Transform>().position;
                }
            }
            else
            {
                enemy.GetComponent<Transform>().position = GameObject.Find("ELITEtoCopy").GetComponent<Transform>().position;
                string name = enemy.transform.parent.name;
                enemy.name = "enemy_elite" + i;
            }
            
            if (name == GetComponent<PlayerStats>().killedEnemyPatrol)
            {
                Destroy(GameObject.Find(name));
            }
            else
            {
                enemy.GetComponent<Transform>().position = EnemySpawn_special[i].GetComponent<Transform>().position;
            }
        }

        //This will spawn enemies on set spawn points at start of game/level 
        EnemySpawnList = GameObject.FindGameObjectsWithTag("EnemySpawns");
        for(int i=0; i<EnemySpawnList.Length;i++)
        {
            EnemySpawns.Add(EnemySpawnList[i]);
        }

        for (int i=0; i<EnemySpawns.Count; i++)
        {
            enemy = (GameObject)Instantiate(GameObject.Find("ENEMYtoCopy"), EnemySpawns[i].GetComponent<Transform>().transform, true);
            enemy.GetComponent<Transform>().position = GameObject.Find("ENEMYtoCopy").GetComponent<Transform>().position;
            string name = enemy.transform.parent.name;
            enemy.name = "enemy" + i; 
            if (name == GetComponent<PlayerStats>().killedEnemyPatrol)
            {
                Destroy(GameObject.Find(name));
            }
            else
            {
                enemy.GetComponent<Transform>().position = EnemySpawns[i].GetComponent<Transform>().position;
            }
        }

        //Searching for Player tagged object and adding to the list just for avoid double spawn after exiting combat
        HeroList = GameObject.FindGameObjectsWithTag("Player");
        if(HeroList.Length > 1)
        {
            int lastIndex = HeroList.Length - 1;
            HeroList[lastIndex] = null;
            
        }
        SystemStuffList = GameObject.FindGameObjectsWithTag("StatsCarrier");
        if(SystemStuffList.Length > 1)
        {
            int lastIndex = SystemStuffList.Length - 1;
            SystemStuffList[lastIndex] = null;
        }

        TeamNpcList = GameObject.FindGameObjectsWithTag("TeamNPC");

        UICleanList = GameObject.FindGameObjectsWithTag("MainUI");
        if(UICleanList.Length > 1)
        {
            int lastIndex = UICleanList.Length - 1;
            DestroyObject(UICleanList[lastIndex]);
        }

        GeneratorCleanList = GameObject.FindGameObjectsWithTag("Generator");
        if(GeneratorCleanList.Length > 1)
        {
            int lastIndex = GeneratorCleanList.Length - 1;
            DestroyObject(GeneratorCleanList[lastIndex]);
        }
        

    }


    void Update()
    {
        TeamNpcList = GameObject.FindGameObjectsWithTag("TeamNPC");
        //deleting upon exiting from combat or event that despawn enemies occured
        // if (checkScene == 1)
        // {
        for (int i = 0; i < hitObjectList.Count; i++)
           {
                Destroy(GameObject.Find(hitObjectList[i]));

           }
           
   //     }
        //Deleting any extra player object
        HeroList = GameObject.FindGameObjectsWithTag("Player");
        if (HeroList.Length > 1)
        {
            int lastIndex = HeroList.Length - 1;
            Destroy(HeroList[lastIndex]);

        }
        if (GameObject.Find("StatsCarrier").GetComponent<PartyStats>().PartyList.Count > 1)
        {
            if (TeamNpcList.Length > 1)
            {
                if (TeamNpcList[1].name == TeamNpcList[0].name)
                {
                    Destroy(TeamNpcList[1]);
                }
            }
        }

        SystemStuffList = GameObject.FindGameObjectsWithTag("StatsCarrier");
        if (SystemStuffList.Length > 1)
        {
            int lastIndex = SystemStuffList.Length - 1;
            Destroy(SystemStuffList[lastIndex]);
        }

        UICleanList = GameObject.FindGameObjectsWithTag("MainUI");
        if (UICleanList.Length > 1)
        {
            int lastIndex = UICleanList.Length - 1;
            DestroyObject(UICleanList[lastIndex]);
        }

        GeneratorCleanList = GameObject.FindGameObjectsWithTag("Generator");
        if (GeneratorCleanList.Length > 1)
        {
            int lastIndex = GeneratorCleanList.Length - 1;
            DestroyObject(GeneratorCleanList[lastIndex]);
        }

        //renable hitbox upon player
        GameObject.Find("Player").GetComponent<BoxCollider2D>().enabled = true;
    }
}
