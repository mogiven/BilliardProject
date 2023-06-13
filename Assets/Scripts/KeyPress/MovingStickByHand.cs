using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MovingStickByHand : MonoBehaviour
{

    private static int is_hand=0;

    void Update() { 
        //检测R键的按下 
        if(Input.GetKeyDown(KeyCode.M)) { 

            Debug.Log("切换为手动");

            if(is_hand==0){
                MoveByHand();
            }else{
                DisableHand();
            }


        }
    }

    static void MoveByHand(){
        is_hand=1;
        global.is_hold=-2;
        Debug.Log("进入手动模式");
        //Cursor.lockState = CursorLockMode.None; //解锁鼠标，可以自由移动
    }

    public static void DisableHand(){
        is_hand=0;
        global.is_hold=1;
        Debug.Log("退出手动模式");
        Cursor.lockState = CursorLockMode.Locked;//锁定鼠标在屏幕中央

    }
        public static void GoOnHand(){
        global.is_hold=-2;
        Debug.Log("继续手动模式");
        //Cursor.lockState = CursorLockMode.Locked;//锁定鼠标在屏幕中央
    }




}
