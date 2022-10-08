using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour
{
    public Transform GetWayPoint(int pointInd)
    {
        Transform point = transform.GetChild(pointInd);
        return point;
    }

    public int GetWayPointCount()
    {
        int pointCount = transform.childCount;
        return pointCount;
    }
}
