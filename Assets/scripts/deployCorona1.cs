using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deployCorona1 : MonoBehaviour
{
    public GameObject coronaPrefab; 
    public float respawnTime = 1.3f;
    private Vector2 screenBounds;
    private int count;
    private int flag = 1;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(coronaWave());
        StartCoroutine(restimered());
        StartCoroutine(singleRestime());
        Debug.Log("start");
        
    }    

    private void spawnCorona()
    {
        GameObject a = Instantiate(coronaPrefab) as GameObject;
        a.transform.position = new Vector2(screenBounds.x * 2, Random.Range(screenBounds.y-1.0f, -screenBounds.y+1.0f));
        
    }

    IEnumerator singleRestime()
    {
        yield return new WaitForSeconds(150.0f);

        respawnTime -= 0.2f;
    }
    IEnumerator restimered()
    {
        count = 0;
        flag += 1;
        yield return new WaitForSeconds(250.0f);

        while (count < 3)
        {
            respawnTime -= 0.1f;
            yield return new WaitForSeconds(15.0f);
            count += 1;
        }

        Debug.Log(respawnTime);

        if (flag < 3)
        {
            StartCoroutine(restimered());
        }
    }
   
    IEnumerator coronaWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnCorona();
        }
    }    

}
