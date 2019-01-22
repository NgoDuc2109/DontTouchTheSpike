using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField]
    private AudioSource effectAudio1;
    [SerializeField]
    private AudioSource effectAudio2;
    [SerializeField]
    private AudioClip flapClip;
    [SerializeField]
    private AudioClip gemClip;
    [SerializeField]
    private AudioClip springsClip;
    [SerializeField]
    private AudioClip deadClip;

    [SerializeField]
    private AudioClip buySuccessClip;

    [SerializeField]
    private AudioClip buyFailClip;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void PlayFlapClip()
    {
        effectAudio1.clip = flapClip;
        effectAudio1.Play();
    }

    public void PlayGemClip()
    {
        effectAudio2.clip = gemClip;
        effectAudio2.Play();
    }

    public void PlaySpringClip()
    {
        effectAudio2.clip = springsClip;
        effectAudio2.Play();
    }

    public void PlayDeadClip()
    {
        effectAudio1.clip = deadClip;
        effectAudio1.Play();
    }

    public void PlayBuySuccessClip()
    {
        effectAudio1.clip = buySuccessClip;
        effectAudio1.Play();
    }

    public void PlayBuyFailClip()
    {
        effectAudio2.clip = buyFailClip;
        effectAudio2.Play();
    }
}
