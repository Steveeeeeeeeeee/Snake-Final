using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementsService : MonoBehaviour
{

    private IAchievements achievements;

    private void Awake()
    {
        achievements = GetComponent<IAchievements>();
    }

    public void UnlockAchievement(string achievementName)
    {
        achievements.UnlockAchievement(achievementName);
    }
  
}
