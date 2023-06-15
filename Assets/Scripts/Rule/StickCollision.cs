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

    List<AudioClip> sounds;

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

        sounds = new List<AudioClip>(); //定义列表

        AudioClip tempSound1=Resources.Load<AudioClip>("Explosion 1");
        AudioClip tempSound2=Resources.Load<AudioClip>("Music/DM-CGS-02");
        AudioClip tempSound3=Resources.Load<AudioClip>("Music/DM-CGS-03");
        AudioClip tempSound4=Resources.Load<AudioClip>("Music/DM-CGS-07");
        AudioClip tempSound5=Resources.Load<AudioClip>("Music/DM-CGS-09");
        AudioClip tempSound6=Resources.Load<AudioClip>("Music/DM-CGS-11");
        AudioClip tempSound7=Resources.Load<AudioClip>("Music/DM-CGS-12");
        AudioClip tempSound8=Resources.Load<AudioClip>("Music/DM-CGS-15");
        AudioClip tempSound9=Resources.Load<AudioClip>("Music/DM-CGS-17");
        AudioClip tempSound10=Resources.Load<AudioClip>("Music/DM-CGS-18");
        AudioClip tempSound11=Resources.Load<AudioClip>("Music/DM-CGS-22");
        AudioClip tempSound12=Resources.Load<AudioClip>("Music/DM-CGS-23");
        AudioClip tempSound13=Resources.Load<AudioClip>("Music/DM-CGS-26");
        AudioClip tempSound14=Resources.Load<AudioClip>("Music/DM-CGS-27");

        sounds.Add(tempSound1);
        sounds.Add(tempSound2);
        sounds.Add(tempSound3);
        sounds.Add(tempSound4);
        sounds.Add(tempSound5);
        sounds.Add(tempSound6);
        sounds.Add(tempSound7);
        sounds.Add(tempSound8);
        sounds.Add(tempSound9);
        sounds.Add(tempSound10);
        sounds.Add(tempSound11);
        sounds.Add(tempSound12);
        sounds.Add(tempSound13);
        sounds.Add(tempSound14);


        // 设置音量为0.5
        audioSource.volume = musicVolume;

    }

    void PlayMusic(){

        int index = Random.Range(0, sounds.Count); //生成一个随机的索引，范围是0到列表的长度
        AudioClip clip = sounds[index]; //用索引访问列表中的音效

        // 播放音效，持续时间为0.3秒
        audioSource.PlayOneShot(clip, 0.6f);
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

            //Debug.Log("当前碰撞速度为"+global.mouseVelocity);
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
