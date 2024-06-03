using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coronaMove : MonoBehaviour
{

    public float speed = 8.0f;    
    private Rigidbody2D rb;
    public float rotationSpeed;
    private float rot;
    private Vector2 screenBounds;    
    public int score;
    public Animator ScoreAnim;
    public GameObject Score;
    private float objwid;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();        
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        Score = GameObject.FindGameObjectWithTag("ScoreUpdate");
        ScoreAnim = Score.GetComponent<Animator>();

        objwid = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
    }

    // Update is called once per frame
    void Update()    {

        
        
        rot -= Time.deltaTime * rotationSpeed;

        this.transform.rotation = Quaternion.Euler(this.transform.rotation.x, -180.0f, rot);


        GameObject theplayer = GameObject.Find("Player");
        scoreupdt scoreScript = theplayer.GetComponent<scoreupdt>();
        score = scoreScript.scorecint;

        if (score > 150)
        {            
            rotationSpeed = 40.0f;
        }

        if (score>600)
        {
            rotationSpeed = 50.0f;

        }
        if (score > 1000)
        {            
            rotationSpeed = 75.0f;
        }

        if (score > 1500)
        {            
            rotationSpeed = 95.0f;
        }

        GameObject theplayer1 = GameObject.Find("Player");
        scoreupdt scoreScript1 = theplayer1.GetComponent<scoreupdt>();
        score = scoreScript1.scorecint;

        if (score > 150)
        {
            speed = 10;
        }

        if (score > 600)
        {
            speed = 12;
        }

        if (score > 1000)
        {
            speed = 14;
        }

        if (score > 1500)
        {
            speed = 15;
        }


        rb.velocity = new Vector2(-speed, 0);

        if (transform.position.x < screenBounds.x * -2) 
        {
            Destroy(this.gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.transform.position.x<=screenBounds.x + objwid)
        {
            if ((collision.GetType() == typeof(CircleCollider2D) && collision.tag == "Player") || collision.tag == "Syringe")
            {
                FindObjectOfType<AudioManager>().Play("CoronaDead");
                GameObject theplayer = GameObject.Find("Player");
                scoreupdt scoreScript = theplayer.GetComponent<scoreupdt>();
                scoreScript.scorecint += 10;
                Debug.Log("bonus");
                ScoreAnim.Play("ScoreEnlarge", -1, 0);

            }

            if (collision.tag != "Sanitizer")
            {
                Destroy(this.gameObject);
            }

        }                    
                
    }    

}
