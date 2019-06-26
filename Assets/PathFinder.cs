using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
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
        CreateGrid();
        ExploreNeighbours(StartPoint);
    }

    private void ExploreNeighbours(Waypoint waypoint)
    {
        
        foreach (Vector2Int direction in Dir)
        {
            Vector2Int neighbour = waypoint.GetPosition() + direction;
            print(neighbour);
           if(grid.ContainsKey(neighbour))
            grid[neighbour].SetTopColor(Color.cyan);
          
                
            
        }
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
                waypoint.SetTopColor(Color.grey);
                grid.Add(gridPos, waypoint);
            }
        }
        StartPoint.SetTopColor(Color.blue);
        EndPoint.SetTopColor(Color.green);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
