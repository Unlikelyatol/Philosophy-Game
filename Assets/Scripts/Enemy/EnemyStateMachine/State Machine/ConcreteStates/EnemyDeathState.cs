public class EnemyDeathState : EnemyState
{
    // The Base State For The Enemy Death State
    // Derives from EnemyState

    // Constructor For the Enemy Death State Base
    public EnemyDeathState(Enemy _enemy, EnemyStateMachine _enemyStateMachine) : base(_enemy, _enemyStateMachine)
    {
    }

    public override void AnimationTriggerEvent(Enemy.AnimationTriggerType triggertype)
    {
        base.AnimationTriggerEvent(triggertype);
        enemy.EnemyDeathBaseInstance.DoAnimationTriggerEventLogic(triggertype);
    }

    public override void EnterState()
    {
        // Call EnterState From Base Script
        base.EnterState();
        // Gets the Instance from the enemy Class And Runs the Code Attached to The SO In DoEnterLogic
        enemy.EnemyDeathBaseInstance.DoEnterLogic();
    }

    public override void ExitState()
    {
        base.ExitState();
        enemy.EnemyDeathBaseInstance.DoExitLogic();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        enemy.EnemyDeathBaseInstance.DoFrameUpdateLogic();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        enemy.EnemyDeathBaseInstance.DoPhysicsUpdateLogic();
    }
}
