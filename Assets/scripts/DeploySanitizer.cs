using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeploySanitizer : MonoBehaviour
{
    public GameObject sanitizerPrefab;
    public float respawnTime = 1.0f;
    private Vector2 screenBounds;
    private int count = 0;


    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(coronaWave());
        StartCoroutine(restimered());
        Debug.Log("start");

    }

    private void spawnCorona()
    {
        GameObject a = Instantiate(sanitizerPrefab) as GameObject;
        a.transform.position = new Vector2(screenBounds.x * 2 + Random.Range(0.0f,15.0f), Random.Range(screenBounds.y - 1.0f, -screenBounds.y + 1.0f)); ;;
       
    }


    IEnumerator restimered()
    {

        yield return new WaitForSeconds(20.0f);

        while (count < 5)
        {
            respawnTime -= 0.07f;
            yield return new WaitForSeconds(1.0f);
            count += 1;
        }

        Debug.Log(respawnTime);
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
