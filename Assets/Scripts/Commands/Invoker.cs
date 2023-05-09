using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invoker
{
    // Start is called before the first frame update
    Stack<ICommand> _commandList;

    public Invoker()
    {
        _commandList = new Stack<ICommand>();   
    }

    public void addCommand(ICommand command)
    {
        command.Execute();
        //Debug.Log(command + " was executed" );
        _commandList.Push(command);
    }

    public void undoCommand()
    {
        if (_commandList.Count > 0)
        {
            ICommand LatestCommand = _commandList.Pop();
            LatestCommand.Undo();
            Debug.Log(LatestCommand + " was undone");  
        }
    }
}
 

