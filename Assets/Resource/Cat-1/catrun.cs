using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catrun : MonoBehaviour
{
    public static catrun insatnce;
    public float speed;
    public bool go;
    public Animator anim;
    public Transform rightPoint;
    void Start()
    {
        insatnce = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (go)
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);
            anim.SetBool("go", true);
        }
            
        if(transform.position.x > rightPoint.position.x)
        {
            go = false;
            anim.SetBool("go", false);
        }
    }
}
