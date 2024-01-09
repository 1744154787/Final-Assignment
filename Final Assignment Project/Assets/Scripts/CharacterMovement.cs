using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMovement : MonoBehaviour
{
    public Transform leftFoot; // 角色的左脚子对象
    public Transform rightFoot; // 角色的右脚子对象
    public float rotationSpeed = 180f; // 角色的旋转速度
    public float maxRotationSpeed = 360f; // 角色的旋转速度的最大值
    

    private bool isLeftFootPivot = false; // 是否以左脚为轴旋转
    [SerializeField] private float rotationAngle = 0f; // 当前的旋转角度
    private float foreFrameInput;

    public float RotationAngle
    {
        get { return rotationAngle; }
    }

    private void Update()
    {
        // 获取玩家的输入
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        //Debug.Log(horizontalInput);

        // 如果玩家按下A键，以右脚为轴顺时针旋转
        if (horizontalInput == -1)
        {
            // 计算旋转角度，根据按键的方向和时间，限制在最大值范围内
            // 如果按住S键，反转旋转方向
            rotationAngle += Mathf.Clamp((Input.GetKey(KeyCode.S) ? -1 : 1) * rotationSpeed * Time.deltaTime, -maxRotationSpeed, maxRotationSpeed);
            // 设置旋转的轴为右脚
            isLeftFootPivot = false;
        }
        // 如果玩家按下D键，以左脚为轴逆时针旋转
        else if (horizontalInput == 1)
        {
            // 计算旋转角度，根据按键的方向和时间，限制在最大值范围内
            // 如果按住S键，反转旋转方向
            rotationAngle -= Mathf.Clamp((Input.GetKey(KeyCode.S) ? -1 : 1) * rotationSpeed * Time.deltaTime, -maxRotationSpeed, maxRotationSpeed);
            // 设置旋转的轴为左脚
            isLeftFootPivot = true;
        }
        // 如果玩家松开A或D键，重置旋转角度
        if ((horizontalInput == 0 && rotationAngle != 0) || (horizontalInput * foreFrameInput) < 0)
        {
            rotationAngle = 0f;
            //Debug.Log("Reset Angle!");
        }
       

        foreFrameInput = horizontalInput;
    }

    // 在固定的时间间隔内调用
    private void FixedUpdate()
    {
        // 选择旋转的轴，根据当前的状态
        Transform pivot = isLeftFootPivot ? leftFoot : rightFoot;

        // 移动角色，根据旋转的轴和角度，使用角色的本地坐标系
        Vector3 move = new Vector3(0, 0, Input.GetAxisRaw("Vertical") * Time.fixedDeltaTime);
        move = transform.TransformDirection(move);
        transform.RotateAround(pivot.position, Vector3.up, rotationAngle);
    }
}
