using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateManager : MonoBehaviour
{
    // Transform to show update popup. Maybe this sould not be here...
    [SerializeField] private GameObject mainUI;

    #region Sigleton

    public static UpdateManager instance { get; private set; }

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

    public string GetAppCurrentVersion()
    {
        return Application.version;
    }

    public void OpenUpdateFolder()
    {
        IBackendService backend = new PlayfabService();

        backend.GetProductionFolderLink(
            (string link) =>
            {
                if(link != null && link != string.Empty)
                {
                    Application.OpenURL(link);
                }
                else
                {
                    Debug.LogWarning("Production folder link is null or empty");
                }
            },
            () =>
            {
                Debug.LogError("Error getting the production folder link. Folder will not be oppened");
            }
        );
    }

    public bool CheckForUpdates()
    {
        bool returnState = false;

        IBackendService backend = new PlayfabService();

        backend.GetLiveVersion(
            (string liveVersion) =>
            {
                if(liveVersion != Application.version)
                {
                    string message = "Looks like your app needs an update! Version " + liveVersion + " is available!";

                    if(this.mainUI != null)
                        PopupController.DisplayUpdateDialog(message, this.mainUI.transform);
                    else
                        Debug.LogError("Null mainUI reference");

                    returnState = true;
                }
                else
                {
                    Debug.Log("App is up to date!");
                }
            }, 
            () =>
            {
                Debug.Log("Error trying to obtain current version");
            }
        );

        return returnState;
    }
}
