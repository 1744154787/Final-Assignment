// BottleManager.cs
using UnityEngine;

public class BottleManager : MonoBehaviour
{
    // ����һ��˽�еľ�̬��BottleManager�����������洢������ʵ��
    private static BottleManager instance;

    // ����һ�������ľ�̬��BottleManager���ԣ�������ȡ������ʵ��
    public static BottleManager Instance
    {
        get
        {
            // ���ʵ��Ϊ�գ����ڳ����в���BottleManager���
            if (instance == null)
            {
                instance = FindObjectOfType<BottleManager>();
            }
            // ����ʵ��
            return instance;
        }
    }
    void Awake()
    {
        // ���GameManagerʵ�������ڣ��ͽ���ǰ����ֵ����
        if (instance == null)
        {
            instance = this;
        }
        // ���GameManagerʵ���Ѿ����ڣ������ǵ�ǰ���󣬾����ٵ�ǰ����
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        // ʹ��ǰ�����ڼ����³���ʱ��������
        DontDestroyOnLoad(gameObject);

    }

    // ����һ��������GameObject���飬�����洢Ԥ�Ƽ�
    public GameObject[] bottles;

    // ����һ�������ķ����������������һ��Ԥ�Ƽ�����������
    public GameObject SpawnRandomBottle()
    {
        // ���ѡ��һ�������е�����
        int index = Random.Range(0, bottles.Length);
        // ��������ѡ��һ��Ԥ�Ƽ�
        GameObject bottle = bottles[index];
        // ����һ��Ԥ�Ƽ���ʵ������������
        return Instantiate(bottle);
    }
}
