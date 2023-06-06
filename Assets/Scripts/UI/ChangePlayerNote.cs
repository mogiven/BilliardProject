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

    //获取游戏获胜提示
    private GameObject GameResultFather;
    private GameObject GameResult;
    Text GameResultText ;

    

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
        GameResult=GameObject.Find("GameResultText");
        GameResultText=GameResult.GetComponent<Text>();
        //获取它的变换组件
        Transform gameResultTransform = GameResult.transform;
        //获取它的父节点
        Transform GameResultFatherTransform = gameResultTransform.parent;
        //获取父节点对应的GameObject
        GameResultFather = GameResultFatherTransform.gameObject;

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

    //定义一个方法，用来显示游戏成功或者失败
    public void displayWinOrLose(int isWin){
        GameResultFather.SetActive(true);
        if(isWin==1){
            GameResultText.text="<color=blue>You WIN !</color>";
        }else{
            GameResultText.text="<color=red>You LOSE !</color>";
        }


    }

    public void hideWinOrLose(){
        GameResultFather.SetActive(false);
    }





}
