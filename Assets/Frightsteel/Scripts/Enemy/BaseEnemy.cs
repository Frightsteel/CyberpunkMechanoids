using UnityEngine;
using UnityEngine.AI;

public abstract class BaseEnemy : MonoBehaviour, IDamageable
{
    #region Stats

    [Header("Stats")]
    [SerializeField] protected float Health;
    //protected float Armor;
    [SerializeField] protected float Damage;
    
    [Header("Speed Options")]
    public float WalkSpeed;
    public float RunSpeed;

    [Header("Attack Type")]
    //public bool Melee;
    public float MeleeAttackRange;
    public float MeleeAttackDamage;
    //public bool Range;
    public float RangeAttackRange;
    public float RangeAttackDamage;

    #endregion

    [SerializeField] private WayPoints _points; //temp, mb it would be better if smth like spawner or gamemanager will share waypoints at the moment of spawn
    private int _destPoint = 0;

    protected float Speed; //temp

    protected Rigidbody Rigidbody;
    protected Collider Collider;
    
    protected GameObject PlayerTarget;

    protected StateMachine StateMachine;

    protected FieldOfView FOV;

    [HideInInspector] public NavMeshAgent Agent;

    #region States

    public ChillState ChillState;
    public PatrolState PatrolState;
    public ChaseState ChaseState;
    public AttackState AttackState;

    #endregion

    #region MonoBehaviour Callbacks

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        Collider = GetComponent<Collider>();
        Agent = GetComponent<NavMeshAgent>();

        FOV = GetComponent<FieldOfView>();

        PlayerTarget = GameObject.FindGameObjectWithTag("Player"); //temp
    }

    private void Update()
    {
        Debug.Log(StateMachine.CurrentState);
        StateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }

    #endregion

    protected BaseEnemy()
    {
        StateMachine = new StateMachine();
        
        ChillState = new ChillState(this, StateMachine);
        PatrolState = new PatrolState(this, StateMachine);
        ChaseState = new ChaseState(this, StateMachine);
        AttackState = new AttackState(this, StateMachine);

        StateMachine.Initialize(ChillState);
    }

    protected virtual void Attack()
    {
        
    }

    protected void MoveTo(Vector3 reachPoint)
    {
        Agent.SetDestination(reachPoint);
    }

    public void Chill()
    {
        if (_points.GetWayPointCount() == 0)
            return;
        MoveTo(_points.GetWayPoint(_destPoint).position);
        _destPoint = (_destPoint + 1) % _points.GetWayPointCount();
    }

    public void Patrol()
    {
        //while time of patrolling is not over, get random point and go there
        MoveTo(RandomNavmeshLocation());
    }

    public void Chase(Vector3 targetPos)
    {
        MoveTo(targetPos);
    }

    public Vector3 RandomNavmeshLocation(float radius = 20f)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += transform.position;
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
        {
            finalPosition = hit.position;
        }
        return finalPosition;
    }

    public Vector3 GetPlayerLastPosition()
    {
        return FOV.PlayerLastSpot;
    }

    public Vector3 GetPlayerPosition()
    {
        return PlayerTarget.transform.position;
    }

    public bool GetPlayerVisionStatus()
    {
        return FOV.CanSeePlayer;
    }

    public void TakeDamage(float damage) // temp
    {
        Health -= damage;
    }

    public void SetSpeed(float speed)
    {
       Speed = speed;
    }
}
