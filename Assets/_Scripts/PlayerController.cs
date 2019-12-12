using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//public enum PlayerState
//{
//    PlayerIddle,
//    PlayerRun,
//    PlayerJump
//}


public class PlayerController : MonoBehaviour {

    public float speed = 3;
    public float jumpspeed = 4;
    public float rigSpeed;
    public GameObject  cube;

    private string level;
    private bool isselectlevel = false;

    // public UiScript slider;


    private Animator anim;
    private bool isGround=false;
    private int groundLayerMsk;
  //  private PlayerState state = PlayerState.PlayerIddle;
    private float maxY = 5.8f;//跳起的最大高度
    private float minY = -5.4f;

   
    private void Start()
    {
      
        anim = GetComponent<Animator>();
        groundLayerMsk = LayerMask.GetMask("Ground");
       // 对hpslider进行赋值
      
    }
    // Update is called once per frame
    void Update () {

      //  HpSlider.value = playerHp;

        rigSpeed = GetComponent<Rigidbody>().velocity.magnitude;
      //  Debug.Log("速度为: "+rigSpeed );
        float h = Input.GetAxis("Horizontal");
        //Debug.Log("h为: " + h);

        RaycastHit hitinfo;

        //isGround = Physics.Raycast(transform.position, Vector3.down, out hitinfo,0.7f  );
        if (this.transform.localScale.x == 1)
        {
            isGround = Physics.Raycast(transform.position + Vector3.left * 0.4f, Vector3.down, out hitinfo, 1f, groundLayerMsk);
            if(hitinfo.collider != null )
            {
              //  Debug.Log(hitinfo.collider.tag);
                if (hitinfo.collider.tag == "Water")
                {
                  //   EditorApplication.isPlaying = false;
                    //Data.isWater = true;
                    //Debug.Log("游戏结束111"+ Data.isWater);
                }
            }
        }

        if (this.transform.localScale.x == -1)
        {
            isGround = Physics.Raycast(transform.position + Vector3.right * 0.4f, Vector3.down, out hitinfo, 1f, groundLayerMsk);
            if (hitinfo.collider != null)
            {
                Debug.Log(hitinfo.collider.tag);
                if (hitinfo.collider.tag == "Water")
                {
                 //     EditorApplication.isPlaying = false;
                    //Data.isWater = true;
                    //Debug.Log("游戏结束2222"+ Data.isWater);
                }
            }
        }

        // Debug.Log(isGround);




        //对动画速度条件进行赋值，并改变人物转向
        anim.SetFloat ("Speed", rigSpeed);
       if(h>0)
        {
            this.transform.localScale = new Vector3(1, 1, 1);
        }
        if(h<0)
            this.transform.localScale = new Vector3(-1, 1, 1);
        // 进行移动......
        Vector3 v = GetComponent<Rigidbody>().velocity;
      
        GetComponent<Rigidbody>().velocity = new Vector3(h * speed, v.y, v.z); 
        v = GetComponent<Rigidbody>().velocity;
        //进行跳跃........
            //判断是否在空中
        if (isGround)

            anim.SetBool("IsSky", false);
        else
            anim.SetBool("IsSky", true);


        //对动画转化条件进行赋值，使人物进行跳跃
        if (Input.GetKeyDown(KeyCode .Space )&&isGround )
        {          
                GetComponent<Rigidbody>().velocity = new Vector3(h * speed, jumpspeed, v.z);         
        }
        //限制人物跳起的最高高度
        float realY = Mathf.Clamp(transform.position.y, minY, maxY);
        this.transform.position = new Vector3(transform.position.x, realY, transform.position.z);

        if(Data.playerHp <=0)
        {
          //  EditorApplication.isPlaying = false;
            Debug.Log("游戏结束");
        }


        if (isselectlevel&&Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(level);

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        isselectlevel = true;
        Debug.Log(other.tag);
         level = other.tag.ToString();
        if (other.tag == "Level1")
            Data.currentLevel = 1;
        if (other.tag == "Level2")
            Data.currentLevel = 2;
        if (other.tag == "Level3")
            Data.currentLevel = 3;
    }
    private void OnTriggerExit(Collider other)
    {
        isselectlevel = false;
    }

}
