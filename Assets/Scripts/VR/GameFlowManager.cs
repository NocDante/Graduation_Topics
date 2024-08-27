using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class GameFlowManager : MonoBehaviour
{


    public static GameFlowManager Instance;
    [Header("Fade Screen Control")]
    [SerializeField] private Fade_Screen fadeScreen;

    [Header("Player Route Control")]
    [SerializeField] private NavMeshAgent player_agent;
    [SerializeField] List<Transform> PhotoRoute_Waypoints;
    [SerializeField] private float RotationDuration;

    private int PhotoRoute_WaypointIndex = 0;

    // Event
    public EventHandler OnStart_PhotoRoute;


    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        player_agent.updateRotation = false;
        fadeScreen.FadeIn();
        OnStart_PhotoRoute += Handle_OnStartPhotoRoute;

    }
    #region AfterSprayGame
    public void After_SprayGame()
    {
        StartCoroutine(Route_After_SprayGame());
    }
    IEnumerator Route_After_SprayGame()
    {
        // Hide_SprayBottle_UI
        yield return new WaitForSeconds(1f);
        GetComponent<SprayGameManager>().Hide_SprayBottle_UI();
        yield return new WaitForSeconds(1f);

        // Start smooth rotation
        Quaternion startRotation = player_agent.gameObject.transform.rotation;
        Quaternion endRotation = startRotation * Quaternion.Euler(0, 180, 0);
        float elapsedTime = 0f;

        while (elapsedTime < RotationDuration)
        {
            player_agent.gameObject.transform.rotation = Quaternion.Slerp(startRotation, endRotation, elapsedTime / RotationDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        player_agent.gameObject.transform.rotation = endRotation;

        // Start moving & narration
        OnStart_PhotoRoute?.Invoke(this, EventArgs.Empty);
        GetComponent<NarrationManager>().Narration_After_SprayGame();
    }
    private void Handle_OnStartPhotoRoute(object sender, EventArgs e)
    {
        StartCoroutine(MoveThroughWaypoints(PhotoRoute_WaypointIndex, PhotoRoute_Waypoints));
    }
    #endregion
    IEnumerator MoveThroughWaypoints(int index, List<Transform> waypoints)
    {
        while (index < waypoints.Count)
        {
            player_agent.SetDestination(waypoints[index].position);
            while (!player_agent.pathPending && player_agent.remainingDistance >= 0.5f)
            {
                yield return null;
            }
            index++;
        }

    }
}
