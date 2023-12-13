using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform3 : MonoBehaviour
{
    public List<Vector3> waypoints = new List<Vector3>();
    public float platformSpeed = 1.8f;
    private int currentPoint = 0;
    private bool movingForward = true;
    public bool isMoving = false;

    void Start()
    {
        if (waypoints.Count > 0) // start at first waypoint
        {
            transform.position = waypoints[0];
        }
    }

    void Update()
    {
        // to work independent of the player, just set isMoving to true at start
        if (isMoving && waypoints.Count > 0)
        {
            MoveToWaypoint();
        }
    }

    private void MoveToWaypoint()
    {
            Vector3 targetWaypoint = waypoints[currentPoint];
            Vector3 moveDirection = (targetWaypoint - transform.position).normalized;
            transform.position += platformSpeed * Time.deltaTime * moveDirection;

            if (Vector3.Distance(transform.position, targetWaypoint) < 0.1f)
            {
                if (movingForward)
                {
                    if (currentPoint >= waypoints.Count - 1) // at the last waypoint - move backwards
                    {
                        Debug.Log("Moving backwards");
                        movingForward = false;
                        currentPoint = waypoints.Count - 2; // set to previous point
                    }
                    else
                    {
                        currentPoint++;
                    }
                }
                else //if movingBackward
                {
                    if (currentPoint <= 0) // at first waypoint
                    {
                        currentPoint = 1; // set to second point
                        Debug.Log("at the start");
                        movingForward = true;
                        isMoving = false; // only does one 'lap'
                    }
                    else
                    {
                        currentPoint--;
                    }
                }
            }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player entered the platform.");
            isMoving = true;
        }
    }
}
