using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainEffect : MonoBehaviour
{

    public GameObject Rain;
    public bool RainOn=false;
    
    void Start()
    {
        StartCoroutine(Starter());
    }

    void startRain()
    {
        RainOn = true;
        Rain.GetComponent<ParticleSystem>().Play();
        FindObjectOfType<AudioManager>().Play("Rain");
        StartCoroutine(stopRain());
    }
    

    IEnumerator stopRain()
    {
        yield return new WaitForSeconds(43);
        RainOn = false;
        Rain.GetComponent<ParticleSystem>().Stop();
    }

    IEnumerator Starter()
    {
        yield return new WaitForSeconds(Random.Range(100, 150));
        startRain();
        StartCoroutine(Starter());
    }
}
