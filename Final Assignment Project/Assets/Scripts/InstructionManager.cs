using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InstructionManager : MonoBehaviour
{
    public GameObject[] instructions; // 存放所有instruction文字的游戏对象的数组
    // 你可以在Unity的属性面板中将你的文本对象拖拽到这个数组中，按照你想要的顺序排列

    // 你可以在这里添加其他的变量和方法，用来控制instruction文字的显示和隐藏，根据你的设计需求

    private int index = 0; // 用来记录当前显示的instruction的索引
    private int count = 0; // 用来记录玩家按下A键或D键的次数
    private float timer = 0f; // 用来记录instruction显示的时间
    private float interval = 6f; // 用来设置instruction显示的间隔
    private int countS = 0; // 用来记录玩家按下S键的次数

    private void Start()
    {
        // 开始时隐藏所有的instruction
        foreach (GameObject instruction in instructions)
        {
            instruction.SetActive(false);
        }
        // 显示第一个instruction
        instructions[index].SetActive(true);
    }

    private void Update()
    {
        // 如果当前显示的instruction不是第三个，也不是最后一个
        if (index != 2 && index < instructions.Length - 1)
        {
            // 计时器累加
            timer += Time.deltaTime;
            // 如果计时器超过了间隔
            if (timer > interval)
            {
                // 隐藏当前的instruction
                instructions[index].SetActive(false);
                // 索引加一
                index++;
                // 显示下一个instruction
                instructions[index].SetActive(true);
                // 重置计时器
                timer = 0f;
            }
        }
        // 如果当前显示的instruction是第三个
        else if (index == 2)
        {
            // 如果玩家按下了A键或D键
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            {
                // 计数器加一
                count++;
                // 如果计数器达到了五次
                if (count == 5)
                {
                    // 隐藏当前的instruction
                    instructions[index].SetActive(false);
                    // 索引加一
                    index++;
                    // 显示下一个instruction
                    instructions[index].SetActive(true);
                    // 重置计数器
                    count = 0;
                }
            }
        }
        else if (index == 3)
        {
            // 如果玩家按下了S键
            if (Input.GetKeyDown(KeyCode.S))
            {
                // 计数器S加一
                countS++;
                // 如果计数器S达到了三次
                if (countS == 3)
                {
                    // 隐藏当前的instruction
                    instructions[index].SetActive(false);
                    // 索引加一
                    index++;
                    // 显示下一个instruction
                    instructions[index].SetActive(true);
                    // 重置计数器S
                    countS = 0;
                }
            }
        }
        else if (index == 4 && index == 5)
        {
            // 计时器累加
            timer += Time.deltaTime;
            // 如果计时器超过了间隔
            if (timer > interval)
            {
                // 隐藏当前的instruction
                instructions[index].SetActive(false);
                // 索引加一
                index++;
                // 显示下一个instruction
                instructions[index].SetActive(true);
                // 重置计时器
                timer = 0f;
            }
        }

    }
}
