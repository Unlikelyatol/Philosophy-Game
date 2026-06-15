using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable, IEnemyMovable, ITriggerCheckable
{
    // This is My Enemy Class, It acts as a Base Class for all scripts got to do with enemy
    // This Class contains methods and variables used in other Classes made for enemy
    // The Enemy Is Controlled by a finite state machine, This Class also inializes the Instances of those scripts
    // Any number of scripts for new enemies can be made Deriving properties from this Class.
    [field: SerializeField] public float MaxHealth { get; set; } = 100f;
    [SerializeField] float DespawnTime = 2f;
    public Animator Animator;

    // Defining variables Recieved from the Interfaces 
    public bool Damaged { get; set; }
    public float CurrentHealth { get; set; }
    public Rigidbody2D Rb { get; set; }
    // 1 is up -1 is down 2 is right -2 is down (can change later)
    public int DirectionFacing { get; set; } = -1;
    public bool IsAggressive { get; set; }
    public bool IsAttackable { get; set; }
    public bool IsDead { get; set; }
    #region State Machine Variables
    // Variables of all the different states enemy can have
    public EnemyStateMachine StateMachine { get; set; }
    public EnemyIdleState idleState { get; set; }
    public EnemyChaseState chaseState { get; set; }
    public EnemyAttackState attackState { get; set; }
    public EnemyDeathState deathState { get; set; }
    // Can add as many states as needed

    #endregion
    #region ScriptableObject Variables
    // These Are serialized so you can set different state Behaviours to the states
    // These are Scriptable Objects Created in another Script
    [SerializeField] private EnemyIdleSOBase EnemyIdleBase;
    [SerializeField] private EnemyChaseSOBase EnemyChaseBase;
    [SerializeField] private EnemyAttackSOBase EnemyAttackBase;
    [SerializeField] private EnemyDeathSOBase EnemyDeathBase;
    // Creating an instance of those SOs
    public EnemyIdleSOBase EnemyIdleBaseInstance { get; set; }
    public EnemyChaseSOBase EnemyChaseBaseInstance { get; set; }
    public EnemyAttackSOBase EnemyAttackBaseInstance { get; set; }
    public EnemyDeathSOBase EnemyDeathBaseInstance { get; set ; }
    #endregion

    private void Awake()
    {
        // Instantiate doesnt Create a literal Clone Here, Rather Sets A new Instance of the Scripts (technically it does)
        EnemyIdleBaseInstance = Instantiate(EnemyIdleBase);
        EnemyChaseBaseInstance = Instantiate(EnemyChaseBase);
        EnemyAttackBaseInstance = Instantiate(EnemyAttackBase);
        EnemyDeathBaseInstance = Instantiate(EnemyDeathBase);

        // Creates a new state machine for this Enemy
        StateMachine = new EnemyStateMachine();

        // Creates new states for this enemy
        idleState = new EnemyIdleState(this,StateMachine);
        chaseState = new EnemyChaseState(this, StateMachine);
        attackState = new EnemyAttackState(this,StateMachine);
        deathState = new EnemyDeathState(this,StateMachine);

    }
    private void Start()
    {
        CurrentHealth = MaxHealth;
        Rb = GetComponent<Rigidbody2D>();

        // Passes in paramaters to the the states
        EnemyIdleBaseInstance.Initalize(gameObject, this);
        EnemyChaseBaseInstance.Initalize(gameObject, this);
        EnemyAttackBaseInstance.Initalize(gameObject, this);
        EnemyDeathBaseInstance.Initalize(gameObject, this);

        // Starts The State machine in the idle State
        StateMachine.Initialize(idleState);
    }
    private void Update()
    {
        /*
        FrameUpdate Is called every Update (serves as an alternate update function
        for the state machines)
        */
        StateMachine.currentEnemyState.FrameUpdate();
    }
    private void FixedUpdate()
    {
        // Physics Update is Called every FixedUpdate
        StateMachine.currentEnemyState.PhysicsUpdate();
    }
    #region Health Functions
    // These are the defualt Health Functions for the enemy
    // They Include Enemy Death and Damage
    public void SetDeadStatus(bool isDead)
    {
        IsDead = isDead;
    }
    /*
    public void Damage(float damageAmount)
    {
        // From the IDamageable interface Calls the Damage Function
        // All things that are damageable use the the IDamageable Interface
        Damaged = true;
        Animator.SetTrigger("Hurt");
        CurrentHealth -= damageAmount;
        AudioManager.Instance.PlaySFX("Hit");
        if (CurrentHealth <= 0)
        {
            Die();
        }
    }
    */
    public void Damage(float damage)
    {

    }
    /*
    private IEnumerator StartDecay(float despawn)
    {
        // This is the timer for the body to despawn
        yield return new WaitForSeconds(despawn);
        Destroy(gameObject);
    }
    */
    private IEnumerator StartDecay(float delay)
    {
        yield return new WaitForSeconds(delay);
    }
    /*
    public void Die()
    {
        Animator.SetBool("Dead", true);
        SetDeadStatus(true);
        GetComponent<Rigidbody2D>().gravityScale = 0;
        GetComponent<CapsuleCollider2D>().enabled = false;
        StartCoroutine(StartDecay(DespawnTime));
        ScoreManager.Instance.IncrementScore();
    }
    */
    public void Die()
    {

    }
    #endregion
    #region Distance Checks
    public void SetAggressiveStatus(bool isAggressive)
    {
        // Variables Used by the state machine
        IsAggressive = isAggressive;
    }

    public void SetAttackableStatus(bool isAttackable)
    {
        IsAttackable = isAttackable;
    }
    #endregion
    #region Move Functions
    // All Base Enemy Movements types
    // Any new types of Movements Can be added here to be Called from States
    public void EnemyMovement(Vector3 PlayerPosition, float MovementSpeed)
    {

    }

    /*
     * old code that ive yet to implement
     
    public void EnemyMovement(Vector3 PlayerPosition, float MovementSpeed)
    {
        Vector3 newPos = transform.position;
        newPos.x = Mathf.MoveTowards(transform.position.x, PlayerPosition.x, MovementSpeed * Time.deltaTime);
        transform.position = newPos;
        Flip(PlayerPosition);
    }
    */
    public void Flip(Vector3 PlayerPos)
    {

    }
    /*
     * Old Code that i have yet to implement
     
    public void Flip(Vector3 PlayerPosition)
    {
        Vector2 direction = PlayerPosition - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Vector3 Scale = new Vector3(1f, 1f, 1f);
        if (angle > 90 || angle < -90)
        {
            Scale.x *= -1;
            IsFacingRight = !IsFacingRight;
        }
        else
        {
            Scale.x *= 1;
        }
        transform.localScale = Scale;
    }
    */
    #endregion
    #region Animation Triggers
    // These Can be called during animations to be used in states
    private void AnimationTriggerEvent(AnimationTriggerType type)
    {
        StateMachine.currentEnemyState.AnimationTriggerEvent(type);
    }
    // list of Possible types of triggers in the animation
    // Can Add new Trigger Types here
    public enum AnimationTriggerType{

        AttackPlayer,
        PlayFootstepSound,
        ShootPlayer,
        }
    #endregion
}
