using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private Sound[] _sounds;
    [SerializeField] private AudioMixer _audioMixer;

    private static AudioManager _instance;
    public static AudioManager Instance => _instance;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Debug.LogWarning("Duplicate AudioManager with name : " + name);
            Destroy(this);
        }
        else
        {
            _instance = this;
        }

        foreach (Sound sound in _sounds)
        {
            SetSound(sound);
        }
    }

    private void SetSound(Sound sound)
    {
        sound.Source = this.gameObject.AddComponent<AudioSource>();

        sound.Source.clip = sound.Clip;
        sound.Source.outputAudioMixerGroup = sound.Output;
        sound.Source.loop = sound.Loop;
        sound.Source.volume = sound.Volume;
        sound.Source.pitch = sound.Pitch;
    }

    public void SetMasterVolume(float masterVolume)
    {
        _audioMixer.SetFloat("MasterVolume", masterVolume);
    }

    public void PlaySound(string name)
    {
        Sound tempSound = Array.Find(_sounds, sound => sound.Name == name);
        if (tempSound != null)
        {
            tempSound.Source.Play();
        }
        else
        {
            Debug.Log(name + "doesn't exist");
        }
    }

    public void PlaySound(AudioClip clip, AudioSource source)
    {
        source.clip = clip;
        source.Play();
    }
}
