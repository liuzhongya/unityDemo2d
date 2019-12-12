using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiScript : MonoBehaviour {

    public Text coinnumber;
    public Text gemnumber;
  //  public Text IsRestartimage;
    private string MainDemo;
    private bool isPause=false;
    public  GameObject IsRestartimage;
    public GameObject IsReturnMaintimage;

    public Image puseImage;
    public Sprite pauseSprite;
    public Sprite startSprite;
    public GameObject IsPuseImage;

    public GameObject IsGameWin;
    public GameObject IsGameOver;
    public GameObject game;

    private Slider HpSlider;


    private void Start()
    {
        coinnumber = GameObject.Find("Canvas/dataImage/Coin/Text").GetComponent<Text>();
        gemnumber = GameObject.Find("Canvas/dataImage/Gem/Text").GetComponent<Text>();
        IsRestartimage = GameObject.Find("Canvas/Istrue");
        IsReturnMaintimage = GameObject.Find("Canvas/IsReturnMain");

        puseImage =GameObject.Find("Canvas/PauseButtton").GetComponent<Image>();
        IsPuseImage = GameObject.Find("Canvas/PauseButtton/Image");

        IsGameWin = GameObject.Find("Canvas/gameOver/GameWin");
        IsGameOver = GameObject.Find("Canvas/gameOver/Gameover");
        game = GameObject.Find("Canvas/gameOver");

        HpSlider = GameObject.Find("Canvas/dataImage/Slider").GetComponent<Slider>();

        //startSprite= Resources.Load("Iconic2048x2048", typeof(Sprite)) as Sprite;  //无法查询到子文件
        //pauseSprite = Resources.Load("Iconic2048x2048", typeof(Sprite)) as Sprite;
    }
    private void Update()
    {
        GetCoinAndGemNumber();
        SubmitSliderSetting();
    }
    public    void StartGame()
    {
        SceneManager.LoadScene("Level1");
       // SceneManager.LoadScene("MainDemo");
    }
    public void GetCoinAndGemNumber()
    {
        coinnumber.text = Data.CoinNumber.ToString();
        gemnumber.text = Data.GemNumber.ToString();
    }
    public void  OnPauseButton()  //暂停函数
    {
        if (isPause==false)
        {
            Debug.Log("暂停");
            puseImage.sprite = pauseSprite;
            IsPuseImage.transform.GetComponent<RectTransform>().Translate(Vector3.right * 1400);

            Time.timeScale = 0;
            isPause = true;
            return ;
        }
      if(isPause)
        {
            puseImage.sprite = startSprite;
            IsPuseImage.transform.GetComponent<RectTransform>().Translate(Vector3.left * 1400);

            Debug.Log("结束暂停");
            Time.timeScale = 1;
            isPause = false;
            return;
        }
     
    }
    public void OnVoiceButton()  //静音
    {

    }
    public void OnResatrtButton()//重新开始响应函数
    {
        Time.timeScale = 0;
        IsRestartimage.transform.GetComponent<RectTransform>().Translate(Vector3.right * 2300);

    }
    public void OnYesRestartButton()//确定重新开始响应函数
    {
        IsRestartimage.transform.GetComponent<RectTransform>().Translate(Vector3.left * 2300);
        Time.timeScale = 1;
        Data.CoinNumber = 100;
        Data.GemNumber = 10;
        SceneManager.LoadScene("Level"+ Data.currentLevel );
    }
    public void OnCancelButton()
    {
        IsRestartimage.transform.GetComponent<RectTransform>().Translate(Vector3.left * 2300);
        Time.timeScale = 1;
    }

    //控制滑动条的变化，
    public void SubmitSliderSetting()
    {
        HpSlider.value = 1 - Data.playerHp / 10.0f;
        //  Debug.Log(HpSlider.value);
    }
    //进入下一关
    public void OnYesEnterNextButton()
    {

        //直接进行确定键的复制进行场景跳转即可
        //思路需要有一个参数对当前是第几关进行判断，以便在跳转的时候可以跳转到下一关。
        Time.timeScale = 1;
        Data.CoinNumber = 100;
        Data.GemNumber = 10;
        int nextlevel = Data.currentLevel + 1;
        SceneManager.LoadScene("Level" + nextlevel);

    }





    //返回主界面
    public void OnReturnMainScenceButton()
    {
        // SceneManager.LoadScene("StartGame");
        IsReturnMaintimage.transform.GetComponent<RectTransform>().Translate(Vector3.right * 2300);
        Time.timeScale = 1;

    }
    public void OnYesReturnMainScenceButton()
    {
        SceneManager.LoadScene("StartGame");      
    }
    public void OnCancelReturnMainScenceButton()
    {
        // SceneManager.LoadScene("StartGame");
        IsReturnMaintimage.transform.GetComponent<RectTransform>().Translate(Vector3.left * 2300);
        Time.timeScale = 1;

    }



}
