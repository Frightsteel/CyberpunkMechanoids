using UnityEngine;

public class Sniper : BaseEnemy
{
    public float RunOffRange;
    protected override void Attack()
    {
        float distance = Vector3.Distance(transform.position, PlayerTarget.transform.position);

        if (distance <= RunOffRange)
        {
            RunOff();
        }
        else if (distance <= RangeAttackRange)
        {
            RangeAttack();
        }
    }

    private void RunOff()
    {
        //get a random point and run to
    }

    private void RangeAttack()
    {
        //shoot
        //use anim
    }
}
