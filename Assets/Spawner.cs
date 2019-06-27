using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject Enemy = null;
    [SerializeField] float SpawnTime = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    IEnumerator Spawn()
    {
        print("Spawn");
        yield return new WaitForSeconds(SpawnTime);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
