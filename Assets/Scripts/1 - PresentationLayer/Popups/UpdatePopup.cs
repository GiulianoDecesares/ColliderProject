using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdatePopup : MonoBehaviour
{
    [SerializeField] private Text message;

    [SerializeField] private Button leftButton;
    [SerializeField] private Button rightButton;

    public void SetMessage(string messageText)
    {
        this.message.text = messageText;
    }

    public void SetLeftButtonText(string text)
    {
        Text buttonText = this.leftButton.GetComponentInChildren<Text>();

        if(buttonText != null)
            buttonText.text = text;
        else
            Debug.LogWarning("Can't get text component on left button");
    }

    public void SetRightButtonText(string text)
    {
        Text buttonText = this.rightButton.GetComponentInChildren<Text>();

        if(buttonText != null)
            buttonText.text = text;
        else
            Debug.LogWarning("Can't get text component on right button");
    }

    public void SetLeftButtonCallback(UnityEngine.Events.UnityAction call)
    {
        this.leftButton.onClick.AddListener(call);
    }

    public void SetRightButtonCallback(UnityEngine.Events.UnityAction call)
    {
        this.rightButton.onClick.AddListener(call);
    }
}
