using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Vector2 direction = Vector2.right;
   
    MoveInvoker _moveInvoker;
    void Start()
    {
        
        _moveInvoker = new MoveInvoker();       
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
        _moveInvoker.addCommand(new MovementCommand(this));   
    }
    void getUserInput() {
        if (Input.GetKeyDown(KeyCode.D) && direction != Vector2.left)
        {
             ICommand StoredCommand = new MoveDCommand(this);
            _moveInvoker.addCommand(StoredCommand);
        }
        if (Input.GetKeyDown(KeyCode.A) && direction != Vector2.right)
        {
              ICommand StoredCommand = new MoveACommand(this);
            _moveInvoker.addCommand(StoredCommand);
        }
        if (Input.GetKeyDown(KeyCode.W) && direction != Vector2.down)
        {
          ICommand StoredCommand = new MoveWCommand(this);
            _moveInvoker.addCommand(StoredCommand); 
        
        }
        if (Input.GetKeyDown(KeyCode.S) && direction != Vector2.up)
        {
              ICommand StoredCommand = new MoveSCommand(this);
            _moveInvoker.addCommand(StoredCommand);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
           
            _moveInvoker.undoCommand();
            _moveInvoker.undoCommand();
            _moveInvoker.undoCommand();
        }   
    }


   
  
}
