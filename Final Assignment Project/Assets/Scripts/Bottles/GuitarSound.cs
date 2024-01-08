using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuitarSound : MonoBehaviour
{
    // ��ȡAudioSource���������
    private AudioSource audioSource;

    // ����һ�������������洢�ĸ�����Ƭ��
    public AudioClip[] clips;

    // ����һ�����������������Ƿ���Բ�������
    private bool canPlay = true;

    // ��Start�����г�ʼ��
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // ��OnCollisionEnter�����м����ײ
    void OnCollisionEnter(Collision collision)
    {
        // �����ײ�������layer��Feet�����ҿ��Բ�������
        if (collision.gameObject.layer == LayerMask.NameToLayer("Feet") && canPlay)
        {
            // ���ѡ��һ������Ƭ�Σ���clips�����л�ȡ
            int index = Random.Range(0, clips.Length);
            AudioClip clip = clips[index];

            // ��������
            audioSource.PlayOneShot(clip);
            Debug.Log("play");

            // ��canPlay��Ϊfalse����ֹ��1�����ٴβ�������
            canPlay = false;

            // ����Э�̣��ӳ�1���canPlay��Ϊtrue��������һ�β�������
            StartCoroutine(DelayPlay());
        }
    }

    // ����һ��Э�̣��ӳ�1���canPlay��Ϊtrue
    private IEnumerator DelayPlay()
    {
        // �ȴ�1��
        yield return new WaitForSeconds(1);

        // ��canPlay��Ϊtrue
        canPlay = true;
    }
}