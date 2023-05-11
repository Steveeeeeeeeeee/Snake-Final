using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]

public class GameData
{
    public int MaxLevel;
    

    public SerializableDictionary<string, bool> achievements;      

    


    public GameData()
    {
        this.MaxLevel = 1;
        achievements = new SerializableDictionary<string, bool>();  
    }
}
