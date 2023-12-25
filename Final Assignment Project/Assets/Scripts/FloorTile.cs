using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTile : MonoBehaviour
{
    //public 编号

    // Start is called before the first frame update
    void Start()
    {
      //自动生成一个不重复编号   
      //注册到管理器的Dic
    }

 

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        // 在Sepcial Floor 的Dic里把对应的砖块删掉/告诉对象池关掉对象
        
    }
}
