// BottleSpawner.cs
using UnityEngine;

public class BottleSpawner : MonoBehaviour
{
    // ��Awake��Start�����У�����BottleManager��SpawnRandomBottle�������������ɵ�Ԥ�Ƽ���λ�ú���ת����Ϊ��������λ�ú���ת
    void Start()
    {
        // ����BottleManager��SpawnRandomBottle��������ȡһ��Ԥ�Ƽ���ʵ��
        GameObject bottle = BottleManager.Instance.SpawnRandomBottle();
        // ��Ԥ�Ƽ���λ������Ϊ��������λ��
        bottle.transform.position = transform.position;
        // ��Ԥ�Ƽ�����ת����Ϊ����������ת
        bottle.transform.rotation = transform.rotation;
    }
}
