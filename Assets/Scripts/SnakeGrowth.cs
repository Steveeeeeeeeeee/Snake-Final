using System.Collections;
using System.Collections.Generic;
using UnityEngine;

  

public class SnakeGrowth : MonoBehaviour

    
{
    Invoker _Invoker;

    public GameObject segment;
    
    public List <GameObject> segments = new List<GameObject>();

    public Sprite[] spriteArray; 

    public Vector2 LastPos;

    public int growFlag = 0;   

    public int score = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
        resetSegments();
        _Invoker = new Invoker();  
        LastPos = segments[segments.Count -1].transform.position + Vector3.left;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        changeSprite();
        
    }

    void FixedUpdate()
    {
        moveSegments();
        grow();
       
    }



     public void resetSegments(){
        for (int i = 1; i < segments.Count; i++)
        {
            Destroy(segments[i].gameObject);
        }
        segments.Clear();
        segments.Add(gameObject);  

        for (int i = 0; i < 3; i++)
        {
          growFlag += 1;
        
        }

    }

    

    public void grow(){
        if (growFlag > 0)
        {
            GameObject newSegment = Instantiate(segment);
            newSegment.transform.position = LastPos;
            segments.Add(newSegment);
            score += 1;
            growFlag -= 1;
        }
    }  
    
      private void moveSegments(){
       _Invoker.addCommand(new TailCommand(this)); 
         
         
    }

    public void Rewind(){
           
            _Invoker.undoCommand();
            _Invoker.undoCommand();
            _Invoker.undoCommand();
         
    }
     public void changeSprite(){
        
        for (int i = 1; i < segments.Count -1; i++)
        {
            Vector2 nextPieceDirection = segments[i+1].transform.position - segments[i].transform.position;
            Vector2 prevPieceDirection = segments[i-1].transform.position - segments[i].transform.position;
            
         if (prevPieceDirection == Vector2.left && nextPieceDirection == Vector2.right)
           {
            segments[i].GetComponent<SpriteRenderer>().sprite = spriteArray[2];
            segments[i].transform.rotation = Quaternion.Euler(0, 0, 0);
          
           }
         else if (prevPieceDirection == Vector2.right && nextPieceDirection == Vector2.left)
           {
            segments[i].GetComponent<SpriteRenderer>().sprite = spriteArray[2];
            segments[i].transform.rotation = Quaternion.Euler(0, 0, 180);
       
           }
           else if (prevPieceDirection == Vector2.up && nextPieceDirection == Vector2.down)
           {
            segments[i].GetComponent<SpriteRenderer>().sprite = spriteArray[2];
            segments[i].transform.rotation = Quaternion.Euler(0, 0, 90);
            
           }
            else if (prevPieceDirection == Vector2.down && nextPieceDirection == Vector2.up)
           {
            segments[i].GetComponent<SpriteRenderer>().sprite = spriteArray[2];
            segments[i].transform.rotation = Quaternion.Euler(0, 0, -90);
          
           }
            else if ((prevPieceDirection == Vector2.left && nextPieceDirection == Vector2.up) || (prevPieceDirection == Vector2.up && nextPieceDirection == Vector2.left))
           {
            segments[i].GetComponent<SpriteRenderer>().sprite = spriteArray[1];
            segments[i].transform.rotation = Quaternion.Euler(0, 0, 0);
            
           }
            else if ((prevPieceDirection == Vector2.left && nextPieceDirection == Vector2.down) || (prevPieceDirection == Vector2.down && nextPieceDirection == Vector2.left))
           {
            segments[i].GetComponent<SpriteRenderer>().sprite = spriteArray[1];
            segments[i].transform.rotation = Quaternion.Euler(0, 0, 90);
            
           }
            else if ((prevPieceDirection == Vector2.right && nextPieceDirection == Vector2.up) || (prevPieceDirection == Vector2.up && nextPieceDirection == Vector2.right))
           {
            segments[i].GetComponent<SpriteRenderer>().sprite = spriteArray[1];
            segments[i].transform.rotation = Quaternion.Euler(0, 0, -90);
            
           }
            else if ((prevPieceDirection == Vector2.right && nextPieceDirection == Vector2.down) || (prevPieceDirection == Vector2.down && nextPieceDirection == Vector2.right))
           {
            segments[i].GetComponent<SpriteRenderer>().sprite = spriteArray[1];
            segments[i].transform.rotation = Quaternion.Euler(0, 0, 180);
            
           }

        }
        if(segments.Count > 1){
        segments[segments.Count - 1].GetComponent<SpriteRenderer>().sprite = spriteArray[0];    
        Vector2 previousPieceDirection = segments[segments.Count -2].transform.position - segments[segments.Count -1].transform.position;
        if (previousPieceDirection  == Vector2.up){
            segments[segments.Count - 1].transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        else if (previousPieceDirection  == Vector2.down){
            segments[segments.Count - 1].transform.rotation = Quaternion.Euler(0, 0, -90);
        }
        else if (previousPieceDirection  == Vector2.right){
            segments[segments.Count - 1].transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (previousPieceDirection  == Vector2.left){
            segments[segments.Count - 1].transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        }

    }

    
}
