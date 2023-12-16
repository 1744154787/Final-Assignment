using UnityEngine;

public class FloorMovement : MonoBehaviour
{
    public float revealRadius = 1f; // ���εİ뾶
    public float revealSpeed = 0.5f; // ���ε��ٶ�
    public float revealAlpha = 1f; // ���ε�͸����

    private Collider floorCollider; // �ذ��Collider���
    private Renderer floorRenderer; // �ذ��Renderer���
    private Material floorMaterial; // �ذ�Ĳ���
    private float originalAlpha; // �ذ��ԭʼ͸����
    private bool isRevealing = false; // �Ƿ���������
    private Vector3 revealCenter; // ���ε����ĵ�

    private void Start()
    {
        // ��ȡ�ذ��Collider��Renderer���
        floorCollider = GetComponent<Collider>();
        floorRenderer = GetComponent<Renderer>();

        // ��ȡ�ذ�Ĳ��ʣ�������ԭʼ͸����
        floorMaterial = floorRenderer.material;
        originalAlpha = floorMaterial.color.a;
    }

    private void Update()
    {
        // �����������
        if (isRevealing)
        {
            // �������εķ�Χ���������ε����ĵ�Ͱ뾶
            Bounds revealBounds = new Bounds(revealCenter, Vector3.one * revealRadius * 2);

            // �����ذ�����ж���
            for (int i = 0; i < floorMaterial.GetVectorArray("_Vertices").Length; i++)
            {
                // ��ȡ�����λ��
                Vector3 vertex = floorMaterial.GetVectorArray("_Vertices")[i];

                // ������������εķ�Χ��
                if (revealBounds.Contains(vertex))
                {
                    // ��ȡ�����͸����
                    float alpha = floorMaterial.GetFloatArray("_Alphas")[i];

                    // ���㶥�����͸���ȣ��������ε��ٶȺ�͸����
                    alpha = Mathf.Lerp(alpha, revealAlpha, revealSpeed * Time.deltaTime);

                    // ���ö������͸���ȣ�ʹ����չ����
                    floorMaterial.SetFloatArrayElement("_Alphas", i, alpha);
                }
            }

            // ���µذ�Ĳ���
            floorRenderer.material = floorMaterial;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // �����ײ�Ķ����ǽ�ɫ
        if (other.CompareTag("Player"))
        {
            // �رյذ��Collider������ý�ɫ����ȥ
            floorCollider.enabled = false;
        }
        // �����ײ�Ķ���������ƿ
        else if (other.CompareTag("Bottle"))
        {
            // ��ʼ���Σ����������ε����ĵ�Ϊ����ƿ��λ��
            isRevealing = true;
            revealCenter = other.transform.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // �����ײ�Ķ����ǽ�ɫ
        if (other.CompareTag("Player"))
        {
            // �����ذ��Collider������ý�ɫ��������
            floorCollider.enabled = true;
        }
    }
}
