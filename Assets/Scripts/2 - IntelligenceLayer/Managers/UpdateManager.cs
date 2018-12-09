using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateManager : MonoBehaviour
{
    [SerializeField] private GameObject UIContainer;

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

    public bool IsUpdateNeeded(System.Action<string> onUpdateNeeded = null)
    {
        bool returnState = false;

        IBackendService backend = new PlayfabService();

        backend.GetLiveVersion(
            (string liveVersion) =>
            {
                if(liveVersion != this.GetAppCurrentVersion())
                {
                    returnState = true;

                    if(onUpdateNeeded != null)
                        onUpdateNeeded(liveVersion);
                }
                else
                {
                    returnState = false;
                }
            }, 
            () =>
            {
                Debug.Log("Error trying to obtain current version");
            }
        );

        return returnState;
    }

    public void CheckForUpdatesProcedure()
    {
        this.IsUpdateNeeded(
            (string liveVersion) =>
            {
                if(this.UIContainer != null)
                {
                    string message = "Looks like your app needs an update! Version " + liveVersion + " is available!";

                    PopupController.DisplayUpdateDialog(message, this.UIContainer.transform);
                }
                else
                {
                    Debug.LogError("Null main UI container");
                }
            }
        );
    }
}
