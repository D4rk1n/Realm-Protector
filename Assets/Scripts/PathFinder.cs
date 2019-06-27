using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    int pathNo = 0;
    [SerializeField] Waypoint StartPoint = null;
    [SerializeField] Waypoint EndPoint = null;
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
  
    Vector2Int[] Dir =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };
    


    // Start is called before the first frame update
    void Start()
    {
        
        
        
    }

    public Stack<Waypoint> GetPath()
    {
        Stack<Waypoint> path = new Stack<Waypoint>();
        pathNo++;
        print(pathNo + ") Stak before : "  );
        CreateGrid();
        BFS();
        CreatePath(ref path);
        print(pathNo + ") Stak after : "  );
        grid.Clear();
        return path;
    }
    private void CreatePath(ref Stack<Waypoint> path)
    {
        Waypoint wp = EndPoint;
        path.Push(wp);
        while (wp != null && wp.prev != null)
        {
            
            
          
            wp = wp.prev;
            path.Push(wp);
        }
    }

    private void BFS()
    {
        Queue<Waypoint> Q = new Queue<Waypoint>();
        Q.Enqueue(StartPoint);
        LinkedList<Waypoint> way = new LinkedList<Waypoint>();
        while(Q.Count > 0)
        {
            
            Waypoint u = Q.Dequeue();
            
            if (!u.visited)
            {
                
                u.visited = true;
                if (ExploreNeighbours(u, ref Q,ref way))
                    return;
            }
        }

    }

    private bool ExploreNeighbours(Waypoint waypoint,ref Queue<Waypoint> Q,ref LinkedList<Waypoint> way)
    {
        
        foreach (Vector2Int direction in Dir)
        {
            Vector2Int neighbour = waypoint.GetPosition() + direction;
            
            if (grid.ContainsKey(neighbour))
            {
                if (!grid[neighbour].visited)
                {
                   
                    
                    grid[neighbour].prev = waypoint;
                    if (grid[neighbour] == EndPoint) return true;
                    Q.Enqueue(grid[neighbour]);
                    
                    
                }
            }
          
                
            
        }
        return false;
    }

    private void CreateGrid()
    {
        Waypoint[] waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints)
        {
            var gridPos = waypoint.GetPosition() ;
            if (grid.ContainsKey(gridPos))
            {
                Debug.LogWarning("Waypoint " + waypoint.name + " is Overlapping");
            }
            else
            {
             
                grid.Add(gridPos, waypoint);
            }
        }
        print(waypoints.Length);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
