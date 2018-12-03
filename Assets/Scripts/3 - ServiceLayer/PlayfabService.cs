using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using PlayFab;
using PlayFab.ClientModels;

public class PlayfabService : IBackendService
{
    string IBackendService.GetLiveVersion()
    {
        string version = string.Empty;

        // Log in in playfab (this could be in the constructor or something)
        LoginWithAndroidDeviceIDRequest request = new LoginWithAndroidDeviceIDRequest
        {
            AndroidDevice = SystemInfo.deviceModel,
            AndroidDeviceId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true
        };

        PlayFabClientAPI.LoginWithAndroidDeviceID(
            request,

            success =>
            {
                PlayFabClientAPI.GetTitleData(new GetTitleDataRequest(),

                    result =>
                    {
                        if(result.Data != null)
                        {
                            if(result.Data.ContainsKey("liveVersion"))
                            {
                                version = result.Data["liveVersion"];
                            }
                            else
                            {
                                Debug.LogWarning("Result data does not contain liveVersion key from playfab");
                            }
                        }
                        else
                        {
                            Debug.LogWarning("Result version data is null");
                        }
                    },

                    error =>
                    {
                        Debug.LogError("Could not get title data from playfab");
                    }
                );
            },

            fail =>
            {
                Debug.LogError("Could not login with AndroidDeviceID to obtain live version");
            }
        );

        return version;
    }
}
