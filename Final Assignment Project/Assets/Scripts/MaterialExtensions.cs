using UnityEngine;

// 创建一个静态类，用于定义拓展方法
public static class MaterialExtensions
{
    // 定义一个拓展方法，用于设置浮点数组的某个元素的值
    public static void SetFloatArrayElement(this Material material, string name, int index, float value)
    {
        // 获取浮点数组的值
        float[] values = material.GetFloatArray(name);

        // 如果索引有效
        if (index >= 0 && index < values.Length)
        {
            // 修改数组的元素
            values[index] = value;

            // 设置数组的值
            material.SetFloatArray(name, values);
        }
        // 如果索引无效
        else
        {
            // 抛出一个异常
            throw new System.IndexOutOfRangeException("Index out of range");
        }
    }
}
