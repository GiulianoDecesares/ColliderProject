using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabManager : MonoBehaviour
{
    // Update period
    public float yieldPeriod = 0.03f;

    // Prefabs array populated manually from inspector (prewarm)
    [SerializeField] private List<GameObject> prefabs;

    // Prefabs in order by name
    private Dictionary<string, GameObject> prefabsByName = new Dictionary<string, GameObject>();

    public bool isInitialized { get; private set; }

    #region Sigleton

    public static PrefabManager instance { get; private set; }

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

        StartCoroutine(this.Initialize());
        DontDestroyOnLoad(this.gameObject);
    }

    #endregion

    public IEnumerator Initialize()
    {
        if(!this.isInitialized)
        {
            float lastYieldTime = Time.realtimeSinceStartup;
            
            for(int index = 0; index < this.prefabs.Count; index++)
            {
                if(this.prefabs[index] != null)
                {
                    if(this.prefabsByName.ContainsKey(prefabs[index].name))
                    {
                        Debug.LogWarning("Duplicated prefab named " + prefabs[index].name, this.gameObject);
                    }
                    else
                    {
                        this.prefabsByName[prefabs[index].name] = prefabs[index];
                    }

                    float currentTime = Time.realtimeSinceStartup;

                    if(currentTime - lastYieldTime > this.yieldPeriod)
                    {
                        lastYieldTime = currentTime;

                        yield return null;
                    }
                }
            }

            this.isInitialized = true;

            yield return null;
        }
        else
        {
            Debug.LogWarning(this.GetType().Name + " is already initialized.");
        }
    }

    public GameObject GetPrefabByName(string prefabName)
    {
        GameObject returnGameObject = null;

        if(!string.IsNullOrEmpty(prefabName))
        {
            this.prefabsByName.TryGetValue(prefabName, out returnGameObject);
        }
        else
        {
            Debug.LogError("Prefab name exception :: null or empty prefab name parameter");
        }

        if(returnGameObject == null)
            Debug.LogWarning("Prefab look up exception :: " + prefabName + " prefab not found");
        // IMPROVEMENT :: Load prefab from disk ?

        return returnGameObject;
    }
}
