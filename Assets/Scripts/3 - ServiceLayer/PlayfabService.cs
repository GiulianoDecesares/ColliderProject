using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PlayFab;
using PlayFab.ClientModels;

public class PlayfabService : IBackendService
{
    private void LogInWithAndroid(System.Action<LoginResult> onSuccess, System.Action<PlayFabError> onError)
    {
        LoginWithAndroidDeviceIDRequest request = new LoginWithAndroidDeviceIDRequest
        {
            AndroidDevice = SystemInfo.deviceModel,
            AndroidDeviceId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true
        };
       
        PlayFabClientAPI.LoginWithAndroidDeviceID(request, onSuccess, onError);
    }

    void IBackendService.GetLiveVersion(System.Action<string> onVersionObtained, System.Action onError)
    {
        this.LogInWithAndroid(
            success => {
                PlayFabClientAPI.GetTitleData(new GetTitleDataRequest(),
                    result => {
                        if(result.Data != null)
                        {
                            if(result.Data.ContainsKey("liveVersion"))
                            {
                                string version = result.Data["liveVersion"];

                                if(onVersionObtained != null)
                                    onVersionObtained(version);
                            }
                            else
                            {
                                Debug.LogWarning("Result data does not contain liveVersion key from playfab");

                                if(onError != null)
                                    onError();
                            }
                        }
                        else
                        {
                            Debug.LogWarning("Result version data is null");

                            if(onError != null)
                                onError();
                        }
                    },

                    error => {
                        Debug.LogError("Could not get title data from playfab");
                        Debug.Log(error.GenerateErrorReport());

                        if(onError != null)
                            onError();
                    }
                );
            },

            fail =>
            {
                Debug.LogError("Could not login with AndroidDeviceID to obtain live version");

                if(onError != null)
                    onError();
            }
        );
    }
}
