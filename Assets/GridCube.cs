using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
public class GridCube : MonoBehaviour
{
    
    [SerializeField] GameObject Label = null;
    Waypoint waypoint;
    void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }

    void Update()
    {
        int gridLength = waypoint.GetGridLength();
        float x = waypoint.GetPosition().x ;
        float z = waypoint.GetPosition().y ;
        transform.position = new Vector3(x*gridLength, 0, z* gridLength);
        Label.GetComponent<TextMesh>().text = x + " , " + z;
        gameObject.name = x  + " , " + z ;
    }
}
