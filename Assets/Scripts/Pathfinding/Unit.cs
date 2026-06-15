using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class Unit : MonoBehaviour
{
    // This script can be integrated into the enemy script for flying enemies
    public Transform target;
    public GameObject targetGameObject;
    public float speed = 1;
    Vector3[] path;
    int targetIndex;
    const float UpdateMoveThreshold = 0.2f;
    const float UpdatePathDelay = 0.2f;
    private void Start()
    {
        // find path at start
        StartCoroutine(UpdatePath());
        targetGameObject = GameObject.FindGameObjectWithTag("Player");
        target = targetGameObject.transform.GetChild(0).transform;
    }
    public void OnPathFound(Vector3[] newPath, bool pathSuccessful)
    {
        if (pathSuccessful)
        {
            path = newPath;
            StopCoroutine("FollowPath");
            StartCoroutine("FollowPath");
        }
        else
        {
            return;
        }
    }
    IEnumerator FollowPath()
    {
        Vector3 currentWaypoint = path[0];
        targetIndex = 0;
        while (true)
        {
            if (transform.position == currentWaypoint)
            {
                targetIndex++;
                // get out of loop if for some reason the index is longer than the length of the path
                if (targetIndex >= path.Length)
                {
                    targetIndex = 0;
                    path = new Vector3[0];
                    yield break;
                }
                currentWaypoint = path[targetIndex];
            }
            // moves towards the next waypoint
            transform.position = Vector3.MoveTowards(transform.position, currentWaypoint, speed*Time.deltaTime);
            yield return null;
        }
    }
    IEnumerator UpdatePath()
    {
        // to avoid high values of time.delta time
        if(Time.timeSinceLevelLoad < 0.3f)
        {
            yield return new WaitForSeconds(0.3f);
        }
        //request a path from the manager
        PathfindingManager.RequestPath(transform.position, target.transform.position, OnPathFound);
        // because distance checks are expensive:
        float sqrMoveThreshold = UpdateMoveThreshold * UpdateMoveThreshold;
        Vector3 targetPosOld = target.position;
        while (true)
        {
            // Delay for finding a new path
            yield return new WaitForSeconds(UpdatePathDelay);
            // only if the target has moved a specific amount then find a new path
            if ((target.position - targetPosOld).sqrMagnitude > sqrMoveThreshold)
            {
                PathfindingManager.RequestPath(transform.position, target.transform.position, OnPathFound);
                targetPosOld = target.position;
            }
            

        }
    }
    public void OnDrawGizmos()
    {
        // purely to visualise the waypoints and path of the object
        if (path != null) {
            for(int i = targetIndex; i  < path.Length; i++)
            {
                Gizmos.color = Color.black;
                Gizmos.DrawCube(path[i], new Vector3(0.5f, 0.5f, 0));

                if (i == targetIndex)
                {
                    Gizmos.DrawLine(transform.position, path[i]);
                }
                else
                {
                    Gizmos.DrawLine(path[i-1], path[i]);
                }
            }
        }
    }
}
