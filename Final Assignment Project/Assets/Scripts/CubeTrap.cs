using UnityEngine;

public class CubeTrap : MonoBehaviour
{
    // 移动间隔，可以在编辑器中调整
    public float moveInterval = 3f;

    // 移动距离，可以在编辑器中调整
    public float moveDistance = 10f;

    // 移动方向，可以在编辑器中调整
    public Vector3 moveDirection = Vector3.forward;

    // 静止时间，可以在编辑器中调整
    public float stopTime = 1f;

    // 记录正方体的初始位置
    private Vector3 initialPosition;

    // 记录正方体的运动状态，0为静止，1为向前移动，2为静止，3为返回
    private int moveState;

    // 记录正方体上一次改变状态的时间
    private float lastChangeTime;

    // 在游戏开始时获取transformer组件的引用，以及记录初始位置和初始状态
    private void Start()
    {
        initialPosition = transform.position;
        moveState = 0;
        lastChangeTime = Time.time;
    }

    // 在每一帧中更新正方体的移动
    private void Update()
    {
        // 根据正方体的运动状态，执行不同的操作
        switch (moveState)
        {
            case 0: // 静止状态
                // 如果距离上一次改变状态的时间超过了移动间隔
                if (Time.time - lastChangeTime > moveInterval)
                {
                    // 改变正方体的运动状态为向前移动，并更新改变状态的时间
                    moveState = 1;
                    lastChangeTime = Time.time;
                }
                break;
            case 1: // 向前移动状态
                // 如果距离初始位置的距离小于移动距离
                if (Vector3.Distance(transform.position, initialPosition) < moveDistance)
                {
                    // 计算正方体的目标位置，根据初始位置，移动方向和移动距离
                    Vector3 targetPosition = initialPosition + moveDirection.normalized * moveDistance;

                    // 让正方体平滑地移动到目标位置，根据一个固定的速度
                    transform.position = Vector3.MoveTowards(transform.position, targetPosition, 5f * Time.deltaTime);
                }
                else
                {
                    // 否则，改变正方体的运动状态为静止，并更新改变状态的时间
                    moveState = 2;
                    lastChangeTime = Time.time;
                }
                break;
            case 2: // 静止状态
                // 如果距离上一次改变状态的时间超过了静止时间
                if (Time.time - lastChangeTime > stopTime)
                {
                    // 改变正方体的运动状态为返回，并更新改变状态的时间
                    moveState = 3;
                    lastChangeTime = Time.time;
                }
                break;
            case 3: // 返回状态
                // 如果距离初始位置的距离大于零
                if (Vector3.Distance(transform.position, initialPosition) > 0f)
                {
                    // 计算正方体的目标位置，根据初始位置
                    Vector3 targetPosition = initialPosition;

                    // 让正方体平滑地移动到目标位置，根据一个固定的速度
                    transform.position = Vector3.MoveTowards(transform.position, targetPosition, 5f * Time.deltaTime);
                }
                else
                {
                    // 否则，改变正方体的运动状态为静止，并更新改变状态的时间
                    moveState = 0;
                    lastChangeTime = Time.time;
                }
                break;
        }
    }
}
