using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooldown
{
    public float CooldownTime;
    public bool IsCooldowned = true;
    
    public Cooldown(float time)
    {
        CooldownTime = time;
    }

    //public IEnumerator Timer()
    //{
    //    IsCooldowned = false;
    //    yield return new WaitForSecondsRealtime(CooldownTime);
    //    IsCooldowned = true;
    //    StopCoroutine(Timer());
    //}

    public void StartCooldown()
    {
        //StartCoroutine(Timer());
    }
}
