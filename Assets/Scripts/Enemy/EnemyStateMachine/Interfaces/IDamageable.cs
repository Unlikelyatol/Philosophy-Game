public interface IDamageable
{
    // Methods and variables to be used by Damageable objects
    public void Damage(float damageAmount);
    void Die();
    public bool Damaged { get; set; }
    float MaxHealth {  get; set; }
    float CurrentHealth {  get; set; }
}
