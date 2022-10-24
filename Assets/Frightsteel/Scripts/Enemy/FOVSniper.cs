using System;
using UnityEngine;
public class FOVSniper : FieldOfView
{
    public float EscapeRadius;
    
    private bool _canEscapePlayer;

    public bool GetEscapeResponse()
    {
        return _canEscapePlayer;
    }

    //protected override void FOVCheck(Action<float> callback = null)
    //{
    //    base.FOVCheck(distanceToTarget => {

    //        if (distanceToTarget <= EscapeRadius)
    //        {
    //            _canEscapePlayer = true;
    //        }
    //        else
    //        {
    //            _canEscapePlayer = false;
    //        }
    //    });
    //}

    protected override void FOVCheck()
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

                        if (distanceToTarget <= EscapeRadius)
                        {
                            _canEscapePlayer = true;
                        }
                        else
                        {
                            _canEscapePlayer = false;
                        }
                    }
                    else
                    {
                        CanAttackPlayer = false;
                        _canEscapePlayer = false;
                    }
                }
                else
                {
                    CanSeePlayer = false;
                    CanAttackPlayer = false;
                    _canEscapePlayer = false;
                }
            }
            else
            {
                CanSeePlayer = false;
                CanAttackPlayer = false;
                _canEscapePlayer = false;
            }
        }
        else if (CanSeePlayer)
        {
            CanSeePlayer = false;
            CanAttackPlayer = false;
            _canEscapePlayer = false;
        }
    }
}
