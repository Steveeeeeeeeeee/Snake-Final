using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collisions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
      
    }
     void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Walls")
        {
            GameController.Instance.GameOver();
        }
        if (collision.gameObject.tag == "Food")
        {
           GetComponent<SnakeGrowth>().growFlag += 1; 
           ScoreManager.Instance.UpdateScore(1); 
           if(ScoreManager.Instance.score >= ScoreManager.Instance.GetWinScore(SceneManager.GetActiveScene().name)){
                GameController.Instance.Win();
           }
        }
        if (collision.gameObject.tag == "Obstacle")
        {
            Time.timeScale = 0;
            GameController.Instance.GameOver();
            // Debug.Log("Game Over");
           
          
        }
         if (collision.gameObject.tag == "BlueFood") {
            GetComponent<SnakeGrowth>().growFlag += 1; 
            ScoreManager.Instance.UpdateScore(2); 
             if(ScoreManager.Instance.score >= ScoreManager.Instance.GetWinScore(SceneManager.GetActiveScene().name)){
                GameController.Instance.Win();
           }
        }
    
    }  
}
