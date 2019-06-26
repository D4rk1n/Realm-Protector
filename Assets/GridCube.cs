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
        float x = waypoint.GetPosition().x * gridLength;
        float z = waypoint.GetPosition().y * gridLength;
        transform.position = new Vector3(x, 0, z);
        Label.GetComponent<TextMesh>().text = x/10 + " , " + z/10;
        gameObject.name = x / 10 + " , " + z / 10;
    }
}
