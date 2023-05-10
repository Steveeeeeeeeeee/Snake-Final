using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{

    public TMP_Text pointsText;
    public static int SaveMax = 1;


  
    public void Setup(int score)
    {

        Debug.Log("Save Max: " + SaveMax); 
        gameObject.SetActive(true);
        pointsText.text = "Score: " + score.ToString();

        if (MainMenu.levelPlayed == SaveMax)
        {

            MainMenu.levelPlayed = SaveMax + 1;

            SaveMax += 1;
            
            
            
        }
        
        DataPersistenceManager.Instance.SaveGame();

    }

    public void NextLevelButton()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    

    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("PlayerScene");
        DataPersistenceManager.Instance.SaveGame();
    }

 

}
