using UnityEngine;

public class DestroyAfterTenSeconds : MonoBehaviour
{
    //public 编号

    void Start()
    {
        Destroy(gameObject, 10f);
        //生成一个不重复的编号
    }

    private void OnDestroy()
    {
        // 在Sepcial Floor 的Dic里把对应的砖块删掉
    }
}
