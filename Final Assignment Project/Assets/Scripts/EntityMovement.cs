using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMovement : MonoBehaviour
{
    public float kickForce = 10f; // 被踢时受到的力的大小
    public float kickFactor = 0.1f; // 被踢时受到的力的倍数，根据角色旋转的时间
    public GameObject hitEffectPrefab; // 受击特效的预制体

    public void OnCollisionEnter(Collision collision)
    {
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
                // 计算被踢的方向，根据碰撞的点和角色的位置
                Vector3 direction = (transform.position - collision.transform.position).normalized;

                // 计算被踢的力，根据被踢的方向，被踢的力的大小，和角色旋转的时间
                Vector3 force = direction * kickForce * (1 + Mathf.Abs(character.RotationAngle) * kickFactor);

                // 给实体添加一个冲力，根据被踢的力
                GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);

                // 在碰撞检测点实例化一个受击特效对象
                GameObject hitEffect = Instantiate(hitEffectPrefab, collision.contacts[0].point, Quaternion.identity);

                // 在2秒后销毁受击特效对象
                Destroy(hitEffect, 0.1f);

                Debug.Log("Hit Player" + collision.collider.name);
            }
        }
    }
}
