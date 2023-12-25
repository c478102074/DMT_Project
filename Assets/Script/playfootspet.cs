using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playfootspet : MonoBehaviour
{
    public AudioSource foot1;

    public AudioSource foot2;
    

    public void footstep1()
    {
        foot1.Play();       
    }
    public void footstep2()
    {
        foot2.Play();       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
