using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInvoker
{
    // Start is called before the first frame update
    Stack<ICommand> _commandList;

    public MoveInvoker()
    {
        _commandList = new Stack<ICommand>();   
    }

    public void addCommand(ICommand command)
    {
        command.Execute();
        _commandList.Push(command);
    }
}
 

