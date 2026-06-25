using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/DataBase/AudioClip",fileName = "AudioClipList")]
public class SC_AudioSourceList : ScriptableObject
{
    public List<AudioClip> audioClipList;
}
