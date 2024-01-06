using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    //传送门的目的地场景名或位置坐标
    public string destinationScene;
    public Vector3 destinationPosition;

    //传送门的触发器
    private Collider portalCollider;

    //传送门的特效
    public GameObject portalEffect;

    //初始化
    private void Start()
    {
        //获取传送门的触发器组件
        portalCollider = GetComponent<Collider>();
        //确保传送门的触发器是触发器类型
        portalCollider.isTrigger = true;
        //确保传送门的layer是Portal
        gameObject.layer = LayerMask.NameToLayer("Portal");
    }

    //当有物体进入传送门的触发器时
    private void OnTriggerEnter(Collider other)
    {
        //如果是玩家角色
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            //播放传送门的特效
            if (portalEffect != null)
            {
                Instantiate(portalEffect, transform.position, transform.rotation);
            }
            //切换场景或位置
            if (!string.IsNullOrEmpty(destinationScene))
            {
                //加载目的地场景
                SceneManager.LoadScene(destinationScene);
            }
            else
            {
                //移动玩家角色到目的地位置
                other.transform.position = destinationPosition;
            }
        }
    }
}
