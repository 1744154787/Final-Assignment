using UnityEngine;



public class DestroyAfterTenSeconds : MonoBehaviour
{
    //public ���
    // public int id; // �����һ��

    //void Start()
    //{

    //Destroy(gameObject, 10f);
    //����һ�����ظ��ı��
    //id = SpecialFloor.floorTilesDic.Count; // �����һ��
    //}

    void OnDestroy()
    {
        // �����ֵ䣬�ҵ��ذ��Ӧ�ļ�
        int key = -1;
        foreach (var pair in SpecialFloor.floorTilesDic)
        {
            if (pair.Value == gameObject)
            {
                key = pair.Key;
                break;
            }
        }
        // ����ҵ��˼����ʹ��ֵ����Ƴ�
        if (key != -1)
        {
            SpecialFloor.floorTilesDic.Remove(key);
        }
    }
}
