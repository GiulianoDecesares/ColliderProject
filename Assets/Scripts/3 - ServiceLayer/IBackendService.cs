using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBackendService
{
    void GetLiveVersion(System.Action<string> onVersionObtained, System.Action onError);
}
