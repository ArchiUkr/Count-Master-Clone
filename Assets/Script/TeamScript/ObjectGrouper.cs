using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectGrouper : MonoBehaviour
{
    public static ObjectGrouper SharedInstance;
    [SerializeField] List<ObjectGroupItem> teammateToGroup;
    [HideInInspector] public List<GameObject> groupingObjects;

    private void Awake() 
    {
        SceneManager.sceneLoaded += OnLevelLoaded;
    }
    private void OnLevelLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        SharedInstance = this;
        groupingObjects = new List<GameObject>();
        foreach (ObjectGroupItem stickman in teammateToGroup)
        {
            for (int i = 0; i < stickman.amountToGroup; i++)
            {
                GameObject _teammate = Instantiate(stickman.objectToGroup);
                _teammate.SetActive(false);
                groupingObjects.Add(_teammate);
            }
        }
    }
    public GameObject GetGroupedObject(string tag)
    {
        for (int i = 0; i < groupingObjects.Count; i++)
        {
            if (!groupingObjects[i].activeInHierarchy && groupingObjects[i].tag == tag)
            {
                return groupingObjects[i];
            }
        }
        foreach (ObjectGroupItem item in teammateToGroup)
        {
            if (item.objectToGroup.tag == tag)
            {
                if (item.shouldExpand)
                {
                    GameObject obj = Instantiate(item.objectToGroup);
                    obj.SetActive(false);
                    groupingObjects.Add(obj);
                    return obj;
                }
            }
        }
        return null;
    }
}
