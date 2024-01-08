using UnityEngine;

public class GhostMove : MonoBehaviour
{
    // 声明一个公共变量，用来控制小幽灵的阻尼系数
    public float damping;

    // 在OnCollisionEnter方法中检测碰撞
    void OnCollisionEnter(Collision collision)
    {
        // 如果碰撞的物体的layer是Feet
        if (collision.gameObject.layer == LayerMask.NameToLayer("Feet"))
        {
            // 获取Rigidbody组件的引用
            Rigidbody rigidbody = GetComponent<Rigidbody>();

            // 获取碰撞的相对速度，乘以一个系数，给小幽灵一个反向的推力，让其沿着角色踢它的方向移动
            Vector3 force = -collision.relativeVelocity * 0.5f;
            rigidbody.AddForce(force, ForceMode.Impulse);
        }
    }

    // 在FixedUpdate方法中控制小幽灵的减速
    void FixedUpdate()
    {
        // 获取Rigidbody组件的引用
        Rigidbody rigidbody = GetComponent<Rigidbody>();

        // 给小幽灵一个反向的阻力，让其逐渐减速
        rigidbody.AddForce(-rigidbody.velocity * damping, ForceMode.Force);
    }
}
