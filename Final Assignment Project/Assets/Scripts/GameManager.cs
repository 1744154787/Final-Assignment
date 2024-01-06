using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    // 定义一个静态的GameManager实例，用来实现单例模式
    public static GameManager instance;

    // 定义一些静态的变量，用来存储游戏的状态和数据
    public static int score;
    public static int lives;
    public static int level;



    // 游戏是否暂停的变量
    public bool isPaused = false;

    // 定义一个公共的Button类型的变量，用来引用返回主菜单的按钮
    public Button pauseButton; // 添加

  



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

    private void Update()
    {
        // 检测玩家是否按下了esc键
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // 调用切换游戏暂停状态的函数
            TogglePause();
        }
    }
    // 切换游戏暂停状态的函数
    public void TogglePause()
    {
        // 检查当前的场景索引是否大于2，如果是，才执行暂停或恢复游戏的逻辑 // 添加
        if (SceneManager.GetActiveScene().buildIndex > 1)
        {
            // 如果游戏是暂停的，就恢复游戏
            if (isPaused)
            {
                // 设置时间流速为1，表示正常速度
                Time.timeScale = 1;
                // 设置游戏暂停变量为false
                isPaused = false;
                // 隐藏返回主菜单按钮 // 修改
                HidePauseButton();
            }
            // 如果游戏是正常的，就暂停游戏
            else
            {
                // 设置时间流速为0，表示停止
                Time.timeScale = 0;
                // 设置游戏暂停变量为true
                isPaused = true;
                // 显示返回主菜单按钮 // 修改
                ShowPauseButton();
            }
        }
    }


    // 显示返回主菜单按钮的函数
    public void ShowPauseButton()
    {
        // 设置按钮的可见性为true
        pauseButton.gameObject.SetActive(true); // 修改
    }

    // 隐藏返回主菜单按钮的函数
    public void HidePauseButton()
    {
        // 设置按钮的可见性为false
        pauseButton.gameObject.SetActive(false); // 修改
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

    // 定义一个方法，用来加载主菜单场景 // 添加
    public void ReturnToMainMenu()
    {
        // 加载名为"MainMenu"的场景
        SceneManager.LoadScene(0);
    }
}
