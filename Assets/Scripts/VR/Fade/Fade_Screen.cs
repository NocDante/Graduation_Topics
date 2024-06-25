using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade_Screen : MonoBehaviour
{
    public float Fade_Duration=1;
    public float Delay_Time=2;
    public Color Fade_Color;
    private Renderer rend;
    void Start()
    {
        rend = GetComponent<Renderer>();
    }
    public void FadeIn(){
        Fade(1,0);
    }
    public void FadeOut(){
        Fade(0,1);
    }

    public void Fade(float alphaIn, float alphaOut){
        StartCoroutine(FadeRoutine(alphaIn,alphaOut));
    }
    public IEnumerator FadeRoutine(float alphaIn, float alphaOut){

        yield return new WaitForSeconds(Delay_Time);
        float timer = 0 ;
        while(timer <= Fade_Duration){
            rend.material.SetFloat("_Alpha", Mathf.Lerp(alphaIn, alphaOut, timer/Fade_Duration));
            timer+=Time.deltaTime;
            yield return null;
        }
        rend.material.SetFloat("_Alpha", alphaOut);

    }
}
