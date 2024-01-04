using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;

public class CharacterMovement : MonoBehaviour
{
    public Transform leftFoot; // ��ɫ������Ӷ���
    public Transform rightFoot; // ��ɫ���ҽ��Ӷ���
    public float rotationSpeed = 180f; // ��ɫ����ת�ٶ�
    public float maxRotationSpeed = 360f; // ��ɫ����ת�ٶȵ����ֵ
    public GameObject leftFootUI; // ���UI����
    public GameObject rightFootUI; // �ҽ�UI����

    private bool isLeftFootPivot = false; // �Ƿ������Ϊ����ת
    [SerializeField] private float rotationAngle = 0f; // ��ǰ����ת�Ƕ�
    private float foreFrameInput;
    
    public float RotationAngle
    {
        get { return rotationAngle; }
    }

    private void Update()
    {
        // ��ȡ��ҵ�����
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        //Debug.Log(horizontalInput);

        // �����Ұ���A��D������ʼ��ת
        if (horizontalInput != 0)
        {
            // ������ת�Ƕȣ����ݰ����ķ����ʱ�䣬���������ֵ��Χ��
            rotationAngle += Mathf.Clamp((horizontalInput) * rotationSpeed * Time.deltaTime, -maxRotationSpeed, maxRotationSpeed);
        }
        // �������ɿ�A��D����ֹͣ��ת���л���ת���ᣬ������ת�Ƕ�
        if ((horizontalInput==0 && rotationAngle!=0) || (horizontalInput * foreFrameInput) <0)
        {
            isLeftFootPivot = !isLeftFootPivot;
            rotationAngle = 0f;
            Debug.Log("Change Feet!");
        }
        // ��������Ϊ����ת����ʾ���UI�������ҽ�UI
        if (isLeftFootPivot)
        {
            leftFootUI.SetActive(false);
            rightFootUI.SetActive(true);
        }
        // ������ҽ�Ϊ����ת����ʾ�ҽ�UI���������UI
        else
        {
            leftFootUI.SetActive(true);
            rightFootUI.SetActive(false);
        }

        // ѡ����ת���ᣬ���ݵ�ǰ��״̬
        Transform pivot = isLeftFootPivot ? leftFoot : rightFoot;

        // �ƶ���ɫ��������ת����ͽǶȣ�ʹ�ý�ɫ�ı�������ϵ
        Vector3 move = new Vector3(0, 0, Input.GetAxisRaw("Vertical") * Time.deltaTime);
        move = transform.TransformDirection(move);
        transform.RotateAround(pivot.position, Vector3.up, rotationAngle);

        foreFrameInput = horizontalInput;
    }

}
