using UnityEngine;

// ����һ����̬�࣬���ڶ�����չ����
public static class MaterialExtensions
{
    // ����һ����չ�������������ø��������ĳ��Ԫ�ص�ֵ
    public static void SetFloatArrayElement(this Material material, string name, int index, float value)
    {
        // ��ȡ���������ֵ
        float[] values = material.GetFloatArray(name);

        // ���������Ч
        if (index >= 0 && index < values.Length)
        {
            // �޸������Ԫ��
            values[index] = value;

            // ���������ֵ
            material.SetFloatArray(name, values);
        }
        // ���������Ч
        else
        {
            // �׳�һ���쳣
            throw new System.IndexOutOfRangeException("Index out of range");
        }
    }
}
