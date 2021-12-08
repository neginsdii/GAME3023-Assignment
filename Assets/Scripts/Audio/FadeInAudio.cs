using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInAudio : MonoBehaviour
{
    public float FinalVolume;
    private float FadeTime = 5;
    AudioSource Sound;
    float currentVol;
    float difference;
    float VolumeChangePerFrame;
    void Start()
    {
        Sound = GetComponent<AudioSource>();
        currentVol = Sound.volume;
        difference = Mathf.Abs(FinalVolume - currentVol);
        VolumeChangePerFrame = difference / FadeTime;
        Sound.Play();
        StartCoroutine(FadeIn());
    }

    public IEnumerator FadeIn()
    {
        Sound.volume += VolumeChangePerFrame;
        StartCoroutine(DelayInFade());
        yield return null;
    }


    IEnumerator DelayInFade()
    {

        yield return new WaitForSeconds(0.5f);
        currentVol = Sound.volume;
        difference = Mathf.Abs(FinalVolume - currentVol);
        if (difference != 0)
            StartCoroutine(FadeIn());


    }
}
