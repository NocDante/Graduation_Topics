using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MR_SetObjectTransform : MonoBehaviour
{
    public float Scale_X;
    public float Scale_Y;
    public float Scale_Z;

    public float Rotation_X;
    public float Rotation_Y;
    public float Rotation_Z;


    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localScale = new Vector3(Scale_X, Scale_Y, Scale_Z) ;
        gameObject.transform.localRotation = Quaternion.Euler(Rotation_X, Rotation_Y, Rotation_Z);
    }

}
