using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelloadscript : MonoBehaviour
{

    public Animator transition;
   
    public float transitionTime = 0.5f;
    
  
    public void loadlevel()
    {
        FindObjectOfType<AudioManager>().Play("Click2");

        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            StartCoroutine(Leveler(1));
        }
        else
        {
            StartCoroutine(Leveler(0));
        }
    }

   IEnumerator Leveler(int n)
    {
        transition.SetTrigger("Start");
       

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(n);
    }
}
