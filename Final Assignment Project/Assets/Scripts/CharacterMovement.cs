using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Transform leftFoot; // ��ɫ������Ӷ���
    public Transform rightFoot; // ��ɫ���ҽ��Ӷ���
    public float rotationSpeed = 180f; // ��ɫ����ת�ٶ�
    public float maxRotationSpeed = 360f; // ��ɫ����ת�ٶȵ����ֵ

    private bool isLeftFootPivot = false; // �Ƿ������Ϊ����ת
    [SerializeField]private float rotationAngle = 0f; // ��ǰ����ת�Ƕ�
    public float RotationAngle
    {
        get { return rotationAngle; }
    }

    private void Update()
    {
        // ��ȡ��ҵ�����
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        // �����Ұ���A��D������ʼ��ת
        if (horizontalInput != 0)
        {
            // ������ת�Ƕȣ����ݰ����ķ����ʱ�䣬���������ֵ��Χ��
            rotationAngle += Mathf.Clamp((horizontalInput) * rotationSpeed * Time.deltaTime, -maxRotationSpeed, maxRotationSpeed);

            // ѡ����ת���ᣬ���ݵ�ǰ��״̬
            Transform pivot = isLeftFootPivot ? leftFoot : rightFoot;

            // ��ת��ɫ��������ת����ͽǶ�
            transform.RotateAround(pivot.position, Vector3.up, rotationAngle);
        }
        // �������ɿ�A��D����ֹͣ��ת���л���ת���ᣬ������ת�Ƕ�
        else if (rotationAngle != 0)
        {
            isLeftFootPivot = !isLeftFootPivot;
            rotationAngle = 0f;
        }
    }
}
