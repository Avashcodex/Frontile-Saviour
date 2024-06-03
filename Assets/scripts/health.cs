
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class health : MonoBehaviour
{

	public Image fullheart1;
	public Image fullheart2;
	public Image fullheart3;
	public Image emptyheart1;
	public Image emptyheart2;
	public Image emptyheart3;
	private int playerLife;
	private int flag;

	void Update()
	{
		GameObject theplayer = GameObject.Find("Player");
		scoreupdt scoreScript = theplayer.GetComponent<scoreupdt>();
		playerLife = scoreScript.lifeCount;
		flag = this.GetComponent<collision>().flag;
	}


	private void OnTriggerEnter2D(Collider2D other)
	{
			
			if (other.CompareTag("enemy") && flag==1)
			{

				if (playerLife == 3)
				{

					fullheart1.enabled = true;
					fullheart2.enabled = true;
					fullheart3.enabled = false;

				}


				if (playerLife == 2)
				{

					fullheart1.enabled = true;
					fullheart2.enabled = false;
					fullheart3.enabled = false;

				}


				if (playerLife <= 1)
				{

					fullheart1.enabled = false;
					fullheart2.enabled = false;
					fullheart3.enabled = false;

				}

			}


		
		
	}


}