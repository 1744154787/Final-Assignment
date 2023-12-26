using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReLoadScene : MonoBehaviour
{
    // ����һ�������������洢��ɫ����͸߶�
    public float minHeight = -10f;

    // ��ÿһ֡�У�����ɫ�ĸ߶Ⱥ���ҵ�����
    void Update()
    {
        // �����ɫ�ĸ߶ȵ�����͸߶ȣ����¼��س���
        if (transform.position.y < minHeight)
        {
            ReloadScene();
        }

        // �����Ұ�����R�������¼��س���
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadScene();
        }
    }

    // ����һ���������������¼�����Ϸ����
    void ReloadScene()
    {
        // ��ȡ��ǰ�ĳ�������
        Scene currentScene = SceneManager.GetActiveScene();

        // ���¼��ظó���
        SceneManager.LoadScene(currentScene.name);
    }
}