public class StateMachine
{
    public BaseEnemyState CurrentState { get; private set; }

    public void Initialize(BaseEnemyState startingState)
    {
        SetState(startingState);
    }

    public void ChangeState(BaseEnemyState newState)
    {
        CurrentState.Exit();

        SetState(newState);
    }

    private void SetState(BaseEnemyState state)
    {
        CurrentState = state;
        state.Enter();
    }
}
