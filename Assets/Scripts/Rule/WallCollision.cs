using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter(Collision col)
{
    //如果碰撞到的物体的父物体的标签是Balls
    if (col.gameObject.transform.parent.tag == "Balls")
    {

        //获取小球的刚体组件
        Rigidbody ballRb = col.gameObject.GetComponent<Rigidbody>();

        //获取小球的速度大小
        var speed = ballRb.velocity.magnitude;

        //取第一个接触点
        ContactPoint contact = col.GetContact(0);

        //计算小球的反弹方向，根据接触点的法线方向反射小球的速度向量
        var direction = Vector3.Reflect(ballRb.velocity.normalized, contact.normal);

        //给小球一个冲量，乘以速度大小来保持无能量损失
        ballRb.AddForce(direction * speed*1.6F, ForceMode.Impulse);
    }
}




}
