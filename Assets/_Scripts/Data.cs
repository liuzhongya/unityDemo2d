using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour {
    static public float playerHp = 10f;

    public static Data Instance;
    static public int CoinNumber = 100;
    static public int GemNumber = 10;
    static public int currentLevel;
   // static public bool isWater = false;

    void Awake () {
        playerHp = 10f;
       // Data.Instance = this;
        Data.Instance = this;
    }

    //保存数据的方法
    public void SavescoreData(int scorenum)
    {
        PlayerPrefs.SetInt("score", scorenum);    
    }
    public void SavecoinData(int coinnum)
    {
        PlayerPrefs.SetInt("coin", coinnum);
    }
    public void SavegemData(int gemnum)
    {
        PlayerPrefs.SetInt("coin", gemnum);
    }





    //读取数据的方法
    public int GetData()
    {
        return PlayerPrefs.GetInt("score");
    }

}
