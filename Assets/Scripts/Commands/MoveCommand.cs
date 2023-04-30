using UnityEngine;

public class MoveCommand : Command
{
    private Vector2 direction;
    private Transform rotation;
    private Vector2 gridPos;
    private Vector2 prevGridPos;
    private Vector2 prevDirection;
    public MoveCommand(IEntity entity, Vector2 direction, Transform rotation, Vector2 gridPos) : base(entity)
    {
        this.direction = direction;
        this.rotation = rotation;
        this.gridPos = gridPos;
    }
    public override void Execute()
    {
        Debug.Log("Executing command: Rotation = " + rotation.rotation);
        // entity.transform.Translate(direction);
        prevDirection = entity.GetDirection();
        entity.SetDirection(direction);

        prevGridPos = gridPos;
        gridPos += direction;
        entity.transform.position = gridPos;
        rotation = entity.transform;
    }
    public override void Undo()
    {
        Debug.Log("Undoing command");
        // entity.transform.Translate(-direction);
        gridPos = prevGridPos;
        entity.transform.position = gridPos;
        entity.transform.rotation = rotation.rotation;
    }
}



