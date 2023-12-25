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

    public bool tennis;

    public bool canteen;


    public float timeclose=2.0f;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!play)
        {
            if(canteen)
            {
                gameObject.GetComponent<Animator>().SetBool("colide",true);
                Invoke("playViedo", 1.0f);

                return;
            }

            
            PlayerPrefs.SetInt("canmove", 0);
            heart.SetActive(false);
            music.GetComponent<AudioSource>().mute=true;
            
            viedo.SetActive(true);
            Invoke("stopViedo", timeclose);
            play = true;
            
        }
    }

    void playViedo()
    {
            PlayerPrefs.SetInt("canmove", 0);
            heart.SetActive(false);
            music.GetComponent<AudioSource>().mute=true;
            
            viedo.SetActive(true);
            Invoke("stopViedo", timeclose);
            play = true;
    }
    void stopViedo()
    {
        viedo.SetActive(false);
        music.GetComponent<AudioSource>().mute=false;
        PlayerPrefs.SetInt("canmove", 1);

        if (tennis)
        {
            talkUI.SetActive(true);
             heart.SetActive(true);
            boy.SetActive(true);
            girl.transform.position = position.position;
        }
        if(canteen)
        {
            talkUI.SetActive(true);
            heart.SetActive(true);
            gameObject.GetComponent<SpriteRenderer>().enabled=false;
            gameObject.GetComponent<Animator>().enabled=false;
        }
    }
}
