using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFriction : MonoBehaviour
{
    //定义刚体组件
    private Rigidbody rb;
    //定义速度变量
    private Vector3 velocity;
    //定义摩擦力系数
    public float friction = 0.1f;
    //定义摩擦力加速度
    public float frictionAcc = 1f;

    //在开始时获取刚体组件
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    //每帧更新速度和摩擦力
    void Update()
    {
        //获取当前速度
        velocity = rb.velocity;
        //如果速度不为零
        if (velocity != Vector3.zero)
        {
            //计算摩擦力大小
            float frictionForce = friction * frictionAcc * Time.deltaTime;
            //计算摩擦力方向（与速度相反）
            Vector3 frictionDirection = -velocity.normalized;
            //计算摩擦力向量
            Vector3 frictionVector = frictionDirection * frictionForce;
            //如果摩擦力大于速度，将速度设为零，否则用摩擦力减去速度
            if (frictionForce > velocity.magnitude)
            {
                velocity = Vector3.zero;
            }
            else
            {
                velocity += frictionVector;
            }
            //设置新的速度
            rb.velocity = velocity;
        }
    }
}
