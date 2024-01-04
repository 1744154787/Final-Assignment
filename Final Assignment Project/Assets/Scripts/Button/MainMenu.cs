using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // 退出游戏的函数
    public void QuitGame()
    {
        // 打印一条消息，提示玩家退出游戏
        Debug.Log("Quit Game");
        // 调用Unity的函数，退出游戏
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
