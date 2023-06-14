using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HoleDetect : MonoBehaviour
{

    private Vector3 smallBlackHouse =new Vector3(-2,0,0);//小黑屋
    
    void OnTriggerEnter(Collider col)
    {
        //脚本挂在球上，如果如果碰到一个标签为"balls"的，则销毁ball
        if (col.gameObject.transform.parent.tag == "Balls")
        {
            //销毁本脚本所属游戏对象
            global.hole_balls++;
            


            string name = col.gameObject.name; //获取碰撞体的名称 
            string[] parts = name.Split('_'); //按照下划线分割名称 
            string n = parts[1]; //取出第二个元素，即n的值

            if(n=="W"){
                n="0";
            }

            Debug.Log("这个球进洞了"+col.gameObject.name+ "是"+n+"号球");


            // if (global.poolRules==null){
            //     global.poolRules=new PoolRules();
            // }
            global.poolRules.PocketBall(Convert.ToInt32(n));


            if(col.gameObject.name!="b_W_M"){
                col.gameObject.transform.position=smallBlackHouse;
            }
            

            //Destroy(this.gameObject, 0.5F);
            // if(global.hole_balls==6){
            //     Debug.Log("你赢了");
            // }
        }
    }
}
