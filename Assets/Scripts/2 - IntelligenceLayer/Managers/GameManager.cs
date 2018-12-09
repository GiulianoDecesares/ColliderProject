using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Start()
    {
        IBackendService backend = new PlayfabService();

        backend.GetLiveVersion(OnVersionObtained, OnVersionError);
    }

    private void OnVersionObtained(string version)
    {
        Debug.Log("Current backend version is -> " + version);
        Debug.Log("App version is -> " + Application.version);
    }

    private void OnVersionError()
    {
        Debug.Log("Error trying to obtain current version");
    }
}
