using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waypoints : MonoBehaviour
{
    [Header ("Waypoint Status")]
    public waypoints previousway;
    public waypoints nextway;

    [Range(0f, 5f)]
    public float waypointwidth = 1f;

    public Vector3 GetPosition()
    {
        Vector3 minBound = transform.position +transform.right *waypointwidth/2f;
        Vector3 maxBound = transform.position -transform.right *waypointwidth/2f;

        return Vector3.Lerp(minBound , maxBound , Random.Range(0f,1f));
        

    }
}
