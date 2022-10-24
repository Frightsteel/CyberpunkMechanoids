public abstract class BaseState
{
    protected BaseEnemy Enemy;
    protected StateMachine StateMachine;

    protected BaseState(BaseEnemy enemy, StateMachine stateMachine)
    {
        Enemy = enemy;
        StateMachine = stateMachine;
    }

    public virtual void Enter() { }

    public virtual void LogicUpdate() { }

    public virtual void PhysicsUpdate() { }

    public virtual void Exit() { }
}
