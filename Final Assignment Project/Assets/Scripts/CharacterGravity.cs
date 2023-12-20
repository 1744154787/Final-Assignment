using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityScript : MonoBehaviour
{
    public float gravity = 9.8f; // �����Ĵ�С
    private bool isGrounded = false; // ��ɫ�Ƿ��ڵ�����
    private CharacterController characterController; // ��ɫ��Character Controller���

    private void Start()
    {
        // ��ȡ��ɫ��Character Controller���
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // ����ɫ�Ƿ��ڵ����ϣ�ʹ��Physics.Raycast����
        // ���ߵ�����ǽ�ɫ�����ģ����������£������ǽ�ɫ�İ뾶��һ��
        if (Physics.Raycast(transform.position, Vector3.down, characterController.radius + 0.1f, LayerMask.GetMask("Ground")))
        {
            // ����У��Ͱ�isGrounded��Ϊtrue����ʾ��ɫ�ڵ�����
            isGrounded = true;
        }
        else
        {
            // ���û�У��Ͱ�isGrounded��Ϊfalse����ʾ��ɫ���ڵ�����
            isGrounded = false;
        }

        // �����ɫ���ڵ����ϣ��͸���ɫʩ��һ�����µ�������СΪgravity * Time.deltaTime
        if (!isGrounded)
        {
            characterController.Move(Vector3.down * gravity * Time.deltaTime);
        }
    }
}
