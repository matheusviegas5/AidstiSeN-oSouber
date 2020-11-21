using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    /**********************USAR ESTA LINHA DE CODIGO PARA FAZER SONS EM OUTRAS SCRIPTS************************************
      * 
      * FindObjectOfType<AudioManager>().Play("COLOCAR-NOME-DO-SOM-AQUI");
      * 
      *         
     */
    //public static AudioManager Instance = null;

    public static AudioManager instance;

     public AudioMixerGroup mixerGroup;

    public Sound[] sounds;

    void Awake()
    {
        if (instance == null) instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        ////If there is not already an instance of SoundManager, set it to this.
        //if (Instance == null)
        //{
        //    Instance = this;
        //}
        ////If an instance already exists, destroy whatever this object is to enforce the singleton.
        // if (Instance != this)
        //  {
        //      Destroy(gameObject);
        //  }

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;

            s.source.outputAudioMixerGroup = mixerGroup;
        }
    }


    public void Play(string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
        s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));
        s.source.Play();
    }

    public float Lenght(string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return 0;
        }

        return s.clip.length;
    }
}
