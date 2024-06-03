using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMove : MonoBehaviour
{
    public float speed = 2;    
    private Boundaries boun;
    private customJoy joy;
    private throwsyringe syr;
    private deployCorona1 depcor;
    public GameObject cam;  
   
    public GameObject scoreanim;
    

    void Start()
    {
        StartCoroutine(begin());
        boun = GetComponent<Boundaries>();
        joy = cam.GetComponent<customJoy>();
        syr = cam.GetComponent<throwsyringe>();
        depcor = cam.GetComponent<deployCorona1>();
        

    }
        

    IEnumerator begin()
    {
        while (true)
        {
            yield return new WaitForSeconds(0f);
            Vector2 direction = new Vector2(1.0f, 0.0f);
            this.transform.Translate(speed * Time.deltaTime * direction * 1);
           

            if (this.transform.position.x > -7)
            {
                StartCoroutine(scriptStart());
                break;
            }

        }       

        /*start boundaried and controls */
    }

    IEnumerator scriptStart()
    {
        yield return new WaitForSeconds(0f);
        
        boun.enabled = true;
        joy.enabled = true;
        syr.enabled = true;
        depcor.enabled = true;        
        
        scoreanim.SetActive(true);

    }
}
