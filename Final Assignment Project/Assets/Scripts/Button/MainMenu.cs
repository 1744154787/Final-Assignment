using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // �˳���Ϸ�ĺ���
    public void QuitGame()
    {
        // ��ӡһ����Ϣ����ʾ����˳���Ϸ
        Debug.Log("Quit Game");
        // ����Unity�ĺ������˳���Ϸ
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
