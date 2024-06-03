using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class throwsyringe : MonoBehaviour
{
    public GameObject syringePrefab;
    private GameObject a;
    private float x;
    public float speed;
    Rigidbody2D rb;
    Vector3 screenBounds;
    public int syringeCount=4;
    public Image Syr1;
    public Image Syr2;
    public Image Syr3;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) | Input.GetKeyDown(KeyCode.K))
        {
            onclick();
        }

        if (syringeCount == 4)
        {
            Syr1.enabled = true;
            Syr2.enabled = true;
            Syr3.enabled = true;
        }

        if (syringeCount == 3)
        {
            Syr1.enabled = true;
            Syr2.enabled = true;
            Syr3.enabled = false;
        }

        if (syringeCount == 2)
        {
            Syr1.enabled = true;
            Syr2.enabled = false;
            Syr3.enabled = false;

        }

        if (syringeCount == 1)
        {
            Syr1.enabled = false;
            Syr2.enabled = false;
            Syr3.enabled = false;
        }
    }

    public void onclick()
    {
        
        syringeCount -= 1;
        
        if (syringeCount > 0)
        {
            FindObjectOfType<AudioManager>().Play("SyrThrow");
            GameObject theplayer = GameObject.Find("Player");
            a = Instantiate(syringePrefab) as GameObject;
            a.transform.position = theplayer.transform.position;
            x = a.transform.position.x;

            rb = a.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector3(1.0f, rb.velocity.y) * speed;

        }
        else
        {
            syringeCount = 0;
        } 
    }


}
