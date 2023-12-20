using System.Collections.Generic;
using UnityEngine;

public class SpecialFloor : MonoBehaviour
{
    // 物品的layer的层级值
    public int bottleLayer;

    // 用于生成可供角色行走的地板的预制件
    public GameObject floorTilePrefab;

    // 预制件的大小
    public Vector3 floorTileSize;

    // 以物品为中心的生成地板的范围，单位是米
    public float floorTileRange;

    // 用于存储已生成的地板的列表
    private List<GameObject> floorTiles;

    // 在开始时初始化列表
    private void Start()
    {
        floorTiles = new List<GameObject>();
    }

    // 在每一帧中检测是否有物品在特殊地板上，并根据物品的位置生成或移动地板
    private void Update()
    {
        // 获取特殊地板的碰撞体组件
        Collider collider = GetComponent<Collider>();

        // 如果没有碰撞体组件，直接返回
        if (collider == null) return;

        // 获取特殊地板的包围盒
        Bounds bounds = collider.bounds;

        // 用于存储检测到的物品的列表
        List<GameObject> bottles = new List<GameObject>();

        // 遍历所有的碰撞体
        foreach (Collider other in Physics.OverlapBox(bounds.center, bounds.extents))
        {
            // 如果碰撞体的层级是物品的层级，且在特殊地板的上方，就将其添加到物品列表中
            if (other.gameObject.layer == bottleLayer && other.transform.position.y > bounds.max.y)
            {
                bottles.Add(other.gameObject);
            }
        }

        // 如果没有检测到物品，就清空已生成的地板列表，并返回
        

        // 如果检测到物品，就根据物品的位置生成或移动地板
        GenerateFloorTiles(bottles);
    }

    // 根据物品的位置生成或移动地板的方法
    private void GenerateFloorTiles(List<GameObject> bottles)
    {
        // 计算每个方向上需要生成的地板的数量
        int xCount = Mathf.CeilToInt(floorTileRange / floorTileSize.x);
        int zCount = Mathf.CeilToInt(floorTileRange / floorTileSize.z);

        // 计算每个方向上生成地板的偏移量
        float xOffset = floorTileSize.x / 2;
        float zOffset = floorTileSize.z / 2;

        // 遍历所有的物品
        foreach (GameObject bottle in bottles)
        {
            // 获取物品的位置
            Vector3 bottlePos = bottle.transform.position;

            // 以物品为中心，遍历每个方向上的地板
            for (int x = -xCount; x <= xCount; x++)
            {
                for (int z = -zCount; z <= zCount; z++)
                {
                    // 计算地板的位置，保持与特殊地板的顶面齐平
                    Vector3 tilePos = new Vector3(bottlePos.x + x * floorTileSize.x + xOffset, transform.position.y - 0.01f, bottlePos.z + z * floorTileSize.z + zOffset);

                    // 检查是否已经有地板在该位置，如果没有，就生成一个新的地板，并将其添加到列表中a
                    if (!HasFloorTileAt(tilePos))
                    {
                        // 计算地板与物品的距离，如果小于半径，就生成地板
                        float distance = Vector3.Distance(tilePos, bottlePos);
                        if (distance < floorTileRange)
                        {
                            // 检查是否已经有地板与该位置相邻，如果没有，就生成地板
                            if (!HasFloorTileAdjacentTo(tilePos))
                            {
                                GameObject tile = Instantiate(floorTilePrefab, tilePos, Quaternion.identity);
                                floorTiles.Add(tile);
                            }
                        }
                    }
                }
            }
        }
    }

    // 检查是否已经有地板在指定的位置的方法
    private bool HasFloorTileAt(Vector3 position)
    {
        // 遍历已生成的地板列表
        foreach (GameObject tile in floorTiles)
        {
            // 如果地板的位置与指定的位置相差小于一个很小的值，就返回true
            if (Vector3.Distance(tile.transform.position, position) < 0.27f)
            {
                return true;
            }
        }

        // 如果没有找到，就返回false
        return false;
    }

    // 检查是否已经有地板与指定的位置相邻的方法
    private bool HasFloorTileAdjacentTo(Vector3 position)
    {
        // 遍历已生成的地板列表
        foreach (GameObject tile in floorTiles)
        {
            // 如果地板的位置与指定的位置在x或z方向上相差等于预制件的大小，就返回true
            if (Mathf.Abs(tile.transform.position.x - position.x) == floorTileSize.x && tile.transform.position.z == position.z)
            {
                return true;
            }
            if (Mathf.Abs(tile.transform.position.z - position.z) == floorTileSize.z && tile.transform.position.x == position.x)
            {
                return true;
            }
        }

        // 如果没有找到，就返回false
        return false;
    }

    // 清空已生成的地板列表的方法
    private void ClearFloorTiles()
    {
        // 遍历已生成的地板列表
        foreach (GameObject tile in floorTiles)
        {
            // 销毁每个地板
            Destroy(tile);
        }

        // 清空列表
        floorTiles.Clear();
    }
}
