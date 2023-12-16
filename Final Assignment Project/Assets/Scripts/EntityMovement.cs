using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMovement : MonoBehaviour
{
    public float kickForce = 10f; // ����ʱ�ܵ������Ĵ�С
    public float kickFactor = 0.1f; // ����ʱ�ܵ������ı��������ݽ�ɫ��ת��ʱ��

    private void OnCollisionEnter(Collision collision)
    {
        // �����ײ�Ķ����ǽ�ɫ
        if (collision.gameObject.CompareTag("Player"))
        {
            // ��ȡ��ɫ�Ľű����
            CharacterMovement character = collision.gameObject.GetComponent<CharacterMovement>();

            // �����ɫ�Ľű��������
            if (character != null)
            {
                // ���㱻�ߵķ��򣬸�����ײ�ĵ�ͽ�ɫ��λ��
                Vector3 direction = (transform.position - collision.transform.position).normalized;

                // ���㱻�ߵ��������ݱ��ߵķ��򣬱��ߵ����Ĵ�С���ͽ�ɫ��ת��ʱ��
                Vector3 force = direction * kickForce * (1 + character.RotationAngle * kickFactor);

                // ��ʵ�����һ�����������ݱ��ߵ���
                GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
            }
        }
    }
}
