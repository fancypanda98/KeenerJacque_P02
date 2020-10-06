﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{

    public static AudioManager Instance = null;

    AudioSource _audioSorce;

    private void Awake()
    {
        #region Singleton Pattern (Simple)
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            _audioSorce = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
        #endregion
    }

    public void PlaySong(AudioClip clip)
    {
        _audioSorce.clip = clip;
        _audioSorce.Play();
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
