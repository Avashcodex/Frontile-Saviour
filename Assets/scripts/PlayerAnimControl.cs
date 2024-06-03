using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAnimControl : MonoBehaviour
{

    public Animation anim; 

    // Start is called before the first frame update
    void Start()
    {
        anim.Play("FlyAnimation");
        anim.Stop("FlyAnimation");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
