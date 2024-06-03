using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCoronaMove : MonoBehaviour
{
    public float rotationSpeed;
    private float rot;
    public float speed = 10.0f;
    public float deathTime;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(end());
    }

    // Update is called once per frame
    void Update()
    {
       

        rot -= Time.deltaTime * rotationSpeed;

        this.transform.rotation = Quaternion.Euler(this.transform.rotation.x, -180.0f, rot);

        Vector3 Move = new Vector3(1f, 0f,0f);
        this.transform.position -= Move * speed *Time.deltaTime;  
    }

    IEnumerator end()
    {
        yield return new WaitForSeconds(deathTime);
        Destroy(this.gameObject);
    }
}
