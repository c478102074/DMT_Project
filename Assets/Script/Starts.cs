using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starts : MonoBehaviour
{
    public GameObject viedo;

    public GameObject ui;

    public GameObject heart; 

    bool viedoplay=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)&&!viedoplay)
        {
                viedo.SetActive(true);
                Invoke("wait", 0.6f);
                Invoke("stopViedo", 2.4f);
                viedoplay=true;
                
        }
    }
    void wait()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled=false;
    }
    void stopViedo()
    {
        viedo.SetActive(false);
        ui.SetActive(true);
        heart.SetActive(true);
    }
}
