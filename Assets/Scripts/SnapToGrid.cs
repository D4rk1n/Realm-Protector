using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class SnapToGrid : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int x = Mathf.RoundToInt(transform.position.x / 10) * 10;
        int y = Mathf.RoundToInt(transform.position.y / 10) * 10;
        int z = Mathf.RoundToInt(transform.position.z / 10) * 10;
        transform.position = new Vector3(x, y, z);
        
    }
}
