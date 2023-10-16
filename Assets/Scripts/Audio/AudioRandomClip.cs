using System.Collections.Generic;
using UnityEngine;

public class AudioRandomClip : MonoBehaviour
{
    [SerializeField] private List<AudioSource> audioSourceList;
    [SerializeField] private List<AudioClip> audioClipList;

    private int _index = 0;

    public void PlayRandomClip()
    {
        if(_index >= audioSourceList.Count) _index = 0;

        audioSourceList[_index].clip = audioClipList[Random.Range(0, audioClipList.Count)];
        audioSourceList[_index].Play();

        _index++;
    }
}
