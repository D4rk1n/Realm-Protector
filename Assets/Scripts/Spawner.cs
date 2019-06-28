using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] Enemy enemy = null;
    [SerializeField] float SpawnTime = 10;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            Instantiate<Enemy>(enemy);
            yield return new WaitForSeconds(SpawnTime);
        }
    }
    // Update is called once per frame
    void Update()
    {
        SpawnTime -= Time.deltaTime/20f;
        SpawnTime = Mathf.Clamp(SpawnTime,2, 10);
    }
}
