using UnityEngine;
using UnityEngine.AI;

public class Sniper : BaseEnemy
{
    [SerializeField] private float WeaponReloadTime = 3.0f;

    public FOVSniper FOV;

    #region Cooldowns

    [HideInInspector] public Cooldown WeaponReloadCooldown;

    #endregion

    protected override void Init()
    {
        base.Init();

        EscapeState = new EscapeState(this, StateMachine);
        AttackState = new AttackStateSniper(this, StateMachine);

        WeaponReloadCooldown = new Cooldown(WeaponReloadTime, name);
    }

    protected override void Awake()
    {
        base.Awake();

        FOV = GetComponent<FOVSniper>();

    }

    public override void Attack()
    {
        base.Attack();
        //shoot
        //use anim
        Debug.Log("Pew-Pew");
        WeaponReloadCooldown.StartCooldown();
    }

    public void Escape()
    {
        //get a random point and run to
        //change speed?
        Vector3 moveDir = GetPlayerPosition() - transform.position;
        moveDir = new Vector3(-moveDir.x, moveDir.y, -moveDir.z);
        MoveTo(moveDir);
    }
}
