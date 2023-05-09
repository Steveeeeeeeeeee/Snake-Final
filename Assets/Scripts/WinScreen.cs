using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{

    public TMP_Text pointsText;
    private static int Max = 1;
    public static int SaveMax = 1;


  
    public void Setup(int score)
    {


        gameObject.SetActive(true);
        pointsText.text = "Score: " + score.ToString();

        if (MainMenu.levelPlayed == Max)
        {

            MainMenu.levelPlayed += 1;

            Max += 1;
            
            
            
        }
        SaveMax = Max;
        DataPersistenceManager.Instance.SaveGame();

    }

    public void NextLevelButton()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    

    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("PlayerScene");
    }

 

}
