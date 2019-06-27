using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] ParticleSystem CongratsFX = null;
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
        var FX = Instantiate(CongratsFX, new Vector3(transform.position.x, transform.position.y + 2.5f, transform.position.z), Quaternion.identity);
        Destroy(FX.gameObject, FX.main.duration);
        Destroy(gameObject);
    }
}
