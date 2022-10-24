using UnityEngine;

public class ChaseState : BaseState
{
    private bool _canSeePlayer;
    private bool _isPlayerInAttackRange;
    private float _chasingTime;
    private Vector3 reachPoint;

    public ChaseState(BaseEnemy enemy, StateMachine stateMachine) : base(enemy, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Enemy.SetSpeed(Enemy.RunSpeed);//mb no need
        _canSeePlayer = false;
        _chasingTime = 10.0f;
        //activate walk anim
    }

    public override void Exit()
    {
        base.Exit();

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (_chasingTime <= 0.0f)
        {
            StateMachine.ChangeState(Enemy.PatrolState);
        }
        else
        {
            if (_canSeePlayer)
            {
                if (_isPlayerInAttackRange)
                {
                    StateMachine.ChangeState(Enemy.AttackState);
                }
                else
                {
                    //run to the player
                    reachPoint = Enemy.GetPlayerPosition();
                    Enemy.Chase(reachPoint);
                }
            }
            else
            {
                //run to the last player point
                reachPoint = Enemy.GetPlayerLastPosition();
                Enemy.Chase(reachPoint);
            }
        }

        _chasingTime -= Time.deltaTime;
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        _canSeePlayer = Enemy.FOV.GetVisionResponse();
        _isPlayerInAttackRange = Enemy.FOV.GetAttackResponce();
    }
}
