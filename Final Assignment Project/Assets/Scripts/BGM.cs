using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    public static BGM instance;
    // Start is called before the first frame update
    // ��Awake�����У���鲢��ʼ��GameManagerʵ��
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


    // Update is called once per frame
    void Update()
    {
        
    }
}
