using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMovement : MonoBehaviour
{
    public float kickForce = 10f; // ����ʱ�ܵ������Ĵ�С
    public float kickFactor = 0.1f; // ����ʱ�ܵ������ı��������ݽ�ɫ��ת��ʱ��

    public void OnCollisionEnter(Collision collision)
    {
        // ��ȡ��ײ�����layer
        int layer = collision.gameObject.layer; // �޸�

        // �����ײ�Ķ����layer�ǡ�Feet��
        if (layer == LayerMask.NameToLayer("Feet")) // �޸�
        {
            // ��ȡ��ɫ�Ľű����
            CharacterMovement character = collision.collider.GetComponentInParent<CharacterMovement>(); // �޸�

            // �����ɫ�Ľű��������
            if (character != null)
            {
                // ���㱻�ߵķ��򣬸�����ײ�ĵ�ͽ�ɫ��λ��
                Vector3 direction = (transform.position - collision.transform.position).normalized;

                // ���㱻�ߵ��������ݱ��ߵķ��򣬱��ߵ����Ĵ�С���ͽ�ɫ��ת��ʱ��
                Vector3 force = direction * kickForce * (1 + Mathf.Abs(character.RotationAngle) * kickFactor);

                // ��ʵ�����һ�����������ݱ��ߵ���
                GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);

                Debug.Log("Hit Player" + collision.collider.name); // �޸�
            }
        }
    }
}
