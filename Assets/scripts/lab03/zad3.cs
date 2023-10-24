using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zad3 : MonoBehaviour
{
    private Vector3[] waypoints = new Vector3[4];
    private int currentWaypointIndex = 0;

    private void Start()
    {
        waypoints[0] = transform.position;
        waypoints[1] = waypoints[0] + Vector3.forward * 10;
        waypoints[2] = waypoints[1] + Vector3.left * 10;
        waypoints[3] = waypoints[2] + Vector3.back * 10;

        SetNextWaypoint();
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex]) < 0.1f)
        {
            SetNextWaypoint();
        }

        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex], 5f * Time.deltaTime);
    }

    private void SetNextWaypoint()
    {
        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;

        Vector3 direction = waypoints[currentWaypointIndex] - transform.position;
        transform.forward = direction;
    }
}
