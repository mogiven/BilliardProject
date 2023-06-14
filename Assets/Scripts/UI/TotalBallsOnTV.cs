using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TotalBallsOnTV : MonoBehaviour
{

    TextMeshPro textMesh;

    // Start is called before the first frame update
    void Start()
    {
        //获取TextMesh组件
        textMesh = GameObject.Find("TextTotalBalls (TMP)").GetComponent<TextMeshPro>();
        global.HoleBallsChanged += OnHoleBallsChanged;
        global.GoalsNumChanged+=OnGoalsNumChanged;
    }

    //在OnDestroy方法中，取消订阅global.hole_balls的变化事件
    void OnDestroy()
    {
        global.HoleBallsChanged -= OnHoleBallsChanged;
        global.GoalsNumChanged-=OnGoalsNumChanged;
    }

    //定义事件处理器，当global.hole_balls发生变化时，更新TextMesh的输出
    void OnHoleBallsChanged(int oldValue, int newValue)
    {
        //Debug.Log("调用了事件，更改电视机");
        UpdateTVDisplay();
    }

    //定义事件处理器，当global.GoalsNum发生变化时，更新TextMesh的输出
    void OnGoalsNumChanged(int oldValue, int newValue)
    {
        //Debug.Log("调用了事件，更改电视机");
        UpdateTVDisplay();
    }


    void UpdateTVDisplay(){

        //设置TextMesh的文本内容，使用<color>标签来改变数字进球数的颜色为红色
        textMesh.text = "now<color=red><size=1.5em><b>rods</b></size></color>is<color=red><size=1.5em><b>" + global.GlobalHoleBalls + "</b></size></color>\n" +
                "now<color=red><size=1.5em><b>score</b></size></color>is<color=red><size=1.5em><b>" + global.GlobalGoalsNum + "</b></size></color>";
    }

}
