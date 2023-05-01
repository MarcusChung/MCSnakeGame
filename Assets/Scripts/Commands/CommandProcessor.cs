using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandProcessor : MonoBehaviour 
{
    private Stack<Command> _commands = new Stack<Command>();

    private Snake snake;

    public void ExecuteCommand(MoveCommand command)
    {
        _commands.Push(command);
        command.Execute();

    }

    public void UndoCommand()
    {
        if (_commands.Count > 0)
        {
            var command = _commands.Pop();
            command.Undo();
        }
    }
}
