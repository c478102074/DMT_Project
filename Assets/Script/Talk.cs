using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
public class Talk : MonoBehaviour

{


    
    public GameObject talkUI;
    
    bool taklornot=false;
    private void OnTriggerEnter2D(Collider2D other)
    {

        if(!taklornot)
        {
            talkUI.SetActive(true);
            taklornot=true;
            PlayerPrefs.SetInt("canmove",0);
        }
        
    }

}
