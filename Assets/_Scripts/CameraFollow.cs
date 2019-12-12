using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    //跟随人物移动，且不超出界限。
    //将人物的x轴赋给摄像机，

    public GameObject  player; //主角
    public float camerafollowspeed; //相机跟随速度

    public float minPosx;  //相机不超过背景边界允许的最小值
    public float maxPosx;//相机不超过背景边界允许的最大值

    void Update()
    {
        FixCameraPos();
    }
   void  FixCameraPos()
    {
        float pPosx = player.transform.position.x;//主角 x轴方向 时实坐标值
        float cPosX = transform.position.x;//相机 x轴方向 时实坐标值

        this.transform.position = new Vector3(player.transform  .position.x, this.transform.position.y, this.transform.position.z);   
        float realPosX = Mathf.Clamp(transform.position.x, minPosx, maxPosx);//相机X轴方向 限制移动区间，防止超过背景边界
        transform.position = new Vector3(realPosX, transform.position.y, transform.position.z);
    }

}
