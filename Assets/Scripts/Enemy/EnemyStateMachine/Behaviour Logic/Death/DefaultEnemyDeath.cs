using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Default Death", menuName = "Enemy Logic/Death Logic/Default Death")]
public class DefaultEnemyDeath : EnemyDeathSOBase
{
    // Basically defaults
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
