using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class PlayVideoOnKeyPress : MonoBehaviour
{
    public GameObject viedo;
    public GameObject boy;
    public GameObject girl;

    public GameObject talkUI;
    public GameObject heart;

    public Transform position;

    public GameObject music;

    private bool play = false;

    private int i=0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!play)
        {
            PlayerPrefs.SetInt("canmove", 0);
            heart.SetActive(false);
            music.GetComponent<AudioSource>().mute=true;
            
            viedo.SetActive(true);
            Invoke("stopViedo", 2.0f);
            play = true;
        }


    }
    void stopViedo()
    {
        viedo.SetActive(false);
        music.GetComponent<AudioSource>().mute=false;
        PlayerPrefs.SetInt("canmove", 1);

        if (i==0)
        {
            talkUI.SetActive(true);
             heart.SetActive(true);
            boy.SetActive(true);
            i++;
            girl.transform.position = position.position;
        }
        if(i==1)
        {
            talkUI.SetActive(true);
            heart.SetActive(true);
            i++;
        }
    }
}
