using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMove : EntityMovement // 继承EntityMovement类
{
    public float jumpForce = 5f; // 跳跃时受到的力的大小

    private new void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision); // 调用父类的方法

        // 获取碰撞对象的layer
        int layer = collision.gameObject.layer;

        // 如果碰撞的对象的layer是“Feet”
        if (layer == LayerMask.NameToLayer("Feet"))
        {
            // 获取角色的脚本组件
            CharacterMovement character = collision.collider.GetComponentInParent<CharacterMovement>();

            // 如果角色的脚本组件存在
            if (character != null)
            {
                // 计算跳跃的力，根据跳跃的力的大小和y轴方向
                Vector3 force = Vector3.up * jumpForce;

                // 给实体添加一个冲力，根据跳跃的力
                GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);

                Debug.Log("Jump Frog" + collision.collider.name);
            }
        }
    }
}
