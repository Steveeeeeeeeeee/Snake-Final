using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Vector2 direction = Vector2.right;
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
        Time.timeScale = 0.1f;
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
             ICommand StoredCommand = new MoveDCommand(this);
            StoredCommand.Execute();
        }
        if (Input.GetKey(KeyCode.A) && direction != Vector2.right)
        {
              ICommand StoredCommand = new MoveACommand(this);
            StoredCommand.Execute();
        }
        if (Input.GetKey(KeyCode.W) && direction != Vector2.down)
        {
          ICommand StoredCommand = new MoveWCommand(this);
            StoredCommand.Execute();
        
        }
        if (Input.GetKey(KeyCode.S) && direction != Vector2.up)
        {
              ICommand StoredCommand = new MoveSCommand(this);
            StoredCommand.Execute();
        }
    }


   
  
}
