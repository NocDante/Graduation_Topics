using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MR_NarrationControl : MonoBehaviour
{
    private Animator anim;
    public void FamilyPictureSetActive()
    {
        GameObject[] allObjects;
        allObjects = GameObject.FindObjectsOfType<GameObject>();
        foreach (GameObject obj in allObjects)
        {
            //FamilyPicture
            if (obj.name == "OTHER")
            {

                GameObject familyPicture = obj.transform.Find("Title_3DModel_FamilyPicture(PrefabSpawner Clone)").gameObject;


                if (familyPicture != null)
                {
                    Debug.Log("FamilyPicture");
                    familyPicture.SetActive(true);
                }
                else
                {
                    return;
                }

            }


        }
      
    }

    public void BabyPictureSetActive()
    {
        GameObject[] allObjects;
        allObjects = GameObject.FindObjectsOfType<GameObject>();

        foreach (GameObject obj in allObjects)
        {

            //BabyPicture
            if (obj.name == "LAMP")
            {

                GameObject babyPicture = obj.transform.Find("Title_3DModel_BabyPicture(PrefabSpawner Clone)").gameObject;


                if (babyPicture != null)
                {
                    Debug.Log("BabyPicture");
                    babyPicture.SetActive(true);

                }
                else
                {
                    return;
                }

            }


        }
     
    }

    public void WindowPictureSetActive()
    {
        GameObject[] allObjects;
        allObjects = GameObject.FindObjectsOfType<GameObject>();
        foreach (GameObject obj in allObjects)
        {

            //WindowPicture
            if (obj.name == "COUCH")
            {

                GameObject WindowPicture = obj.transform.Find("Title_3DModel_WindowPicture(PrefabSpawner Clone)").gameObject;

                if (WindowPicture != null)
                {
                    Debug.Log("windowpicture");
                    WindowPicture.SetActive(true);

                }
                else
                {
                    return;
                }

            }

        }

    }

    public void WindowSetActive()
    {
        GameObject[] allObjects;
        allObjects = GameObject.FindObjectsOfType<GameObject>();

        foreach (GameObject obj in allObjects)
        {

            //Window
            if (obj.name == "SCREEN")
            {

                GameObject Window = obj.transform.Find("windowFrame(PrefabSpawner Clone)").gameObject;
                


                if (Window != null)
                {
                    Debug.Log("window");
                    Window.SetActive(true);
                    anim = Window.GetComponentInChildren<Animator>();
                    

                }
                else
                {
                    return;
                }

            }
   
        }

    }
    public void Set_Window_Animation(){
        
        anim.SetTrigger("Open");
    }

    public void PlantSetActive()
    {
        GameObject[] allObjects;
        allObjects = GameObject.FindObjectsOfType<GameObject>();

        foreach (GameObject obj in allObjects)
        {

            //Window
            if (obj.name == "PLANT")
            {

                GameObject Plant = obj.transform.Find("MR_FlowerPot(PrefabSpawner Clone)").gameObject;


                if (Plant != null)
                {
                    Debug.Log("plant");
                    Plant.SetActive(true);

                }
                else
                {
                    return;
                }

            }
  
        }

    }


}
