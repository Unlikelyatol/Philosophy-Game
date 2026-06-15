using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PathfindingManager : MonoBehaviour
{
    // A queue of path requests
    Queue <PathRequest> pathRequestQueue = new Queue<PathRequest>();
    PathRequest currentPathrequest;

    static PathfindingManager instance;
    Pathfinding pathfinding;

    bool isProcessingPath;
    void Awake()
    {
        instance = this;
        pathfinding = GetComponent<Pathfinding>();
    }
    // to request a path, since we are spreading the method over multiple frames,
    // action is a way of storing a method and call it when we calculate path
    public static void RequestPath(Vector3 PathStart, Vector3 PathEnd, Action<Vector3[], bool> callback)
    {
        PathRequest newRequest = new PathRequest (PathStart, PathEnd, callback);
        instance.pathRequestQueue.Enqueue(newRequest);
        instance.TryProcessNext();
    }
    //check if we are already trying to process a path if not process next path
    void TryProcessNext()
    {
        if (!isProcessingPath && pathRequestQueue.Count > 0)
        {
            currentPathrequest = pathRequestQueue.Dequeue();
            isProcessingPath = true;
            pathfinding.StartCreatePath(currentPathrequest.PathStart, currentPathrequest.PathEnd);
        }
    }
    // will be called in original pathfinding script when finished path
    public void FinishingProcessingPath(Vector3[] path, bool success)
    {
        currentPathrequest.callback(path,success);
        isProcessingPath = false;
        TryProcessNext();
    }
    //data structure that will store all this information
    struct PathRequest
    {
        public Vector3 PathStart;
        public Vector3 PathEnd;
        public Action<Vector3[], bool> callback;
        //constructor
        public PathRequest(Vector3 _start, Vector3 _end, Action<Vector3[], bool> _callback)
        {
            PathStart = _start;
            PathEnd = _end;
            callback = _callback;
        }
    }
}

