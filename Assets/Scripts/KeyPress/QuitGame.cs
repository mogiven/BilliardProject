using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class QuitGame : MonoBehaviour
{

    void Update() { 
        //检测R键的按下 
        if(Input.GetKeyDown(KeyCode.Q)) { 

            Debug.Log("退出游戏！");

            //设置isPlaying属性为false，表示停止游戏
            //EditorApplication.isPlaying = false;

            //调用Quit方法来退出游戏
            Application.Quit();

        }
    }

}
