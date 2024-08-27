using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class SprayGameManager : MonoBehaviour
{


    [Header("GameObject Setting")]
    [SerializeField] private GameObject SprayBottle;
    [SerializeField] private GameObject SprayBottle_UI;

    [Header("TestMode Setting")]
    [Tooltip("Press T")][SerializeField] private bool TestMode;



    void Start()
    {
        Hide_SprayBottle_UI();
        if (SprayBottle_UI != null)
            SprayBottle_UI.GetComponent<Plant_Progress>().OnSprayGameOver += Handle_OnSprayGameOver;
    }
    void Update()
    {
        TestModeFunction();
    }
    private void Handle_OnSprayGameOver(object sender, EventArgs e)
    {
        GetComponent<GameFlowManager>().After_SprayGame();
        SprayBottle_UI.GetComponent<Plant_Progress>().OnSprayGameOver -= Handle_OnSprayGameOver;

    }


    public void Hide_SprayBottle_UI()
    {
        SprayBottle.SetActive(false);
        SprayBottle_UI.SetActive(false);
    }
    public void Show_SprayBottle_UI()
    {

        SprayBottle.SetActive(true);
        SprayBottle_UI.SetActive(true);
    }
    private void TestModeFunction()
    {
        // Test mode
        if (TestMode)
        {
            if (Input.GetKey(KeyCode.T) && SprayBottle.activeInHierarchy && SprayBottle_UI.activeInHierarchy)
            {
                SprayBottle.GetComponent<Water_Spray>().ComputeUseStrength(1);
            }
            else
            {
                SprayBottle.GetComponent<Water_Spray>().ComputeUseStrength(0);
            }
        }
    }
}
