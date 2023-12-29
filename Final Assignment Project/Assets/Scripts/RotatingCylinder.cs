using UnityEngine;

public class RotatingCylinder : MonoBehaviour
{
    // ��ת�ٶȣ������ڱ༭���е���
    public float rotateSpeed = 10f;

    // �ƿ����ȣ������ڱ༭���е���
    public float pushForce = 100f;

    // ������������ã�������ȡ������Բ����Ľ��ٶ�
    private Rigidbody rb;

    // ����Ϸ��ʼʱ��ȡ�������������
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // ��ÿһ֡�и���Բ����Ľ��ٶȣ�ʹ��Χ�ƴ�ֱ��ƽ�����ֱ����ת
    private void Update()
    {
        // ������ת�ᣬ����Բ�������ת���򣬿�����transform.right����transform.forward
        Vector3 rotateAxis = transform.right;

        // ������ٶȣ�������ת�����ת�ٶ�
        Vector3 angularVelocity = rotateAxis * rotateSpeed;

        // ���ø�������Ľ��ٶ�
        rb.angularVelocity = angularVelocity;
    }
}