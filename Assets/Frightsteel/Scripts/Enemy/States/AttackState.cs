using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseEnemyState
{
    private bool _isPlayerInAttackRange;

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
        if (_isPlayerInAttackRange)
        {
            //attack
        }
        else
        {
            StateMachine.ChangeState(Enemy.ChaseState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

    }
}
