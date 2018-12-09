
public interface IBackendService
{
    /// <summary>
    /// Backend request to obtain the live version of the app
    /// </summary>
    /// <param name="onVersionObtained"> Callback to be executed when version request is finished with the result version as a parameter</param>
    /// <param name="onError"> Callback to be executed when error </param>
    void GetLiveVersion(System.Action<string> onVersionObtained, System.Action onError);
}
