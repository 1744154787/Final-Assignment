using UnityEngine;

public class Billboard : MonoBehaviour
{
    // �����������
    public Camera cam;

    // ÿ֡����ʱ
    void Update()
    {
        // �ö�������泯���������λ��
        transform.LookAt(transform.position + cam.transform.forward);
    }
}
