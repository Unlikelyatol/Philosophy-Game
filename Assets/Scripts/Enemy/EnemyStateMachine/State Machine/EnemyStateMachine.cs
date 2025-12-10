public class EnemyStateMachine
{
    // This Enemy State Machine Class Contains the Methods for Controlling the state machine
    // Just like the arrows in a State Machine Diagram
    public EnemyState currentEnemyState { get; set; }
    public void Initialize(EnemyState StartingEnemyState)
    {
        //Start of the State machine
        currentEnemyState = StartingEnemyState;
        currentEnemyState.EnterState();
    }
    public void ChangeState(EnemyState newState)
    {
        currentEnemyState.ExitState();
        currentEnemyState = newState;
        currentEnemyState.EnterState();
    }
}
