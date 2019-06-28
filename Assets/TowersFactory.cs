using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowersFactory : MonoBehaviour
{
    FBase Base =null;
    Queue<Tower> towers = new Queue<Tower>();
    [SerializeField] Tower tower = null;
    // Start is called before the first frame update
    void Start()
    {
        Base = FindObjectOfType<FBase>();
    }

    // Update is called once per frame
    void Update()
    {
       if(!Base.Alive)
        {
            DestroyTowers();
        }
    }

    private void DestroyTowers()
    {
        while(towers.Count > 0)
        {
            var dTower = towers.Dequeue();
            Destroy(dTower.gameObject);
        }
    }

    public void CreateTower(Waypoint waypoint)
    {
        if (Base.Alive)
        {
            waypoint.hasTower = true;
            if (towers.Count < 3)
            {
                InstantiateNew(waypoint);
            }
            else if (towers.Count == 3)
            {
                var oldTower = towers.Dequeue();
                if (oldTower == null)
                {
                    InstantiateNew(waypoint);
                }
                else
                {
                    oldTower.Base.hasTower = false;
                    oldTower.Base = waypoint;
                    oldTower.transform.position = waypoint.transform.position;
                    towers.Enqueue(oldTower);
                }

            }
        }
    }

    private void InstantiateNew(Waypoint waypoint)
    {
        Tower newTower = Instantiate(tower, waypoint.transform);
        newTower.Base = waypoint;
        towers.Enqueue(newTower);
    }
}
