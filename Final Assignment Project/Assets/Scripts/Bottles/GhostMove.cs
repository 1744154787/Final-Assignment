using UnityEngine;

public class GhostMove : MonoBehaviour
{
    // ����һ��������������������С���������ϵ��
    public float damping;

    // ��OnCollisionEnter�����м����ײ
    void OnCollisionEnter(Collision collision)
    {
        // �����ײ�������layer��Feet
        if (collision.gameObject.layer == LayerMask.NameToLayer("Feet"))
        {
            // ��ȡRigidbody���������
            Rigidbody rigidbody = GetComponent<Rigidbody>();

            // ��ȡ��ײ������ٶȣ�����һ��ϵ������С����һ��������������������Ž�ɫ�����ķ����ƶ�
            Vector3 force = -collision.relativeVelocity * 0.5f;
            rigidbody.AddForce(force, ForceMode.Impulse);
        }
    }

    // ��FixedUpdate�����п���С����ļ���
    void FixedUpdate()
    {
        // ��ȡRigidbody���������
        Rigidbody rigidbody = GetComponent<Rigidbody>();

        // ��С����һ������������������𽥼���
        rigidbody.AddForce(-rigidbody.velocity * damping, ForceMode.Force);
    }
}
