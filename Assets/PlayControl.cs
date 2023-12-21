using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayControl : MonoBehaviour
{
    public float moveSpeed=0.3f;
    private Animator ani;
    private Rigidbody2D rBody;
    void Start()
    {
        ani=GetComponent<Animator>();
        rBody=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal=Input.GetAxisRaw("Horizontal");
        float vertical=Input.GetAxisRaw("Vertical");
        if(horizontal!=0)
        {
            ani.SetFloat("Vertical",0);
            ani.SetFloat("Horizontal",horizontal);
        }
        if(vertical!=0)
        {
            ani.SetFloat("Vertical",vertical);
            ani.SetFloat("Horizontal",0);
        }

        Vector2 dir=new Vector2(horizontal,vertical);
        ani.SetFloat("Speed",dir.magnitude);

        rBody.velocity=dir*moveSpeed;
    }
}
