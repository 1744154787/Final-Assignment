using UnityEngine;

public class DestroyAfterTenSeconds : MonoBehaviour
{
    //public ���

    void Start()
    {
        Destroy(gameObject, 10f);
        //����һ�����ظ��ı��
    }

    private void OnDestroy()
    {
        // ��Sepcial Floor ��Dic��Ѷ�Ӧ��ש��ɾ��
    }
}
