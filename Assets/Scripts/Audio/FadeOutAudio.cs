using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutAudio : MonoBehaviour
{
    private float FinalVolume=0;
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
       
    }
    public void StartFading()
    {
        StartCoroutine(FadeOut());
    }

    public IEnumerator FadeOut()
    {
        Sound.volume -= VolumeChangePerFrame;
        StartCoroutine(DelayInFade());
        yield return null;
    }


    IEnumerator DelayInFade()
    {

        yield return new WaitForSeconds(0.5f);
        currentVol = Sound.volume;
        difference = Mathf.Abs(FinalVolume - currentVol);
        if (difference != 0)
            StartCoroutine(FadeOut());


    }
}
