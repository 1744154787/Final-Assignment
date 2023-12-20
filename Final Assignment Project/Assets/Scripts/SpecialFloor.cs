using System.Collections.Generic;
using UnityEngine;

public class SpecialFloor : MonoBehaviour
{
    // ��Ʒ��layer�Ĳ㼶ֵ
    public int bottleLayer;

    // �������ɿɹ���ɫ���ߵĵذ��Ԥ�Ƽ�
    public GameObject floorTilePrefab;

    // Ԥ�Ƽ��Ĵ�С
    public Vector3 floorTileSize;

    // ����ƷΪ���ĵ����ɵذ�ķ�Χ����λ����
    public float floorTileRange;

    // ���ڴ洢�����ɵĵذ���б�
    private List<GameObject> floorTiles;

    // �ڿ�ʼʱ��ʼ���б�
    private void Start()
    {
        floorTiles = new List<GameObject>();
    }

    // ��ÿһ֡�м���Ƿ�����Ʒ������ذ��ϣ���������Ʒ��λ�����ɻ��ƶ��ذ�
    private void Update()
    {
        // ��ȡ����ذ����ײ�����
        Collider collider = GetComponent<Collider>();

        // ���û����ײ�������ֱ�ӷ���
        if (collider == null) return;

        // ��ȡ����ذ�İ�Χ��
        Bounds bounds = collider.bounds;

        // ���ڴ洢��⵽����Ʒ���б�
        List<GameObject> bottles = new List<GameObject>();

        // �������е���ײ��
        foreach (Collider other in Physics.OverlapBox(bounds.center, bounds.extents))
        {
            // �����ײ��Ĳ㼶����Ʒ�Ĳ㼶����������ذ���Ϸ����ͽ�����ӵ���Ʒ�б���
            if (other.gameObject.layer == bottleLayer && other.transform.position.y > bounds.max.y)
            {
                bottles.Add(other.gameObject);
            }
        }

        // ���û�м�⵽��Ʒ������������ɵĵذ��б�������
        

        // �����⵽��Ʒ���͸�����Ʒ��λ�����ɻ��ƶ��ذ�
        GenerateFloorTiles(bottles);
    }

    // ������Ʒ��λ�����ɻ��ƶ��ذ�ķ���
    private void GenerateFloorTiles(List<GameObject> bottles)
    {
        // ����ÿ����������Ҫ���ɵĵذ������
        int xCount = Mathf.CeilToInt(floorTileRange / floorTileSize.x);
        int zCount = Mathf.CeilToInt(floorTileRange / floorTileSize.z);

        // ����ÿ�����������ɵذ��ƫ����
        float xOffset = floorTileSize.x / 2;
        float zOffset = floorTileSize.z / 2;

        // �������е���Ʒ
        foreach (GameObject bottle in bottles)
        {
            // ��ȡ��Ʒ��λ��
            Vector3 bottlePos = bottle.transform.position;

            // ����ƷΪ���ģ�����ÿ�������ϵĵذ�
            for (int x = -xCount; x <= xCount; x++)
            {
                for (int z = -zCount; z <= zCount; z++)
                {
                    // ����ذ��λ�ã�����������ذ�Ķ�����ƽ
                    Vector3 tilePos = new Vector3(bottlePos.x + x * floorTileSize.x + xOffset, transform.position.y - 0.01f, bottlePos.z + z * floorTileSize.z + zOffset);

                    // ����Ƿ��Ѿ��еذ��ڸ�λ�ã����û�У�������һ���µĵذ壬��������ӵ��б���a
                    if (!HasFloorTileAt(tilePos))
                    {
                        // ����ذ�����Ʒ�ľ��룬���С�ڰ뾶�������ɵذ�
                        float distance = Vector3.Distance(tilePos, bottlePos);
                        if (distance < floorTileRange)
                        {
                            // ����Ƿ��Ѿ��еذ����λ�����ڣ����û�У������ɵذ�
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

    // ����Ƿ��Ѿ��еذ���ָ����λ�õķ���
    private bool HasFloorTileAt(Vector3 position)
    {
        // ���������ɵĵذ��б�
        foreach (GameObject tile in floorTiles)
        {
            // ����ذ��λ����ָ����λ�����С��һ����С��ֵ���ͷ���true
            if (Vector3.Distance(tile.transform.position, position) < 0.27f)
            {
                return true;
            }
        }

        // ���û���ҵ����ͷ���false
        return false;
    }

    // ����Ƿ��Ѿ��еذ���ָ����λ�����ڵķ���
    private bool HasFloorTileAdjacentTo(Vector3 position)
    {
        // ���������ɵĵذ��б�
        foreach (GameObject tile in floorTiles)
        {
            // ����ذ��λ����ָ����λ����x��z������������Ԥ�Ƽ��Ĵ�С���ͷ���true
            if (Mathf.Abs(tile.transform.position.x - position.x) == floorTileSize.x && tile.transform.position.z == position.z)
            {
                return true;
            }
            if (Mathf.Abs(tile.transform.position.z - position.z) == floorTileSize.z && tile.transform.position.x == position.x)
            {
                return true;
            }
        }

        // ���û���ҵ����ͷ���false
        return false;
    }

    // ��������ɵĵذ��б�ķ���
    private void ClearFloorTiles()
    {
        // ���������ɵĵذ��б�
        foreach (GameObject tile in floorTiles)
        {
            // ����ÿ���ذ�
            Destroy(tile);
        }

        // ����б�
        floorTiles.Clear();
    }
}
