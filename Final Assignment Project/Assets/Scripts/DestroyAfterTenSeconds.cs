using UnityEngine;



public class DestroyAfterTenSeconds : MonoBehaviour
{
    //public 编号
    // public int id; // 添加这一行

    //void Start()
    //{

    //Destroy(gameObject, 10f);
    //生成一个不重复的编号
    //id = SpecialFloor.floorTilesDic.Count; // 添加这一行
    //}

    void OnDestroy()
    {
        // 遍历字典，找到地板对应的键
        int key = -1;
        foreach (var pair in SpecialFloor.floorTilesDic)
        {
            if (pair.Value == gameObject)
            {
                key = pair.Key;
                break;
            }
        }
        // 如果找到了键，就从字典中移除
        if (key != -1)
        {
            SpecialFloor.floorTilesDic.Remove(key);
        }
    }
}
