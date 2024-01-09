using UnityEngine;

public class Billboard : MonoBehaviour
{
    // 摄像机的引用
    public Camera cam;

    // 每帧更新时
    void Update()
    {
        // 让对象的正面朝向摄像机的位置
        transform.LookAt(transform.position + cam.transform.forward);
    }
}
