using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // ����һ����̬��GameManagerʵ��������ʵ�ֵ���ģʽ
    public static GameManager instance;

    // ����һЩ��̬�ı����������洢��Ϸ��״̬������
    public static int score;
    public static int lives;
    public static int level;

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

    // ��Start�����У�����SetFrameRate����������Ϸ��֡������Ϊ60֡
    void Start()
    {
        SetFrameRate(60);
    }

    // ����һ����������������Ϸ��֡������Ϊָ����ֵ
    void SetFrameRate(int frameRate)
    {
        // ʹ��Application.targetFrameRate���ԣ���ָ����Ϸ��Ŀ��֡��
        Application.targetFrameRate = frameRate;
    }

    // ����һЩ��̬�ķ������������ʺ��޸���Ϸ��״̬������
    public static void AddScore(int amount)
    {
        // ���ӷ���
        score += amount;
    }

    public static void LoseLife()
    {
        // ��������
        lives--;
    }

    public static void NextLevel()
    {
        // ���ӹؿ�
        level++;
    }
}