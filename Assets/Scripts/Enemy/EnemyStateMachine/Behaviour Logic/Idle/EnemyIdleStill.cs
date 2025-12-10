using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Almost exactly the same as the Enemy default death state with a different file name
[CreateAssetMenu(fileName = "Idle Still", menuName = "Enemy Logic/Idle Logic/Stand Still")]
public class EnemyIdleStill : EnemyIdleSOBase
{
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
        base.DoFrameUpdateLogic();
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
