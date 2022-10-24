using UnityEngine;
public class EscapeState : BaseState
{
    private bool _isPlayerInEscapeRange;
    private bool _isPlayerInAttackRange;

    private Sniper _sniper;

    public EscapeState(BaseEnemy enemy, StateMachine stateMachine) : base(enemy, stateMachine)
    {
        _sniper = Enemy as Sniper;
    }

    public override void Enter()
    {
        base.Enter();
        //_sniper.SetSpeed(_sniper.RunSpeed);
        //run anim
    }

    public override void Exit()
    {
        base.Exit();

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        Debug.Log(_isPlayerInEscapeRange + " - escape");

        if (_isPlayerInEscapeRange)
        {
            Debug.Log("1");
            _sniper.Escape(); //MUST ESCAPE BUT STAY IN ATTACK RANGE!!!
        }
        else
        {
            Debug.Log("2");
            StateMachine.ChangeState(_sniper.AttackState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        _isPlayerInEscapeRange = _sniper.FOV.GetEscapeResponse();
    }
}
