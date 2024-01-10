using UnityEngine;

public class Billboard : MonoBehaviour
{
    // 摄像机的引用
    private Camera cam;

    // 起始时
    void Start()
    {
        // 获取场景中标签为"myCamera"的摄像机
        cam = GameObject.FindGameObjectWithTag("myCamera").GetComponent<Camera>();
    }

    // 每帧更新时
    void Update()
    {
        // 让对象的正面朝向摄像机的位置
        transform.LookAt(transform.position + cam.transform.forward);
    }
}
