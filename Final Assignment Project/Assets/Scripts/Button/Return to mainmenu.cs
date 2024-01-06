using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Returntomainmenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        // 调用DontDestroyOnLoad方法，传入按钮对象
        Object.DontDestroyOnLoad(this);
    }

    
}
