using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int Health = 5 ;

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)
            Destroy(gameObject);
    }
    private void OnParticleCollision(GameObject other)
    {
       
        Health--;
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
    }
}
