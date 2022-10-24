using UnityEngine;
public class AttackState : BaseState
{
    protected bool IsPlayerInAttackRange;

    public AttackState(BaseEnemy enemy, StateMachine stateMachine) : base(enemy, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        IsPlayerInAttackRange = Enemy.FOV.GetAttackResponce();
    }
}
