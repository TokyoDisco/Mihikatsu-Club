using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Room  {

    public string name;
    public string direction;
    public int type;
    public string enter;
    public string exit;
    public GameObject[] walls;
    public GameObject[] floors;
    public GameObject enterPoint;
    public GameObject exitPoints;
	
	
	public Room (string newName, string newDirection, int newType, string enterDir, string exitDir, GameObject[] newWalls,GameObject[] newFloors)
    {
        name = newName;
        direction = newDirection;
        type = newType;
        enter = enterDir;
        exit = exitDir;
        walls = newWalls;
        floors = newFloors;
    }
}
