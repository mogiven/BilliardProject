using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class global : MonoBehaviour
{
    //当前总共的进球数
    public static int hole_balls= 0;
    //球杆是否拿在手上
    public static int is_hold=1;
    //球杆移动方向
    public static Vector3 move_forward_direction;

    //出杆数
    public static int stick_attacks= 0;

    //定义静态规则类
    public static PoolRules poolRules =new PoolRules();

}
