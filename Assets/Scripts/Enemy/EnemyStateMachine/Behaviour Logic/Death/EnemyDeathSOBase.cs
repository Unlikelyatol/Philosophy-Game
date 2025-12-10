using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyDeathSOBase : ScriptableObject
{
    protected Enemy enemy;
    protected Transform transform;
    protected GameObject gameObject;

    //protected Transform playerTransform;

    public virtual void Initalize(GameObject gameObject, Enemy enemy)
    {
        this.enemy = enemy;
        this.gameObject = gameObject;
        transform = gameObject.transform;
        //playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }
    public virtual void DoEnterLogic() { }
    public virtual void DoExitLogic() { }
    public virtual void DoFrameUpdateLogic()
    {
        // Death doesnt need to do anything by default so nothing will be put here
    }
    public virtual void DoPhysicsUpdateLogic() { }
    public virtual void DoAnimationTriggerEventLogic(Enemy.AnimationTriggerType type) { }
    public virtual void ResetValues() { }
}
