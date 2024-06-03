using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathEffect : MonoBehaviour
{
    private GameObject deathParticle;

    private void Start()
    {
        deathParticle = GameObject.FindGameObjectWithTag("EnemyDeathParticle");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Sanitizer")
        {
            deathParticle.GetComponent<ParticleSystem>().Play();
            deathParticle.transform.position = this.transform.position;
        }
        
    }

}