using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReLoadScene : MonoBehaviour
{
    // 定义一个变量，用来存储角色的最低高度
    public float minHeight = -10f;

    // 在每一帧中，检查角色的高度和玩家的输入
    void Update()
    {
        // 如果角色的高度低于最低高度，重新加载场景
        if (transform.position.y < minHeight)
        {
            ReloadScene();
        }

        // 如果玩家按下了R键，重新加载场景
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadScene();
        }
    }

    // 定义一个方法，用来重新加载游戏场景
    void ReloadScene()
    {
        // 获取当前的场景对象
        Scene currentScene = SceneManager.GetActiveScene();

        // 重新加载该场景
        SceneManager.LoadScene(currentScene.name);
    }
}