using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DayNightCycle : MonoBehaviour
{

    [SerializeField] private Gradient lightColour;
    [SerializeField] private GameObject light;

    private int days;
    public int Days => days;
    private float time = 0;
    private bool canChangeDay = true;


    // Update is called once per frame
    void Update()
    {
        if (time>500)
        {
            time = 0;
        }

        if ((int)time == 250 && canChangeDay)
        {
            canChangeDay = false;
            days++;
        }

        if ((int)time == 255)
        {
            canChangeDay = true;
        }


        time += Time.deltaTime;
        light.GetComponent<UnityEngine.Rendering.Universal.Light2D>().color = lightColour.Evaluate(time * 0.002f);

        
    }  

}
