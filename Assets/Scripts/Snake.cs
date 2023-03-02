using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Snake : MonoBehaviour
{

    [SerializeField]
    public Tilemap GroundTilemap; 
    [SerializeField]
    public Tilemap WallTilemap;     
    
    private Vector2 gridMoveDirection;
    private Vector2 gridPosition;
    private float gridMoveTimer;
    private float gridMoveTimerMax; 

    // Start is called before the first frame update
    void Start()
    {
        gridMoveTimerMax = 0.2f;
        gridMoveTimer = gridMoveTimerMax;
        gridMoveDirection = Vector2.right;
        gridPosition = new Vector2(0,0);
        
    }

    // Update is called once per frame
    void Update()
    {
      HandleMovement(); 
      HandleGridMovement();
         
        
    }

    private void HandleMovement(){
         if (Input.GetKeyDown(KeyCode.W))
        {
            if (gridMoveDirection.y != -1)
            {
                gridMoveDirection = Vector2.up;
            }
        }   
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (gridMoveDirection.y != 1)
            {
                gridMoveDirection = Vector2.down;
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (gridMoveDirection.x != 1)
            {
                gridMoveDirection = Vector2.left;
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (gridMoveDirection.x != -1)
            {
                gridMoveDirection = Vector2.right;
            }   
        }
    }

    private void HandleGridMovement()
    {
       gridMoveTimer += Time.deltaTime;
       if (gridMoveTimer >=gridMoveTimerMax){
            gridPosition +=gridMoveDirection;
            gridMoveTimer -= gridMoveTimerMax;
       }
       //transform player so that they only occupy one
       transform.position = new Vector3(gridPosition.x, gridPosition.y );

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Walls")
        {
            Time.timeScale = 0;
            Debug.Log("Game Over");
        }
    }   
  
}
