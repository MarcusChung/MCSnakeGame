using UnityEngine;

public class MoveCommand : Command
{
    private Vector2 direction;
    private Transform rotation;
    private Vector2 gridPos;
    public MoveCommand(IEntity entity, Vector2 direction, Transform rotation,Vector2 gridPos) : base(entity)
    {
        this.direction = direction;
        this.rotation = rotation;
        this.gridPos = gridPos;
    }

    public override void Execute()
    {
        // Debug.Log("Executing command");
        // Debug.Log("Direction: " + direction + " Rotation: " + rotation.rotation + " GridPos: " + gridPos);
        // entity.transform.Translate(direction);
        // entity.transform.rotation = rotation.rotation;
         // direction = Vector2.up;
        // transform.rotation = Quaternion.Euler (0, 0, 0);
    }

    public override void Undo()
    {
       Debug.Log("Undoing command");
    //    entity.transform.Translate(direction);
       entity.transform.rotation = rotation.rotation;
       entity.transform.position = gridPos;
    }
}