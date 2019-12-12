using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Water : MonoBehaviour
{


    public GameObject gamewin;
    public GameObject gameover;
    public GameObject game;




    void Start()
    {
        gamewin = GameObject.Find("Canvas/gameOver/GameWin");
        gameover = GameObject.Find("Canvas/gameOver/Gameover");
        game = GameObject.Find("Canvas/gameOver");
    }

    // Update is called once per frame
    void Update()
    {
        //如果使用Updata进行判断，浪费资源且会进行二次判断， 可尝试使用触发器或colliter进行判断
        //if (Data.isWater)
        //{
        //    gamewin.SetActive(false);
        //    Time.timeScale = 0;
        //    game.transform.GetComponent<RectTransform>().Translate(Vector3.right * 2300);
        //    Debug.Log("游戏结束3333" + Data.isWater);
        //    this.enabled = false;
        //    Data.isWater = false;
        //}

    }
    private void OnCollisionEnter(Collision collision)
    {
       if( collision.collider.tag == "Water")
        {
            gamewin.SetActive(false);
            Time.timeScale = 0;
            game.transform.GetComponent<RectTransform>().Translate(Vector3.right * 2300);

         //   this.enabled = false;
        }

    }



    public void OnWaterYesRestartButton()//确定重新开始响应函数
    {
        game.transform.GetComponent<RectTransform>().Translate(Vector3.left * 2300);
        
        Time.timeScale = 1;
        Data.CoinNumber = 100;
        Data.GemNumber = 10;
      
        SceneManager.LoadScene("Level" + Data.currentLevel);
    }
}
