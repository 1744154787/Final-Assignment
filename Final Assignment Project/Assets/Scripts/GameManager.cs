using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 定义一个静态的GameManager实例，用来实现单例模式
    public static GameManager instance;

    // 定义一些静态的变量，用来存储游戏的状态和数据
    public static int score;
    public static int lives;
    public static int level;

    // 在Awake方法中，检查并初始化GameManager实例
    void Awake()
    {
        // 如果GameManager实例不存在，就将当前对象赋值给它
        if (instance == null)
        {
            instance = this;
        }
        // 如果GameManager实例已经存在，但不是当前对象，就销毁当前对象
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        // 使当前对象在加载新场景时不被销毁
        DontDestroyOnLoad(gameObject);
    }

    // 在Start方法中，调用SetFrameRate方法，将游戏的帧率设置为60帧
    void Start()
    {
        SetFrameRate(60);
    }

    // 定义一个方法，用来将游戏的帧率设置为指定的值
    void SetFrameRate(int frameRate)
    {
        // 使用Application.targetFrameRate属性，来指定游戏的目标帧率
        Application.targetFrameRate = frameRate;
    }

    // 定义一些静态的方法，用来访问和修改游戏的状态和数据
    public static void AddScore(int amount)
    {
        // 增加分数
        score += amount;
    }

    public static void LoseLife()
    {
        // 减少生命
        lives--;
    }

    public static void NextLevel()
    {
        // 增加关卡
        level++;
    }
}