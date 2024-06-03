using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour {

	public float speed;
	private float x;
	public float PointDestination;	
	private float width;
	private int score;



	// Use this for initialization
	void Start () {

		width = GetComponent<SpriteRenderer>().bounds.size.x;
		

	}
	
	// Update is called once per frame
	void Update () {


		GameObject theplayer = GameObject.Find("Player");
		scoreupdt scoreScript = theplayer.GetComponent<scoreupdt>();
		score = scoreScript.scorecint;

		if (score == 20)
		{
			speed-= 0.005f;
		}

		if (score == 50)
		{
			speed-= 0.005f;
		}

		if (score == 100)
		{
			speed-= 0.005f;
		}


		x = transform.position.x;
		x += speed * Time.deltaTime;
		transform.position = new Vector3 (x, transform.position.y, transform.position.z);



		if (x <= PointDestination)
		{			
			x = x+(width*3-0.15f);
			transform.position = new Vector3 (x, transform.position.y, transform.position.z);
		}	


	}
}
