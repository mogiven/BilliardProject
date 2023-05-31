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
                Debug.Log("Hit "+hit.point);
                // 在场景视图中绘制射线  
                //Debug.DrawLine(ray.origin, hit.point, Color.red);
                //StartCoroutine(SphereIndicator(hit.point));//运行此协程


                //ray.origin = Camera.main.transform.position
                //发射炮弹，暂时注释
                // GameObject bullet = Instantiate(bulletPrefab, ray.origin, Quaternion.identity); // 通过预设体创建炮弹
                // bullet.GetComponent<Rigidbody>().velocity = ray.direction * 20;
                // Destroy(bullet, 0.5F);


                if(global.is_hold==1){
                    StartCoroutine(MoveStick(ray));//运行此协程
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

    private IEnumerator MoveStick(Ray ray)//运行协程来响应击中
    {
        global.is_hold=0;
        Debug.Log("协程运行开始");

        stick.parent.position=ray.origin;
        //stick.rotation=Quaternion.LookRotation(ray.direction);
        global.move_forward_direction=ray.direction;
        //stick.forward=ray.direction;
        //stick.parent.LookAt(ray.direction);
        

        
        yield return new WaitForSeconds(1);//表示等待一秒再执行此函数下面的内容


        //重置杆的位置
        //stick.position=stick.parent.position;

        global.is_hold=1;
        Debug.Log("协程运行结束");
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
