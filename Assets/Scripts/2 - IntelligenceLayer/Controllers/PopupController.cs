using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupController : MonoBehaviour
{
    public static void DisplayUpdateDialog(string message, Transform parent)
    {
        GameObject popupPrefab = PrefabManager.instance.GetPrefabByName("UpdatePopup");

        if(popupPrefab != null)
        {
            GameObject popupInstance = Instantiate(popupPrefab, parent);
            UpdatePopup updatePopup = popupInstance.GetComponent<UpdatePopup>();

            updatePopup.SetMessage(message);
            updatePopup.SetLeftButtonText("Exit");
            updatePopup.SetRightButtonText("Update");

            updatePopup.SetRightButtonCallback(delegate { UpdateManager.instance.OpenUpdateFolder(); } );
            updatePopup.SetLeftButtonCallback(
                delegate 
                {
                    // save any game data here
                    #if UNITY_EDITOR
                            // Application.Quit() does not work in the editor so
                            // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
                            UnityEditor.EditorApplication.isPlaying = false;
                    #else
                        Application.Quit();
                    #endif
                }
            );
        }
        else
        {
            Debug.LogError("Pop up prefab is null");
        }
    }
}
