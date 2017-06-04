using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// This is procedural generated scene for theme : Pool Basement. It has assets to support this theme 
public class LevelGenerationControl : MonoBehaviour {
    public List<Room> RoomList = new List<Room>();
    public Room LastRoom;
    public List<GameObject> RoomListSpawn = new List<GameObject>();
    public int roomCount;
    public int roomListSpawnCount;
    public int deep;
    public int layer = 1;
    public int freeRoomCount;
   // public List<>
    public int roomWithEnemyCount;
    public int roomWithChestCount;
    public int roomWithBonusCount;
    public GameObject roomToCopy;
    public GameObject finalRoom;
    public GameObject enemy;
    public GameObject chest;
    public GameObject door;
    public GameObject[] ListOfWalls;
    public GameObject[] ListOfFloors;
    public GameObject[] ListOfDoors;
    public GameObject[] ListOfEnemySprites;
    public GameObject[] ListOfPickUpSprites;
    public GameObject RoomPackage;
    public GameObject RoomPackageProcedural;
    public string SceneName;
    bool positonConflict;
    bool readyToGo;
    bool clearingDone = false;
    public  List<String> DirList = new List<string>(4);

    


    // Use this for initialization
    public void Start() {
        Application.logMessageReceived += HandleException;
        deep = UnityEngine.Random.Range(7, 10);
        
        
        Scene act = SceneManager.GetActiveScene();
        SceneName = act.name;
        if (GameObject.Find("Player").GetComponent<BasicContolScript>().LastSceneEnter == SceneName)
        {
           if(GameObject.Find("Player").GetComponent<BasicContolScript>().LayerChangeFlag)
            {
                
                GameObject.Find("Player").GetComponent<BasicContolScript>().LayerChangeFlag = false;
                ClearingFunction();
                StartCoroutine(WaitForDestor());
                if (clearingDone)
                {
                    NewLayerGeneration();
                }
                else
                {
                    ClearingFunction();
                    
                }
                
            }
           
        }
        else
        {
            if (layer == deep)
            {
                GameObject.Find("FinalRoomExit").GetComponent<SpriteRenderer>().sprite = GameObject.Find("RatHauntedBoss").GetComponent<SpriteRenderer>().sprite;
                GameObject.Find("FinalRoomExit").tag = "EnemySpawns_special";
                GameObject.Find("FinalRoomExit").name = "FinalBoss_poolBasement";
            }

            ListOfWalls = GameObject.FindGameObjectsWithTag("WallSprite");
            ListOfDoors = GameObject.FindGameObjectsWithTag("DoorSprite");
            ListOfFloors = GameObject.FindGameObjectsWithTag("FloorSprite");
            ListOfEnemySprites = GameObject.FindGameObjectsWithTag("EnemyPatrol");
            
            DirList.Add("North");
            DirList.Add("South");
            DirList.Add("West");
            DirList.Add("East");
            roomCount = UnityEngine.Random.Range(4, 11);
            freeRoomCount = roomCount;
            roomWithChestCount = UnityEngine.Random.Range(1, 3);
            roomWithEnemyCount = roomCount - roomWithChestCount;
            int ifChest = UnityEngine.Random.Range(1, 5);


            for (int i = 0; i < roomCount; i++)
            {

                string ranDir = DirList[UnityEngine.Random.Range(0, DirList.Count - 1)];
                RoomList.Add(new Room("Room" + i, ranDir, ifChest, ranDir, ranDir, ListOfWalls, ListOfFloors));
                if (RoomList[i].enter == RoomList[i].exit)
                {
                    string ranDir2 = DirList[UnityEngine.Random.Range(0, DirList.Count - 1)];
                    do
                    {
                        ranDir2 = DirList[UnityEngine.Random.Range(0, DirList.Count - 1)];
                    }
                    while (ranDir == ranDir2);
                    RoomList[i].exit = ranDir2;
                }

                ifChest = UnityEngine.Random.Range(1, 3);
            }
            /* for (int i = 0; i < roomWithEnemyCount; i++)
             {
                 string ranDir = DirList[UnityEngine.Random.Range(0, DirList.Count - 1)];
                 RoomList.Add(new Room("RoomEnemy" + i, ranDir, 1, ranDir, ranDir, ListOfWalls, ListOfDoors));
                 if (RoomList[i].enter == RoomList[i].exit)
                 {
                     string ranDir2 = DirList[UnityEngine.Random.Range(0, DirList.Count - 1)];
                     do
                     {
                         ranDir2 = DirList[UnityEngine.Random.Range(0, DirList.Count - 1)];
                     }
                     while (ranDir == ranDir2);
                     RoomList[i].exit = ranDir2;
                 }

             } */

            for (int shuffle = 1; shuffle < RoomList.Count; shuffle++)
            {
                Room temp = RoomList[shuffle];
                int RandomOrder = UnityEngine.Random.Range(shuffle, RoomList.Count);
                RoomList[shuffle] = RoomList[RandomOrder];
                RoomList[RandomOrder] = temp;
            }

            for (int i = 0; i < RoomList.Count; i++)
            {

                RoomListSpawn.Add(new GameObject("Room" + i));
                RoomListSpawn[i] = (GameObject)Instantiate(roomToCopy, RoomPackageProcedural.GetComponent<Transform>().transform, true);
                RoomListSpawn[i].transform.Find("EastDoor").GetComponent<SpriteRenderer>().sprite = GameObject.Find("BasementWallBattle2").GetComponent<SpriteRenderer>().sprite;
                RoomListSpawn[i].transform.Find("EastDoor").GetComponent<BoxCollider2D>().isTrigger = false;
                RoomListSpawn[i].name = "roomSpawn " + i;
                int randomLocationOfSpawn = UnityEngine.Random.Range(0, 4);
                GameObject spawn = null;
                switch(randomLocationOfSpawn)
                {
                    case 0: spawn = RoomListSpawn[i].transform.Find("SpawnLocation").gameObject;
                        break;
                    case 1:
                        if (RoomListSpawn[i].transform.Find("SpawnLocation2").gameObject)
                        {
                            spawn = RoomListSpawn[i].transform.Find("SpawnLocation2").gameObject;
                        }
                        else
                        {
                            spawn = RoomListSpawn[i].transform.Find("SpawnLocation").gameObject;
                        }
                        break;
                    case 2:
                        if (RoomListSpawn[i].transform.Find("SpawnLocation3").gameObject)
                        {
                            spawn = RoomListSpawn[i].transform.Find("SpawnLocation3").gameObject;
                        }
                        else
                        {
                            spawn = RoomListSpawn[i].transform.Find("SpawnLocation").gameObject;
                        }
                        break;
                    case 3:
                        if (RoomListSpawn[i].transform.Find("SpawnLocation4").gameObject)
                        {
                            spawn = RoomListSpawn[i].transform.Find("SpawnLocation4").gameObject;
                        }
                        else
                        {
                            spawn = RoomListSpawn[i].transform.Find("SpawnLocation").gameObject;
                        }
                        break;
                    default:
                        spawn = RoomListSpawn[i].transform.Find("SpawnLocation").gameObject;
                        break;

                }
                
                spawn.name = "Spawn" + i;
                if (i != 0)
                {
                    
                   
                    Vector3 move = new Vector3(30, 0, 0);
                    if (RoomList[i - 1].exit == "South")
                    {
                        move = new Vector3(0, -20, 0);
                        RoomList[i].enter = "North";
                        if (RoomList[i].enter == RoomList[i].exit || positonConflict)
                        {
                            string ranDir2 = DirList[UnityEngine.Random.Range(0, DirList.Count - 1)];
                            do
                            {
                                ranDir2 = DirList[UnityEngine.Random.Range(0, DirList.Count - 1)];
                            }
                            while (RoomList[i].enter == ranDir2);
                            RoomList[i].exit = ranDir2;
                            /*    door = RoomListSpawn[i].transform.Find("NorthDoor").gameObject;
                                door.GetComponent<SpriteRenderer>().sprite = GameObject.Find("BasementDoor1").GetComponent<SpriteRenderer>().sprite;
                                door.GetComponent<BoxCollider2D>().enabled = false; */



                        }
                        RoomListSpawn[i].transform.Find("NorthDoor").GetComponent<SpriteRenderer>().sprite = GameObject.Find("BasementDoor1").GetComponent<SpriteRenderer>().sprite;
                        RoomListSpawn[i].transform.Find("NorthDoor").GetComponent<BoxCollider2D>().isTrigger = true;
                        RoomListSpawn[i].transform.Find(RoomList[i].exit + "Door").GetComponent<SpriteRenderer>().sprite = GameObject.Find("BasementDoor1").GetComponent<SpriteRenderer>().sprite;
                        RoomListSpawn[i].transform.Find(RoomList[i].exit + "Door").GetComponent<BoxCollider2D>().isTrigger = true;
                    }
                    if (RoomList[i - 1].exit == "North" || positonConflict)
                    {
                        move = new Vector3(0, 20, 0);
                        RoomList[i].enter = "South";

                        if (RoomList[i].enter == RoomList[i].exit)
                        {
                            string ranDir2 = DirList[UnityEngine.Random.Range(0, DirList.Count - 1)];
                            do
                            {
                                ranDir2 = DirList[UnityEngine.Random.Range(0, DirList.Count - 1)];
                            }
                            while (RoomList[i].enter == ranDir2);
                            RoomList[i].exit = ranDir2;
                        }

                        RoomListSpawn[i].transform.Find("SouthDoor").GetComponent<SpriteRenderer>().sprite = GameObject.Find("BasementDoor1").GetComponent<SpriteRenderer>().sprite;
                        RoomListSpawn[i].transform.Find("SouthDoor").GetComponent<BoxCollider2D>().isTrigger = true;
                        RoomListSpawn[i].transform.Find(RoomList[i].exit + "Door").GetComponent<SpriteRenderer>().sprite = GameObject.Find("BasementDoor1").GetComponent<SpriteRenderer>().sprite;
                        RoomListSpawn[i].transform.Find(RoomList[i].exit + "Door").GetComponent<BoxCollider2D>().isTrigger = true;
                    }

                    if (RoomList[i - 1].exit == "West")
                    {
                        move = new Vector3(-35, 0, 0);
                        RoomList[i].enter = "East";

                        if (RoomList[i].enter == RoomList[i].exit || positonConflict)
                        {
                            string ranDir2 = DirList[UnityEngine.Random.Range(0, DirList.Count - 1)];
                            do
                            {
                                ranDir2 = DirList[UnityEngine.Random.Range(0, DirList.Count - 1)];
                            }
                            while (RoomList[i].enter == ranDir2);
                            RoomList[i].exit = ranDir2;
                        }

                        RoomListSpawn[i].transform.Find("EastDoor").GetComponent<SpriteRenderer>().sprite = GameObject.Find("BasementDoor1").GetComponent<SpriteRenderer>().sprite;
                        RoomListSpawn[i].transform.Find("EastDoor").GetComponent<BoxCollider2D>().isTrigger = true;
                        RoomListSpawn[i].transform.Find(RoomList[i].exit + "Door").GetComponent<SpriteRenderer>().sprite = GameObject.Find("BasementDoor1").GetComponent<SpriteRenderer>().sprite;
                        RoomListSpawn[i].transform.Find(RoomList[i].exit + "Door").GetComponent<BoxCollider2D>().isTrigger = true;
                    }

                    if (RoomList[i - 1].exit == "East")
                    {
                        move = new Vector3(35, 0, 0);
                        RoomList[i].enter = "West";

                        if (RoomList[i].enter == RoomList[i].exit || positonConflict)
                        {
                            string ranDir2 = DirList[UnityEngine.Random.Range(0, DirList.Count - 1)];
                            do
                            {
                                ranDir2 = DirList[UnityEngine.Random.Range(0, DirList.Count - 1)];
                            }
                            while (RoomList[i].enter == ranDir2);
                            RoomList[i].exit = ranDir2;
                        }

                        RoomListSpawn[i].transform.Find("WestDoor").GetComponent<SpriteRenderer>().sprite = GameObject.Find("BasementDoor1").GetComponent<SpriteRenderer>().sprite;
                        RoomListSpawn[i].transform.Find("WestDoor").GetComponent<BoxCollider2D>().isTrigger = true;
                        RoomListSpawn[i].transform.Find(RoomList[i].exit + "Door").GetComponent<SpriteRenderer>().sprite = GameObject.Find("BasementDoor1").GetComponent<SpriteRenderer>().sprite;
                        RoomListSpawn[i].transform.Find(RoomList[i].exit + "Door").GetComponent<BoxCollider2D>().isTrigger = true;
                    }

                    RoomListSpawn[i].GetComponent<Transform>().position = RoomListSpawn[i - 1].GetComponent<Transform>().position + move;

                    for (int y = i-1; y < i; y++)
                    {
                        if (RoomListSpawn[i].GetComponent<Transform>().position == RoomListSpawn[y].GetComponent<Transform>().position || RoomListSpawn[i].GetComponent<Transform>().position == roomToCopy.GetComponent<Transform>().position)
                        {
                            NewLayerGeneration();
                           
                        }
                        else
                        {
                            positonConflict = false;
                        }
                    }


                }
                else
                {
                    Vector3 move = new Vector3(35, 0, 0);
                    RoomListSpawn[i].GetComponent<Transform>().position = roomToCopy.GetComponent<Transform>().position + move;
                    RoomList[i].enter = "West";

                    if (RoomList[i].enter == RoomList[i].exit)
                    {
                        string ranDir2 = DirList[UnityEngine.Random.Range(0, DirList.Count - 1)];
                        do
                        {
                            ranDir2 = DirList[UnityEngine.Random.Range(0, DirList.Count - 1)];
                        }
                        while (RoomList[i].enter == ranDir2);
                        RoomList[i].exit = ranDir2;
                    }

                    RoomListSpawn[i].transform.Find("WestDoor").GetComponent<SpriteRenderer>().sprite = GameObject.Find("BasementDoor1").GetComponent<SpriteRenderer>().sprite;
                    RoomListSpawn[i].transform.Find("WestDoor").GetComponent<BoxCollider2D>().isTrigger = true;
                    RoomListSpawn[i].transform.Find(RoomList[i].exit + "Door").GetComponent<SpriteRenderer>().sprite = GameObject.Find("BasementDoor1").GetComponent<SpriteRenderer>().sprite;
                    RoomListSpawn[i].transform.Find(RoomList[i].exit + "Door").GetComponent<BoxCollider2D>().isTrigger = true;

                }



                if (RoomList[i].type == 1)
                {
                    enemy = (GameObject)Instantiate(GameObject.Find("Spawn" + i), RoomListSpawn[i].transform.FindChild("Spawn" + i).transform, false);
                    enemy.GetComponent<Transform>().position = RoomListSpawn[i].transform.FindChild("Spawn" + i).GetComponent<Transform>().position;
                    if (!enemy.GetComponent<SpriteRenderer>())
                    {
                        enemy.AddComponent<SpriteRenderer>();
                    }
                    int randomSprite = UnityEngine.Random.Range(0, ListOfEnemySprites.Length - 1);
                    enemy.GetComponent<SpriteRenderer>().sprite = ListOfEnemySprites[randomSprite].GetComponent<SpriteRenderer>().sprite;
                    enemy.AddComponent<OnHitTrigger>();

                    enemy.tag = "EnemySpawns";
                    enemy.name = "enemy" + i;
                    enemy.GetComponent<BoxCollider2D>().isTrigger = true;
                    //  RoomListSpawn[i].transform.FindChild("SpawnLocation" + i).GetComponent<SpriteRenderer>().sprite = GameObject.Find("ENEMYtoCopy").GetComponent<SpriteRenderer>().sprite;

                }
                else
                {
                    if (RoomList[i].type == 2)
                    {
                        chest = (GameObject)Instantiate(GameObject.Find("Spawn" + i), RoomListSpawn[i].transform.FindChild("Spawn" + i).transform, true);
                        chest.GetComponent<Transform>().position = RoomListSpawn[i].transform.FindChild("Spawn" + i).GetComponent<Transform>().position;
                        chest.tag = "ItemPickUp";
                        chest.name = "itemDrop" + i;

                        chest.GetComponent<SpriteRenderer>().sprite = GameObject.Find("ItemRandomSpawn").GetComponent<SpriteRenderer>().sprite;
                        RoomListSpawn[i].transform.FindChild("Spawn" + i).GetComponent<SpriteRenderer>().sprite = GameObject.Find("ItemRandomSpawn").GetComponent<SpriteRenderer>().sprite;
                        chest.AddComponent<ItemPickUp>();
                        chest.GetComponent<ItemPickUp>().me = chest;
                        chest.GetComponent<BoxCollider2D>().isTrigger = true;

                    }
                    else
                    {
                        if(RoomList[i].type == 3)
                        {

                        }
                        else
                        {
                            if(RoomList[i].type ==4)
                            {
                                chest = (GameObject)Instantiate(GameObject.Find("Spawn" + i), RoomListSpawn[i].transform.FindChild("Spawn" + i).transform, true);
                                chest.GetComponent<Transform>().position = RoomListSpawn[i].transform.FindChild("Spawn" + i).GetComponent<Transform>().position;
                                chest.tag = "RandomTrinket";
                                chest.name = "TrinketDrop" + i;

                                chest.GetComponent<SpriteRenderer>().sprite = GameObject.Find("RandomTrinketDrop").GetComponent<SpriteRenderer>().sprite;
                                RoomListSpawn[i].transform.FindChild("Spawn" + i).GetComponent<SpriteRenderer>().sprite = chest.GetComponent<SpriteRenderer>().sprite;
                                chest.AddComponent<ItemPickUp>();
                                chest.GetComponent<ItemPickUp>().me = chest;
                                chest.GetComponent<BoxCollider2D>().isTrigger = true;
                            }
                        }
                    }
                }

                if (GameObject.Find("RoomPackage").transform.FindChild("roomSpawn" + i) == true)
                {
                    Destroy(GameObject.Find("RoomPackage").transform.FindChild("roomSpawn" + i));
                }

                List<GameObject> ProceduralGeneratedRoomsList = new List<GameObject>();
                foreach(Transform room in GameObject.Find("RoomPackageProcedural").transform )
                {
                    ProceduralGeneratedRoomsList.Add(room.gameObject);
                }

                //   foreach (GameObject child in RoomListSpawn[i].transform) if (child.CompareTag("Walls"))

                if (RoomList[RoomList.Count - 1].exit == "North")
                {
                    Vector3 move = new Vector3(0, 28, 0);

                    Quaternion rotation = new Quaternion(0, 0, -90, 0);
                    finalRoom.transform.GetComponent<Transform>().position = ProceduralGeneratedRoomsList[ProceduralGeneratedRoomsList.Count - 1].GetComponent<Transform>().position + move;
                    finalRoom.transform.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, -90);
                }
                else
                {
                    if (RoomList[RoomList.Count - 1].exit == "South") //(RoomList[RoomList.Count - 1].exit == "South")
                    {
                        Quaternion rotation = new Quaternion(0, 0, 90, 0);
                        Vector3 move = new Vector3(0, -25, 0);
                        finalRoom.transform.GetComponent<Transform>().position = ProceduralGeneratedRoomsList[ProceduralGeneratedRoomsList.Count - 1].GetComponent<Transform>().position + move;
                        finalRoom.transform.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 90);
                    }
                    else
                    {

                        if (RoomList[RoomList.Count - 1].exit == "East")
                        {
                            Quaternion rotation = new Quaternion(0, 0, 180, 0);
                            Vector3 move = new Vector3(30, 0, 0);
                            finalRoom.transform.GetComponent<Transform>().position = ProceduralGeneratedRoomsList[ProceduralGeneratedRoomsList.Count - 1].GetComponent<Transform>().position + move;
                            finalRoom.transform.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 180);
                        }
                        else
                        {
                            if (RoomList[RoomList.Count - 1].exit == "West")
                            {
                                Quaternion rotation = new Quaternion(0, 0, 180, 0);
                                Vector3 move = new Vector3(-30, 0, 0);
                                finalRoom.transform.GetComponent<Transform>().position = ProceduralGeneratedRoomsList[ProceduralGeneratedRoomsList.Count - 1].GetComponent<Transform>().position + move;
                                finalRoom.transform.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 0);
                                //  finalRoom.transform.GetComponent<Transform>().rotation = rotation;

                            }
                        }
                    }
                } //final room else end
                if (RoomList[RoomList.Count - 1] != null)
                {
                    LastRoom = RoomList[RoomList.Count - 1];
                }
            }

           

        }
        roomListSpawnCount = RoomPackageProcedural.transform.childCount;
        layer = layer + 1;
        Debug.Log("First generation " + Time.realtimeSinceStartup);
        SceneName = GameObject.Find("Player").GetComponent<BasicContolScript>().LastSceneEnter;

    }

  

    IEnumerator WaitForDestor()
    {
        yield return new WaitForSeconds(0.1f);
        readyToGo = true;

    }

    public void NewLayerGeneration()
    {
        /*    GameObject[] ClearingArray;
            ClearingArray = GameObject.FindGameObjectsWithTag("RandomSpawn");
            for (int a = 0; a < ClearingArray.Length; a++)
            {
                Destroy(ClearingArray[a]);
            } */


       

      //  System.Threading.Thread.Sleep(1000);
        //StartCoroutine(WaitForDestor());
       if (readyToGo)
        {
           
            
            readyToGo = false;
            if (RoomList.Count == 0 && RoomListSpawn.Count == 0)
            {

            }
            else
            {
                NewLayerGeneration();
            }
            finalRoom.transform.position = new Vector3(0, 0, 0);
            Scene act = SceneManager.GetActiveScene();
            SceneName = act.name;



            ListOfWalls = GameObject.FindGameObjectsWithTag("WallSprite");
            ListOfDoors = GameObject.FindGameObjectsWithTag("DoorSprite");
            ListOfFloors = GameObject.FindGameObjectsWithTag("FloorSprite");
            ListOfEnemySprites = GameObject.FindGameObjectsWithTag("EnemyPatrol");
            DirList.Add("North");
            DirList.Add("South");
            DirList.Add("West");
            DirList.Add("East");
            roomCount = UnityEngine.Random.Range(4, 11);
            freeRoomCount = roomCount;
            roomWithChestCount = UnityEngine.Random.Range(1, 3);
            roomWithEnemyCount = roomCount - roomWithChestCount;
            int ifChest = UnityEngine.Random.Range(1, 3);


            for (int i = 0; i < roomCount; i++)
            {

                string ranDir = DirList[UnityEngine.Random.Range(0, DirList.Count - 1)];
                RoomList.Add(new Room("Room" + i, ranDir, ifChest, ranDir, ranDir, ListOfWalls, ListOfFloors));
                if (RoomList[i].enter == RoomList[i].exit)
                {
                    string ranDir2 = DirList[UnityEngine.Random.Range(0, DirList.Count - 1)];
                    do
                    {
                        ranDir2 = DirList[UnityEngine.Random.Range(0, DirList.Count - 1)];
                    }
                    while (ranDir == ranDir2);
                    RoomList[i].exit = ranDir2;
                }

                ifChest = UnityEngine.Random.Range(1, 3);
            }
            /* for (int i = 0; i < roomWithEnemyCount; i++)
             {
                 string ranDir = DirList[UnityEngine.Random.Range(0, DirList.Count - 1)];
                 RoomList.Add(new Room("RoomEnemy" + i, ranDir, 1, ranDir, ranDir, ListOfWalls, ListOfDoors));
                 if (RoomList[i].enter == RoomList[i].exit)
                 {
                     string ranDir2 = DirList[UnityEngine.Random.Range(0, DirList.Count - 1)];
                     do
                     {
                         ranDir2 = DirList[UnityEngine.Random.Range(0, DirList.Count - 1)];
                     }
                     while (ranDir == ranDir2);
                     RoomList[i].exit = ranDir2;
                 }

             } */
            for (int shuffle = 1; shuffle < RoomList.Count; shuffle++)
            {
                Room temp = RoomList[shuffle];
                int RandomOrder = UnityEngine.Random.Range(shuffle, RoomList.Count);
                RoomList[shuffle] = RoomList[RandomOrder];
                RoomList[RandomOrder] = temp;
            }

            for (int i = 0; i < RoomList.Count; i++)
            {


                RoomListSpawn.Add(new GameObject("Room" + i));
                RoomListSpawn[i] = (GameObject)Instantiate(roomToCopy, RoomPackageProcedural.GetComponent<Transform>().transform, true);
                RoomListSpawn[i].transform.Find("EastDoor").GetComponent<SpriteRenderer>().sprite = GameObject.Find("BasementWallBattle2").GetComponent<SpriteRenderer>().sprite;
                RoomListSpawn[i].transform.Find("EastDoor").GetComponent<BoxCollider2D>().isTrigger = false;
                RoomListSpawn[i].name = "roomSpawn " + i;



                if (i != 0)
                {




                    Vector3 move = new Vector3(30, 0, 0);
                    if (RoomList[i - 1].exit == "South")
                    {
                        move = new Vector3(0, -20, 0);
                        RoomList[i].enter = "North";
                        if (RoomList[i].enter == RoomList[i].exit)
                        {
                            string ranDir2 = DirList[UnityEngine.Random.Range(0, DirList.Count - 1)];
                            do
                            {
                                ranDir2 = DirList[UnityEngine.Random.Range(0, DirList.Count - 1)];
                            }
                            while (RoomList[i].enter == ranDir2);
                            RoomList[i].exit = ranDir2;
                            /*    door = RoomListSpawn[i].transform.Find("NorthDoor").gameObject;
                                door.GetComponent<SpriteRenderer>().sprite = GameObject.Find("BasementDoor1").GetComponent<SpriteRenderer>().sprite;
                                door.GetComponent<BoxCollider2D>().enabled = false; */



                        }
                        RoomListSpawn[i].transform.Find("NorthDoor").GetComponent<SpriteRenderer>().sprite = GameObject.Find("BasementDoor1").GetComponent<SpriteRenderer>().sprite;
                        RoomListSpawn[i].transform.Find("NorthDoor").GetComponent<BoxCollider2D>().isTrigger = true;
                        RoomListSpawn[i].transform.Find(RoomList[i].exit + "Door").GetComponent<SpriteRenderer>().sprite = GameObject.Find("BasementDoor1").GetComponent<SpriteRenderer>().sprite;
                        RoomListSpawn[i].transform.Find(RoomList[i].exit + "Door").GetComponent<BoxCollider2D>().isTrigger = true;
                    }
                    if (RoomList[i - 1].exit == "North")
                    {
                        move = new Vector3(0, 20, 0);
                        RoomList[i].enter = "South";

                        if (RoomList[i].enter == RoomList[i].exit)
                        {
                            string ranDir2 = DirList[UnityEngine.Random.Range(0, DirList.Count - 1)];
                            do
                            {
                                ranDir2 = DirList[UnityEngine.Random.Range(0, DirList.Count - 1)];
                            }
                            while (RoomList[i].enter == ranDir2);
                            RoomList[i].exit = ranDir2;
                        }

                        RoomListSpawn[i].transform.Find("SouthDoor").GetComponent<SpriteRenderer>().sprite = GameObject.Find("BasementDoor1").GetComponent<SpriteRenderer>().sprite;
                        RoomListSpawn[i].transform.Find("SouthDoor").GetComponent<BoxCollider2D>().isTrigger = true;
                        RoomListSpawn[i].transform.Find(RoomList[i].exit + "Door").GetComponent<SpriteRenderer>().sprite = GameObject.Find("BasementDoor1").GetComponent<SpriteRenderer>().sprite;
                        RoomListSpawn[i].transform.Find(RoomList[i].exit + "Door").GetComponent<BoxCollider2D>().isTrigger = true;
                    }

                    if (RoomList[i - 1].exit == "West")
                    {
                        move = new Vector3(-35, 0, 0);
                        RoomList[i].enter = "East";

                        if (RoomList[i].enter == RoomList[i].exit)
                        {
                            string ranDir2 = DirList[UnityEngine.Random.Range(0, DirList.Count - 1)];
                            do
                            {
                                ranDir2 = DirList[UnityEngine.Random.Range(0, DirList.Count - 1)];
                            }
                            while (RoomList[i].enter == ranDir2);
                            RoomList[i].exit = ranDir2;
                        }

                        RoomListSpawn[i].transform.Find("EastDoor").GetComponent<SpriteRenderer>().sprite = GameObject.Find("BasementDoor1").GetComponent<SpriteRenderer>().sprite;
                        RoomListSpawn[i].transform.Find("EastDoor").GetComponent<BoxCollider2D>().isTrigger = true;
                        RoomListSpawn[i].transform.Find(RoomList[i].exit + "Door").GetComponent<SpriteRenderer>().sprite = GameObject.Find("BasementDoor1").GetComponent<SpriteRenderer>().sprite;
                        RoomListSpawn[i].transform.Find(RoomList[i].exit + "Door").GetComponent<BoxCollider2D>().isTrigger = true;
                    }

                    if (RoomList[i - 1].exit == "East")
                    {
                        move = new Vector3(35, 0, 0);
                        RoomList[i].enter = "West";

                        if (RoomList[i].enter == RoomList[i].exit)
                        {
                            string ranDir2 = DirList[UnityEngine.Random.Range(0, DirList.Count - 1)];
                            do
                            {
                                ranDir2 = DirList[UnityEngine.Random.Range(0, DirList.Count - 1)];
                            }
                            while (RoomList[i].enter == ranDir2);
                            RoomList[i].exit = ranDir2;
                        }

                        RoomListSpawn[i].transform.Find("WestDoor").GetComponent<SpriteRenderer>().sprite = GameObject.Find("BasementDoor1").GetComponent<SpriteRenderer>().sprite;
                        RoomListSpawn[i].transform.Find("WestDoor").GetComponent<BoxCollider2D>().isTrigger = true;
                        RoomListSpawn[i].transform.Find(RoomList[i].exit + "Door").GetComponent<SpriteRenderer>().sprite = GameObject.Find("BasementDoor1").GetComponent<SpriteRenderer>().sprite;
                        RoomListSpawn[i].transform.Find(RoomList[i].exit + "Door").GetComponent<BoxCollider2D>().isTrigger = true;
                    }

                    RoomListSpawn[i].GetComponent<Transform>().position = RoomListSpawn[i - 1].GetComponent<Transform>().position + move;

                    //     for (int y = 0; y < i; y++)
                    if (i > 0)
                    {
                        if (RoomListSpawn[i].GetComponent<Transform>().position == RoomListSpawn[i - 1].GetComponent<Transform>().position || RoomListSpawn[i].GetComponent<Transform>().position == roomToCopy.GetComponent<Transform>().position)
                        {
                            NewLayerGeneration();
                        }
                        else
                        {
                            positonConflict = false;
                        }

                    }

                }
                else
                {
                    Vector3 move = new Vector3(35, 0, 0);
                    RoomListSpawn[i].GetComponent<Transform>().position = roomToCopy.GetComponent<Transform>().position + move;
                    RoomList[i].enter = "West";

                    if (RoomList[i].enter == RoomList[i].exit)
                    {
                        string ranDir2 = DirList[UnityEngine.Random.Range(0, DirList.Count - 1)];
                        do
                        {
                            ranDir2 = DirList[UnityEngine.Random.Range(0, DirList.Count - 1)];
                        }
                        while (RoomList[i].enter == ranDir2);
                        RoomList[i].exit = ranDir2;
                    }

                    RoomListSpawn[i].transform.Find("WestDoor").GetComponent<SpriteRenderer>().sprite = GameObject.Find("BasementDoor1").GetComponent<SpriteRenderer>().sprite;
                    RoomListSpawn[i].transform.Find("WestDoor").GetComponent<BoxCollider2D>().isTrigger = true;
                    RoomListSpawn[i].transform.Find(RoomList[i].exit + "Door").GetComponent<SpriteRenderer>().sprite = GameObject.Find("BasementDoor1").GetComponent<SpriteRenderer>().sprite;
                    RoomListSpawn[i].transform.Find(RoomList[i].exit + "Door").GetComponent<BoxCollider2D>().isTrigger = true;

                }
                /*      if (RoomListSpawn[i].transform.FindChild("SpawnLocation") != null)
                      {
                          GameObject spawn = RoomListSpawn[i].transform.Find("SpawnLocation").gameObject;
                          spawn.name = "SpawnLocation" + i;
                      } */

                int randomLocationOfSpawn = UnityEngine.Random.Range(0, 4);
                GameObject spawn = null;
                switch (randomLocationOfSpawn)
                {
                    case 0:
                        spawn = RoomListSpawn[i].transform.Find("SpawnLocation").gameObject;
                        break;
                    case 1:
                        if (RoomListSpawn[i].transform.Find("SpawnLocation2").gameObject)
                        {
                            spawn = RoomListSpawn[i].transform.Find("SpawnLocation2").gameObject;
                        }
                        else
                        {
                            spawn = RoomListSpawn[i].transform.Find("SpawnLocation").gameObject;
                        }
                        break;
                    case 2:
                        if (RoomListSpawn[i].transform.Find("SpawnLocation3").gameObject)
                        {
                            spawn = RoomListSpawn[i].transform.Find("SpawnLocation3").gameObject;
                        }
                        else
                        {
                            spawn = RoomListSpawn[i].transform.Find("SpawnLocation").gameObject;
                        }
                        break;
                    case 3:
                        if (RoomListSpawn[i].transform.Find("SpawnLocation4").gameObject)
                        {
                            spawn = RoomListSpawn[i].transform.Find("SpawnLocation4").gameObject;
                        }
                        else
                        {
                            spawn = RoomListSpawn[i].transform.Find("SpawnLocation").gameObject;
                        }
                        break;
                    default:
                        spawn = RoomListSpawn[i].transform.Find("SpawnLocation").gameObject;
                        break;

                }

                spawn.name = "Spawn" + i;



                if (RoomList[i].type == 1)
                {
                    enemy = (GameObject)Instantiate(GameObject.Find("Spawn" + i), RoomListSpawn[i].transform.FindChild("Spawn" + i).transform, false);
                    enemy.GetComponent<Transform>().position = RoomListSpawn[i].transform.FindChild("Spawn" + i).GetComponent<Transform>().position;
                    if (!enemy.GetComponent<SpriteRenderer>())
                    {
                        enemy.AddComponent<SpriteRenderer>();
                    }
                    int randomSprite = UnityEngine.Random.Range(0, ListOfEnemySprites.Length - 1);
                    enemy.GetComponent<SpriteRenderer>().sprite = ListOfEnemySprites[randomSprite].GetComponent<SpriteRenderer>().sprite;
                    enemy.GetComponent<BoxCollider2D>().enabled = true;
                    enemy.AddComponent<OnHitTrigger>();
                    enemy.GetComponent<BoxCollider2D>().isTrigger = true;
                    enemy.tag = "EnemySpawns";
                    enemy.name = "enemy" + i;
                    // RoomListSpawn[i].transform.FindChild("SpawnLocation").GetComponent<BoxCollider>().enabled = false;
                    //    RoomListSpawn[i].transform.FindChild("SpawnLocation" + i).GetComponent<SpriteRenderer>().sprite = GameObject.Find("ENEMYtoCopy").GetComponent<SpriteRenderer>().sprite;

                }
                else
                {
                    if (RoomList[i].type == 2)
                    {
                        chest = (GameObject)Instantiate(GameObject.Find("Spawn" + i), RoomListSpawn[i].transform.FindChild("Spawn" + i).transform, true);
                        chest.GetComponent<Transform>().position = RoomListSpawn[i].transform.FindChild("Spawn" + i).GetComponent<Transform>().position;
                        chest.tag = "ItemPickUp";
                        chest.name = "itemDrop" + i;
                        chest.GetComponent<BoxCollider2D>().enabled = true;
                        chest.GetComponent<BoxCollider2D>().isTrigger = true;
                        chest.AddComponent<ItemPickUp>();
                        chest.GetComponent<ItemPickUp>().me = chest;
                        chest.GetComponent<SpriteRenderer>().sprite = GameObject.Find("ItemRandomSpawn").GetComponent<SpriteRenderer>().sprite;
                        RoomListSpawn[i].transform.FindChild("Spawn" + i).GetComponent<SpriteRenderer>().sprite = GameObject.Find("ItemRandomSpawn").GetComponent<SpriteRenderer>().sprite;
                        //RoomListSpawn[i].transform.FindChild("SpawnLocation").GetComponent<BoxCollider>().enabled = false;

                    }
                    else
                    {
                        if (RoomList[i].type == 3)
                        {

                        }
                        else
                        {
                            if (RoomList[i].type == 4)
                            {
                                chest = (GameObject)Instantiate(GameObject.Find("Spawn" + i), RoomListSpawn[i].transform.FindChild("Spawn" + i).transform, true);
                                chest.GetComponent<Transform>().position = RoomListSpawn[i].transform.FindChild("Spawn" + i).GetComponent<Transform>().position;
                                chest.tag = "RandomTrinket";
                                chest.name = "TrinketDrop" + i;

                                chest.GetComponent<SpriteRenderer>().sprite = GameObject.Find("RandomTrinketDrop").GetComponent<SpriteRenderer>().sprite;
                                RoomListSpawn[i].transform.FindChild("Spawn" + i).GetComponent<SpriteRenderer>().sprite = chest.GetComponent<SpriteRenderer>().sprite;
                                chest.AddComponent<ItemPickUp>();
                                chest.GetComponent<ItemPickUp>().me = chest;
                                chest.GetComponent<BoxCollider2D>().isTrigger = true;
                            }
                        }
                    }
                }

                if (GameObject.Find("RoomPackage").transform.FindChild("roomSpawn" + i) == true)
                {
                    Destroy(GameObject.Find("RoomPackage").transform.FindChild("roomSpawn" + i));
                }

                //   foreach (GameObject child in RoomListSpawn[i].transform) if (child.CompareTag("Walls"))

                /*          if (RoomList[RoomList.Count - 1].exit == "North")
                          {
                              Vector3 move = new Vector3(0, 30, 0);

                              Quaternion rotation = new Quaternion(0, 0, -90, 0);
                              finalRoom.transform.GetComponent<Transform>().position = RoomListSpawn[RoomListSpawn.Count - 1].GetComponent<Transform>().position + move;
                              finalRoom.transform.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, -90);
                          }
                          else
                          {
                              if (RoomList[RoomList.Count - 1].exit == "South") //(RoomList[RoomList.Count - 1].exit == "South")
                              {
                                  Quaternion rotation = new Quaternion(0, 0, 90, 0);
                                  Vector3 move = new Vector3(0, -30, 0);
                                  finalRoom.transform.GetComponent<Transform>().position = RoomListSpawn[RoomListSpawn.Count - 1].GetComponent<Transform>().position + move;
                                  finalRoom.transform.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 90);
                              }
                              else
                              {

                                  if (RoomList[RoomList.Count - 1].exit == "East")
                                  {
                                      Quaternion rotation = new Quaternion(0, 0, 180, 0);
                                      Vector3 move = new Vector3(35, 0, 0);
                                      finalRoom.transform.GetComponent<Transform>().position = RoomListSpawn[RoomListSpawn.Count - 1].GetComponent<Transform>().position + move;
                                      finalRoom.transform.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 180);
                                  }
                                  else
                                  {
                                      if (RoomList[RoomList.Count - 1].exit == "West")
                                      {
                                          Quaternion rotation = new Quaternion(0, 0, 180, 0);
                                          Vector3 move = new Vector3(-35, 0, 0);
                                          finalRoom.transform.GetComponent<Transform>().position = RoomListSpawn[RoomListSpawn.Count - 1].GetComponent<Transform>().position + move;
                                          //  finalRoom.transform.GetComponent<Transform>().rotation = rotation;

                                      }
                                  }
                              }
                          } */
                //final room else end

                List<GameObject> ProceduralGeneratedRoomsList = new List<GameObject>();
                foreach (Transform room in GameObject.Find("RoomPackageProcedural").transform)
                {
                    ProceduralGeneratedRoomsList.Add(room.gameObject);
                }

                //   foreach (GameObject child in RoomListSpawn[i].transform) if (child.CompareTag("Walls"))

                if (RoomList[RoomList.Count - 1].exit == "North")
                {
                    Vector3 move = new Vector3(0, 28, 0);

                    Quaternion rotation = new Quaternion(0, 0, -90, 0);
                    finalRoom.transform.GetComponent<Transform>().position = ProceduralGeneratedRoomsList[ProceduralGeneratedRoomsList.Count - 1].GetComponent<Transform>().position + move;
                    finalRoom.transform.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, -90);
                }
                else
                {
                    if (RoomList[RoomList.Count - 1].exit == "South") //(RoomList[RoomList.Count - 1].exit == "South")
                    {
                        Quaternion rotation = new Quaternion(0, 0, 90, 0);
                        Vector3 move = new Vector3(0, -25, 0);
                        finalRoom.transform.GetComponent<Transform>().position = ProceduralGeneratedRoomsList[ProceduralGeneratedRoomsList.Count - 1].GetComponent<Transform>().position + move;
                        finalRoom.transform.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 90);
                    }
                    else
                    {

                        if (RoomList[RoomList.Count - 1].exit == "East")
                        {
                            Quaternion rotation = new Quaternion(0, 0, 180, 0);
                            Vector3 move = new Vector3(33, 0, 0);
                            finalRoom.transform.GetComponent<Transform>().position = ProceduralGeneratedRoomsList[ProceduralGeneratedRoomsList.Count - 1].GetComponent<Transform>().position + move;
                            finalRoom.transform.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 180);

                        }
                        else
                        {
                            if (RoomList[RoomList.Count - 1].exit == "West")
                            {
                                Quaternion rotation = new Quaternion(0, 0, 180, 0);
                                Vector3 move = new Vector3(-33, 0, 0);
                                finalRoom.transform.GetComponent<Transform>().position = ProceduralGeneratedRoomsList[ProceduralGeneratedRoomsList.Count - 1].GetComponent<Transform>().position + move;
                                finalRoom.transform.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 0);
                                //  finalRoom.transform.GetComponent<Transform>().rotation = rotation;

                            }
                        }
                    }
                } //final room else end

                if (RoomList[RoomList.Count - 1] != null)
                {
                    LastRoom = RoomList[RoomList.Count - 1];
                }

                for (int z = 0; z < RoomListSpawn.Count; z++)
                {
                    if (finalRoom.GetComponent<Transform>().position == RoomListSpawn[z].GetComponent<Transform>().position)
                    {
                        NewLayerGeneration();

                    }
                }

            }

            if (layer == deep)
            {
                GameObject.Find("FinalRoomExit").GetComponent<SpriteRenderer>().sprite = GameObject.Find("RatHauntedBoss").GetComponent<SpriteRenderer>().sprite;
                GameObject.Find("FinalRoomExit").tag = "EnemySpawns_special";
                GameObject.Find("FinalRoomExit").name = "FinalBoss_poolBasement";
            }
            roomCount = RoomList.Count;
            //roomListSpawnCount = RoomListSpawn.Count;
            roomListSpawnCount = RoomPackageProcedural.transform.childCount;

            Debug.Log("Regenerated " + Time.realtimeSinceStartup);
            if (roomCount != roomListSpawnCount)
            {
                roomListSpawnCount = roomCount;
               
            }
            else
            {


                // 
            }

        }
        
    }


    public void LayerChange()
    {
          layer = layer + 1;
        if (layer == deep)
        {

            GameObject.Find("FinalRoomExit").GetComponent<SpriteRenderer>().sprite = GameObject.Find("RatHauntedBoss").GetComponent<SpriteRenderer>().sprite;
            GameObject.Find("FinalRoomExit").tag = "EnemySpawns_special";
            GameObject.Find("FinalRoomExit").name = "FinalBoss_poolBasement";
            GameObject.Find("StatsCarrier").GetComponent<MapSpawnControl>().hitObjectList.Clear();
            // GameObject.Find("FinalRoomExit").GetComponent<BoxCollider2D>().enabled = false;
        }
        
    }

    public void ClearingFunction()
    {
        for (int i = 0; i < RoomListSpawn.Count; i++)
        {
            Destroy(RoomListSpawn[i]);
        }

        for (int i_2 = 0; i_2 < RoomList.Count; i_2++)
        {
            Destroy(GameObject.Find("Room" + i_2));
        }
        RoomList.Clear();
        RoomListSpawn.Clear();
        //readyToGo = false;

        //waitForDestor();
        foreach (Transform child in RoomPackageProcedural.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        if (RoomPackageProcedural.transform.childCount == 0)
        {
            readyToGo = true;
        }
      
            StartCoroutine(WaitForClear());
      

    }
    public IEnumerator WaitForClear()
    {
        yield return new WaitForSeconds(1f);
        clearingDone = true;
        readyToGo = true;
        NewLayerGeneration();
    }

    private void HandleException(string condition, string stackTrace, LogType type)
    {
        if (type == LogType.Error)
        {
            Application.Quit();
            throw new Exception("Error during generating, please restart game");
            
        }
    }

}
