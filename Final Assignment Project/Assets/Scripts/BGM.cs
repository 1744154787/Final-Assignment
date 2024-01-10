using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    public static BGM instance;
    // Start is called before the first frame update
    // 在Awake方法中，检查并初始化GameManager实例
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


    // Update is called once per frame
    void Update()
    {
        
    }
}
