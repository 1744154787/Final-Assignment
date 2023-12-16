using UnityEngine;

public class FloorMovement : MonoBehaviour
{
    public float revealRadius = 1f; // 显形的半径
    public float revealSpeed = 0.5f; // 显形的速度
    public float revealAlpha = 1f; // 显形的透明度

    private Collider floorCollider; // 地板的Collider组件
    private Renderer floorRenderer; // 地板的Renderer组件
    private Material floorMaterial; // 地板的材质
    private float originalAlpha; // 地板的原始透明度
    private bool isRevealing = false; // 是否正在显形
    private Vector3 revealCenter; // 显形的中心点

    private void Start()
    {
        // 获取地板的Collider和Renderer组件
        floorCollider = GetComponent<Collider>();
        floorRenderer = GetComponent<Renderer>();

        // 获取地板的材质，并保存原始透明度
        floorMaterial = floorRenderer.material;
        originalAlpha = floorMaterial.color.a;
    }

    private void Update()
    {
        // 如果正在显形
        if (isRevealing)
        {
            // 计算显形的范围，根据显形的中心点和半径
            Bounds revealBounds = new Bounds(revealCenter, Vector3.one * revealRadius * 2);

            // 遍历地板的所有顶点
            for (int i = 0; i < floorMaterial.GetVectorArray("_Vertices").Length; i++)
            {
                // 获取顶点的位置
                Vector3 vertex = floorMaterial.GetVectorArray("_Vertices")[i];

                // 如果顶点在显形的范围内
                if (revealBounds.Contains(vertex))
                {
                    // 获取顶点的透明度
                    float alpha = floorMaterial.GetFloatArray("_Alphas")[i];

                    // 计算顶点的新透明度，根据显形的速度和透明度
                    alpha = Mathf.Lerp(alpha, revealAlpha, revealSpeed * Time.deltaTime);

                    // 设置顶点的新透明度，使用拓展方法
                    floorMaterial.SetFloatArrayElement("_Alphas", i, alpha);
                }
            }

            // 更新地板的材质
            floorRenderer.material = floorMaterial;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // 如果碰撞的对象是角色
        if (other.CompareTag("Player"))
        {
            // 关闭地板的Collider组件，让角色掉下去
            floorCollider.enabled = false;
        }
        // 如果碰撞的对象是饮料瓶
        else if (other.CompareTag("Bottle"))
        {
            // 开始显形，并设置显形的中心点为饮料瓶的位置
            isRevealing = true;
            revealCenter = other.transform.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // 如果碰撞的对象是角色
        if (other.CompareTag("Player"))
        {
            // 开启地板的Collider组件，让角色可以行走
            floorCollider.enabled = true;
        }
    }
}
