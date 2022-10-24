using UnityEngine;

public class Spider : BaseEnemy
{
    [Header("Spider")]
    public int MaxCharges = 3;
    public float ChargesCooldown = 5f;
    
    private int _charges;
    private float _timer;

    public override void Attack()
    {
        base.Attack();

        float distance = Vector3.Distance(transform.position, PlayerTarget.transform.position);

        if (_charges > 0 && distance <= RangeAttackRange)
        {
            RangeAttack();
        }
        else if (distance <= MeleeAttackRange)
        {
            MeleeAttack();
        }
    }

    private void MeleeAttack()
    {
        //go to the player and hit
        //use anim
    }

    private void RangeAttack()
    {
        //shoot
        //use anim
    }

    //private void Start()
    //{
    //    _timer = ChargesCooldown;
    //}

    //private void Update()
    //{
    //    if (_charges < MaxCharges)
    //    {
    //        _timer -= Time.deltaTime;
    //        if (_timer <= 0f)
    //        {
    //            _charges++;
    //        }
    //    }
    //}
}
