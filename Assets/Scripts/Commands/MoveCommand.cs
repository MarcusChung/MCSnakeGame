using UnityEngine;

public class MoveCommand : Command
{
    private Vector2 direction;
    private Transform rotation;
    public MoveCommand(IEntity entity, Vector2 direction, Transform rotation) : base(entity)
    {
        this.direction = direction;
        this.rotation = rotation;
    }
    
    public override void Execute()
    {
        Debug.Log("Executing command");
       
        // entity.transform.Translate(direction);
        // entity.transform.rotation = rotation.rotation;
         // direction = Vector2.up;
        // transform.rotation = Quaternion.Euler (0, 0, 0);
    }

    public override void Undo()
    {
       Debug.Log("Undoing command");
        // entity.transform.Translate(direction);
        // entity.transform.rotation = rotation.rotation;
    }
}