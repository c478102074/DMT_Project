using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
    public int heartvalue=20;

    public Text heart;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        heart.text=heartvalue.ToString("0")+"%";
    }
}
