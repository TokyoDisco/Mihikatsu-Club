using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
    public class Trinket
    {
        public string name; //name of trinket
        public string desc; //description of trinket
        public int type; // 0 - passive , 1 - active
        public bool unique; // false - no element restrication , true - element
        public string element;
        public string owner;
        public int id;

        public Trinket(string newName, string newDesc, int newType, bool newUnique, string newElement, string newOwner, int newId)
        {
            name = newName;
            desc = newDesc;
            type = newType;
            unique = newUnique;
            if (unique)
            {
                element = newElement;
            }
            else
            {
                element = "None";
            }
            owner = newOwner;
            id = newId;
        }

    }

