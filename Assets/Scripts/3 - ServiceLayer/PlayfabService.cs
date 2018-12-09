using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PlayFab;
using PlayFab.ClientModels;

public class PlayfabService : IBackendService
{
    private void LogInWithAndroid(System.Action<LoginResult> onSuccess, System.Action<PlayFabError> onError)
    {
#if UNITY_EDITOR

            LoginWithCustomIDRequest request = new LoginWithCustomIDRequest
            {
                CreateAccount = true,
                CustomId = "Develop"
            };
            
            PlayFabClientAPI.LoginWithCustomID(request, onSuccess, onError);

#elif UNITY_ANDROID

            LoginWithAndroidDeviceIDRequest request = new LoginWithAndroidDeviceIDRequest
            {
                AndroidDevice = SystemInfo.deviceModel,
                AndroidDeviceId = SystemInfo.deviceUniqueIdentifier,
                CreateAccount = true
            };
       
            PlayFabClientAPI.LoginWithAndroidDeviceID(request, onSuccess, onError);

#endif
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
                                if(onVersionObtained != null)
                                    onVersionObtained(result.Data["liveVersion"]);
                            }
                            else
                            {
                                // Result data does not contain liveVersion key from playfab
                                if(onError != null)
                                    onError();
                            }
                        }
                        else
                        {
                            // Result version data is null
                            if(onError != null)
                                onError();
                        }
                    },

                    error => {
                        // Could not get title data from playfab
                        Debug.Log(error.GenerateErrorReport());
                        if(onError != null)
                            onError();
                    }
                );
            },

            fail =>
            {
                // Could not login with AndroidDeviceID to obtain live version
                if(onError != null)
                    onError();
            }
        );
    }

    void IBackendService.GetProductionFolderLink(System.Action<string> onLinkObtained, System.Action onError)
    {
        this.LogInWithAndroid(
            success => {
                PlayFabClientAPI.GetTitleData(new GetTitleDataRequest(),
                    result => {
                        if(result.Data != null)
                        {
                            if(result.Data.ContainsKey("productionFolderLink"))
                            {
                                if(onLinkObtained != null)
                                    onLinkObtained(result.Data["productionFolderLink"]);
                            }
                            else
                            {
                                // Result data does not contain productionFolderLink key 
                                if(onError != null)
                                    onError();
                            }
                        }
                        else
                        {
                            // Result version data is null
                            if(onError != null)
                                onError();
                        }
                    },

                    error => {
                        // Could not get title data from playfab
                        Debug.Log(error.GenerateErrorReport());
                        if(onError != null)
                            onError();
                    }
                );
            },

            fail =>
            {
                // Could not login with AndroidDeviceID to obtain productionFolderLink data
                if(onError != null)
                    onError();
            }
        );
    }
}
