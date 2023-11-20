using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public enum sfxNumber
{
    FLAP,
    WIND_SWOOSH
}


public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioMixer m_Mixer;
    [SerializeField] private AudioSource m_musicSource;
    [SerializeField] private AudioSource m_sfxSource;
    [SerializeField] private Slider m_musicSlider;
    [SerializeField] private Slider m_sfxSlider;
    private AudioManager instance = null;
    
    public float minWaitBetweenPlays = 1f;
    public float maxWaitBetweenPlays = 5f;
    public float waitTimeCountdown = -1f;
    // Start is called before the first frame update

    public AudioClip[] sfx;
    public AudioClip[] music;

    public void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume") || PlayerPrefs.HasKey("sfxVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolume();
            SetSFXVolume();
        }
        
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    public void Update()
    {
        if (!m_musicSource.isPlaying)
        {
            PlayNextSong();
        }
        if (!m_sfxSource.isPlaying)
        {
            if (waitTimeCountdown < 0f)
            {
                m_sfxSource.clip = sfx[(int)sfxNumber.WIND_SWOOSH]; // wind swoosh
                m_sfxSource.Play();
                waitTimeCountdown = Random.Range(minWaitBetweenPlays, maxWaitBetweenPlays);
            }
            else
            {
                waitTimeCountdown -= Time.deltaTime;
            }
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        m_sfxSource.PlayOneShot(clip);
    }
    
    void PlayNextSong(){
        m_musicSource.clip = music[Random.Range(0,music.Length)];
        m_musicSource.Play();
        Invoke("PlayNextSong", m_musicSource.clip.length);
    }
    
    private void LoadVolume()
    {
        m_musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        m_sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");
        
        SetMusicVolume();
        SetSFXVolume();
    }
    
    public void SetMusicVolume()
    {
        float volume = m_musicSlider.value;
        m_Mixer.SetFloat("music", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }
    public void SetSFXVolume()
    {
        float volume = m_sfxSlider.value;
        m_Mixer.SetFloat("sfx", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("sfxVolume", volume);
    }
    
    
}
