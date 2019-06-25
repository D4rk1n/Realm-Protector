using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    const int gridLength = 10;
    Vector2Int position;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()

    {
        int x = Mathf.RoundToInt(transform.position.x / gridLength);
        int z = Mathf.RoundToInt(transform.position.z / gridLength);
        position = new Vector2Int(x, z);
        print(x);
        print(z);
    }
    public int GetGridLength()
    {
        return gridLength;
    }

    public Vector2 GetPosition()
    {
        int x = Mathf.RoundToInt(transform.position.x / gridLength);
        int z = Mathf.RoundToInt(transform.position.z / gridLength);
        
        return position;
    }
}
