public class ChillState : BaseEnemyState
{
    private bool _canSeePlayer;
    
    public ChillState(BaseEnemy enemy, StateMachine stateMachine) : base(enemy, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Enemy.SetSpeed(Enemy.WalkSpeed);
        Enemy.Agent.autoBraking = false;
        _canSeePlayer = false;
        //activate idle anim
    }

    public override void Exit()
    {
        base.Exit();
        Enemy.Agent.autoBraking = true;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (_canSeePlayer)
        {
            StateMachine.ChangeState(Enemy.PatrolState);
        }
        if (!Enemy.Agent.pathPending && Enemy.Agent.remainingDistance < 0.5f)
        {
            Enemy.Chill();
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        _canSeePlayer = Enemy.GetPlayerVisionStatus();
    }
}
