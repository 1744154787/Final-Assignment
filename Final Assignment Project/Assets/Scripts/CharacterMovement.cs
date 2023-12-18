using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Transform leftFoot; // 角色的左脚子对象
    public Transform rightFoot; // 角色的右脚子对象
    public float rotationSpeed = 180f; // 角色的旋转速度
    public float maxRotationSpeed = 360f; // 角色的旋转速度的最大值

    private bool isLeftFootPivot = false; // 是否以左脚为轴旋转
    [SerializeField]private float rotationAngle = 0f; // 当前的旋转角度
    public float RotationAngle
    {
        get { return rotationAngle; }
    }

    private void Update()
    {
        // 获取玩家的输入
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        // 如果玩家按下A或D键，开始旋转
        if (horizontalInput != 0)
        {
            // 计算旋转角度，根据按键的方向和时间，限制在最大值范围内
            rotationAngle += Mathf.Clamp((horizontalInput) * rotationSpeed * Time.deltaTime, -maxRotationSpeed, maxRotationSpeed);

            // 选择旋转的轴，根据当前的状态
            Transform pivot = isLeftFootPivot ? leftFoot : rightFoot;

            // 旋转角色，根据旋转的轴和角度
            transform.RotateAround(pivot.position, Vector3.up, rotationAngle);
        }
        // 如果玩家松开A或D键，停止旋转，切换旋转的轴，重置旋转角度
        else if (rotationAngle != 0)
        {
            isLeftFootPivot = !isLeftFootPivot;
            rotationAngle = 0f;
        }
    }
}
