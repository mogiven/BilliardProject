using UnityEngine;
using Cinemachine;

public class CameraView : MonoBehaviour
{
    //摄像头的camera组件
    private Camera cam;
    //摄像头的原始field of view
    private float originalFOV;

    //放大倍数
    public float zoomFactor = 2f;

    public CinemachineVirtualCamera vcam;

    void Start()
    {
        //获取摄像头的camera组件
        cam = GetComponent<Camera>();
        //保存摄像头的原始field of view
        originalFOV = cam.fieldOfView;

    }

    void Update()
    {
        //如果按住右键
        if (Input.GetMouseButton(1))
        {
            //设置摄像头的field of view为原始值除以放大倍数
            cam.fieldOfView = originalFOV / zoomFactor;
            vcam.m_Lens.FieldOfView = originalFOV / zoomFactor;
        }
        else
        {
            //恢复摄像头的field of view为原始值
            cam.fieldOfView = originalFOV;
            vcam.m_Lens.FieldOfView = originalFOV;

        }
    }
}

