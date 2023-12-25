using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float directin;
    public Transform rightPoint;
    public Transform leftPoint;
    public Animator anim;
    public float speed;
    void Start()
    {
        rightPoint.parent = null;
        leftPoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(directin * speed * Time.deltaTime, 0f, 0f);
        anim.SetBool("isMove", true);
        if (transform.position.x > rightPoint.position.x || transform.position.x < leftPoint.position.x)
        {
            
            directin *= -1;
            transform.localScale = new Vector3(directin, 1, 0);
        }
    }
}
