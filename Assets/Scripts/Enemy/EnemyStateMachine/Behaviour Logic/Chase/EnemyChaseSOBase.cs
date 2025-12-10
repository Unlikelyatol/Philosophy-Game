using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseSOBase : ScriptableObject
{
    // The Base Class For All Sciptable objects In the Chase State
    // Any Defaults needed across the different Chase Logic are set here

    // acts like private to other classes but acts like public to any classes that derive from this script
    protected Enemy enemy;
    protected Transform transform;
    protected GameObject gameObject;
    protected GameObject player;

    protected Transform playerTransform;
    protected Animator Enemyanimator;

    public virtual void Initalize(GameObject gameObject, Enemy enemy)
    {
        this.enemy = enemy;
        this.gameObject = gameObject;
        transform = gameObject.transform;
        Enemyanimator = gameObject.GetComponent<Animator>();
        //player = GameObject.FindGameObjectWithTag("Player");
        //playerTransform = player.transform;
    }
    // Trigger for the animations
    public virtual void DoEnterLogic() { 
        //Enemyanimator.SetBool("Chase", true); 
    }
    public virtual void DoExitLogic() { 
        //Enemyanimator.SetBool("Chase", false); 
    }
    public virtual void DoFrameUpdateLogic()
    {
        if (enemy.IsAttackable)
        {
            enemy.StateMachine.ChangeState(enemy.attackState);
        }
    }
    public virtual void DoPhysicsUpdateLogic() { }
    public virtual void DoAnimationTriggerEventLogic(Enemy.AnimationTriggerType type) { }
    public virtual void ResetValues() { }
}
