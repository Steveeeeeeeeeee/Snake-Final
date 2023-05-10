using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public TMP_Text playerText;

    public static int firstLevel = 1;
    public static int levelPlayed = 1;
    public static int selectedPlayer;
    // Start is called before the first frame update

   public void Start()
    {
       
    }
    
    public void PlayLevel1()
    {
        SceneManager.LoadScene("Level1");
        levelPlayed = 1;
    }
    public void PlayLevel2()
    {
        SceneManager.LoadScene("Level2");
        levelPlayed = 2;
    }
    public void PlayLevel3()
    {
        SceneManager.LoadScene("Level3");
        levelPlayed = 3;
    }
    public void PlayLevel4()
    {
        SceneManager.LoadScene("Level4");
        levelPlayed = 4;

    }
    public void PlayLevel5()
    {
        SceneManager.LoadScene("Level5");
        levelPlayed = 5;
    }
    public void setPlayer(int playerNumber)
    {
        //depending on which player button is pressed load the corresponding player
        selectedPlayer = playerNumber;
        


    }

    






    public void LoadMainMenu()
    {

        SceneManager.LoadScene("MainMenu");
        DataPersistenceManager.Instance.SaveGame();
    }

    public void LoadPlayerScreen()
    {

        SceneManager.LoadScene("PlayerScene");
    }





    public void QuitGame()
    {
        Application.Quit();
    }

    
}
