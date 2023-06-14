using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickCollision : MonoBehaviour
{


    //定义一个变量，用来存储特效的预制体
    public GameObject effectPrefab;

    //定义一个变量，用来存储特效的持续时间
    public float effectDuration = 0.3f;

    public AudioSource audioSource; // 音源组件

    //定义一个变量，用来存储音乐的剪辑
    public AudioClip musicClip;

    //定义一个变量，用来存储音乐的音量
    public float musicVolume = 1f;

    public float speedFactor=1f;

    private void Awake()
    {
        // 加载音效文件
        musicClip = Resources.Load<AudioClip>("Explosion 1");
        // 将音效文件赋值给音源组件的clip属性
        audioSource.clip = musicClip;
    }

    // Start is called before the first frame update
    void Start()
    {
        effectPrefab = (GameObject) Resources.Load("Explosion_A");

        // 设置音量为0.5
        audioSource.volume = musicVolume;

    }

    void PlayMusic(){
        // 播放音效，持续时间为0.3秒
        audioSource.PlayOneShot(musicClip, 0.6f);
    }

    void OnCollisionEnter(Collision col)
    {
        if(col==null || col.gameObject.transform.parent==null){
            return;
        }

        //脚本挂在球杆上，如果如果碰到一个标签为"balls"的，则制造特效
        if (col.gameObject.transform.parent.tag == "Balls")
        {
            //获取碰撞点的位置和旋转
            Vector3 position = col.GetContact(0).point;
            Quaternion rotation = Quaternion.LookRotation(col.GetContact(0).normal);

            //创建特效的实例，并设置其位置和旋转
            GameObject effect = Instantiate(effectPrefab, position, rotation);

            PlayMusic();//播放爆炸音效

            //在0.3s后销毁特效的实例
            Destroy(effect, effectDuration);

            Debug.Log("当前碰撞速度为"+global.mouseVelocity);
            //获取球的刚体组件
            Rigidbody ballRb = col.gameObject.GetComponent<Rigidbody>();
            //计算球的速度方向，根据碰撞点的法线方向反射鼠标的速度向量
            Vector3 velocityDirection = Vector3.Reflect(global.mouseVelocity, col.GetContact(0).normal);
            //给球一个冲量，乘以一个系数来调整速度大小
            ballRb.AddForce(velocityDirection * speedFactor, ForceMode.Impulse);

            //把球的速度在Y轴方向上设为0，避免球飞起来
            Vector3 ballVelocity = ballRb.velocity;
            ballVelocity.y = 0;
            ballRb.velocity = ballVelocity;


            //给球添加一个向下的力，乘以一个系数来调整力的大小
            // ballRb.AddForce(Vector3.down * 1f, ForceMode.Impulse);


        }
    }

}
