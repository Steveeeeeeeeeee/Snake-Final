using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCommand : ICommand
    
{
    Vector3 _previousPosition; 
    private Player snake;



    public MovementCommand(Player snake) {
        this.snake = snake;
       
         _previousPosition = snake.transform.position;
         
    }       

    

    public void Execute(){
        float x = snake.transform.position.x + snake.direction.x;
        float y = snake.transform.position.y + snake.direction.y;
        snake.transform.position = new Vector2(x, y);  
        
    }

    public void Undo(){
        
        snake.transform.position = _previousPosition;
       
    }
}
