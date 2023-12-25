using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float forceCounter;
    public float xforce;
    public float yforce;
    public float max;
    public Rigidbody2D rb;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("a")) 
            transform.localScale = new Vector3(-1, 1, 0);
        if (Input.GetKey("d"))
            transform.localScale = new Vector3(1, 1, 0);
        if (Input.GetKey("space"))
        {
            forceCounter += Time.deltaTime;
            if (forceCounter >= max)
                forceCounter = max;
        }
            
        if(Input.GetKeyUp("space"))
        {
            rb.velocity = new Vector2(transform.localScale.x * xforce, yforce * forceCounter);
            forceCounter = 0f;
        }
           


    }
}
