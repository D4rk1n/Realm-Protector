using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Waypoint : MonoBehaviour
{
    public bool visited = false;
    public Waypoint prev = null;
    const int gridLength = 10;
    
    public bool hasTower = false;
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

    }
    public int GetGridLength()
    {
        return gridLength;
    }

    public Vector2Int GetPosition()
    {
        int x = Mathf.RoundToInt(transform.position.x / gridLength);
        int z = Mathf.RoundToInt(transform.position.z / gridLength);

        return new Vector2Int(x, z);
    }
    private void OnMouseOver()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (!hasTower)
            {
                GetComponentInParent<TowersFactory>().CreateTower(this);
            }
        }
    }
}

