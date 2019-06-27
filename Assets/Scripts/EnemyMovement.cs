using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public PathFinder pathFinder = null;
    // Start is called before the first frame update
    void Start()
    {

        pathFinder = FindObjectOfType<PathFinder>();
        var path = pathFinder.GetPath();
        StartCoroutine(FollowPath(path));

        
    }
    IEnumerator FollowPath(Stack<Waypoint> path)
    {
        
        while (path.Count > 0)
        {
            Waypoint wp = path.Pop();
            transform.position = wp.transform.position;
            yield return new WaitForSeconds(1f);
        }
        print("Congrats");
    }
}
