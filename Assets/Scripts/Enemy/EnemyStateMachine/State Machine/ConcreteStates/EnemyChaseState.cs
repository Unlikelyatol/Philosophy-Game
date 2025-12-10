public class EnemyChaseState : EnemyState
{
    // The Base State For The Enemy Chase State
    // Derives from EnemyState

    // Constructor For the Enemy Chase State Base
    public EnemyChaseState(Enemy _enemy, EnemyStateMachine _enemyStateMachine) : base(_enemy, _enemyStateMachine)
    {
    }

    public override void AnimationTriggerEvent(Enemy.AnimationTriggerType triggertype)
    {
        base.AnimationTriggerEvent(triggertype);
        enemy.EnemyChaseBaseInstance.DoAnimationTriggerEventLogic(triggertype);
    }

    public override void EnterState()
    {
        // Call EnterState From Base Script
        base.EnterState();
        // Gets the Instance from the enemy Class And Runs the Code Attached to The SO In DoEnterLogic
        enemy.EnemyChaseBaseInstance.DoEnterLogic();
    }

    public override void ExitState()
    {
        base.ExitState();
        enemy.EnemyChaseBaseInstance.DoExitLogic();

    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        enemy.EnemyChaseBaseInstance.DoFrameUpdateLogic();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        enemy.EnemyChaseBaseInstance.DoPhysicsUpdateLogic();
    }
}
