using UnityEngine;
using System.Collections;


public class DiceText : MonoBehaviour
{
    // ����һ�������������洢����������еĶ������
    public GameObject[] texts;

    // ����һ�����������������Ƿ���Ը�������
    private bool canChange = true;

    // ����һ��������������¼�Ƿ�������ײ
    private bool isCollided = false; // ����

    // ��Start�����г�ʼ���������е�������Ϊ���ɼ�
    void Start()
    {
        foreach (GameObject text in texts)
        {
            text.SetActive(false);
        }
    }

    // ��OnCollisionEnter�����м����ײ
    void OnCollisionEnter(Collision collision)
    {
        // �����ײ�������layer��Feet�����ҿ��Ը�������
        if (collision.gameObject.layer == LayerMask.NameToLayer("Feet") && canChange)
        {
            // ���ѡ��һ�����֣�������Ϊ�ɼ�
            int index = Random.Range(0, texts.Length);
            GameObject text = texts[index];
            text.SetActive(true);

            // ��������������Ϊ���ɼ�
            foreach (GameObject other in texts)
            {
                if (other != text)
                {
                    other.SetActive(false);
                }
            }

            // ��canChange��Ϊfalse����ֹ��5�����ٴθ�������
            canChange = false;

            // ��isCollided��Ϊtrue����ʾ��������ײ
            isCollided = true; // ����

            // ����Э�̣��ӳ�5���canChange��Ϊtrue��������һ�θ�������
            StartCoroutine(DelayChange());
        }
    }

    // ��OnCollisionExit�����м����ײ����
    void OnCollisionExit(Collision collision)
    {
        // �����ײ�������layer��Feet
        if (collision.gameObject.layer == LayerMask.NameToLayer("Feet"))
        {
            // ��isCollided��Ϊfalse����ʾû����ײ
            isCollided = false; // ����
        }
    }

    // ����һ��Э�̣��ӳ�5���canChange��Ϊtrue
    private IEnumerator DelayChange()
    {
        // �ȴ�5��
        yield return new WaitForSeconds(5);

        // ��canChange��Ϊtrue
        canChange = true;

        // ���û����ײ
        if (!isCollided) // ����
        {
            // �����е�������Ϊ���ɼ�
            foreach (GameObject text in texts)
            {
                text.SetActive(false);
            }
        }
    }
}
