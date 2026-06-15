using UnityEngine;

public interface IEnemyMovable
{
    // Methods/Variables To be used by Movable Enemies
    Rigidbody2D Rb { get; set; }
    int DirectionFacing {  get; set; }
    void EnemyMovement(Vector3 PlayerPosition, float MovementSpeed);
    void Flip(Vector3 PlayerPosition);
}
