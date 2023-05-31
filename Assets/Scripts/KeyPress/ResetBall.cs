using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBall : MonoBehaviour
{

    //声明一个列表来存储球的游戏对象
    private List<GameObject> balls = new List<GameObject>();
    //声明一个列表来存储球的初始位置
    private List<Vector3> positions = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        //获取PoolBallSet节点的Transform组件
        Transform poolBallSet = GameObject.Find("PoolBallSet01").transform;

        //遍历PoolBallSet节点的子节点，即所有的球
        for(int i = 0; i < poolBallSet.childCount; i++)
        {
            //获取第i个子节点的游戏对象
            GameObject ball = poolBallSet.GetChild(i).gameObject;

            //将球的游戏对象添加到balls列表中
            balls.Add(ball);

            //将球的初始位置添加到positions列表中
            positions.Add(ball.transform.position);
        }
    }

    void Update() { 
        //检测R键的按下 
        if(Input.GetKeyDown(KeyCode.R)) { 
            //调用ResetBalls函数
            ResetBalls();
        }
    }

    void ResetBalls()
    {
    //遍历balls列表中的每个球
    for(int i = 0; i < balls.Count; i++)
    {
        //获取第i个球的游戏对象
        GameObject ball = balls[i];

        //获取第i个球的初始位置
        Vector3 position = positions[i];

        //将第i个球的位置设置为初始位置
        ball.transform.position = position;

        //将第i个球的速度设置为零
        ball.GetComponent<Rigidbody>().velocity = Vector3.zero;

        //将第i个球的角速度设置为零
        ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

    }
    }
}
