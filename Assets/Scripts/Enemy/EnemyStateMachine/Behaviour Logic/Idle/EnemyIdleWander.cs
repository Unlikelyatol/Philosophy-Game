using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Idle Wander", menuName = "Enemy Logic/Idle Logic/Wander")]
public class EnemyIdleWander : EnemyIdleSOBase
{
    [SerializeField] private float RandomMovementRange = 5f;
    [SerializeField] private float RandomMovementSpeed = 1f;
    [SerializeField] LayerMask GroundChecker;

    private Vector3 _targetPos;
    private Vector3 _GroundUnderTarget;
    private float _Distance;
    public override void DoAnimationTriggerEventLogic(Enemy.AnimationTriggerType type)
    {
        base.DoAnimationTriggerEventLogic(type);
    }

    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
        //Makes sure there is always a target position at the start of the state
        //_targetPos = GetRandomPointInRectangle();
    }

    public override void DoExitLogic()
    {
        base.DoExitLogic();
    }

    public override void DoFrameUpdateLogic()
    {
        base.DoFrameUpdateLogic();
        /*
        enemy.EnemyMovement(_targetPos, RandomMovementSpeed);
        // Distance between the current enemy position and the random point
        _Distance = System.MathF.Abs(enemy.transform.position.x - _targetPos.x);
        // We find the ground under target to make sure the target position isnt in air
        _GroundUnderTarget = _targetPos - new Vector3(0, 1, 0);
        // If the enemy gets close to the target position or theres no ground under the target
        if (_Distance < 0.01f || !Physics2D.OverlapCircle(_GroundUnderTarget, 0.3f, GroundChecker))
        {
            //get new point
            _targetPos = GetRandomPointInRectangle();
        }
        */
    }

    public override void DoPhysicsUpdateLogic()
    {
        base.DoPhysicsUpdateLogic();
    }

    public override void Initalize(GameObject gameObject, Enemy enemy)
    {
        base.Initalize(gameObject, enemy);
    }

    public override void ResetValues()
    {
        base.ResetValues();
    }
    /*
    private Vector3 GetRandomPointInRectangle()
    {
        // returns a postion with a random X Value within a set range
        return enemy.transform.position + new Vector3(UnityEngine.Random.Range(-RandomMovementRange, RandomMovementRange),0,0);
    }
    */
}
