using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Day1_GameManager : MonoBehaviour
{
    private NarrationManager narrationManager;
    [SerializeField] private Fade_Screen fadeScreen;
    [SerializeField] private GameObject SprayBottle;
    [SerializeField] private GameObject SprayBottle_UI;
    void Awake()
    {
        narrationManager = GetComponent<NarrationManager>();
    }

    void Start()
    {
        Hide_SprayBottle();
        fadeScreen.FadeIn();
        narrationManager.StartNarration();
    }
    public void Hide_SprayBottle(){

        SprayBottle.SetActive(false);
    }
     public void Show_SprayBottle_UI(){
        
        SprayBottle.SetActive(true);
        SprayBottle_UI.SetActive(true);
    }
}
