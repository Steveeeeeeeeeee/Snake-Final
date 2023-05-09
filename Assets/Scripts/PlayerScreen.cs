using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerScreen : MonoBehaviour, IDataPersistence

{


    public TMP_Text playerText;

    public GameObject[] Levels;

    public static int selectedPlayer;
    
    // Start is called before the first frame update
    void Awake()
    {
        selectedPlayer = MainMenu.selectedPlayer;
        Debug.Log("Max level: " + WinScreen.SaveMax);       
        UpdateText();
        ActivatedLevels();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


   public void UpdateText()   
    {
        playerText.text = "Player " + selectedPlayer;
    }

    public void ActivatedLevels(){
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
    }

    public void SaveData(ref GameData data)
    {
        data.MaxLevel = WinScreen.SaveMax;
    }
}
