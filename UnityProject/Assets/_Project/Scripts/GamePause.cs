using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePause : MonoBehaviour
{
    public static GamePause Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // �Q�[�����ꎞ��~���郁�\�b�h
    public void PauseGame()
    {
        // �Q�[���̎��Ԃ��~
        Time.timeScale = 0;

        // �ǉ��̒�~�����i�A�j���[�^�[��I�[�f�B�I�̒�~�Ȃǁj
        // ��: �A�j���[�^�[���~����
        // animator.enabled = false;

        // ��: �I�[�f�B�I���ꎞ��~
        // if (audioSource != null && audioSource.isPlaying)
        // {
        //     audioSource.Pause();
        // }
    }

    // �Q�[�����ĊJ���郁�\�b�h
    public void ResumeGame()
    {
        // �Q�[���̎��Ԃ��ĊJ
        Time.timeScale = 1;

        // �ǉ��̍ĊJ����
        // ��: �A�j���[�^�[���ĊJ����
        // animator.enabled = true;

        // ��: �I�[�f�B�I���ĊJ
        // if (audioSource != null && !audioSource.isPlaying)
        // {
        //     audioSource.Play();
        // }
    }
}
