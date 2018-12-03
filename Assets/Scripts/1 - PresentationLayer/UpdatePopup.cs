using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdatePopup : MonoBehaviour
{
    [SerializeField] private Text messageToShow;

    [SerializeField] private Button acceptButton;
    [SerializeField] private Button cancelButton;

    private void Awake()
    {
        

    }

    public void Populate()
    {
        this.messageToShow.text = "Looks like your game needs an update!";

        Text acceptButtonText = this.acceptButton.GetComponentInChildren<Text>();
        Text cancelButtonText = this.cancelButton.GetComponentInChildren<Text>();

        acceptButtonText.text = "Update";
        cancelButtonText.text = "Exit";

        //this.acceptButton.onClick +=
    }
}
