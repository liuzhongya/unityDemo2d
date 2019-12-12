using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    private float Enemyspeed=2.5f;
    private bool IsWall = false;
    private int wallLayerMsk;


	void Start () {
        wallLayerMsk = LayerMask.GetMask("Wall");
    }

   
    void Update () {
        Vector3 v = GetComponent<Rigidbody>().velocity;
        RaycastHit hitnfo;

        //控制检测方向
        if (this.tag == "Enemy2")
        {
            if (this.transform.localScale.x < 0)
                IsWall = Physics.Raycast(transform.position, Vector3.left, out hitnfo, 1f, wallLayerMsk);
            if (this.transform.localScale.x > 0)
                IsWall = Physics.Raycast(transform.position, Vector3.right, out hitnfo, 1f, wallLayerMsk);

          //  Debug.Log("  " + IsWall);
        }
        else
        {

            if (this.transform.localScale.x > 0)
                IsWall = Physics.Raycast(transform.position, Vector3.left, out hitnfo, 1f, wallLayerMsk);
            if (this.transform.localScale.x < 0)
                IsWall = Physics.Raycast(transform.position, Vector3.right, out hitnfo, 1f, wallLayerMsk);

           // Debug.Log("  " + IsWall);
        }


        //控制移动方向
        if (this.tag == "Enemy2")
        {
            if (this.transform.localScale.x < 0)
                GetComponent<Rigidbody>().velocity = new Vector3(-Enemyspeed, v.y, v.z);
            else
                GetComponent<Rigidbody>().velocity = new Vector3(Enemyspeed, v.y, v.z);

            if (IsWall)   //控制人物转向和速度方向一致
            {
                this.transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
        }
        else
        {
            if (this.transform.localScale.x > 0)
                GetComponent<Rigidbody>().velocity = new Vector3(-Enemyspeed, v.y, v.z);
            else
                GetComponent<Rigidbody>().velocity = new Vector3(Enemyspeed, v.y, v.z);

            if (IsWall)   //控制人物转向和速度方向一致
            {
                this.transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            int sj = Random.Range(2, 4);
            Data.playerHp = Data.playerHp - sj;
            Debug.Log("收到伤害2  " + sj + " 剩余生命 " + Data.playerHp);
        }
    }





}
