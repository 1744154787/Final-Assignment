using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityScript : MonoBehaviour
{
    public float gravity = 9.8f; // 重力的大小
    private bool isGrounded = false; // 角色是否在地面上
    private CharacterController characterController; // 角色的Character Controller组件

    private void Start()
    {
        // 获取角色的Character Controller组件
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // 检测角色是否在地面上，使用Physics.Raycast方法
        // 射线的起点是角色的中心，方向是向下，长度是角色的半径加一点
        if (Physics.Raycast(transform.position, Vector3.down, characterController.radius + 0.1f, LayerMask.GetMask("Ground")))
        {
            // 如果有，就把isGrounded设为true，表示角色在地面上
            isGrounded = true;
        }
        else
        {
            // 如果没有，就把isGrounded设为false，表示角色不在地面上
            isGrounded = false;
        }

        // 如果角色不在地面上，就给角色施加一个向下的力，大小为gravity * Time.deltaTime
        if (!isGrounded)
        {
            characterController.Move(Vector3.down * gravity * Time.deltaTime);
        }
    }
}
