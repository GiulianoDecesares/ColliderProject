using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayDialog : MonoBehaviour
{
    [SerializeField] private RectTransform playerOneUiContainer;
    [SerializeField] private RectTransform playerTwoUiContainer;
    [SerializeField] private RectTransform arena;

    private void Start()
    {
        this.PopulateUI();
    }

    private void PopulateUI()
    {
        GameObject characterCardPrefab = PrefabManager.instance.GetPrefabByName("CharacterCard");

        if(characterCardPrefab == null)
            Debug.Log("Null character card prefab");

        for(int index = 0; index < 3; index++)
        {
            Instantiate(characterCardPrefab, playerOneUiContainer);
            Instantiate(characterCardPrefab, playerTwoUiContainer);
        }
    }
}
