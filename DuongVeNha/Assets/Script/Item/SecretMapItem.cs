using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretMapItem : MonoBehaviour
{
    ItemHandle ih;

    public GameObject secretMap;

    void Start()
    {
        GameObject gameObject = new GameObject("ItemHandle");
        gameObject.AddComponent<ItemHandle>();
        ih = gameObject.GetComponent<ItemHandle>();
    }

    void Update()
    {
        ih.CheckToDestroyItem(secretMap, ContainerController.secretMap);
    }

    public void SecretMapUse()
    {
        ih.ItemPress(3);
    }
}
