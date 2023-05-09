using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{

    public bool isPaused = false;

     public Player Player;

    
     

   public void Setup()
    {
        gameObject.SetActive(true);
        isPaused = true;
       
    }

    public void Shutdown(){
        gameObject.SetActive(false);
        isPaused = false;
    }

    public void RestartButton(){
        ;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenuButton(){
        SceneManager.LoadScene("MainMenu");
    }

    public void RewindButton(){
        Player.Rewind(); 
        
    }
   
}
