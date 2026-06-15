using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// This is the gridmaker class where the grid for the pathfinding script is created
// This uses 2D arrays to make a grid of "Nodes"
public class GridMaker : MonoBehaviour
{
    [SerializeField] public Transform Player;
    [SerializeField] LayerMask SolidObject;
    Node[,] grid;
    Node TempNode;
    public Vector2 GridWorldSize;
    public bool ShowGrid;
    [SerializeField] float NodeRadius;
    public float GizmosOffset;
    float NodeDiameter;
    public int GridSizeY, GridSizeX;

    // Awake is called before Start
    private void Awake()
    {
        // Finds the Size of the Grid in "Nodes" first
        NodeDiameter = 2 * NodeRadius;
        GridSizeX = Mathf.RoundToInt(GridWorldSize.x / NodeDiameter);
        GridSizeY = Mathf.RoundToInt(GridWorldSize.y / NodeDiameter);
        CreateGrid();
        Debug.LogWarning("GridMaker script Has been slightly altered to not check for some non integer size colliders");
    }
    public void Startviabutton()
    {
        // Does the same thing but can be called when the Create grid button is clicked
        NodeDiameter = 2 * NodeRadius;
        GridSizeX = Mathf.RoundToInt(GridWorldSize.x / NodeDiameter);
        GridSizeY = Mathf.RoundToInt(GridWorldSize.y / NodeDiameter);
        CreateGrid();
    }
    public int MaxSize
    {
        get
        {
            return GridSizeX * GridSizeY;
        }
    }
    public void CreateGrid()
    {
        // Creates a Static 2D Array of Size X, SizeY
        grid = new Node[GridSizeX, GridSizeY];
        // finds the in world position of the bottom left corner where the grid should start from
        Vector3 WorldBottomLeft = transform.position - Vector3.right * GridWorldSize.x/2 - Vector3.up * GridWorldSize.y/2;
        for (int x = 0; x < GridSizeX; x++)
        {
            for (int y = 0; y < GridSizeY; y++)
            {
                //Finds the new in world position where the next node should go
                Vector3 worldPoint = WorldBottomLeft + Vector3.right * (x * NodeDiameter + NodeRadius) + Vector3.up * (y * NodeDiameter + NodeRadius);
                // Checks if there is an obstacle at the world point
                // WARNING THIS CODE IS SLIGHTLY ALTERED FOR THIS PROJECT -0.01 IS NOT MEANT TO BE THERE
                bool IsObstacle = Physics2D.OverlapCircle(worldPoint, NodeRadius-0.05f, SolidObject);
                // Creates a new Node at the world point position and assigns it a position in the 2D array
                grid[x, y] = new Node(IsObstacle,worldPoint, x, y);

            }

        }
    }
    public List<Node> GetNeighbours(Node node)
    {
        // Finds the surounding Nodes of one central node and returns a list of them.
        List<Node> neighbours = new List<Node>();
        // imagine a 3 by 3 block , we want to skip the middle node because it is not a neighbour
        for (int x=-1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                if (x==0 && y == 0)
                {
                    continue;
                }
                int checkX = node.gridX + x;
                int checkY = node.gridY + y;
                if (checkX >= 0 && checkX < GridSizeX && checkY >=0 && checkY < GridSizeY)
                {
                    neighbours.Add(grid[checkX, checkY]);
                }
            }
        }
        return neighbours;
    }
    public Node NodeFinder(Vector3 worldPosition)
    {
        // Converts a world position into a position of the node

        // basically finds world position as percentage of the grid size
        // 0 = left 1 = right
        float percentX = (worldPosition.x + GridWorldSize.x / 2) / GridWorldSize.x;
        // 0 = bottom 1 = top
        float percentY = (worldPosition.y + GridWorldSize.y / 2) / GridWorldSize.y;
        //uses that percentage to find the x and y in terms of the array
        int x = Mathf.FloorToInt(Mathf.Clamp((GridSizeX) * percentX, 0, GridSizeX - 1));
        int y = Mathf.FloorToInt(Mathf.Clamp((GridSizeY) * percentY, 0, GridSizeY - 1));
        //returns the node in the array using x and y
        return grid[x, y];

    }
    // called when draw gizmos is enabled
    private void OnDrawGizmos()
    {
        // purely to visualise the grid and current player position in the grid
        Gizmos.DrawWireCube(transform.position, new Vector3(GridWorldSize.x, GridWorldSize.y, 0));
            if (grid != null && ShowGrid)
            {
                Node playerNode = NodeFinder(Player.position);
                foreach (Node n in grid)
                {
                    Gizmos.color = (n.IsObstacle)?new Color(1,0,0,0.2f): new Color(1, 1, 1, 0.2f);
                if (playerNode == n)
                    {
                        Gizmos.color = Color.yellow;
                    }
               
                    Gizmos.DrawCube(n.worldPosition, Vector2.one * (NodeDiameter-GizmosOffset));
                }
            }
        

    }
   
}
// The Node Class used throught the grid
 public class Node : IHeapItem<Node>
    {
    // Variables that need to be contained in the class to be used in pathfinding
        public Vector3 worldPosition;
        public bool IsObstacle;
    public int gCost;
    public int hCost;
    public int gridX, gridY;
    public Node Parent;
    int heapIndex;
    // Constructor
        public Node(bool _isObstacle, Vector3 _worldPosition, int _gridX, int _gridY)
        {
            IsObstacle = _isObstacle;
            worldPosition = _worldPosition;
            gridX = _gridX;
            gridY = _gridY;
        }
    public int fCost
    {
        get
        {
            return gCost + hCost;
        }
    }
    // Stores where the item is in the heap
    public int HeapIndex
    {
        get
        {
            return heapIndex;
        }
        set
        {
            heapIndex = value;
        }
    }
    public int CompareTo(Node comparingNode)
    {
        int compare = fCost.CompareTo(comparingNode.fCost);
        if (compare == 0)
        {
            compare = hCost.CompareTo(comparingNode.hCost);
        }
        return -compare;
    }
    }