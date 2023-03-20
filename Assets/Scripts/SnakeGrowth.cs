using System.Collections;
using System.Collections.Generic;
using UnityEngine;

  

public class SnakeGrowth : MonoBehaviour

    
{
    MoveInvoker _moveInvoker;

    public GameObject segment;
    public List <GameObject> segments = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        resetSegments();
        _moveInvoker = new MoveInvoker();  
        
    }

    // Update is called once per frame
    void Update()
    {
        getUserInput();
    }

    void FixedUpdate()
    {
        moveSegments();
       
    }



     void resetSegments(){
        for (int i = 1; i < segments.Count; i++)
        {
            Destroy(segments[i].gameObject);
        }
        segments.Clear();
        segments.Add(gameObject);  

        for (int i = 0; i < 3; i++)
        {
          grow();
        }

    }

    

    public void grow(){
        

        GameObject newSegment = Instantiate(segment);
        newSegment.transform.position = segments[segments.Count - 1].transform.position;
        segments.Add(newSegment);
    }  
    
      private void moveSegments(){
       _moveInvoker.addCommand(new TailCommand(this)); 
         
         
    }

    private void getUserInput(){

        if (Input.GetKeyDown(KeyCode.Z))
         {
           
             _moveInvoker.undoCommand();
         }
    }
}
