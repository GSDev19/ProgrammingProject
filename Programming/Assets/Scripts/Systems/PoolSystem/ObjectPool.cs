using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectPool 
{
    [SerializeField] private GameObject objectPrefab;
    [SerializeField] private int amount = 20;
    [SerializeField] private int incrementAmount = 5; // Number of objects to create when the pool is expanded
    [Space]
    [SerializeField] private Transform objectParent;

    List<GameObject> objectsList = new List<GameObject>();
    private int index = 0;

    //public void Initialize()
    //{
    //    for (int i = 0; i < amount; i++)
    //    {
    //        GameObject newGameObject = GameObject.Instantiate(objectPrefab);
    //        newGameObject.transform.SetParent(objectParent);
    //        if (!objectsList.Contains(newGameObject))
    //        {
    //            objectsList.Add(newGameObject);
    //        }
    //        newGameObject.SetActive(false);
    //    }
    //}
    public void Initialize()
    {
        for (int i = 0; i < amount; i++)
        {
            CreateObject();
        }
    }
    private GameObject CreateObject()
    {
        GameObject newGameObject = GameObject.Instantiate(objectPrefab);
        newGameObject.transform.SetParent(objectParent);
        newGameObject.SetActive(false);
        objectsList.Add(newGameObject);
        return newGameObject;
    }

    private GameObject GetNextAvailableObject()
    {
        for (int i = 0; i < objectsList.Count; i++)
        {
            if (!objectsList[i].activeSelf)
            {
                return objectsList[i];
            }
        }
        // If no inactive objects are found, create more
        for (int i = 0; i < incrementAmount; i++)
        {
            CreateObject();
        }
        // Return the first newly created object
        return objectsList[objectsList.Count - incrementAmount];
    }

    public GameObject Spawn(Vector3 pos, Quaternion quaternion)
    {
        GameObject temp = GetNextAvailableObject();
        temp.SetActive(true);
        temp.transform.position = pos;
        temp.transform.rotation = quaternion;

        index = (index + 1) % objectsList.Count;

        return temp;
    }
}
