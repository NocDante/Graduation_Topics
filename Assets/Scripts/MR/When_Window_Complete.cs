using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class When_Window_Complete : MonoBehaviour
{
    public void When_Window_Open(){
        GameObject _sceneManager = GameObject.Find("SceneManager");
        SceneTransitionManager SC =  _sceneManager.GetComponent<SceneTransitionManager>();
        SC.Go_To_Scene_Async(1);
    }
}
