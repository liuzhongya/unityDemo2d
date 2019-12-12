using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Coin : MonoBehaviour {

    //自动生成金币，TODO

    //触碰金币，增加金币数量，同时销毁金币



    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player"&&this.gameObject.tag=="Coin")
        {
            Data.CoinNumber++;
            Debug.Log(Data.CoinNumber);           
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "Player" && this.gameObject.tag == "Gem")
        {
            Data.GemNumber++;
            Debug.Log(Data.GemNumber);
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag == "Player" && this.gameObject.tag == "Cherry")
        {
            Data.playerHp =Mathf.Clamp(Data.playerHp +5,-1,10);
            Debug.Log("增加血量5");
            Destroy(this.gameObject);
        }

    }
    public void OnTriggerExit(Collider other)
    { }




}
