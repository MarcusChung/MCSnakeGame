using UnityEngine;

public class MoveCommand : Command
{
    private Vector2 direction;
    private Transform rotation;
    private Vector2 gridPos;
    private Vector2 prevGridPos;
    private Vector2 prevDirection;

    private int snakeSegments;
    private int prevSnakeSegments;
    public MoveCommand(IEntity entity, Vector2 direction, Transform rotation, Vector2 gridPos, int snakeSegments) : base(entity)
    {
        this.direction = direction;
        this.rotation = rotation;
        this.gridPos = gridPos;
        this.snakeSegments = snakeSegments;
    }
    public override void Execute()
    {
        prevDirection = entity.GetDirection();
        entity.SetDirection(direction);
        prevGridPos = gridPos;
        gridPos += direction;
        entity.transform.position = gridPos;
        rotation = entity.transform;
        prevSnakeSegments = entity.prevSnakeSegments();
    }
    public override void Undo()
    {
        gridPos = prevGridPos;
        entity.transform.position = gridPos;
        entity.transform.rotation = rotation.rotation;
        entity.SetDirection(prevDirection);
        // if(snakeSegments > prevSnakeSegments)
        // {
        //     // Debug.Log("Shrinking snake");
        //     entity.RemoveSegment();
        // }
    }
}



