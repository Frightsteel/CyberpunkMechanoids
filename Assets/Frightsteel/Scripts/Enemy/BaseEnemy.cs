using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour, IDamageable
{
    public float _health;
    //protected float _armor;
    public float _damage;
    public float _speed;

    public Rigidbody _rigidbody;
    public Collider _collider;

    public BaseEnemy()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
    }

    protected abstract void MovementPattern();
    protected abstract void AttackPattern();

    public void TakeDamage(float damage)
    {
        _health -= damage;
    }
}
