using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMovement : MonoBehaviour
{
    public Transform leftFoot; // ��ɫ������Ӷ���
    public Transform rightFoot; // ��ɫ���ҽ��Ӷ���
    public float rotationSpeed = 180f; // ��ɫ����ת�ٶ�
    public float maxRotationSpeed = 360f; // ��ɫ����ת�ٶȵ����ֵ
    

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

        // �����Ұ���A�������ҽ�Ϊ��˳ʱ����ת
        if (horizontalInput == -1)
        {
            // ������ת�Ƕȣ����ݰ����ķ����ʱ�䣬���������ֵ��Χ��
            // �����סS������ת��ת����
            rotationAngle += Mathf.Clamp((Input.GetKey(KeyCode.S) ? -1 : 1) * rotationSpeed * Time.deltaTime, -maxRotationSpeed, maxRotationSpeed);
            // ������ת����Ϊ�ҽ�
            isLeftFootPivot = false;
        }
        // �����Ұ���D���������Ϊ����ʱ����ת
        else if (horizontalInput == 1)
        {
            // ������ת�Ƕȣ����ݰ����ķ����ʱ�䣬���������ֵ��Χ��
            // �����סS������ת��ת����
            rotationAngle -= Mathf.Clamp((Input.GetKey(KeyCode.S) ? -1 : 1) * rotationSpeed * Time.deltaTime, -maxRotationSpeed, maxRotationSpeed);
            // ������ת����Ϊ���
            isLeftFootPivot = true;
        }
        // �������ɿ�A��D����������ת�Ƕ�
        if ((horizontalInput == 0 && rotationAngle != 0) || (horizontalInput * foreFrameInput) < 0)
        {
            rotationAngle = 0f;
            //Debug.Log("Reset Angle!");
        }
       

        foreFrameInput = horizontalInput;
    }

    // �ڹ̶���ʱ�����ڵ���
    private void FixedUpdate()
    {
        // ѡ����ת���ᣬ���ݵ�ǰ��״̬
        Transform pivot = isLeftFootPivot ? leftFoot : rightFoot;

        // �ƶ���ɫ��������ת����ͽǶȣ�ʹ�ý�ɫ�ı�������ϵ
        Vector3 move = new Vector3(0, 0, Input.GetAxisRaw("Vertical") * Time.fixedDeltaTime);
        move = transform.TransformDirection(move);
        transform.RotateAround(pivot.position, Vector3.up, rotationAngle);
    }
}
