using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollisionScript : MonoBehaviour
{
    public float minDistance = 0.1f; // 角色和地面的最小距离

    private void OnCollisionEnter(Collision collision)
    {
        // 判断碰撞对象的层级是否为“Ground”
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            // 计算角色和地面的距离
            float distance = Vector3.Distance(transform.position, collision.contacts[0].point);

            // 如果距离小于最小距离，就把角色的位置向上移动，使其等于最小距离
            if (distance < minDistance)
            {
                transform.position += Vector3.up * (minDistance - distance);
            }
        }
    }
}
