using System;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    
    [SerializeField] private AudioMixerGroup _Master;
    [SerializeField] private AudioMixerGroup _SFX;
    [SerializeField] private AudioMixerGroup _Music; 
    [SerializeField] private AudioMixer _audioMixer;
    
    [SerializeField] private AudioClip _MusicScene; 
    [SerializeField] private AudioClip _Floor;
    [SerializeField] private AudioClip _Portal;
    [SerializeField] private AudioClip _Death;
    [SerializeField] private AudioClip _Jump;
    [SerializeField] private AudioClip _Menu;
   
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void PlayDeath(AudioSource audioSource)
    {
        audioSource.clip = _Death;
        audioSource.outputAudioMixerGroup = _SFX;
        audioSource.Play(); 
    }
    
    public void PlayPortal(AudioSource audioSource)
    {
        audioSource.clip = _Portal;
        audioSource.outputAudioMixerGroup = _SFX;
        audioSource.Play(); 
    }
    
    public void PlayFloor(AudioSource audioSource)
    {
        audioSource.clip = _Floor;
        audioSource.outputAudioMixerGroup = _SFX;
        audioSource.Play(); 
    }
    
    public void PlayMenu(AudioSource audioSource)
    {
        audioSource.clip = _Menu;
        audioSource.outputAudioMixerGroup = _SFX;
        audioSource.Play(); 
    }
    
    public void PlayMusic(AudioSource audioSource)
    {
        audioSource.clip = _MusicScene;
        audioSource.outputAudioMixerGroup = _Music;
        audioSource.Play(); 
    }
    
    public void PlayJump(AudioSource audioSource)
    {
        audioSource.clip = _Jump;
        audioSource.outputAudioMixerGroup = _SFX;
        audioSource.Play(); 
    }

  
    public void SetValueMusic(float value)
    {
        float db = value;
        
        if (db<=0.01)
             db = -80f;
        else
            db = (float)(Math.Log10(value) * 20.0f);
       
        _audioMixer.SetFloat("MusicVolumen", db);
    }
}
