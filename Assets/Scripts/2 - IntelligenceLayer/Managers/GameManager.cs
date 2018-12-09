using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Fields

    [SerializeField] private GameObject mainUI;

    #endregion

    #region Singleton

    public static GameManager instance { get; private set; }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    #endregion

    private void Start()
    {
        IBackendService backend = new PlayfabService();

        backend.GetLiveVersion(OnVersionObtained, OnVersionError);
    }

    private void OnVersionObtained(string version)
    {
        Debug.Log("Current backend version is -> " + version);
        Debug.Log("App version is -> " + Application.version);

        if(version != Application.version)
        {
            PopupController.DisplayUpdateDialog(this.mainUI.transform);
        }
    }

    private void OnVersionError()
    {
        Debug.Log("Error trying to obtain current version");
    }
}
