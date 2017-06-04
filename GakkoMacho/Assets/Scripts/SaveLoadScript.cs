using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

[System.Serializable]
public  class SaveLoadScript : MonoBehaviour {
    
    public GameObject[] systemCleanList;
    public int SaveSlots;
    public SaveData[] Saves;

    public int LastSave;
    public Hero hero1;
    public Hero hero2;
    public Hero hero3;
    public int PartySize;
    public Vector3 ExitPos;
    public Vector3 CameraPos;
    /*
    public GameObject[] EnemySpawnsList;
    public GameObject[] EnemySpawns_SpecialList;
    public List<GameObject> EnemySpawn;
    public List<GameObject> EnemySpawnSpecial;
    public GameObject[] HeroList;
    public GameObject[] TeamNPClist; */

    public List<string> HitObjectList;
    public List<Item> ItemsList;
    public List<Item> QuestItemsList;
    public List<Quest> QuestList;
    public List<Trinket> TrinketList;
    public string levelname;
    public string levelname1;
    public string levelname2;
    public string levelname3;
    public int Herolevel;
    public int Herolevel2;
    public int Herolevel3;
    public bool LoadingFromSavedGame;
    public bool loadingDone;
    public GameObject SaveButton;

    [System.Serializable]
    public class SaveData
    {

        public static List<GameObject> savedGames = new List<GameObject>();
        public Hero hero1;
        public Hero hero2;
        public Hero hero3;
        public int PartySize;
        public float VectorXCamera;
        public float VectorYCamera;
        public float VectorZCamera;
        public float VectorXPlayer;
        public float VectorYPlayer;
      //  public Vector3 ExitPos;
      /* public Vector3 CameraPos;
        public GameObject[] EnemySpawnsList;
        public GameObject[] EnemySpawns_SpecialList;
        public List<GameObject> EnemySpawn;
        public List<GameObject> EnemySpawnSpecial;
        public GameObject[] HeroList;
        public GameObject[] TeamNPClist; */
        public List<string> HitObjectList;
        public List<Item> ItemsList;
        public List<Item> QuestItemsList;
        public List<Quest> QuestList;
        public List<Trinket> TrinketList;
        public string levelname;
    }



    public  void Save(GameObject SaveSlot)
    {
        
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + "/Save1.SAVE");
        SaveData data = new SaveData();
        data.hero1 = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero1;
        data.hero2 = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero2;
        data.hero3 = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero3;
        data.PartySize = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().PartySize;
        data.VectorXCamera = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().camerapos.x;
        data.VectorYCamera = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().camerapos.y;
        data.VectorZCamera = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().camerapos.z;
        data.VectorXPlayer = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().exitpos.x;
        data.VectorYPlayer = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().exitpos.y;
        data.HitObjectList = GameObject.Find("StatsCarrier").GetComponent<MapSpawnControl>().hitObjectList;
        data.ItemsList = GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems;
        data.QuestItemsList = GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfQuestsItems;
        data.QuestList = GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests;
        data.levelname = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().LevelName;
        data.TrinketList = GameObject.Find("StatsCarrier").GetComponent<TrinketsList>().ListOfTrinkets;
        levelname = data.levelname;
        levelname1 = levelname;
        Herolevel = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero1.level;
        bf.Serialize(file, data);
        SaveSlot.GetComponentInChildren<Text>().text = levelname + " " + Herolevel;
        
        file.Close();
            Debug.Log("save bulwo");
        LastSave = 1;
        
        
            
    }

    public void Save2(GameObject SaveSlot)
    {

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/Save2.SAVE");
        SaveData data = new SaveData();
        data.hero1 = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero1;
        data.hero2 = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero2;
        data.hero3 = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero3;
        data.PartySize = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().PartySize;
        data.VectorXCamera = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().camerapos.x;
        data.VectorYCamera = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().camerapos.y;
        data.VectorZCamera = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().camerapos.z;
        data.VectorXPlayer = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().exitpos.x;
        data.VectorYPlayer = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().exitpos.y;
        data.HitObjectList = GameObject.Find("StatsCarrier").GetComponent<MapSpawnControl>().hitObjectList;
        data.ItemsList = GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems;
        data.QuestItemsList = GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfQuestsItems;
        data.QuestList = GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests;
        data.levelname = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().LevelName;
        data.TrinketList = GameObject.Find("StatsCarrier").GetComponent<TrinketsList>().ListOfTrinkets;
        levelname = data.levelname;
        levelname2 = levelname;
        Herolevel2 = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero1.level;
        bf.Serialize(file, data);
        SaveSlot.GetComponentInChildren<Text>().text = levelname + " " + Herolevel;
        
        file.Close();
        Debug.Log("save bulwo");
        LastSave = 2;



    }

    public void Save3(GameObject SaveSlot)
    {

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/Save3.SAVE");
        SaveData data = new SaveData();
        data.hero1 = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero1;
        data.hero2 = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero2;
        data.hero3 = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero3;
        data.PartySize = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().PartySize;
        data.VectorXCamera = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().camerapos.x;
        data.VectorYCamera = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().camerapos.y;
        data.VectorZCamera = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().camerapos.z;
        data.VectorXPlayer = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().exitpos.x;
        data.VectorYPlayer = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().exitpos.y;
        data.HitObjectList = GameObject.Find("StatsCarrier").GetComponent<MapSpawnControl>().hitObjectList;
        data.ItemsList = GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems;
        data.QuestItemsList = GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfQuestsItems;
        data.QuestList = GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests;
        data.levelname = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().LevelName;
        data.TrinketList = GameObject.Find("StatsCarrier").GetComponent<TrinketsList>().ListOfTrinkets;
        levelname = data.levelname;
        levelname3 = levelname;
        Herolevel3 = GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero1.level;
        bf.Serialize(file, data);
        SaveSlot.GetComponentInChildren<Text>().text = levelname + " " + Herolevel;
        
        file.Close();
        Debug.Log("save bulwo");
        LastSave = 3;



    }

    public void  Load()
    {
        if(File.Exists(Application.persistentDataPath + "/Save1.Save"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/Save1.Save", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();
            Debug.Log("Loading");
            // playerStats
            hero1 = data.hero1;
            hero2 = data.hero2;
            hero3 = data.hero3;
            PartySize =data.PartySize;
            ExitPos = new Vector3(data.VectorXPlayer, data.VectorYPlayer, 0);
            CameraPos = new Vector3(data.VectorXCamera, data.VectorYCamera, data.VectorZCamera);
            //MapControl
            HitObjectList = data.HitObjectList;
            //ItemList
            ItemsList = data.ItemsList;
            QuestItemsList = data.QuestItemsList;
            //QuestList
            QuestList = data.QuestList;
            //PlayerStats
            levelname = data.levelname;
            //TrinketList
            TrinketList = data.TrinketList;
            SceneManager.LoadSceneAsync("LoadingSplash");
            StartCoroutine(WaitingForLoad());
                
                SceneManager.LoadSceneAsync(levelname);

            
            if (LoadingFromSavedGame)
                {


                
            }
            
            if (loadingDone == true)
            {
              
                
                SceneManager.UnloadSceneAsync("LoadingSplash");
               
              
            }


            //  GameObject game = (GameObject)Instantiate(savedGames[0], savedGames[0].GetComponent<Transform>().transform, true);
            //  DontDestroyOnLoad(game);


        }
        else
        {
            Debug.Log("Not Saved files");
        }
    }

    public void Load2()
    {
        if (File.Exists(Application.persistentDataPath + "/Save2.Save"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/Save2.Save", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();
            Debug.Log("Loading");
            // playerStats
            hero1 = data.hero1;
            hero2 = data.hero2;
            hero3 = data.hero3;
            PartySize = data.PartySize;
            ExitPos = new Vector3(data.VectorXPlayer, data.VectorYPlayer, 0);
            CameraPos = new Vector3(data.VectorXCamera, data.VectorYCamera, data.VectorZCamera);
            //MapControl
            HitObjectList = data.HitObjectList;
            //ItemList
            ItemsList = data.ItemsList;
            QuestItemsList = data.QuestItemsList;
            //QuestList
            QuestList = data.QuestList;
            //PlayerStats
            levelname = data.levelname;
            //TrinketList
            TrinketList = data.TrinketList;
            SceneManager.LoadSceneAsync("LoadingSplash");
            StartCoroutine(WaitingForLoad());

            SceneManager.LoadSceneAsync(levelname);


            if (LoadingFromSavedGame)
            {



            }

            if (loadingDone == true)
            {


                SceneManager.UnloadSceneAsync("LoadingSplash");


            }


            //  GameObject game = (GameObject)Instantiate(savedGames[0], savedGames[0].GetComponent<Transform>().transform, true);
            //  DontDestroyOnLoad(game);


        }
        else
        {
            Debug.Log("Not Saved files");
        }
    }

    public void Load3()
    {
        if (File.Exists(Application.persistentDataPath + "/Save3.Save"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/Save3.Save", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();
            Debug.Log("Loading");
            // playerStats
            hero1 = data.hero1;
            hero2 = data.hero2;
            hero3 = data.hero3;
            PartySize = data.PartySize;
            ExitPos = new Vector3(data.VectorXPlayer, data.VectorYPlayer, 0);
            CameraPos = new Vector3(data.VectorXCamera, data.VectorYCamera, data.VectorZCamera);
            //MapControl
            HitObjectList = data.HitObjectList;
            //ItemList
            ItemsList = data.ItemsList;
            QuestItemsList = data.QuestItemsList;
            //QuestList
            QuestList = data.QuestList;
            //PlayerStats
            levelname = data.levelname;
            //TrinketList
            TrinketList = data.TrinketList;
            SceneManager.LoadSceneAsync("LoadingSplash");
            StartCoroutine(WaitingForLoad());

            SceneManager.LoadSceneAsync(levelname);


            if (LoadingFromSavedGame)
            {



            }

            if (loadingDone == true)
            {


                SceneManager.UnloadSceneAsync("LoadingSplash");


            }


            //  GameObject game = (GameObject)Instantiate(savedGames[0], savedGames[0].GetComponent<Transform>().transform, true);
            //  DontDestroyOnLoad(game);


        }
        else
        {
            Debug.Log("Not Saved files");
        }
    }

    private void Awake()
    {
        systemCleanList = GameObject.FindGameObjectsWithTag("System");
        LoadingFromSavedGame = false;
        loadingDone = false;
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if(systemCleanList.Length > 1)
        {
            int lastIndex = systemCleanList.Length - 1;
            DestroyObject(systemCleanList[lastIndex]);
        }
    }

    IEnumerator WaitingForLoad()
    {
        yield return new WaitForSeconds(0.3f);
        LoadingFromSavedGame = true;
        TransferData();
        yield return new WaitForSeconds(4f);
        loadingDone = true;
        
    }

    public void TransferData()
    {
        if (GameObject.Find("StatsCarrier"))
        {
            GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero1 = hero1;
            GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero2 = hero2;
            GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().hero3 = hero3;
            GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().PartySize = PartySize;
            GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().exitpos = ExitPos;
            GameObject.Find("Player").GetComponent<Transform>().position = ExitPos;
            GameObject.Find("Main Camera").GetComponent<Transform>().position = CameraPos;
            GameObject.Find("StatsCarrier").GetComponent<PlayerStats>().LevelName = levelname;
            GameObject.Find("StatsCarrier").GetComponent<MapSpawnControl>().hitObjectList = HitObjectList;
            GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfItems = ItemsList;
            GameObject.Find("StatsCarrier").GetComponent<ItemsList>().ListOfQuestsItems = QuestItemsList;
            GameObject.Find("StatsCarrier").GetComponent<QuestList>().ListOfQuests = QuestList;
            GameObject.Find("StatsCarrier").GetComponent<TrinketsList>().ListOfTrinkets = TrinketList;
        }
        else
        {
            StartCoroutine(WaitingForLoad());
        }
    }

   


}
