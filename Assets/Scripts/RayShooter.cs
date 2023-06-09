using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter: MonoBehaviour 
{

    private Camera _camera;
    private GameObject bulletPrefab; // 炮弹预设体
    Transform stick;//球杆

    //准星图片
    public Texture2D crosshairTexture;

    void Start()
    {
        _camera = GetComponent<Camera>();//获取相机上的Camera组件
        bulletPrefab = (GameObject) Resources.Load("EmptyRotation");
        stick=_camera.transform.Find("EmptyRotation").Find("Bullet2");
        global.is_hold=-2;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))//当点击左建执行发射射线
        {
            Vector3 point = new Vector3(_camera.pixelWidth/2,_camera.pixelHeight/2,0);//发射位置

            Ray ray = _camera.ScreenPointToRay(point);//创建射线
            RaycastHit hit;//数据结构变量
            if(Physics.Raycast(ray,out hit))//在此方法中寻找射线信息，并且赋值给hit变量
            {
                //获取射线与射击到物体的交叉位置，并且进行一些操作
                //Debug.Log("Hit "+hit.point);

                //Debug.Log("点击了鼠标左键，此时is_hold="+global.is_hold);

                if(global.is_hold==1){
                    //更新出杆数
                    //global.stick_attacks+=1;
                    global.GlobalHoleBalls=global.GlobalHoleBalls+1;
                    //global.poolRules.UpdateStickNote(global.GlobalHoleBalls);
                    
                    //StartCoroutine(MoveStick(ray));//运行此协程
                    StartCoroutine(MoveStick(ray.origin,hit.point));//运行此协程
                }

                if(global.is_hold==-2){
                    //更新出杆数
                    //global.stick_attacks+=1;
                    global.GlobalHoleBalls=global.GlobalHoleBalls+1;
                    //global.poolRules.UpdateStickNote(global.stick_attacks);
                    
                    //StartCoroutine(MoveStick(ray));//运行此协程
                    StartCoroutine(MoveStickByHand(ray.origin,hit.point));//运行此协程
                }

                





            }
        }
    }

    private IEnumerator SphereIndicator(Vector3 pos)//运行协程来响应击中
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);//创建一个球体。
        sphere.transform.position = pos;//表示击中此位置
        yield return new WaitForSeconds(1);//表示等待一秒再执行此函数下面的内容

        Destroy(sphere);
    }

    private IEnumerator MoveStick(Vector3 origin_pos, Vector3 end_pos){

        global.is_hold=0;
        //Debug.Log("协程运行开始");
        stick.parent.position=origin_pos+new Vector3(0,-0.5F,0);
        global.move_forward_direction=end_pos-stick.parent.position;
        yield return new WaitForSeconds(1);//表示等待一秒再执行此函数下面的内容
        global.is_hold=1;
        //Debug.Log("协程运行结束");
    }

    private IEnumerator MoveStickByHand(Vector3 origin_pos, Vector3 end_pos){

        global.is_hold=-1;
        Cursor.lockState = CursorLockMode.None; //解锁鼠标，可以自由移动
        //Debug.Log("协程运行开始");
        stick.parent.position=origin_pos+new Vector3(0,-0.3F,0);
        global.move_forward_direction=end_pos-stick.parent.position;
        yield return new WaitForSeconds(3);//表示等待一秒再执行此函数下面的内容
        global.is_hold=1;
        Cursor.lockState = CursorLockMode.Locked;//锁定鼠标在屏幕中央
        MovingStickByHand.GoOnHand();
        //Debug.Log("协程运行结束");
    }


    private IEnumerator MoveStick(Ray ray)//运行协程来响应击中
    {
        global.is_hold=0;
        //Debug.Log("协程运行开始");



        stick.parent.position=ray.origin;
        //stick.rotation=Quaternion.LookRotation(ray.direction);
        global.move_forward_direction=ray.direction;
        //stick.forward=ray.direction;
        //stick.parent.LookAt(ray.direction);
        

        
        yield return new WaitForSeconds(1);//表示等待一秒再执行此函数下面的内容


        //重置杆的位置
        //stick.position=stick.parent.position;

        global.is_hold=1;
        //Debug.Log("协程运行结束");
    }

    // 添加可视化指示器
    void OnGUI()//unity会自动响应OnGUI方法。每帧之后执行
    {
        // int size = 12;//这是准星图像的长度，减去它确保准星对准中心点
        // float posX = _camera.pixelWidth/2-size/4;
        // float posY = _camera.pixelHeight/2-size/2;

        //计算准星图片的位置和大小
        Rect crosshairRect = new Rect(
            (_camera.pixelWidth - 64) / 2, //水平居中
            (_camera.pixelHeight - 64) / 2, //垂直居中
            64, //宽度
            64 //高度
        );
        //绘制准星图片
        GUI.DrawTexture(crosshairRect, crosshairTexture);


    }
}
