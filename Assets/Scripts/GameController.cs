using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public static GameController Instance;
    public GameOverScreen GameOverScreen;

    public WinScreen WinScreen;

    public PauseScreen PauseScreen;


    void Awake() {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        getUserInput();
    }

    public void GameOver(){
        Time.timeScale = 0;
        GameOverScreen.Setup(ScoreManager.Instance.score);
    }


    public void Win(){
        Time.timeScale = 0;

        WinScreen.Setup(ScoreManager.Instance.score);
    }

    public void OpenPauseScreen(){
        Time.timeScale = 0;

        PauseScreen.Setup();
    }

    public void ClosePauseScreen(){
        Time.timeScale = 0.1f;
        PauseScreen.Shutdown();


    }

    public void getUserInput(){
          if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(!PauseScreen.isPaused){
            OpenPauseScreen();
            }
            else {
                ClosePauseScreen();
            }
        }
    }
    
}
