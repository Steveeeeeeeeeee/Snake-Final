using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockerAPI : MonoBehaviour, IAchievements
{
    private void Awake()
    {
        if(FindObjectsOfType<UnlockerAPI>().Length > 1)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void UnlockAchievement(string achievementName)
    {
        Debug.Log("Unlocking achievement: " + achievementName);
        
    }
}