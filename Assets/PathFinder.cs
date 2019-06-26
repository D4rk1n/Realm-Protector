using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    // Start is called before the first frame update
    void Start()
    {
        Waypoint[] waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints)
        {
            if(grid.ContainsKey(waypoint.GetPosition()))
            {
                Debug.LogWarning("Waypoint " + waypoint.name+ " is Overlapping");
            }
            else
            grid.Add(waypoint.GetPosition(), waypoint);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
