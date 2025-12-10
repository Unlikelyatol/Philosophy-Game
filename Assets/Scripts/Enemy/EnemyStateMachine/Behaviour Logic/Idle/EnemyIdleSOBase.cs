using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleSOBase : ScriptableObject
{
    protected Enemy enemy;
    protected Transform transform;
    protected GameObject gameObject;
   // protected GameObject player;


    //protected Transform playerTransform;

    public virtual void Initalize(GameObject gameObject, Enemy enemy)
    {
        this.enemy = enemy;
        this.gameObject = gameObject;
        transform = gameObject.transform;
    }
    public virtual void DoEnterLogic(){ }
    public virtual void DoExitLogic() { }
    public virtual void DoFrameUpdateLogic()
    {
        // if statements makes it always is in the right state
        
        if (enemy.IsAttackable)
        {
            enemy.StateMachine.ChangeState(enemy.attackState);
        }
        else if (enemy.IsAggressive)
        {
            enemy.StateMachine.ChangeState(enemy.chaseState);
        }
    }
    public virtual void DoPhysicsUpdateLogic() { }    
    public virtual void DoAnimationTriggerEventLogic(Enemy.AnimationTriggerType type) { }
    public virtual void ResetValues() { }
}
