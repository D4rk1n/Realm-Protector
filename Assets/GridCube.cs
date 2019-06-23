using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class GridCube : MonoBehaviour
{
    void Awake()
    {
        
    }

    void Update()
    {
       
        float x = Mathf.RoundToInt(transform.position.x / 10) * 10;
        float z = Mathf.RoundToInt(transform.position.z / 10) * 10;
        transform.position = new Vector3(x, 0, z);
    }
}
