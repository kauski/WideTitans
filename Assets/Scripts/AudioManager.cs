using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://www.daggerhartlab.com/unity-audio-and-sound-manager-singleton-script/

public class AudioManager : MonoBehaviour
{
    public AudioSource MusicSource;
    public AudioSource SFXSource;

    public float LowPitchRange = 0.95f;
    public float HighPitchRange = 1.05f;

    public static AudioManager Instance = null;

    private void AudioAwake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void PlayMusic(AudioClip clip)
    {
        MusicSource.clip = clip;
        MusicSource.Play();
    }

    public void RandomSFX(params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, clips.Length);
        float randomPitch = Random.Range(LowPitchRange, HighPitchRange);

        SFXSource.pitch = randomPitch;
        SFXSource.clip = clips[randomIndex];
        SFXSource.Play();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
