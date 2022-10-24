using System;
using System.Collections;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float Radius;
    public float AttackRadius;
    
    [Range(0,360)]
    public float Angle;

    public GameObject PlayerRef;

    public LayerMask TargetMask;
    public LayerMask ObstrucionMask;

    [HideInInspector] public bool CanSeePlayer;
    [HideInInspector] public bool CanAttackPlayer;
    [HideInInspector] public Vector3 PlayerLastSpot;

    public bool GetVisionResponse()
    {
        return CanSeePlayer;
    }

    public bool GetAttackResponce()
    {
        return CanAttackPlayer;
    }

    protected void Start()
    {
        PlayerRef = GameObject.FindGameObjectWithTag("Player");//temp

        StartCoroutine(FOVRoutine());
    }

    protected IEnumerator FOVRoutine()
    {
        float delay = 0.2f;

        WaitForSeconds wait = new WaitForSeconds(delay);

        while (true)
        {
            yield return wait;
            FOVCheck();
        }
    }

    protected virtual void FOVCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, Radius, TargetMask);

        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < Angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, ObstrucionMask))
                {
                    CanSeePlayer = true;
                    PlayerLastSpot = PlayerRef.transform.position;

                    if (distanceToTarget <= AttackRadius)
                    {
                        CanAttackPlayer = true;

                        //callback?.Invoke(distanceToTarget);
                    }
                    else
                    {
                        CanAttackPlayer = false;
                    }
                }
                else
                {
                    CanSeePlayer = false;
                    CanAttackPlayer = false;
                }
            }
            else
            {
                CanSeePlayer = false;
                CanAttackPlayer = false;
            }
        }
        else if (CanSeePlayer)
        {
            CanSeePlayer = false;
            CanAttackPlayer = false;
        }
    }
}
