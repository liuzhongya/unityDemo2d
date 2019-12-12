using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour {

    public Text ScoreText;
    public Text HighScoreText;

    public int Scorenum;
    public int HighScorenum;


	void Start () {
        HighScorenum = Data.Instance.GetData();
        HighScoreText.text = "最高分数:" + HighScorenum;
	}
	
	// Update is called once per frame
	void Update () {
        AddScore();
	}
    public void AddScore()
    {
        Scorenum = Data.CoinNumber - 100 + (Data.GemNumber - 10) * 10;
        if(Scorenum>HighScorenum)
        {
            Data.Instance.SavescoreData(Scorenum);

        }
        ScoreText.text = "分数:" + Scorenum;
    }
    public void AddCoin()
    {


    }



}
