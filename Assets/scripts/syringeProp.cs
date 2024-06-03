using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class syringeProp : MonoBehaviour
{
    Vector3 screenBounds;
    

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        
        if (this.transform.position.x > screenBounds.x * 2)
        {
            Destroy(this.gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "enemy")
        {            
            Destroy(this.gameObject);
            Camera.main.GetComponent<throwsyringe>().syringeCount+=1;
        }
    }


}