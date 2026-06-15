using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System;

public class Pathfinding : MonoBehaviour
{
    PathfindingManager manager;
    GridMaker grid;
    private void Awake()
    {
        manager = GetComponent<PathfindingManager>();
        grid = GetComponent<GridMaker>();
    }
    // Method to be called in PathfindingManager
    public void StartCreatePath(Vector3 startPos, Vector3 targetpos)
    {
        StartCoroutine(CreatePath(startPos, targetpos));
    }
    IEnumerator CreatePath(Vector3 Startpos, Vector3 TargetPos)
    {
        print("start find path");
        //Stopwatch for testing purposes
        Stopwatch sw = new Stopwatch();
        sw.Start();
        Vector3[] waypoints = new Vector3[0];
        bool pathSuccess = false;
        // Find the Nodes associated with the start and target position
        Node startNode = grid.NodeFinder(Startpos);
        Node targetNode = grid.NodeFinder(TargetPos);
        if (!startNode.IsObstacle && !targetNode.IsObstacle)
        {
            //Using the Heap we created in the last file
            Heap<Node> openSet = new Heap<Node>(grid.MaxSize);
            HashSet<Node> closedSet = new HashSet<Node>();
            openSet.Add(startNode);
            // while there are still nodes in the open set
            while (openSet.Count > 0)
            { 
                // progress through heap by pop the first item
                Node currentNode = openSet.RemoveFirst();
                closedSet.Add(currentNode);
                // Stopped once we find the target node
                if (currentNode == targetNode)
                {
                    sw.Stop();
                    print("Path found" + sw.ElapsedMilliseconds + "ms");
                    pathSuccess = true;
                    break;
                }
                // Update the Neighbours of the node
                foreach (Node neighbour in grid.GetNeighbours(currentNode))
                {
                    //Skip if it is an obstacle or already has been added to the closed set
                    if (neighbour.IsObstacle || closedSet.Contains(neighbour))
                    {
                        continue;
                    }
                    //Change the cost of the neighbour
                    int newMoveToNeighbourCost = currentNode.gCost + GetDistance(currentNode, neighbour);
                    // re evaluate node in the closed set or if the nighbour is has a new lower gCost and adds it to the open set
                    if (newMoveToNeighbourCost < neighbour.gCost || !openSet.Contains(neighbour))
                    {
                        neighbour.gCost = newMoveToNeighbourCost;
                        neighbour.hCost = GetDistance(neighbour, targetNode);
                        // Sets the parent of the neighbour to the current node so we can create a long list of parents that make up a path
                        neighbour.Parent = currentNode;
                        if (!openSet.Contains(neighbour))
                        {
                            openSet.Add(neighbour);
                        }
                        else
                        {
                            openSet.UpdateITem(neighbour);
                        }

                    }
                }
            }
            //wait for one frame
            yield return null;
            if (pathSuccess)
            {
                // waypoints are individual points where the path changes direction
                waypoints = RetracePath(startNode, targetNode);
                // if the path is too short the path success should be set to false
                if (waypoints.Length == 0)
                {
                    print("tester");
                    pathSuccess = false;
                }
            }
        }
        else
        {
            pathSuccess = false;
        }
        // the path is now complete
        manager.FinishingProcessingPath(waypoints, pathSuccess);
    }
    private Vector3[] RetracePath(Node startNode, Node endNode)
    {
        List<Node> path = new List<Node>();
        Node currentNode = endNode;
        // follow the list of parents up so we create a path
        while(currentNode != startNode)
        {
            path.Add(currentNode);
            currentNode = currentNode.Parent;
        }
        Vector3[] waypoints = SimplifyPath(path);
        print(waypoints);
        Array.Reverse(waypoints);
        return waypoints;
    }
    // returns an array of vector3
    Vector3[] SimplifyPath(List<Node> path)
    {
        List<Vector3> waypoints = new List<Vector3>();
        // original direction ( which way it is going) is set to 0
        Vector2 directionOld = Vector2.zero;
        for (int i = 1; i < path.Count; i++)
        {
            //whenever the path changes direction adds a new waypoint to where it changed direction
            Vector2 directionNew = new Vector2(path[i - 1].gridX - path[i].gridX, path[i - 1].gridY - path[i].gridY);
            if (directionNew != directionOld)
            {
                waypoints.Add(path[i-1].worldPosition);
            }
            //sets the new direction and loops again until i is one smaller than path count
            directionOld = directionNew;
        }
        // These two if statements fix very specific bugs
        //Since if path count is = 1 gets skipped we can add it here
        if (path.Count == 1)
        {
            waypoints.Add(path[0].worldPosition);
        }
        // the last waypoint is not added to the path so we need to add it here
        else if (path.Count > 1)
        {
           waypoints.Add(path[path.Count-1].worldPosition);
        }

        return waypoints.ToArray();
    }
    int GetDistance(Node nodeA , Node nodeB)
    {
        
        int DistX = Mathf.Abs(nodeA.gridX- nodeB.gridX);
        int DistY = Mathf.Abs(nodeA.gridY - nodeB.gridY);
        // 14 is one diagonal movement 10 is one horizontal movement;
        //14x+10(X-Y)
        if (DistX > DistY)
        {
            return 14*DistY + 10 *(DistX-DistY);
        }
        //14y+10(y-x), if y is greater
        else
        {
            return 14 * DistX + 10 * (DistY - DistX);
        }
    }
}
