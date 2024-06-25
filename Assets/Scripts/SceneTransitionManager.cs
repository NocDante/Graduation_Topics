using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    [SerializeField] private Fade_Screen fadeScreen;
    
    void Start()
    {
        fadeScreen.FadeIn();
    }
    // Normal Scene Change
    public void Go_To_Scene(int scene_index){
        StartCoroutine(Go_To_Scene_Routine(scene_index));
    }
    IEnumerator Go_To_Scene_Routine(int scene_index){

        fadeScreen.FadeOut();

        yield return new WaitForSeconds(fadeScreen.Fade_Duration + fadeScreen.Delay_Time);

        SceneManager.LoadScene(scene_index);

    }

    // Async Scene Change
    public void Go_To_Scene_Async(int scene_index){
        StartCoroutine(Go_To_Scene_Routine_Async(scene_index));
    }
    IEnumerator Go_To_Scene_Routine_Async(int scene_index){

        fadeScreen.FadeOut();
        AsyncOperation operation = SceneManager.LoadSceneAsync(scene_index);
        operation.allowSceneActivation = false;

        float timer = 0;
        while(timer <= fadeScreen.Fade_Duration + fadeScreen.Delay_Time && !operation.isDone){
            timer += Time.deltaTime;
            yield return null;
        }
        operation.allowSceneActivation = true;
    }
}
