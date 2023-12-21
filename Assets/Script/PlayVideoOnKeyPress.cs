using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class PlayVideoOnKeyPress : MonoBehaviour
{
    public GameObject viedo;
     

    void Start()
    {
        
        
    }
    void Update()
    {
        // 在按下指定按键时播放视频
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayVideo();
        }
    }

    void PlayVideo()
    {
        viedo.SetActive(true);
        Invoke("stopViedo", 4.0f);
    }
    void stopViedo()
    {
        viedo.SetActive(false);
    }
}
