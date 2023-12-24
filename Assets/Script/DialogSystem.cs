using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class DialogSystem : MonoBehaviour

{

    public Text textLabel;//文字组件

    public Image faceImage;//头像图片

    public TextAsset textFile;

    public int index;//文本内容索引+

    public Sprite face01, face02;

    public float textSpeed;

    bool textFinished;//判断是否输出完了当前行的内容

    List<string> textList = new List<string>();

    bool cancelTyping;//取消逐字打印

    public bool choice;

    public GameObject b1;
    public GameObject b2;

    public GameObject c1;
    public GameObject c2;

    public GameObject heart;

    


    public string word;

    private void Awake()

    {

        GetTextFormFile(textFile);//从文本文件中得到文本内容

    }

    private void OnEnable()

    {

        textFinished = true;//当前文本没有输出完

        StartCoroutine(SetTextUI());//获得这一行长度的每一个文字，累加输出

    }

    private void Update()

    {

        if(Input.GetMouseButtonDown(0)&&index==textList.Count)//如果按下R键，并且当前文本索引等于文本总长度

        {
            if(choice)
            {
                PlayerPrefs.SetInt("canmove",0);
                faceImage.sprite = face02;
                textLabel.text=word;
                b1.SetActive(true);
                b2.SetActive(true);
            }
            else
            {
                gameObject.SetActive(false);//销毁当前对话框

                index = 0;//索引归零
                PlayerPrefs.SetInt("canmove",1);
                                
            }
            return;
        }

        if (Input.GetMouseButtonDown(0))//按下R键

        {

            if (textFinished && !cancelTyping)//如果上一行文本输入完，并没有取消逐字打印

            {

                StartCoroutine(SetTextUI());//开启逐字打印

            }

            else if (!textFinished && !cancelTyping)//如果上一行文本没有输入完，并没有取消逐字打印

            {

                cancelTyping = true;//取消逐字打印

            }

        }

    }

        public void choose1()
    {
        
        c1.SetActive(true);
        heart.GetComponent<Heart>().heartvalue+=20;
        gameObject.SetActive(false);//销毁当前对话框
    }
        public void choose2()
    {
        
        c2.SetActive(true);
        heart.GetComponent<Heart>().heartvalue-=10;
        gameObject.SetActive(false);//销毁当前对话框
    }

    /// <summary>

    /// 把整片文件分成每一行，输出到一个列表中，再转换成文本

    /// </summary>

    /// <param name="file"></param>

    void GetTextFormFile(TextAsset file)

    {

        textList.Clear();

        index = 0;

        var lineData = file.text.Split("\n");

        foreach(var line in lineData)

        {

            textList.Add(line);

        }

    }

    /// <summary>

    /// 获得这一行长度的每一个文字，累加输出

    /// </summary>

    /// <returns></returns>

    IEnumerator SetTextUI()

    {
        
        textLabel.text = "";

        
        textFinished = false;//文本内容正在输出

        switch (textList[index].Trim().ToString())

        {

            case "A":

                faceImage.sprite = face01;

                Debug.Log("aaa");

                index++;

                break;

            case "B":

                faceImage.sprite = face02;

                index++;

                Debug.Log("bbb");

                break;

        }

        int letter = 0;

        while(!cancelTyping&&letter<textList[index].Length-1)

        {

            Debug.Log("逐字打印");

            textLabel.text += textList[index][letter];

            letter++;

            yield return new WaitForSeconds(textSpeed);

        }

        cancelTyping = false;

        textFinished = true;

        index++;

    }

}
