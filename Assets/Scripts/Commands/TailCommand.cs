using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailCommand : ICommand
{

    List <GameObject> segments;

    List <GameObject> _previousSegments;
    private SnakeGrowth tail;   
    private Vector3 last;

    public TailCommand(SnakeGrowth tail)
    {
        this.tail = tail;
        segments = tail.segments;
        _previousSegments = tail.segments;
        last = segments[segments.Count - 1].transform.position;
    }
    // Start is called before the first frame update
    public void Execute()
    {
         for (int i = segments.Count - 1; i > 0; i--)
        {
            segments[i].transform.position = segments[i - 1].transform.position;
        }
    }

    public void Undo()
    {
      for (int i = 0; i < segments.Count -1; i++)
      {
        segments[i].transform.position = segments[i + 1].transform.position;

      }
      segments[segments.Count -1 ].transform.position = last;

    }   

}
