using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            Time.timeScale = 0;
            Debug.Log("Game Over");
        }
        if (collision.gameObject.tag == "Food")
        {
           GetComponent<SnakeGrowth>().grow();  
        }
        if (collision.gameObject.tag == "Obstacle")
        {
            Time.timeScale = 0;
            Debug.Log("Game Over");
          
        }
    
    }  
}
