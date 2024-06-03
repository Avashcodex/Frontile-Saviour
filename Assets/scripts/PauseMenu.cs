using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public RainEffect RainScript;
    public Text ThreeCount;
    public static bool gamePaused = false;
    public Animator transition;
    public Animator AlphaCan;
    public collision collisionScript;
    private bool auraStatus;
    private bool rainStatus;

    private void Update()
    {
        auraStatus = collisionScript.AuraOn;
        rainStatus = RainScript.RainOn;
    }
    public void Pause()
    {

        FindObjectOfType<AudioManager>().Play("Click1");
        FindObjectOfType<AudioManager>().Pause("CoronaGoThemeSong");
        FindObjectOfType<AudioManager>().Pause("Rain");
        FindObjectOfType<AudioManager>().Pause("Aura");
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
        
    }

    public void Resume()
    {
        FindObjectOfType<AudioManager>().Play("Click2");
        FindObjectOfType<AudioManager>().Play("CoronaGoThemeSong");
        if (auraStatus)
        {
            FindObjectOfType<AudioManager>().Play("Aura");
        }
        if (rainStatus)
        {
            FindObjectOfType<AudioManager>().Play("Rain");
        }
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;                
        gamePaused = false;
    }

    public void startMainMenu()
    {
        FindObjectOfType<AudioManager>().Play("Click2");
        StartCoroutine(MainMenu());
        Time.timeScale = 1f;
    }

    IEnumerator  MainMenu()
    {
        transition.SetTrigger("Start");
        AlphaCan.SetTrigger("StartAlpha");

        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }  
    
}
