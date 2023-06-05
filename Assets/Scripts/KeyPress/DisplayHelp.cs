using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayHelp : MonoBehaviour
{

    private GameObject UI;
    private GameObject Edge;

    //定义一个变量来表示UI元素的显示状态
    private bool isHidden = false;

    void Start(){
        UI=GameObject.Find("selsct map");
        UI.SetActive(isHidden);
        Edge=GameObject.Find("Edge");
    }

    void Update() { 
        //检测R键的按下 
        if(Input.GetKeyDown(KeyCode.H)) { 


            isHidden=!isHidden;
            UI.SetActive(isHidden);
            Edge.SetActive(!isHidden);

        }
    }

    
}
