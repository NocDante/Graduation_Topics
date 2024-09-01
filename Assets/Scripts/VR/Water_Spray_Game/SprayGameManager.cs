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
        Display_SprayBottle_UI(false);

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
    public void Display_SprayBottle_UI(bool visible)
    {
        SprayBottle.SetActive(visible);
        SprayBottle_UI.SetActive(visible);
    }


    #region TestMode
    private void TestModeFunction()
    {
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
    #endregion
}
