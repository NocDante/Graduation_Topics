using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Meta.XR.MRUtilityKit;
using TMPro;
using System;

//當掛載的物體碰撞到MRUK物件且標籤為"OTHER"時
//將方向及座標調整到被碰撞物體最近的表面
public class MRUK_Picture : MonoBehaviour
{
    //抓取相關的功能物件
    public GameObject GrabFunctionObject;
    public string MRUK_AnchorTag;

    private void OnTriggerEnter(Collider other)
    {
        Transform parentTransform = other.gameObject.transform.parent;//獲取被碰撞物體的父項

        if (parentTransform != null)
        {
            MRUKAnchor anchor = parentTransform.GetComponent<MRUKAnchor>();//獲取被碰撞物體父項的錨點(現實空間定位用的)物件


            //判斷父項的標籤是否是"OTHER"
            if (anchor != null && anchor.HasLabel(MRUK_AnchorTag))
            {

                //摧毀抓取功能物件
                Destroy(GrabFunctionObject);

                //獲取離碰觸點最接近的面的中心點，並將物體座標設為該點
                Vector3 SurfacePosition;
                anchor.GetClosestSurfacePosition(this.gameObject.transform.position, out SurfacePosition);
                transform.position = SurfacePosition;

                //獲取父項的旋轉值進行座標轉換(MetaXR的座標系與Unity不同)，並將物體旋轉值設為該父項旋轉值
                Quaternion anchorRotation = parentTransform.rotation;
                Quaternion adjustedRotation = Quaternion.Euler(anchorRotation.eulerAngles.x - 90, anchorRotation.eulerAngles.y, anchorRotation.eulerAngles.z);
                transform.rotation = adjustedRotation;

                // transform.SetParent(parentTransform);
            }
            else
            {
                Debug.Log("Not MRUK_AnchorTag's object");
            }

        }
        else
        {
            Debug.Log("No parent");
        }
    }
}
