using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    // ����һ����̬��GameManagerʵ��������ʵ�ֵ���ģʽ
    public static GameManager instance;

    // ����һЩ��̬�ı����������洢��Ϸ��״̬������
    public static int score;
    public static int lives;
    public static int level;

    

    // ��Ϸ�Ƿ���ͣ�ı���
    public bool isPaused = false;

    

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

    private void Update()
    {
        // �������Ƿ�����esc��
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // �����л���Ϸ��ͣ״̬�ĺ���
            TogglePause();
        }
    }
    // �л���Ϸ��ͣ״̬�ĺ���
    public void TogglePause()
    {
        // �����Ϸ����ͣ�ģ��ͻָ���Ϸ
        if (isPaused)
        {
            // ����ʱ������Ϊ1����ʾ�����ٶ�
            Time.timeScale = 1;
            // ������Ϸ��ͣ����Ϊfalse
            isPaused = false;
            
        }
        // �����Ϸ�������ģ�����ͣ��Ϸ
        else
        {
            // ����ʱ������Ϊ0����ʾֹͣ
            Time.timeScale = 0;
            // ������Ϸ��ͣ����Ϊtrue
            isPaused = true;
            
        }
    }

    
    // ��ʾ�������˵���ť�ĺ���
    public void ShowPauseButton()
    {
        // ���ð�ť�Ŀɼ���Ϊtrue
       
    }

    // ���ط������˵���ť�ĺ���
    public void HidePauseButton()
    {
        // ���ð�ť�Ŀɼ���Ϊfalse
        
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