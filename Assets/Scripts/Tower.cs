using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform TowerHead = null;
     Transform Enemy = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetEnemy();
        TowerHead.LookAt(Enemy);
        ProccessFiring();
    }

    private void SetEnemy()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        if (enemies.Length > 0)
        {
            Enemy NearEnemy = enemies[0];
            foreach (Enemy enemy in enemies)
            {
                float NearDist = Vector3.Distance(transform.position, NearEnemy.transform.position);
                float Dist = Vector3.Distance(transform.position, enemy.transform.position);
                if (Dist < NearDist)
                {
                    NearEnemy = enemy;
                }
            }
            Enemy = NearEnemy.transform;
        }
    }

    private void ProccessFiring()
    {

        if (NearEnemy())
        {
            SetEmission(true);
        }
        else
        {
            SetEmission(false);
        }
    }

    private bool NearEnemy()
    {
        if (Enemy != null)
        {
            var x = Mathf.Abs(transform.position.x - Enemy.position.x);
            var z = Mathf.Abs(transform.position.z - Enemy.position.z);
            if (x <= 10 && z <= 10) return true;
        }
        return false;
    }

    private void SetEmission(bool Fire)
    {

        var emit = GetComponentInChildren<ParticleSystem>().emission;
            emit.enabled = Fire;
        
    }

}
