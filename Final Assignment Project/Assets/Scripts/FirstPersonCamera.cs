using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public float sensitivityX = 15f; // 摄像机水平旋转的速度
    public float sensitivityY = 15f; // 摄像机垂直旋转的速度
    //public float minimumX = -360f; // 摄像机水平旋转的最小角度
    //public float maximumX = 360f; // 摄像机水平旋转的最大角度
    public float minimumY = -60f; // 摄像机垂直旋转的最小角度
    public float maximumY = 60f; // 摄像机垂直旋转的最大角度

    private float rotationX = 0f; // 摄像机当前水平旋转的角度
    private float rotationY = 0f; // 摄像机当前垂直旋转的角度
    private GameObject player; // 角色对象的引用

    private void Start()
    {
        // 获取角色对象的引用，假设角色对象的标签是Player
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        // 获取鼠标的水平和垂直输入
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // 计算摄像机的水平和垂直旋转角度，根据输入和速度，并限制在范围内
        rotationX += mouseX * sensitivityX;
        //rotationX = Mathf.Clamp(rotationX, minimumX, maximumX);
        rotationY += mouseY * sensitivityY;
        rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

        // 创建一个四元数，表示摄像机的旋转，根据旋转角度
        Quaternion cameraRotation = Quaternion.Euler(-rotationY, rotationX, 0);

        // 旋转摄像机，根据四元数
        transform.localRotation = cameraRotation;

        // 设置摄像机的位置，根据角色的位置，假设摄像机的位置偏移量是(0, 1, 0)
        transform.position = player.transform.position + new Vector3(0, 1, 0);
    }
}
