using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public SC_AudioSourceList BGMList;
    public SC_AudioSourceList SEList;

    private AudioSource BGMSource;
    private AudioSource[] audioSourceList;

    private void Awake() 
    {
        BGMSource = gameObject.AddComponent<AudioSource>();
        audioSourceList = new AudioSource[SEList.audioClipList.Count];
        for(int i = 0;i < SEList.audioClipList.Count;i++)
        {
            audioSourceList[i] = gameObject.AddComponent<AudioSource>();
        }
    }

    private void Start() 
    {
        BGMSource = GetComponent<AudioSource>();
    }

    public void PlayBGM(int BGMNumber)
    {
        BGMSource.clip = BGMList.audioClipList[BGMNumber-1];
        BGMSource.volume = 1.0f;
        BGMSource.loop = true;
        BGMSource.Play();
    }

    public void StopBGM()
    {
        if(BGMSource.isPlaying)
        {
            BGMSource.Stop();
        }
    }

    public void PlaySE(int SENumber)
    {
        audioSourceList[SENumber].clip = SEList.audioClipList[SENumber-1];
        audioSourceList[SENumber].volume = 1.0f;
        audioSourceList[SENumber].loop = false;
        audioSourceList[SENumber].Play();
    }
}
