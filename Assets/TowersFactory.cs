using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowersFactory : MonoBehaviour
{
    Queue<Tower> towers = new Queue<Tower>();
    [SerializeField] Tower tower = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

   public void CreateTower(Waypoint waypoint)
    {
        waypoint.hasTower = true;
        if (towers.Count < 3)
        {
            InstantiateNew(waypoint);
        }
        else if(towers.Count == 3)
        {
            var oldTower = towers.Dequeue();
           while(oldTower == null)
            {
                oldTower = towers.Dequeue();
            }
          
                oldTower.Base.hasTower = false;
                oldTower.Base = waypoint;
                oldTower.transform.position = waypoint.transform.position;
                towers.Enqueue(oldTower);
            

        }
    }

    private void InstantiateNew(Waypoint waypoint)
    {
        Tower newTower = Instantiate(tower, waypoint.transform);
        newTower.Base = waypoint;
        towers.Enqueue(newTower);
        print(towers.Count);
    }
}
