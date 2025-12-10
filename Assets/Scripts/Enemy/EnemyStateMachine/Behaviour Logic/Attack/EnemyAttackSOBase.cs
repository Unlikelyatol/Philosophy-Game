using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackSOBase : ScriptableObject
{
    // The Base Class For All Sciptable objects In the attack State
    // Any Defaults needed across the different Attack Logic are set here

    // acts like private to other classes but acts like public to any classes that derive from this script
    protected Enemy enemy;
    protected Transform transform;
    protected GameObject gameObject;
    protected GameObject player;

    protected Transform playerTransform;
    protected Animator Enemyanimator;

    public virtual void Initalize(GameObject gameObject, Enemy enemy)
    {
        //Assigns the variables and sets defaults
        this.enemy = enemy;
        this.gameObject = gameObject;
        Enemyanimator = gameObject.GetComponent<Animator>();
        transform = gameObject.transform;
        //player = GameObject.FindGameObjectWithTag("Player");
        //playerTransform = player.transform;
    }
    public virtual void DoEnterLogic() {
        // Trigger for the animations
    }
    public virtual void DoExitLogic() {
    }
    public virtual void DoFrameUpdateLogic()
    {
        // Change to Death State If Player Or Enemy Dies
        if (enemy.IsDead)
        {
            enemy.StateMachine.ChangeState(enemy.deathState);
        }
    }
    public virtual void DoPhysicsUpdateLogic() { }
    public virtual void DoAnimationTriggerEventLogic(Enemy.AnimationTriggerType type) { }
    public virtual void ResetValues() { }
}
