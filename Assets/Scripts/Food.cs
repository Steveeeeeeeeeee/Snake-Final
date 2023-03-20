using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        randomPosition();
    }

    void randomPosition()
    {
        float x = Random.Range(-12, 12);
        float y = Random.Range(-4, 4);
        y += 0.5f;
        x += 0.5f;
        transform.position = new Vector2(x, y);
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {   
        if (other.gameObject.tag == "Player")
        {
            randomPosition();
        }
        
    }
}
