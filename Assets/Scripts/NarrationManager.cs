using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class NarrationGroup
{
    public AudioClip[] audioClips;
    public UnityEvent[] unityEvents;
}
public class NarrationManager : MonoBehaviour
{
    public NarrationGroup[] narrationGroups;


    private AudioSource audioSource;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Narration_Before_SprayGame();

    }
    public void Narration_Before_SprayGame()
    {
        PlayNarration(0, 1, 1);
    }
    public void Narration_After_SprayGame()
    {
        PlayNarration(1, 1, 1);
    }
    public void Narration_When_MatchGame()
    {
        PlayNarration(2, 1, 1);
    }


    public void PlayNarration(int groupIndex, float start_delay, float every_audio_delay)
    {
        if (groupIndex >= 0 && groupIndex < narrationGroups.Length)
        {
            NarrationGroup group = narrationGroups[groupIndex];
            StartNarration(group.audioClips, group.unityEvents, start_delay, every_audio_delay);
        }
    }

    public void StartNarration(AudioClip[] audioClips, UnityEvent[] events, float start_delay, float every_audio_delay)
    {

        if (audioClips.Length > 0 && events.Length > 0)
        {
            StartCoroutine(PlayAudioClips(audioClips, events, start_delay, every_audio_delay));
        }

    }

    IEnumerator PlayAudioClips(AudioClip[] audioClips, UnityEvent[] events, float start_duration, float every_audio_duration)
    {
        int currentClipIndex = 0;
        yield return new WaitForSeconds(start_duration);
        while (currentClipIndex < audioClips.Length)
        {
            audioSource.clip = audioClips[currentClipIndex];
            yield return new WaitForSeconds(every_audio_duration);
            audioSource.Play();

            yield return new WaitForSeconds(audioSource.clip.length);


            if (currentClipIndex < events.Length && events[currentClipIndex] != null)
            {
                //Debug.Log(currentClipIndex);
                events[currentClipIndex].Invoke();
            }

            currentClipIndex++;
        }
    }
}
