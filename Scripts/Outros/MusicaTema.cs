using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicaTema : MonoBehaviour
{
    private static MusicaTema playerInstance;

    private AudioSource _audioSource;
    private void Awake()
    {
        DontDestroyOnLoad(this);
        _audioSource = GetComponent<AudioSource>();
        PlayMusic();
        if (playerInstance == null)
        {
            playerInstance = this;
        }
        else
        {
            Object.Destroy(gameObject);
        }
    }

    public void PlayMusic()
    {
        if (_audioSource.isPlaying) return;
        _audioSource.Play();
    }

    public void StopMusic()
    {
        _audioSource.Stop();
    }
}
