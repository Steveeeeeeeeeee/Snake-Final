using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScreen : MonoBehaviour, IDataPersistence

{


    public TMP_Text playerText;

    public GameObject[] Levels;





    public static int selectedPlayer;

    // Start is called before the first frame update

    void Start()
    {
        ActivatedLevels();
    }
    void Awake()
    {
        selectedPlayer = MainMenu.selectedPlayer;
        Debug.Log("Player " + selectedPlayer + " selected");
        Debug.Log("Max level: " + WinScreen.SaveMax);
        UpdateText();





    }

    // Update is called once per frame
    void Update()
    {

    }


    public void UpdateText()
    {
        playerText.text = "Player " + selectedPlayer;
    }

    public void ActivatedLevels()
    {
        // activates levels based on the maxLevel reached
        for (int i = 0; i < Levels.Length; i++)
        {
            if (i < WinScreen.SaveMax)
            {
                Levels[i].SetActive(true);
            }
            else
            {
                Levels[i].SetActive(false);
            }
        }
    }

    public void LoadData(GameData data)
    {

        WinScreen.SaveMax = data.MaxLevel;


        Debug.Log("Max level: " + WinScreen.SaveMax + "OR" + data.MaxLevel);
    }

    public void SaveData(ref GameData data)
    {

        data.MaxLevel = WinScreen.SaveMax;

        AchievementsService achievementsService = FindAnyObjectByType<AchievementsService>();

        if(achievementsService)
        {
            Debug.Log("Found achievements service");
        }

        if (ScoreManager.Instance.score >= ScoreManager.Instance.GetWinScore(SceneManager.GetActiveScene().name))
        {
            if (data.achievements.ContainsKey(SceneManager.GetActiveScene().name))
            {
                data.achievements.Remove(SceneManager.GetActiveScene().name);
            }
            data.achievements.Add(SceneManager.GetActiveScene().name, true);

            if (data.achievements.ContainsKey(SceneManager.GetActiveScene().name + Collisions.blueEaten))
            {
                data.achievements.Remove(SceneManager.GetActiveScene().name + Collisions.blueEaten);
            }
            data.achievements.Add(SceneManager.GetActiveScene().name + Collisions.blueEaten, true);
        }


    }
}
