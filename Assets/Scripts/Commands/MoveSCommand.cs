using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSCommand : ICommand
{

    private Player snake;

    
    Vector2 _previousDirection;
    Quaternion _previousRotation;

    public MoveSCommand(Player snake) {
        
        this.snake = snake;
       
        _previousDirection = snake.direction;
        _previousRotation = snake.transform.rotation;
    }
 
    // Start is called before the first frame update
    public void Execute()
    {
        snake.direction = Vector2.down;
        snake.transform.rotation = Quaternion.Euler(0, 0, -90);
      
    }

    public void Undo()
    {
        
        snake.direction = _previousDirection;
        snake.transform.rotation = _previousRotation;
    }   
}
