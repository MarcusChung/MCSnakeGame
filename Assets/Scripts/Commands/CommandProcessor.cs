using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandProcessor : MonoBehaviour 
{
    private Stack<Command> _commands = new Stack<Command>();
    // private int _currentCommandIndex = -1;

    public void ExecuteCommand(MoveCommand command)
    {
        _commands.Push(command);
        command.Execute();
        // _currentCommandIndex = _commands.Count - 1;
    }

    public void UndoCommand()
    {
        if (_commands.Count > 0)
        {
            var command = _commands.Pop();
            command.Undo();
        }

        // if (_currentCommandIndex < 0) return;

        // _commands[_currentCommandIndex].Undo();
        // Debug.Log("Undoing command " + _currentCommandIndex);
        // _commands.RemoveAt(_currentCommandIndex);
        // _currentCommandIndex--;
        
    }
}