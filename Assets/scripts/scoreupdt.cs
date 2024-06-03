using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class scoreupdt : MonoBehaviour
{

	public int scorecint = 0;
	public int lifeCount = 3;
	private int hs;
	public Text scoreCount;
	public Text endScore;
	public Text HighScore;
	[SerializeField] private GameObject uiStarter;
	private int flag;
	public GameObject PauseButton;
	public GameObject SryringeAttackButton;
	public GameObject ScoreUi;
	public GameObject HighScoreIcon;
	public Animator transition;
	public Animator AlphaCan;

	private customJoy joyScript;
	public GameObject cam;


	void Start()
	{
		
		StartCoroutine(ScoreUpdator());
		HighScore.text = "BEST :  "+PlayerPrefs.GetInt("BestScore", 0).ToString();
		joyScript = cam.GetComponent<customJoy>();

	}

    private void Update()
    {
		flag = this.GetComponent<collision>().flag;
		scoreCount.text = scorecint.ToString("0");

	}

    private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("enemy") && flag==1)
		{
			lifeCount -= 1;
			FindObjectOfType<AudioManager>().Play("PlayerHit");

			if (lifeCount <= 0)
			{
				this.GetComponent<PolygonCollider2D>().enabled = false;				
				StopCoroutine(ScoreUpdator());
				endScore.text = scorecint.ToString("0");
				
				uiStarter.SetActive(true);
				PauseButton.SetActive(false);
								
				ScoreUi.SetActive(false);
				Debug.Log("end");

				/*stop movement , collisions*/

				joyScript.enabled = false;				
				


                if (scorecint > PlayerPrefs.GetInt("BestScore", 0))
                {
					PlayerPrefs.SetInt("BestScore", scorecint);
					
					HighScoreIcon.SetActive(true);

					HighScore.enabled = false;

				}
                else
                {
					
					Debug.Log("yes");
				}

				HighScore.text = "BEST :  " + PlayerPrefs.GetInt("BestScore", 0).ToString();


			}
			
		}
	}
	
	IEnumerator ScoreUpdator()
	{
		yield return new WaitForSeconds(1);
		scorecint += 1;
		scoreCount.text = scorecint.ToString("0");
		StartCoroutine(ScoreUpdator());
	}

	public void RestartButton()
	{
		FindObjectOfType<AudioManager>().Play("Click2");
		ScoreUi.GetComponent<Text>().enabled = false;
		ScoreUi.SetActive(true);
		StartCoroutine(resbut());
	}

	IEnumerator resbut()
    {
		transition.SetTrigger("Start");
		AlphaCan.SetTrigger("StartAlpha");

		yield return new WaitForSeconds(0.5f);

		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
	
	public void MainMenuButton()
    {
		SceneManager.LoadScene(0);
		Time.timeScale = 1.0f;
    }

}