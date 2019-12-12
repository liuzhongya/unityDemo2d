using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {      
            Debug.Log("收到伤害");          
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            int sj= Random.Range(2, 4);
            Data.playerHp = Data.playerHp - sj;            
                Debug.Log("收到伤害 " + sj +" 剩余生命 " + Data.playerHp);
        }
    }
}
