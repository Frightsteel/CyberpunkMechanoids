public class StateMachine
{
    public BaseState CurrentState { get; private set; }

    public void Initialize(BaseState startingState)
    {
        SetState(startingState);
    }

    public void ChangeState(BaseState newState)
    {
        CurrentState.Exit();

        SetState(newState);
    }

    private void SetState(BaseState state)
    {
        CurrentState = state;
        state.Enter();
    }
}
