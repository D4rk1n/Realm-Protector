using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] Waypoint StartPoint = null;
    [SerializeField] Waypoint EndPoint = null;
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();

    // Start is called before the first frame update
    void Start()
    {
        Waypoint[] waypoints = FindObjectsOfType<Waypoint>();
        foreach (Waypoint waypoint in waypoints)
        {
            var gridPos = waypoint.GetPosition() * 10;
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
        StartPoint.SetTopColor(Color.green);
        EndPoint.SetTopColor(Color.cyan);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
