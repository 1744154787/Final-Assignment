using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;

public class CharacterMovement : MonoBehaviour
{
    public Transform leftFoot; // 角色的左脚子对象
    public Transform rightFoot; // 角色的右脚子对象
    public float rotationSpeed = 180f; // 角色的旋转速度
    public float maxRotationSpeed = 360f; // 角色的旋转速度的最大值
    public GameObject leftFootUI; // 左脚UI对象
    public GameObject rightFootUI; // 右脚UI对象

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

        // 如果玩家按下A或D键，开始旋转
        if (horizontalInput != 0)
        {
            // 计算旋转角度，根据按键的方向和时间，限制在最大值范围内
            rotationAngle += Mathf.Clamp((horizontalInput) * rotationSpeed * Time.deltaTime, -maxRotationSpeed, maxRotationSpeed);
        }
        // 如果玩家松开A或D键，停止旋转，切换旋转的轴，重置旋转角度
        if ((horizontalInput==0 && rotationAngle!=0) || (horizontalInput * foreFrameInput) <0)
        {
            isLeftFootPivot = !isLeftFootPivot;
            rotationAngle = 0f;
            Debug.Log("Change Feet!");
        }
        // 如果以左脚为轴旋转，显示左脚UI，隐藏右脚UI
        if (isLeftFootPivot)
        {
            leftFootUI.SetActive(false);
            rightFootUI.SetActive(true);
        }
        // 如果以右脚为轴旋转，显示右脚UI，隐藏左脚UI
        else
        {
            leftFootUI.SetActive(true);
            rightFootUI.SetActive(false);
        }

        // 选择旋转的轴，根据当前的状态
        Transform pivot = isLeftFootPivot ? leftFoot : rightFoot;

        // 移动角色，根据旋转的轴和角度，使用角色的本地坐标系
        Vector3 move = new Vector3(0, 0, Input.GetAxisRaw("Vertical") * Time.deltaTime);
        move = transform.TransformDirection(move);
        transform.RotateAround(pivot.position, Vector3.up, rotationAngle);

        foreFrameInput = horizontalInput;
    }

}
