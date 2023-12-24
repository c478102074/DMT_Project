using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class PlayVideoOnKeyPress : MonoBehaviour
{
    public GameObject viedo;
    private bool tennis = false;

    public GameObject boy;
    public GameObject girl;

    public GameObject talkUI;
    public GameObject heart;
    public Transform position;

    public Sprite down;

    private bool play = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!play)
        {
            PlayerPrefs.SetInt("canmove", 0);
            heart.SetActive(false);
            viedo.SetActive(true);
            Invoke("stopViedo", 2.0f);
            play = true;
        }


    }
    void stopViedo()
    {
        viedo.SetActive(false);
        PlayerPrefs.SetInt("canmove", 1);
        if (!tennis)
        {
            boy.SetActive(true);
            talkUI.SetActive(true);
            tennis = true;
            heart.SetActive(true);
            girl.transform.position = position.position;
            Animator ani = girl.GetComponent<Animator>();
            ani.SetFloat("Vertical", -1);
            ani.SetFloat("Horizontal", 0);
        }
    }
}
