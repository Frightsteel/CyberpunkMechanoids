using UnityEngine;
public class AttackStateSniper : AttackState
{
    private bool _isPlayerInEscapeRange;

    private Sniper _sniper;

    public AttackStateSniper(BaseEnemy enemy, StateMachine stateMachine) : base(enemy, stateMachine)
    {
        _sniper = Enemy as Sniper;
    }

    public override void Enter()
    {
        base.Enter();
        //stop nav agent;
        _sniper.StopMovement();
    }

    public override void Exit()
    {
        base.Exit();

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (_isPlayerInEscapeRange)
        {
            StateMachine.ChangeState(_sniper.EscapeState);
        }
        else if (IsPlayerInAttackRange)
        {
            if (_sniper.WeaponReloadCooldown.IsCooldowned)
            {
                _sniper.Attack();
            }   
        }
        else
        {
            StateMachine.ChangeState(_sniper.ChaseState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        _isPlayerInEscapeRange = _sniper.FOV.GetEscapeResponse();
    }
}
