using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * Quick overview:
 * you can cycle through the various sound modes using the keys 1-7 (above qwerty)
 * crossfade can be altered to any float value.
 */
public class AudioManagerTester : MonoBehaviour
{
    [SerializeField] private AudioClip SoundEffect;
    [SerializeField] private AudioClip music1;
    [SerializeField] private AudioClip music2;

    private void Start()
    {
        AudioManager.Instance.PlayMusic(music2);
    }

    private void Update()
    {
        // Play soundeffect
        if (Input.GetKeyDown(KeyCode.Alpha1))
            AudioManager.Instance.PlaySFX(SoundEffect);

        // Play music track 1
        if (Input.GetKeyDown(KeyCode.Alpha2))
            AudioManager.Instance.PlayMusic(music1);

        // Play music track 2
        if (Input.GetKeyDown(KeyCode.Alpha3))
            AudioManager.Instance.PlayMusic(music2);

        // Play music track 1 with fade
        if (Input.GetKeyDown(KeyCode.Alpha4))
            AudioManager.Instance.PlayMusicWithFade(music1);

        // Play music track 2 with fade
        if (Input.GetKeyDown(KeyCode.Alpha5))
            AudioManager.Instance.PlayMusicWithFade(music2);

        // Play music track 1 with a crossfade of 3 seconds
        if (Input.GetKeyDown(KeyCode.Alpha6))
            AudioManager.Instance.PlayMusicWithCrossFade(music1, 3.0f);

        // play music track 2 with a crossfade of 3 seconds
        if (Input.GetKeyDown(KeyCode.Alpha7))
            AudioManager.Instance.PlayMusicWithCrossFade(music2, 3.0f);
    }
}