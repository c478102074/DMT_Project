using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public static move instance;
    public float forceCounter;
    public float xforce;
    public float yforce;
    public float max;
    public Rigidbody2D rb;
    public Animator anim;
    public float xVelocity;
    public float speed;

    public GameObject bar;
    public Transform Bar;

    public float knockBackLength;
    public float knockBackCounter;
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(knockBackCounter <= 0)
        {
            xVelocity = Input.GetAxisRaw("Horizontal");  //可改其他速度变化模式GetAxis
            if (xVelocity < 0)
                transform.localScale = new Vector3(-1, 1, 0);
            if (xVelocity > 0)
                transform.localScale = new Vector3(1, 1, 0);

            rb.velocity = new Vector2(xVelocity * speed, rb.velocity.y);
            anim.SetFloat("moveSpeed", Mathf.Abs(xVelocity));

            if (Input.GetKey("space"))
            {
                bar.SetActive(true);
                forceCounter += Time.deltaTime;
                if (forceCounter >= max)
                    forceCounter = max;
                Bar.localScale = new Vector3(forceCounter / max, 1, 0);
                Bar.position = new Vector3(transform.position.x - (1 - forceCounter / max) / 2f, transform.position.y + 1f, 0);

            }
            if (Input.GetKeyUp("space"))
            {
                rb.velocity = new Vector2(transform.localScale.x * xforce, yforce * forceCounter);
                forceCounter = 0f;
                bar.SetActive(false);
            }
        }
        else
        {
            knockBackCounter -= Time.deltaTime;

            rb.velocity = new Vector2(12f, rb.velocity.y);
        }
        
    }
    public void knockBakc()
    {
        knockBackCounter = knockBackLength;
        rb.velocity = new Vector2(0f,20f);
    }
}
