using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Vector2 direction = Vector2.right;
    public float speed = 1f;
    bool canChangeDirection = true;

    float directionChangeCooldown = 0.2f;
    Invoker _Invoker;
    void Start()
    {

        
        _Invoker = new Invoker();
        reset();


    }

    public void reset()
    {
        transform.position = new Vector2(1.5f, 1.5f);
        transform.rotation = Quaternion.Euler(0, 0, 0);
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
        EnableDirectionChange();
        Time.timeScale  = speed * 0.1f;

    }

    void moveSnake()
    {
        _Invoker.addCommand(new MovementCommand(this));
    }
    void getUserInput()
    {
        if (Input.GetKeyDown(KeyCode.D) && direction != Vector2.left)
        {
            if (canChangeDirection)
            {
                ICommand StoredCommand = new MoveDCommand(this);
                _Invoker.addCommand(StoredCommand);
                direction = Vector2.right;
                canChangeDirection = false;
                Invoke("EnableDirectionChange", directionChangeCooldown);
            }
        }
        if (Input.GetKeyDown(KeyCode.A) && direction != Vector2.right)
        {
            if (canChangeDirection)
            {
                ICommand StoredCommand = new MoveACommand(this);
                _Invoker.addCommand(StoredCommand);
                direction = Vector2.left;
                canChangeDirection = false;
                Invoke("EnableDirectionChange", directionChangeCooldown);
            }
        }
        if (Input.GetKeyDown(KeyCode.W) && direction != Vector2.down)
        {
            if (canChangeDirection)
            {
                ICommand StoredCommand = new MoveWCommand(this);
                _Invoker.addCommand(StoredCommand);
                direction = Vector2.up;
                canChangeDirection = false;
                Invoke("EnableDirectionChange", directionChangeCooldown);
            }
        }
        if (Input.GetKeyDown(KeyCode.S) && direction != Vector2.up)
        {
            if (canChangeDirection)
            {
                ICommand StoredCommand = new MoveSCommand(this);
                _Invoker.addCommand(StoredCommand);
                direction = Vector2.down;
                canChangeDirection = false;
                Invoke("EnableDirectionChange", directionChangeCooldown);
            }
        }
       
       
    }

    void EnableDirectionChange()
    {
        canChangeDirection = true;
    }

    public void Rewind(){
        _Invoker.undoCommand();
            _Invoker.undoCommand();
            _Invoker.undoCommand();
            GetComponent<SnakeGrowth>().Rewind();
    }

}
