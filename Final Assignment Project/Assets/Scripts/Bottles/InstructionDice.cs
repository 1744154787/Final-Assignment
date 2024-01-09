using UnityEngine;
using System.Collections;


public class InstructionDice : MonoBehaviour // 修改类名
{
    // 声明一个公共变量，存储你的子物体中的多段文字
    public GameObject[] texts;

    // 声明一个布尔变量，控制是否可以更换文字
    private bool canChange = true;

    // 声明一个布尔变量，记录是否发生了碰撞
    private bool isCollided = false;

    // 声明一个整型变量，记录当前显示的文字的索引 // 新增
    private int textIndex = 0;

    // 在Start方法中初始化，将所有的文字设为不可见
    void Start()
    {
        foreach (GameObject text in texts)
        {
            text.SetActive(false);
        }
    }

    // 在OnCollisionEnter方法中检测碰撞
    void OnCollisionEnter(Collision collision)
    {
        // 如果碰撞的物体的layer是Feet，并且可以更换文字
        if (collision.gameObject.layer == LayerMask.NameToLayer("Feet") && canChange)
        {
            // 根据textIndex的值选择一个文字，将其设为可见 // 修改
            GameObject text = texts[textIndex];
            text.SetActive(true);
            // 将其他的文字设为不可见
            foreach (GameObject other in texts)
            {
                if (other != text)
                {
                    other.SetActive(false);
                }
            }

            // 将textIndex加一，如果超过了texts数组的长度，就将它重置为0 // 新增
            textIndex++;
            if (textIndex >= texts.Length)
            {
                textIndex = 0;
            }

            // 将canChange设为false，防止在5秒内再次更换文字
            canChange = false;

            // 将isCollided设为true，表示发生了碰撞
            isCollided = true;

            // 调用协程，延迟5秒后将canChange设为true，允许下一次更换文字
            StartCoroutine(DelayChange());
        }
    }

    // 在OnCollisionExit方法中检测碰撞结束
    void OnCollisionExit(Collision collision)
    {
        // 如果碰撞的物体的layer是Feet
        if (collision.gameObject.layer == LayerMask.NameToLayer("Feet"))
        {
            // 将isCollided设为false，表示没有碰撞
            isCollided = false;
        }
    }

    // 定义一个协程，延迟5秒后将canChange设为true
    private IEnumerator DelayChange()
    {
        // 等待5秒
        yield return new WaitForSeconds(2);

        // 将canChange设为true
        canChange = true;

        // 如果没有碰撞
        if (!isCollided)
        {
            // 将当前显示的文字设为不可见 // 修改
            GameObject text = texts[textIndex];
            text.SetActive(false);
        }
    }
}
