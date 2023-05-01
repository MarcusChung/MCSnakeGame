using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEntity
{
    Transform transform { get; }
    void SetDirection(Vector2 direction);
    Vector2 GetDirection();

    void RemoveSegment();

    int prevSnakeSegments();
}
