using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMove : EntityMovement // �̳�EntityMovement��
{
    public float jumpForce = 5f; // ��Ծʱ�ܵ������Ĵ�С

    private new void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision); // ���ø���ķ���

        // ��ȡ��ײ�����layer
        int layer = collision.gameObject.layer;

        // �����ײ�Ķ����layer�ǡ�Feet��
        if (layer == LayerMask.NameToLayer("Feet"))
        {
            // ��ȡ��ɫ�Ľű����
            CharacterMovement character = collision.collider.GetComponentInParent<CharacterMovement>();

            // �����ɫ�Ľű��������
            if (character != null)
            {
                // ������Ծ������������Ծ�����Ĵ�С��y�᷽��
                Vector3 force = Vector3.up * jumpForce;

                // ��ʵ�����һ��������������Ծ����
                GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);

                Debug.Log("Jump Frog" + collision.collider.name);
            }
        }
    }
}
