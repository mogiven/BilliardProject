using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PoolRules: MonoBehaviour 
{



    //定义一个数组，用来存储16个球的引用
    public GameObject[] balls;

    //定义一个数组，用来存储16个球的进球状态，true表示已进，false表示未进
    private bool[] pocketed;

    //声明一个列表来存储球的初始位置
    private Vector3[] positions;

    //定义一个变量，用来表示当前玩家的类型，0表示无效，1表示全色球,2表示条纹球
    private int playerType;

    //定义一个变量，用来表示当前玩家是否可以继续击球
    private bool canContinue;

    //定义一个变量，用来表示游戏是否结束
    private bool gameOver;

    //定义玩家提示信息
    private ChangePlayerNote changePlayerNote;

    //定义一个变量，用来记录是否有球进过
    private bool hasPocketed = false;

    //定义一个变量，用来存储粒子效果特效的预制体
    public GameObject particleEffect;

    //定义一个变量，用来存储特效缩放的比例
    public float effectScale = 0.15f;

    public PoolRules(){
        Start();
    }

    //在开始时记录所有球的位置，并初始化进球状态和玩家类型
    void Start()
    {

        particleEffect=(GameObject) Resources.Load("Heart");

        changePlayerNote=new ChangePlayerNote();

        //获取PoolBallSet节点的Transform组件
        Transform poolBallSet = GameObject.Find("PoolBallSet01").transform;

        balls= new GameObject[16];
        positions=new Vector3[16];

        //遍历PoolBallSet节点的子节点，即所有的球
        for(int i = 0; i < poolBallSet.childCount; i++)
        {
            //获取第i个子节点的游戏对象
            GameObject ball = poolBallSet.GetChild(i).gameObject;

            //将球的游戏对象添加到balls列表中
            balls[i]=(ball);

            //将球的初始位置添加到positions列表中
            positions[i]=(ball.transform.position);

            //获取球的子节点，假设第一个子节点就是Heart特效节点
            Transform child = balls[i].transform.GetChild(0);

            //获取子节点对应的GameObject
            GameObject heart = child.gameObject;

            heart.SetActive(false);

        }

        

        pocketed = new bool[16];
        for (int i = 0; i < 16; i++)
        {
            pocketed[i] = false;
        }
        playerType = 0;
        canContinue = true;
        gameOver = false;
    }


    //在类中定义一个公共方法，接收进球的球的号码
public void PocketBall(int i)
{
    //如果球已经进过，或者游戏已经结束，则返回
    if (pocketed[i] || gameOver) return;

    //更新进球状态
    pocketed[i] = true;

    // //判断是否是第一个进球
    // if (!hasPocketed)
    // {
    //     //如果是第一个进球，做一些操作，例如打印信息
    //     Debug.Log("This is the first pocketed ball.");
    //     //把变量的值设为true，表示已经有球进过了
    //     hasPocketed = true;
    //     if(i<=7){
    //         playerType=1;//纯色球
    //     }
    // }            

    Debug.Log("进球第"+i+"个球");

    //如果是白球，则重置白球的位置，并切换玩家
    if (i == 0)
    {
        balls[15].transform.position = positions[15];
        SwitchPlayer();
    }
    else
    {
        //如果是黑八，则判断是否获胜或失败
        if (i == 8)
        {
            CheckBlackEight();
        }
        else
        {
            //如果是其他彩球，则判断是否符合玩家类型
            CheckPlayerType(i);
        }
    }
}

    //在每一次击球后，检查所有球的位置，并更新进球状态和玩家类型
    void CheckBalls()
    {
        //遍历所有球
        for (int i = 0; i < 16; i++)
        {
            //如果球已经进过，则跳过
            if (pocketed[i]) continue;

            //获取球的位置
            Vector3 position = balls[i].transform.position;

            //判断球是否进入了袋子，这里可以根据你的具体逻辑来修改
            if (position.y < -1f)
            {
                //更新进球状态
                pocketed[i] = true;

                //如果是白球，则重置白球的位置，并切换玩家
                if (i == 0)
                {
                    balls[15].transform.position = positions[15];
                    SwitchPlayer();
                }
                else
                {
                    //如果是黑八，则判断是否获胜或失败
                    if (i == 8)
                    {
                        CheckBlackEight();
                    }
                    else
                    {
                        //如果是其他彩球，则判断是否符合玩家类型
                        CheckPlayerType(i);
                    }
                }
            }
        }
    }

    //判断黑八是否获胜或失败
    void CheckBlackEight()
    {
        //如果玩家类型为无效，则失败
        if (playerType == 0)
        {
            gameOver = true;
            Debug.Log("You lose!");
        }
        else
        {
            //遍历玩家类型对应的彩球，如果都已经进过，则获胜，否则失败
            bool win = true;
            for (int i = 1; i < 8; i += 1)
            {
                if (!pocketed[i+(playerType-1)*8])
                {
                    win = false;
                    break;
                }
            }
            gameOver = true;
            if (win)
            {
                Debug.Log("You win!");
            }
            else
            {
                Debug.Log("You lose!");
            }
        }
    }


    //判断彩球是否符合玩家类型，并更新玩家类型和继续击球状态
    void CheckPlayerType(int i)
    {
        //如果玩家类型为无效，则根据彩球的奇偶性确定玩家类型，并继续击球
        if (playerType == 0)
        {
            
            playerType = i / 8 + 1;
            SwitchPlayer(playerType);

            canContinue = true;
        }
        else
        {
            //如果玩家类型为有效，则判断彩球是否与玩家类型相同，如果相同，则继续击球，否则切换玩家
            if (i / 8 + 1 == playerType)
            {
                canContinue = true;
            }
            else
            {
                canContinue = false;
                SwitchPlayer();
            }
        }
    }


    //切换玩家类型
    void SwitchPlayer()
    {
        //如果玩家类型为无效，则不切换
        if (playerType == 0) return;

        //如果玩家类型为条纹球，则切换为全色球，反之亦然
        if (playerType == 1)
        {
            playerType = 2;
        }
        else
        {
            playerType = 1;
        }

        Debug.Log("CHANGE PLAYER NOTE");

        changePlayerNote.UpdateText(playerType);

    }

        //切换玩家类型
    void SwitchPlayer(int n)
    {
        playerType = n;
        Debug.Log("CHANGE PLAYER NOTE");
        changePlayerNote.UpdateText(playerType);

        ShowParticleEffects(playerType);

    }

    //获取玩家类型
    public int getPlayerType(){
        return playerType;
    }

    public void UpdateStickNote(int number){
        changePlayerNote.UpdateStickNote(number);
    }



//定义一个方法，用来根据玩家类型在对应的球的位置生成粒子效果特效
void ShowParticleEffects(int playerType)
{
    //遍历所有球
    for (int i = 0; i < 16; i++)
    {
        //如果球已经进过，则跳过
        if (pocketed[i]) continue;

        //获取球的子节点，假设第一个子节点就是Heart特效节点
        Transform child = balls[i].transform.GetChild(0);

        //获取子节点对应的GameObject
        GameObject heart = child.gameObject;

        //根据玩家类型的不同，判断是否在球的位置生成特效，这里可以根据你的具体需求来修改
        switch (playerType)
        {
            case 1:
                //如果玩家类型为全色球，则在全色球的位置生成特效
                heart.SetActive(i>8);
                break;
            case 2:
                //如果玩家类型为条纹球，则在条纹球的位置生成特效
                heart.SetActive(i<8);
                break;
            default:
                //如果玩家类型为无效，则不生成任何特效
                break;
        }
    }
}



}
