// BottleSpawner.cs
using UnityEngine;

public class BottleSpawner : MonoBehaviour
{
    // 在Awake或Start方法中，调用BottleManager的SpawnRandomBottle方法，并把生成的预制件的位置和旋转设置为生成器的位置和旋转
    void Start()
    {
        // 调用BottleManager的SpawnRandomBottle方法，获取一个预制件的实例
        GameObject bottle = BottleManager.Instance.SpawnRandomBottle();
        // 把预制件的位置设置为生成器的位置
        bottle.transform.position = transform.position;
        // 把预制件的旋转设置为生成器的旋转
        bottle.transform.rotation = transform.rotation;
    }
}
