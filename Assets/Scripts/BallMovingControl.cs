using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class BallMovingControl : MonoBehaviour
{

    public float FloPower = 10F;                             //小球移动的速度（力度）

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        //得到键盘按键，控制小球
        float floX = Input.GetAxis("Horizontal");           //得到键盘的水平移动数值(键盘的A和D键)
        float floY = Input.GetAxis("Vertical");             //得到键盘的垂直移动数值（键盘的W和S键）
        Console.WriteLine(floX);
        //控制小球往右移动
        if (floX > 0)
        {
            //this本脚本，gameObject这个脚本所挂载上的物体，GetComponent获得组件的方法，Rigibody刚体组件，velocity速度属性，Vector3.right*FloPower 给物体施加一个向右的速度值
            this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.right * FloPower;
        }
        //控制小球往左移动
        else if (floX < 0)
        {
            this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.left * FloPower;
        }
        //控制小球往前移动
        if (floY > 0)
        {
            this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.forward * FloPower;
        }
        //控制小球往后移动
        else if (floY < 0)
        {
            this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.back * FloPower;
        }
    }
}

