using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class customJoy : MonoBehaviour
{
    public Transform player;
    public float speed = 5.0f;
    private int score;
      


    // Update is called once per frame
    void Update()
    {
        GameObject theplayer = GameObject.Find("Player");
        scoreupdt scoreScript = theplayer.GetComponent<scoreupdt>();
        score = scoreScript.scorecint;

        if (score > 150)
        {
            speed = 8;
        }

        if (score > 600)
        {
            speed = 10;
        }

        if (score > 1000)
        {
            speed = 12;
        }

        if (score > 1500)
        {
            speed = 13;
        }
    }
    private void FixedUpdate()
    {

            float inputx = Input.GetAxis("Horizontal");
            float inputy = Input.GetAxis("Vertical");
            
            Vector2 direction =new Vector2(inputx,inputy);
        
            player.Translate(direction * speed * Time.deltaTime);

    }
  

   
}