using System;
using UnityEngine;

public class MusicControl : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private void Start()
    {
        AudioManager.instance.PlayMusic(_audioSource);
    }
}
