using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangePlayerNote
{

    //获取玩家状态提示的文本
    private GameObject Note;

    //获取玩家状态提示Text组件的引用
    Text text ;

    //获取玩家击打球杆次数提示的文本
    private GameObject StickNote;

    //获取玩家击打球杆次数提示Text组件的引用
    Text stickNoteText ;


    public ChangePlayerNote(){
        Start();
    }

    // Start is called before the first frame update
    void Start()
    {
        Note=GameObject.Find("PlayerTextNote");
        text= Note.GetComponent<Text>();
        StickNote=GameObject.Find("StickAttackNote");
        stickNoteText=StickNote.GetComponent<Text>();
    }


    public void UpdateStickNote(int number){
        stickNoteText.text="当前击打杆数：<color=green>"+number+"</color>";
    }

    //定义一个方法，用来根据玩家类型改变Text的文字
    public void UpdateText(int playerType)
    {
        //根据玩家类型的不同，给Text赋不同的值，这里可以根据你的具体需求来修改
        switch (playerType)
        {
            case 2:
                text.text = "需要进攻 <color=red>条纹球</color>";
                break;
            case 1:
                text.text = "需要进攻 <color=red>纯色球</color>";
                break;
            default:
                text.text = "Invalid player type";
                break;
        }
    }





}
