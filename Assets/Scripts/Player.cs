using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    Vector2 direction = Vector2.right;
    // Start is called before the first frame update
    

    // Start is called before the first frame update
    void Start()
    {
        
        reset();
        
    }

    void reset() {
        transform.position = new Vector2(0.5f, 0.5f);
        transform.rotation = Quaternion.Euler(0, 0, -90);
        direction = Vector2.right;
        Time.timeScale = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
      getUserInput();
   
        
    }

    void FixedUpdate() 
    {
     moveSnake();
        
    }

    void moveSnake() {
        float x = transform.position.x + direction.x;
        float y = transform.position.y + direction.y;
        transform.position = new Vector2(x, y);     
    }
    void getUserInput() {
        if (Input.GetKey(KeyCode.D) && direction != Vector2.left)
        {
            direction = Vector2.right;
            transform.rotation = Quaternion.Euler(0, 0, -90);
        }
        if (Input.GetKey(KeyCode.A) && direction != Vector2.right)
        {
            direction = Vector2.left;
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        if (Input.GetKey(KeyCode.W) && direction != Vector2.down)
        {
            direction = Vector2.up;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    
        if (Input.GetKey(KeyCode.S) && direction != Vector2.up)
        {
            direction = Vector2.down;
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }
    }


   
  
}
