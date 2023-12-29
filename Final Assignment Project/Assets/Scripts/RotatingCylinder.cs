using UnityEngine;

public class RotatingCylinder : MonoBehaviour
{
    // 旋转速度，可以在编辑器中调整
    public float rotateSpeed = 10f;

    // 推开力度，可以在编辑器中调整
    public float pushForce = 100f;

    // 刚体组件的引用，用来获取和设置圆柱体的角速度
    private Rigidbody rb;

    // 在游戏开始时获取刚体组件的引用
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // 在每一帧中更新圆柱体的角速度，使其围绕垂直于平分轴的直线旋转
    private void Update()
    {
        // 计算旋转轴，根据圆柱体的旋转方向，可以是transform.right或者transform.forward
        Vector3 rotateAxis = transform.right;

        // 计算角速度，根据旋转轴和旋转速度
        Vector3 angularVelocity = rotateAxis * rotateSpeed;

        // 设置刚体组件的角速度
        rb.angularVelocity = angularVelocity;
    }
}