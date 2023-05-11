using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager Instance;    
    public TMP_Text scoreText;

    public int score = 0;

    private void Awake () {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + score.ToString() + " / " + GetWinScore(SceneManager.GetActiveScene().name);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score.ToString() + " / " + GetWinScore(SceneManager.GetActiveScene().name);
    }

    public void ResetScore()
    {
        score = 0;
        scoreText.text = "Score: " + score;
    }

    public int GetWinScore(string level){
        int winScore = 0;
    

        switch (level){
        
            case "Level1":
                winScore = 1;
                break;
            case "Level2":
                winScore = 1;
                break;
            case "Level3":
                winScore = 1;
                break;    
            case "Level4":
                winScore = 20;
                break;
            case "Level5":
                winScore = 30;
                break;
            default:
            Debug.LogError("Invalid Level");
            break;
    }
    return winScore;
    }
}
