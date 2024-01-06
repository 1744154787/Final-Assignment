using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    //�����ŵ�Ŀ�ĵس�������λ������
    public string destinationScene;
    public Vector3 destinationPosition;

    //�����ŵĴ�����
    private Collider portalCollider;

    //�����ŵ���Ч
    public GameObject portalEffect;

    //��ʼ��
    private void Start()
    {
        //��ȡ�����ŵĴ��������
        portalCollider = GetComponent<Collider>();
        //ȷ�������ŵĴ������Ǵ���������
        portalCollider.isTrigger = true;
        //ȷ�������ŵ�layer��Portal
        gameObject.layer = LayerMask.NameToLayer("Portal");
    }

    //����������봫���ŵĴ�����ʱ
    private void OnTriggerEnter(Collider other)
    {
        //�������ҽ�ɫ
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            //���Ŵ����ŵ���Ч
            if (portalEffect != null)
            {
                Instantiate(portalEffect, transform.position, transform.rotation);
            }
            //�л�������λ��
            if (!string.IsNullOrEmpty(destinationScene))
            {
                //����Ŀ�ĵس���
                SceneManager.LoadScene(destinationScene);
            }
            else
            {
                //�ƶ���ҽ�ɫ��Ŀ�ĵ�λ��
                other.transform.position = destinationPosition;
            }
        }
    }
}
