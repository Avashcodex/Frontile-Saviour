using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoronaMainMenu : MonoBehaviour
{
    public GameObject coronaPrefab;
    public float respawnTime = 1.0f;
    private Vector2 screenBounds;
    private int count = 0;
    private float var;
    public float offsetCorona=1f;
    

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(coronaWave());
        StartCoroutine(restimered());        
        Debug.Log("start");
        Debug.Log(screenBounds.y);

        
    }

    private void spawnCorona()
    {
       
        GameObject a = Instantiate(coronaPrefab) as GameObject;
        

        a.transform.SetParent(GameObject.FindGameObjectWithTag("MainMenuCanvas").transform, false);

        /*a.transform.position = new Vector2(screenBounds.x * 2, 0.0f);*/
        a.transform.position = new Vector2(screenBounds.x * 2, Random.Range(screenBounds.y/3, 2*screenBounds.y/3)+offsetCorona);
        

        var = a.transform.position.y;
        


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
