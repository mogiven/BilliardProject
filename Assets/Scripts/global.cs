using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class global : MonoBehaviour
{

    //球杆是否拿在手上,1为在手中,0为在自动移动，-1为手动操纵移动,-2不动
    public static int is_hold=-2;
    //球杆移动方向
    public static Vector3 move_forward_direction;

    //出杆数
    public static int stick_attacks= 0;

    //鼠标的移动速度
    public static Vector3 mouseVelocity;

    //定义静态规则类
    public static PoolRules poolRules =new PoolRules();


    //当前总共的出杆数
    public static int hole_balls= 0;
    //声明一个委托类型，用于定义事件处理器的签名
    public delegate void HoleBallsChangedHandler(int oldValue, int newValue);

    //声明一个静态事件，用于通知global.hole_balls的变化
    public static event HoleBallsChangedHandler HoleBallsChanged;

    //声明一个公共静态属性，用于获取或设置global.hole_balls的值
    public static int GlobalHoleBalls
    {
        get
        {
            //返回私有变量的值
            return hole_balls;
        }
        set
        {
            //如果新值和旧值不同
            if (value != hole_balls)
            {
                //保存旧值
                int oldValue = hole_balls;

                //更新私有变量的值
                hole_balls = value;

                //Debug.Log("将触发事件");

                //触发事件，传递旧值和新值
                HoleBallsChanged?.Invoke(oldValue, value);
            }
        }
    }






    //得分数
    public static int goalsNum =0;

    //声明一个委托类型，用于定义委托的签名
    public delegate void GoalsNumChangedHandler(int oldValue, int newValue);
    //声明一个静态事件，用于通知global.goalsNum的变化
    public static event GoalsNumChangedHandler GoalsNumChanged;
    //声明一个公共静态属性，用于获取或设置global.hole_balls的值
    public static int GlobalGoalsNum
    {
        get
        {
            //返回私有变量的值
            return goalsNum;
        }
        set
        {
            //如果新值和旧值不同
            if (value != goalsNum)
            {
                //保存旧值
                int oldValue = goalsNum;

                //更新私有变量的值
                goalsNum = value;

                //Debug.Log("将触发事件");

                //触发事件，传递旧值和新值
                GoalsNumChanged?.Invoke(oldValue, value);
            }
        }
    }



    //玩家类型，0表示无效，1表示全色球,2表示条纹球
    public static int playerType= 0;
    //声明一个委托类型，用于定义事件处理器的签名
    public delegate void PlayerTypeChangedHandler(int oldValue, int newValue);

    //声明一个静态事件，用于通知global.playerType的变化
    public static event PlayerTypeChangedHandler PlayerTypeChanged;

    //声明一个公共静态属性，用于获取或设置global.playerType的值
    public static int GlobalPlayerType
    {
        get
        {
            //返回私有变量的值
            return playerType;
        }
        set
        {
            //如果新值和旧值不同
            if (value != playerType)
            {
                //保存旧值
                int oldValue = playerType;

                //更新私有变量的值
                playerType = value;

                //Debug.Log("将触发事件");

                //触发事件，传递旧值和新值
                PlayerTypeChanged?.Invoke(oldValue, value);
            }
        }
    }



    //是否显示结果，0表示不显示，1表示成功,2表示失败
    public static int winOrLose= 0;
    //声明一个委托类型，用于定义事件处理器的签名
    public delegate void WinOrLoseChangedHandler(int oldValue, int newValue);

    //声明一个静态事件，用于通知global.playerType的变化
    public static event WinOrLoseChangedHandler WinOrLoseChanged;

    //声明一个公共静态属性，用于获取或设置global.winOrLose的值
    public static int GlobalWinOrLose
    {
        get
        {
            //返回私有变量的值
            return winOrLose;
        }
        set
        {
            //如果新值和旧值不同
            if (value != winOrLose)
            {
                //保存旧值
                int oldValue = winOrLose;

                //更新私有变量的值
                winOrLose = value;

                //Debug.Log("将触发事件");

                //触发事件，传递旧值和新值
               WinOrLoseChanged?.Invoke(oldValue, value);
            }
        }
    }



}
