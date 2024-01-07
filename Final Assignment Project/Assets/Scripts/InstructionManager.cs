using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InstructionManager : MonoBehaviour
{
    public GameObject[] instructions; // �������instruction���ֵ���Ϸ���������
    // �������Unity����������н�����ı�������ק����������У���������Ҫ��˳������

    // �������������������ı����ͷ�������������instruction���ֵ���ʾ�����أ���������������

    private int index = 0; // ������¼��ǰ��ʾ��instruction������
    private int count = 0; // ������¼��Ұ���A����D���Ĵ���
    private float timer = 0f; // ������¼instruction��ʾ��ʱ��
    private float interval = 6f; // ��������instruction��ʾ�ļ��
    private int countS = 0; // ������¼��Ұ���S���Ĵ���

    private void Start()
    {
        // ��ʼʱ�������е�instruction
        foreach (GameObject instruction in instructions)
        {
            instruction.SetActive(false);
        }
        // ��ʾ��һ��instruction
        instructions[index].SetActive(true);
    }

    private void Update()
    {
        // �����ǰ��ʾ��instruction���ǵ�������Ҳ�������һ��
        if (index != 2 && index < instructions.Length - 1)
        {
            // ��ʱ���ۼ�
            timer += Time.deltaTime;
            // �����ʱ�������˼��
            if (timer > interval)
            {
                // ���ص�ǰ��instruction
                instructions[index].SetActive(false);
                // ������һ
                index++;
                // ��ʾ��һ��instruction
                instructions[index].SetActive(true);
                // ���ü�ʱ��
                timer = 0f;
            }
        }
        // �����ǰ��ʾ��instruction�ǵ�����
        else if (index == 2)
        {
            // �����Ұ�����A����D��
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            {
                // ��������һ
                count++;
                // ����������ﵽ�����
                if (count == 5)
                {
                    // ���ص�ǰ��instruction
                    instructions[index].SetActive(false);
                    // ������һ
                    index++;
                    // ��ʾ��һ��instruction
                    instructions[index].SetActive(true);
                    // ���ü�����
                    count = 0;
                }
            }
        }
        else if (index == 3)
        {
            // �����Ұ�����S��
            if (Input.GetKeyDown(KeyCode.S))
            {
                // ������S��һ
                countS++;
                // ���������S�ﵽ������
                if (countS == 3)
                {
                    // ���ص�ǰ��instruction
                    instructions[index].SetActive(false);
                    // ������һ
                    index++;
                    // ��ʾ��һ��instruction
                    instructions[index].SetActive(true);
                    // ���ü�����S
                    countS = 0;
                }
            }
        }
        else if (index == 4 && index == 5)
        {
            // ��ʱ���ۼ�
            timer += Time.deltaTime;
            // �����ʱ�������˼��
            if (timer > interval)
            {
                // ���ص�ǰ��instruction
                instructions[index].SetActive(false);
                // ������һ
                index++;
                // ��ʾ��һ��instruction
                instructions[index].SetActive(true);
                // ���ü�ʱ��
                timer = 0f;
            }
        }

    }
}
