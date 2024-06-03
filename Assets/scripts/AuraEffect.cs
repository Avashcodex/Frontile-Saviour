using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuraEffect : MonoBehaviour
{
    public GameObject player;
    
    void Update()
    {
        this.transform.position = player.transform.position + new Vector3(0.0f, 0.0f, -5.3f);
    }
}
