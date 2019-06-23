using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
public class GridCube : MonoBehaviour
{
    [SerializeField] [Range(0,20)] float gridLength = 10;
    [SerializeField] GameObject Label = null;
    void Awake()
    {
        
    }

    void Update()
    {
       
        float x = Mathf.RoundToInt(transform.position.x / gridLength) * gridLength;
        float z = Mathf.RoundToInt(transform.position.z / gridLength) * gridLength;
        transform.position = new Vector3(x, 0, z);
        Label.GetComponent<TextMesh>().text = x/10 + " , " + z/10;
    }
}
