using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] private AudioSource _effectSource, _musicSource, _loopEffectSource;
    [SerializeField] private AudioClip _backgroundMusic;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        _loopEffectSource.loop = true;
        playMusic(_backgroundMusic, 0.15f);
    }

    public void playEffect(AudioClip effect)
    {
        _effectSource.PlayOneShot(effect);
    }

    public void playLoopingEffect(AudioClip effect)
    {
        _loopEffectSource.PlayOneShot(effect);
    }

    public void playMusic(AudioClip music, float volume)
    {
        _musicSource.PlayOneShot(music, volume);
    }
}
