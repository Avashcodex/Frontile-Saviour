using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class collision : MonoBehaviour
{
    public GameObject auraEffect;  
    
    public int flag=1; /*circlecollider if off*/
    private int playerLife;

    public bool AuraOn=false;


    void Update()
    {
        GameObject theplayer = GameObject.Find("Player");
        scoreupdt scoreScript = theplayer.GetComponent<scoreupdt>();
        playerLife = scoreScript.lifeCount;
               

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (playerLife>0)
        {

            if (collision.tag == "enemy" && flag == 1)
            {
                StartCoroutine(Camera.main.GetComponent<cameraShake>().camShake(0.3f, 0.2f));
            }

            if (collision.tag == "Sanitizer")
            {
                AuraOn = true;
                FindObjectOfType<AudioManager>().Play("Aura");
                auraEffect.GetComponent<ParticleSystem>().Play();
                StartCoroutine(stopAura());
                flag = 0;
                this.GetComponent<CircleCollider2D>().enabled = true;

            }

        }
    }

    IEnumerator stopAura()
    {
        yield return new WaitForSeconds(5.8f);
        AuraOn = false;
        auraEffect.GetComponent<ParticleSystem>().Stop();
        StopCoroutine(stopAura());
        flag = 1;
        this.GetComponent<CircleCollider2D>().enabled = false;
    }
    
}





