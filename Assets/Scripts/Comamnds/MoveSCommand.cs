using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSCommand : ICommand
{

    private Player snake;

    public MoveSCommand(Player snake) {
        
        this.snake = snake;
        
    }
 
    // Start is called before the first frame update
    public void Execute()
    {
        snake.direction = Vector2.down;
        snake.transform.rotation = Quaternion.Euler(0, 0, 180);
      
    }
}
