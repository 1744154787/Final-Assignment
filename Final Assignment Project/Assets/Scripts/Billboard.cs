using UnityEngine;

public class Billboard : MonoBehaviour
{
    // �����������
    private Camera cam;

    // ��ʼʱ
    void Start()
    {
        // ��ȡ�����б�ǩΪ"myCamera"�������
        cam = GameObject.FindGameObjectWithTag("myCamera").GetComponent<Camera>();
    }

    // ÿ֡����ʱ
    void Update()
    {
        // �ö�������泯���������λ��
        transform.LookAt(transform.position + cam.transform.forward);
    }
}
