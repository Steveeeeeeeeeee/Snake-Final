using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeSprites : MonoBehaviour
{
    public GameObject segment;
    public List <GameObject> segments;
    
     public Sprite[] spriteArray;


    public SnakeSprites(List<GameObject> segments){
        this.segments = segments;        
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

   
}
