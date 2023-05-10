using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{

     public TMP_Text pointsText;
     

   public void Setup(int score)
    {
        gameObject.SetActive(true);
        pointsText.text = "Score: " + score.ToString();
       
    }

    public void RestartButton(){
        ;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenuButton(){
        SceneManager.LoadScene("PlayerScene");

        DataPersistenceManager.Instance.SaveGame();
    }

   
}
