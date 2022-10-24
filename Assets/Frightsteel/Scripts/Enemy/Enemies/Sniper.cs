using UnityEngine;
using UnityEngine.AI;

public class Sniper : BaseEnemy
{
    public FOVSniper FOV;

    public float EscapeRange;

    protected override void Init()
    {
        base.Init();

        EscapeState = new EscapeState(this, StateMachine);
        AttackState = new AttackStateSniper(this, StateMachine);
    }

    protected override void Awake()
    {
        base.Awake();

        FOV = GetComponent<FOVSniper>();
    }

    public override void Attack()
    {
        base.Attack();
        //shoot
        //use anim
        Debug.Log("Pew-Pew");
    }

    public void Escape()
    {
        //get a random point and run to
        //change speed?
        Vector3 moveDir = GetPlayerPosition() - transform.position;
        moveDir = new Vector3(-moveDir.x, moveDir.y, -moveDir.z);
        MoveTo(moveDir);
    }
}
