// BottleManager.cs
using UnityEngine;

public class BottleManager : MonoBehaviour
{
    // 声明一个私有的静态的BottleManager变量，用来存储单例的实例
    private static BottleManager instance;

    // 声明一个公共的静态的BottleManager属性，用来获取单例的实例
    public static BottleManager Instance
    {
        get
        {
            // 如果实例为空，就在场景中查找BottleManager组件
            if (instance == null)
            {
                instance = FindObjectOfType<BottleManager>();
            }
            // 返回实例
            return instance;
        }
    }
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

    // 声明一个公共的GameObject数组，用来存储预制件
    public GameObject[] bottles;

    // 声明一个公共的方法，用来随机生成一个预制件，并返回它
    public GameObject SpawnRandomBottle()
    {
        // 随机选择一个数组中的索引
        int index = Random.Range(0, bottles.Length);
        // 根据索引选择一个预制件
        GameObject bottle = bottles[index];
        // 生成一个预制件的实例，并返回它
        return Instantiate(bottle);
    }
}
