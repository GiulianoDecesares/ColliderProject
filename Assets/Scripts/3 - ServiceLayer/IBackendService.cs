
public interface IBackendService
{
    /// <summary>
    /// Backend request to obtain the live version of the app
    /// </summary>
    /// <param name="onVersionObtained"> Callback to be executed when version request is finished with the result version as a parameter</param>
    /// <param name="onError"> Callback to be executed when error </param>
    void GetLiveVersion(System.Action<string> onVersionObtained, System.Action onError);

    /// <summary>
    /// Backend request to get the link to the production folder. Useful for the app updating
    /// </summary>
    /// <param name="onLinkObtained"> Callback to be executed when request is success. Parameter is the folder link </param>
    /// <param name="onError"> Callback to be executed when error </param>
    void GetProductionFolderLink(System.Action<string> onLinkObtained, System.Action onError);

}
