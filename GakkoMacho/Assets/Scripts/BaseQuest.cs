using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest   {

    public string name;
    public string mainDesc;
    public string objectiveDesc;
    public int questID;
    public bool isCompleted;


    public Quest (string newName, string newMainDesc ,string newObjectiveDesc, int newQuestId , bool newIsCompteted)
    {
        name = newName;
        mainDesc = newMainDesc;
        objectiveDesc = newObjectiveDesc;
        questID = newQuestId;
        isCompleted = newIsCompteted;
    }




}
