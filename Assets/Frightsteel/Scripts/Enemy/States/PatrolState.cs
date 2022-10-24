using UnityEngine;

public class PatrolState : BaseState
{
    private bool _canSeePlayer;
    private float _patrollingTime;
    private bool _isPatrolling;

    public PatrolState(BaseEnemy enemy, StateMachine stateMachine) : base(enemy, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Enemy.SetSpeed(Enemy.WalkSpeed);//mb no need
        _canSeePlayer = false;
        _isPatrolling = false;
        _patrollingTime = 20.0f;
        //activate walk anim
    }

    public override void Exit()
    {
        base.Exit();

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        
        if (_patrollingTime <= 0f)
        {
            StateMachine.ChangeState(Enemy.ChillState);
        }
        else
        {
            if (_canSeePlayer)
            {
                StateMachine.ChangeState(Enemy.ChaseState);
            }
            else
            {
                if (!_isPatrolling)
                {
                    _isPatrolling = true;
                    Enemy.Patrol();
                }
            }
        }

        _patrollingTime -= Time.deltaTime;
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        _canSeePlayer = Enemy.FOV.GetVisionResponse();
    }
}
