using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TotalBallsOnTV : MonoBehaviour
{

    TextMeshPro textMesh;

    // Start is called before the first frame update
    void Start()
    {
        //获取TextMesh组件
        textMesh = GameObject.Find("TextTotalBalls (TMP)").GetComponent<TextMeshPro>();
        
        global.GoalsNumChanged+=OnGoalsNumChanged;
        global.PlayerTypeChanged+=OnPlayerTypeChanged;
        global.HoleBallsChanged += OnHoleBallsChanged;
    }

    //在OnDestroy方法中，取消订阅global.hole_balls的变化事件
    void OnDestroy()
    {
        
        global.GoalsNumChanged-=OnGoalsNumChanged;
        global.PlayerTypeChanged-=OnPlayerTypeChanged;
        global.HoleBallsChanged -= OnHoleBallsChanged;
    }

    //定义事件处理器，当global.hole_balls发生变化时，更新TextMesh的输出
    void OnHoleBallsChanged(int oldValue, int newValue)
    {
        Debug.Log("调用了事件，更改电视机击球数");
        UpdateTVDisplay();
    }

    //定义事件处理器，当global.GoalsNum发生变化时，更新TextMesh的输出
    void OnGoalsNumChanged(int oldValue, int newValue)
    {
        Debug.Log("调用了事件，更改电视机得分数");
        UpdateTVDisplay();
    }

    void OnPlayerTypeChanged(int oldValue, int newValue)
    {
        Debug.Log("调用了事件，更改电视机玩家类型");
        UpdateTVDisplay();
    }


    void UpdateTVDisplay(){

        String text="";
        //根据玩家类型的不同，给Text赋不同的值，这里可以根据你的具体需求来修改
        switch (global.playerType)
        {
            case 2:
                text = "need to attack <color=red>striped ball</color>";
                break;
            case 1:
                text = "need to attack <color=red>striped ball</color>";
                break;
            default:
                text = "Invalid player type";
                break;
        }

        //设置TextMesh的文本内容，使用<color>标签来改变数字进球数的颜色为红色
        textMesh.text = "now<color=red><size=1.5em><b>rods</b></size></color>is<color=red><size=1.5em><b>" + global.GlobalHoleBalls + "</b></size></color>\n" +
                "now<color=red><size=1.5em><b>score</b></size></color>is<color=red><size=1.5em><b>" + global.GlobalGoalsNum + "</b></size></color>\n"+
                text;
    }

}
