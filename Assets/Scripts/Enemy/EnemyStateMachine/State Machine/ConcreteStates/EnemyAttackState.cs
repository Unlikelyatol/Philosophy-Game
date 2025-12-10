public class EnemyAttackState : EnemyState
{
    // The Base State For The Enemy Attack State
    // Derives from EnemyState

    // Constructor For the Enemy Attack State Base
    public EnemyAttackState(Enemy _enemy, EnemyStateMachine _enemyStateMachine) : base(_enemy, _enemyStateMachine)
    {
    }

    public override void AnimationTriggerEvent(Enemy.AnimationTriggerType triggertype)
    {
        base.AnimationTriggerEvent(triggertype);
        enemy.EnemyAttackBaseInstance.DoAnimationTriggerEventLogic(triggertype);
    }

    public override void EnterState()
    {
        // Call EnterState From Base Script
        base.EnterState();
        // Gets the Instance from the enemy Class And Runs the Code Attached to The SO In DoEnterLogic
        enemy.EnemyAttackBaseInstance.DoEnterLogic();

    }

    public override void ExitState()
    {
        base.ExitState();
        enemy.EnemyAttackBaseInstance.DoExitLogic();

    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        enemy.EnemyAttackBaseInstance.DoFrameUpdateLogic();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        enemy.EnemyAttackBaseInstance.DoPhysicsUpdateLogic();
    }
}
