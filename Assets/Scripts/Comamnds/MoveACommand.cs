using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveACommand : ICommand
{

    private Player snake;

    public MoveACommand(Player snake) {
        
        this.snake = snake;
        
    }
 
    // Start is called before the first frame update
    public void Execute()
    {
        snake.direction = Vector2.left;
        snake.transform.rotation = Quaternion.Euler(0, 0, 90);
      
    }
}
