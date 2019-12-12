using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWin : MonoBehaviour {


    public  GameObject gamewin;
    public GameObject gameover;
    public GameObject game;



    private void Start()
    {
        gamewin = GameObject.Find("Canvas/gameOver/GameWin");
        gameover = GameObject.Find("Canvas/gameOver/Gameover");
        game = GameObject.Find("Canvas/gameOver");
    }

    private void Update()
    {
        if (Data.playerHp<=0) 
        {
            gamewin.SetActive(false);
            Time.timeScale = 0;
            game.transform.GetComponent<RectTransform>().Translate(Vector3.right * 2300);
            this.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        gameover.SetActive(false);
        Time.timeScale = 0;
        game.transform.GetComponent<RectTransform>().Translate(Vector3.right * 2300);
    }
}
