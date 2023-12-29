using UnityEngine;

public class CubeTrap : MonoBehaviour
{
    // �ƶ�����������ڱ༭���е���
    public float moveInterval = 3f;

    // �ƶ����룬�����ڱ༭���е���
    public float moveDistance = 10f;

    // �ƶ����򣬿����ڱ༭���е���
    public Vector3 moveDirection = Vector3.forward;

    // ��ֹʱ�䣬�����ڱ༭���е���
    public float stopTime = 1f;

    // ��¼������ĳ�ʼλ��
    private Vector3 initialPosition;

    // ��¼��������˶�״̬��0Ϊ��ֹ��1Ϊ��ǰ�ƶ���2Ϊ��ֹ��3Ϊ����
    private int moveState;

    // ��¼��������һ�θı�״̬��ʱ��
    private float lastChangeTime;

    // ����Ϸ��ʼʱ��ȡtransformer��������ã��Լ���¼��ʼλ�úͳ�ʼ״̬
    private void Start()
    {
        initialPosition = transform.position;
        moveState = 0;
        lastChangeTime = Time.time;
    }

    // ��ÿһ֡�и�����������ƶ�
    private void Update()
    {
        // ������������˶�״̬��ִ�в�ͬ�Ĳ���
        switch (moveState)
        {
            case 0: // ��ֹ״̬
                // ���������һ�θı�״̬��ʱ�䳬�����ƶ����
                if (Time.time - lastChangeTime > moveInterval)
                {
                    // �ı���������˶�״̬Ϊ��ǰ�ƶ��������¸ı�״̬��ʱ��
                    moveState = 1;
                    lastChangeTime = Time.time;
                }
                break;
            case 1: // ��ǰ�ƶ�״̬
                // ��������ʼλ�õľ���С���ƶ�����
                if (Vector3.Distance(transform.position, initialPosition) < moveDistance)
                {
                    // �����������Ŀ��λ�ã����ݳ�ʼλ�ã��ƶ�������ƶ�����
                    Vector3 targetPosition = initialPosition + moveDirection.normalized * moveDistance;

                    // ��������ƽ�����ƶ���Ŀ��λ�ã�����һ���̶����ٶ�
                    transform.position = Vector3.MoveTowards(transform.position, targetPosition, 5f * Time.deltaTime);
                }
                else
                {
                    // ���򣬸ı���������˶�״̬Ϊ��ֹ�������¸ı�״̬��ʱ��
                    moveState = 2;
                    lastChangeTime = Time.time;
                }
                break;
            case 2: // ��ֹ״̬
                // ���������һ�θı�״̬��ʱ�䳬���˾�ֹʱ��
                if (Time.time - lastChangeTime > stopTime)
                {
                    // �ı���������˶�״̬Ϊ���أ������¸ı�״̬��ʱ��
                    moveState = 3;
                    lastChangeTime = Time.time;
                }
                break;
            case 3: // ����״̬
                // ��������ʼλ�õľ��������
                if (Vector3.Distance(transform.position, initialPosition) > 0f)
                {
                    // �����������Ŀ��λ�ã����ݳ�ʼλ��
                    Vector3 targetPosition = initialPosition;

                    // ��������ƽ�����ƶ���Ŀ��λ�ã�����һ���̶����ٶ�
                    transform.position = Vector3.MoveTowards(transform.position, targetPosition, 5f * Time.deltaTime);
                }
                else
                {
                    // ���򣬸ı���������˶�״̬Ϊ��ֹ�������¸ı�״̬��ʱ��
                    moveState = 0;
                    lastChangeTime = Time.time;
                }
                break;
        }
    }
}
