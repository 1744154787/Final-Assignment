using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollisionScript : MonoBehaviour
{
    public float minDistance = 0.1f; // ��ɫ�͵������С����

    private void OnCollisionEnter(Collision collision)
    {
        // �ж���ײ����Ĳ㼶�Ƿ�Ϊ��Ground��
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            // �����ɫ�͵���ľ���
            float distance = Vector3.Distance(transform.position, collision.contacts[0].point);

            // �������С����С���룬�Ͱѽ�ɫ��λ�������ƶ���ʹ�������С����
            if (distance < minDistance)
            {
                transform.position += Vector3.up * (minDistance - distance);
            }
        }
    }
}
