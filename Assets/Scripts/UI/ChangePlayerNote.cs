using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangePlayerNote: MonoBehaviour
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


    // Start is called before the first frame update
    void Start()
    {
        //找到所有的Text组件，包括未激活的
        Text[] allTexts = Resources.FindObjectsOfTypeAll<Text>();

        Note=GameObject.Find("PlayerTextNote");
        text= Note.GetComponent<Text>();
        StickNote=GameObject.Find("StickAttackNote");
        stickNoteText=StickNote.GetComponent<Text>();
        GameResult=GameObject.Find("GameResultText");
        if(GameResult==null){
            //遍历数组，找到名字为GameResultText的Text组件
            foreach (Text text in allTexts)
            {
                //如果Text组件的名字是GameResultText
                if (text.name == "GameResultText")
                {
                    GameResultText=text;
                    GameResult = text.transform.parent.gameObject;
                }
            }
        }else{
            GameResultText=GameResult.GetComponent<Text>();
        }
        
        //获取它的变换组件
        Transform gameResultTransform = GameResult.transform;
        //获取它的父节点
        Transform GameResultFatherTransform = gameResultTransform.parent;
        //获取父节点对应的GameObject
        GameResultFather = GameResultFatherTransform.gameObject;


        //添加委托
        global.PlayerTypeChanged+=UpdateText;
        global.HoleBallsChanged += UpdateStickNote;
        global.WinOrLoseChanged+=displayWinOrLose;


        global.GlobalWinOrLose=0;
        hideWinOrLose();

    }

    //在OnDestroy方法中，取消订阅global.hole_balls的变化事件
    void OnDestroy()
    {
        
        global.PlayerTypeChanged-=UpdateText;
        global.HoleBallsChanged -= UpdateStickNote;
        global.WinOrLoseChanged-=displayWinOrLose;
    }



    public void UpdateStickNote(int old_value,int number){

        //Debug.Log("stickNoteText==NULL?"+stickNoteText==null);

        stickNoteText.text="当前击打杆数：<color=green>"+number+"</color>";
    }

    //定义一个方法，用来根据玩家类型改变Text的文字
    public void UpdateText(int old_value,int playerType)
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
    public void displayWinOrLose(int old_value,int isWin){
        GameResultFather.SetActive(true);
        if(isWin==1){
            GameResultText.text="<color=blue>You WIN !</color>\n<color=green>press R to restart!</color>";
        }else if(isWin==2){
            GameResultText.text="<color=red>You LOSE !</color>\n<color=green>press R to restart!</color>";
        }else{
            hideWinOrLose();
        }


    }

    public void hideWinOrLose(){
        GameResultFather.SetActive(false);
    }





}
