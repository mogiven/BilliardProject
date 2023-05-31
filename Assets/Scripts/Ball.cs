using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        //脚本挂在球上，如果如果碰到一个标签为"Tag_Hol"的，则自身销毁
        if (col.gameObject.tag == "Tag_Hole")
        {
            //销毁本脚本所属游戏对象
            global.hole_balls++;
            Destroy(this.gameObject, 0.5F);
            if(global.hole_balls==6){
                Debug.Log("你赢了");
            }
        }
    }

}
