public class EnemyIdleState : EnemyState
{
    // The Base State For The Enemy Idle State
    // Derives from EnemyState

    // Constructor For the Enemy Idle State Base
    public EnemyIdleState(Enemy _enemy, EnemyStateMachine _enemyStateMachine) : base(_enemy, _enemyStateMachine)
    {
    }

    public override void AnimationTriggerEvent(Enemy.AnimationTriggerType triggertype)
    {
        base.AnimationTriggerEvent(triggertype);
        enemy.EnemyIdleBaseInstance.DoAnimationTriggerEventLogic(triggertype);
    }

    public override void EnterState()
    {
        // Call EnterState From Base Script
        base.EnterState();
        // Gets the Instance from the enemy Class And Runs the Code Attached to The SO In DoEnterLogic
        enemy.EnemyIdleBaseInstance.DoEnterLogic();
    }

    public override void ExitState()
    {
        base.ExitState();
        enemy.EnemyIdleBaseInstance.DoExitLogic();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        enemy.EnemyIdleBaseInstance.DoFrameUpdateLogic();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        enemy.EnemyIdleBaseInstance.DoPhysicsUpdateLogic();
    }
}
