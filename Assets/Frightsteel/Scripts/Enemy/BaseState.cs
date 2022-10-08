public abstract class BaseEnemyState
{
    protected BaseEnemy Enemy;
    protected StateMachine StateMachine;

    protected BaseEnemyState(BaseEnemy enemy, StateMachine stateMachine)
    {
        Enemy = enemy;
        StateMachine = stateMachine;
    }

    public virtual void Enter() { }

    public virtual void LogicUpdate() { }

    public virtual void PhysicsUpdate() { }

    public virtual void Exit() { }
}
