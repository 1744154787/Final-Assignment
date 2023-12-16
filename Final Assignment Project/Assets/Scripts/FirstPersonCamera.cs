using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public float sensitivityX = 15f; // �����ˮƽ��ת���ٶ�
    public float sensitivityY = 15f; // �������ֱ��ת���ٶ�
    //public float minimumX = -360f; // �����ˮƽ��ת����С�Ƕ�
    //public float maximumX = 360f; // �����ˮƽ��ת�����Ƕ�
    public float minimumY = -60f; // �������ֱ��ת����С�Ƕ�
    public float maximumY = 60f; // �������ֱ��ת�����Ƕ�

    private float rotationX = 0f; // �������ǰˮƽ��ת�ĽǶ�
    private float rotationY = 0f; // �������ǰ��ֱ��ת�ĽǶ�
    private GameObject player; // ��ɫ���������

    private void Start()
    {
        // ��ȡ��ɫ��������ã������ɫ����ı�ǩ��Player
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        // ��ȡ����ˮƽ�ʹ�ֱ����
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // �����������ˮƽ�ʹ�ֱ��ת�Ƕȣ�����������ٶȣ��������ڷ�Χ��
        rotationX += mouseX * sensitivityX;
        //rotationX = Mathf.Clamp(rotationX, minimumX, maximumX);
        rotationY += mouseY * sensitivityY;
        rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

        // ����һ����Ԫ������ʾ���������ת��������ת�Ƕ�
        Quaternion cameraRotation = Quaternion.Euler(-rotationY, rotationX, 0);

        // ��ת�������������Ԫ��
        transform.localRotation = cameraRotation;

        // �����������λ�ã����ݽ�ɫ��λ�ã������������λ��ƫ������(0, 1, 0)
        transform.position = player.transform.position + new Vector3(0, 1, 0);
    }
}
