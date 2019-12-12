using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour {

    private Animator anim;
    private Collider colli;
    public GameObject gem;


    private void Start()
    {
        anim = GetComponent<Animator>();
        colli = GetComponent<BoxCollider>();
        gem  = GameObject.Find("Reward/chest/gem");
    }
    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            anim.SetBool("IsOpen", true);
           //Data . CoinNumber++;
           // Debug.Log(Data.CoinNumber);
            Destroy(colli);
            Invoke("Invokegem", 0.8f);
          
        }
  
    }
     public  void Invokegem()
    {
        gem.SetActive(true);
    } 


}
