using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class NarrationManager : MonoBehaviour
{
    public AudioClip[] audioClips_1;
    public UnityEvent[] events_1;
    public AudioClip[] audioClips_2;
    public UnityEvent[] events_2;

    private AudioSource audioSource;
    

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Game1_Narration();
        
    }
    public void Game1_Narration(){
        StartNarration(audioClips_1, events_1 , 1f , 1f);
    }
    public void Narration_After_Game1_End(){
        StartNarration(audioClips_2, events_2 ,1f, 1f);
    }

    public void StartNarration(AudioClip[] audioClips , UnityEvent[] events ,float start_duration, float every_audio_duration)
    {

        if (audioClips.Length > 0 && events.Length > 0)
        {
            StartCoroutine(PlayAudioClips(audioClips, events,start_duration,every_audio_duration));
        }

    }

    IEnumerator PlayAudioClips(AudioClip[] audioClips , UnityEvent[] events, float start_duration, float every_audio_duration)
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
