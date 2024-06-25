using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;


public class AnchorLoader : MonoBehaviour
{

   // private OVRSpatialAnchor anchorPrefab;

    //private SpatialAnchorManager spatialAnchorManager;
    //Action<OVRSpatialAnchor.UnboundAnchor, bool> _onLoadAnchor;

    // Start is called before the first frame update
    private void Awake()
    {
        // spatialAnchorManager = GetComponent<SpatialAnchorManager>();
        // anchorPrefab = spatialAnchorManager.anchorPrefab;
        //_onLoadAnchor = OnLocalized;
    }



    List<OVRSpatialAnchor.UnboundAnchor> _unboundAnchors = new();

    async void LoadAnchorsByUuid(IEnumerable<Guid> uuids)
    {
        // Step 1: Load
        var result = await OVRSpatialAnchor.LoadUnboundAnchorsAsync(uuids, _unboundAnchors);

        if (result.Success)
        {
            Debug.Log($"Anchors loaded successfully.");
        }
        else
        {
            Debug.LogError($"Load failed with error {result.Status}.");
        }
    }

}
