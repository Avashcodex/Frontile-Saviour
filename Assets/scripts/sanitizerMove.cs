using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sanitizerMove : MonoBehaviour
{
    public float speed = 10.0f;
    private float rot;
    public float rotationSpeed;
    private Rigidbody2D rb; 
    private Vector2 screenBounds;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));                
    }

    // Update is called once per frame
    void Update()
    {

        rot -= Time.deltaTime * rotationSpeed;

        this.transform.rotation = Quaternion.Euler(this.transform.rotation.x, -180.0f, rot);

        GameObject theplayer = GameObject.Find("Player");
        scoreupdt scoreScript = theplayer.GetComponent<scoreupdt>();
        score = scoreScript.scorecint;

        if (score > 10)
        {
            speed = 10;
            rotationSpeed = 100.0f;
        }

        if (score > 15)
        {
            speed = 12;
            rotationSpeed = 150.0f;
        }

        if (score > 20)
        {
            speed = 13;
            rotationSpeed = 180.0f;
        }


        rb.velocity = new Vector2(-speed, 0);

        if (transform.position.x < screenBounds.x * -2)
        {
            Destroy(this.gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(this.gameObject);
        }        
    }

}
