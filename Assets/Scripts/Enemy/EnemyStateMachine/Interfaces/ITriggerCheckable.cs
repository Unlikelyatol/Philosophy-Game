public interface ITriggerCheckable
{
    // Methods/Variables to be used by Enemies that need Triggers
    bool IsAggressive { get; set; }
    bool IsAttackable { get; set; }
    bool IsDead { get; set; }

    void SetAggressiveStatus(bool isAggressive);
    void SetAttackableStatus (bool isAttackable);
    void SetDeadStatus (bool isDead);

}
