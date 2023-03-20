using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWCommand : ICommand
{

    private Player snake;

    public MoveWCommand(Player snake) {
        
        this.snake = snake;
        
    }
 
    // Start is called before the first frame update
    public void Execute()
    {
        snake.direction = Vector2.up;
        snake.transform.rotation = Quaternion.Euler(0, 0, 0);
      
    }
}
