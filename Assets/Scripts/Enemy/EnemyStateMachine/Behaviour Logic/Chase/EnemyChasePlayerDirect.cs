using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Creates an Asset for the Scriptable Object in the inspector menu
[CreateAssetMenu(fileName = "Chase Direct", menuName = "Enemy Logic/Chase Logic/Chase Direct")]
public class EnemyChasePlayerDirect : EnemyChaseSOBase
{
    [SerializeField]private float _MovementSpeed = 1.75f;
    public override void DoAnimationTriggerEventLogic(Enemy.AnimationTriggerType type)
    {
        base.DoAnimationTriggerEventLogic(type);
    }

    public override void DoEnterLogic()
    {
        base.DoEnterLogic();
    }

    public override void DoExitLogic()
    {
        base.DoExitLogic();
    }

    public override void DoFrameUpdateLogic()
    {
        // Moves towards the players transform (chases them)
        base.DoFrameUpdateLogic();
        enemy.EnemyMovement(playerTransform.position, _MovementSpeed);
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
}
