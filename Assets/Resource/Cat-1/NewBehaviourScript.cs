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
    public float time1;
    public float time2;
    public float counter1;
    public float counter2;
    void Start()
    {
        rightPoint.parent = null;
        leftPoint.parent = null;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (counter1 > 0)
        {
            transform.position += new Vector3(directin * speed * Time.deltaTime, 0f, 0f);
            anim.SetBool("isMove", true);
            if (transform.position.x > rightPoint.position.x || transform.position.x < leftPoint.position.x)
            {
                directin *= -1;
                transform.localScale = new Vector3(directin, 1, 0);
            }
            counter1 -= Time.deltaTime;
            counter2 = time2;
        }
        else
        {
            if (counter2 > 0)
            {
                counter2 -= Time.deltaTime;
                anim.SetBool("isMove", false);
            }
            else
            {
                counter1 = time1;
            }
            

        }
        
    }

    
}
