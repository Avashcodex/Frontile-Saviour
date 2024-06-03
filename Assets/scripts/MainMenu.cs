using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Animator transition;
    public GameObject HelpMenu;
    public GameObject CredMenu;
    public Text HighScore;
    public GameObject hs;

    private void Start()
    {
        if (PlayerPrefs.GetInt("BestScore", 0) > 3)
        {
            hs.SetActive(true);
            HighScore.text = PlayerPrefs.GetInt("BestScore", 0).ToString();
        }
    }
    public void StartGame()
    {
        StartCoroutine(PlayGame());
                
    }
    IEnumerator PlayGame()
    {
        transition.SetTrigger("TriggerCrossfade");

        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        FindObjectOfType<AudioManager>().Play("Click2");
        Application.Quit();
    }

    public void openHelp()
    {
        FindObjectOfType<AudioManager>().Play("Click1");
        HelpMenu.SetActive(true);        
    }

    public void closeHelp()
    {
        FindObjectOfType<AudioManager>().Play("Click2");
        HelpMenu.SetActive(false);
    }

    public void openCred()
    {
        FindObjectOfType<AudioManager>().Play("Click1");
        CredMenu.SetActive(true);
    }

    public void closeCred()
    {
        FindObjectOfType<AudioManager>().Play("Click2");
        CredMenu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (CredMenu.activeInHierarchy)
            {
                closeCred();
            }
            if (HelpMenu.activeInHierarchy)
            {
                closeHelp();
            }
           
        }
    }

}
