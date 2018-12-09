using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupController : MonoBehaviour
{
    public static void DisplayUpdateDialog(Transform parent, System.Action onExitPressed = null)
    {
        GameObject popupPrefab = PrefabManager.instance.GetPrefabByName("UpdatePopup");

        if(popupPrefab != null)
        {
            GameObject popupInstance = Instantiate(popupPrefab, parent);
            UpdatePopup updatePopup = popupInstance.GetComponent<UpdatePopup>();

            string message = "Looks like the game needs to update!";

            updatePopup.SetMessage(message);
            updatePopup.SetLeftButtonText("Exit");
            updatePopup.SetRightButtonText("Update");

            updatePopup.SetRightButtonCallback
            (
                delegate
                {
                    // Update method. THIS SOULDNT BE HERE!!
                    Debug.Log("Updating!");
                    //Application.OpenURL();
                }   
            );

            updatePopup.SetLeftButtonCallback
            (
                delegate
                {
                    Destroy(popupInstance);
                }
            );
        }
        else
        {
            Debug.LogWarning("Can't get the update popup prefab");
        }
    }
}
