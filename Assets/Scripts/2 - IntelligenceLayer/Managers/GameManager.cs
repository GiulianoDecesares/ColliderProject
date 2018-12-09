using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject UIContainer;

    #region Sigleton

    public static GameManager instance { get; private set; }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    #endregion

    private void Start()
    {
        // Menu dialog instantiation
        GameObject dialogPrefab = PrefabManager.instance.GetPrefabByName("MenuDialog");
        Instantiate(dialogPrefab, this.UIContainer.transform);

        // Then check for updates
        UpdateManager.instance.CheckForUpdatesProcedure();
    }
}
