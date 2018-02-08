using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour {

    static PoolManager _instance;
    public static PoolManager instance {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<PoolManager>();
            }
            return _instance;
        }
    }

    Dictionary<int, List<GameObject>> poolDictionary = new Dictionary<int, List<GameObject>>();
    public bool ableToGrow;

	public void CreatePool(GameObject prefab, int size)
    {
        int key = prefab.GetInstanceID();
        if (!poolDictionary.ContainsKey(key))
        {
            poolDictionary.Add(key, new List<GameObject>());
            for (int i =0; i < size; i++)
            {
                GameObject obj = (GameObject)Instantiate(prefab);
                obj.SetActive(false);
                poolDictionary[key].Add(obj);
            }
        }
    }

    public GameObject GetObject(GameObject prefab)
    {
        int key = prefab.GetInstanceID();
        if (poolDictionary.ContainsKey(key))
        {
            //GameObject objectToReturn = poolDictionary[key]
            foreach (GameObject obj in poolDictionary[key])
            {
                if (!obj.activeInHierarchy)
                {
                    return obj;
                }
            }

            if (ableToGrow)
            {
                GameObject newObject = (GameObject)Instantiate(prefab);
                poolDictionary[key].Add(newObject);
                newObject.SetActive(false);
                return newObject;
            }
        }

        return null;
    }

}
