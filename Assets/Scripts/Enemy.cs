using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int Health = 5 ;
    [SerializeField] ParticleSystem OnHitFX = null;
    [SerializeField] ParticleSystem DeathFX = null;

    // Update is called once per frame
    void Update()
    {

        if (Health <= 0)
        {
            FindObjectOfType<FBase>().IncreaseScore();
            var FX = Instantiate(DeathFX, new Vector3(transform.position.x, transform.position.y + 2.5f, transform.position.z), Quaternion.identity);
            Destroy(FX.gameObject, FX.main.duration);
            Destroy(gameObject);
            
        }
    }
    private void OnParticleCollision(GameObject other)
    {
        Health--;
        OnHitFX.Play();
    }

}
