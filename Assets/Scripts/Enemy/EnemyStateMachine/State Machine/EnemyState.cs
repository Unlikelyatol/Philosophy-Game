
public class EnemyState
{
    // EnemyState acts as a base/ default Class/State For all other States
    // All States within The FSM Derive from this Script

    // acts like private to other classes but acts like public to any classes that derive from this script
    protected Enemy enemy;
    protected EnemyStateMachine enemyStateMachine;
    public EnemyState(Enemy _enemy, EnemyStateMachine _enemyStateMachine)
    {
        enemy = _enemy;
        enemyStateMachine = _enemyStateMachine;
    }
    // can be overriden in a state later on but we are not forced to call the method
    public virtual void EnterState()
    {

    }
    public virtual void ExitState() { }
    public virtual void FrameUpdate() { }

    public virtual void PhysicsUpdate() { }
    public virtual void AnimationTriggerEvent(Enemy.AnimationTriggerType triggertype) { }

}
