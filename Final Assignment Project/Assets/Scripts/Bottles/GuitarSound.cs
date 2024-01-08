using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuitarSound : MonoBehaviour
{
    // 获取AudioSource组件的引用
    private AudioSource audioSource;

    // 声明一个公共变量，存储四个声音片段
    public AudioClip[] clips;

    // 声明一个布尔变量，控制是否可以播放声音
    private bool canPlay = true;

    // 在Start方法中初始化
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // 在OnCollisionEnter方法中检测碰撞
    void OnCollisionEnter(Collision collision)
    {
        // 如果碰撞的物体的layer是Feet，并且可以播放声音
        if (collision.gameObject.layer == LayerMask.NameToLayer("Feet") && canPlay)
        {
            // 随机选择一个声音片段，从clips变量中获取
            int index = Random.Range(0, clips.Length);
            AudioClip clip = clips[index];

            // 播放声音
            audioSource.PlayOneShot(clip);
            Debug.Log("play");

            // 将canPlay设为false，防止在1秒内再次播放声音
            canPlay = false;

            // 调用协程，延迟1秒后将canPlay设为true，允许下一次播放声音
            StartCoroutine(DelayPlay());
        }
    }

    // 定义一个协程，延迟1秒后将canPlay设为true
    private IEnumerator DelayPlay()
    {
        // 等待1秒
        yield return new WaitForSeconds(1);

        // 将canPlay设为true
        canPlay = true;
    }
}