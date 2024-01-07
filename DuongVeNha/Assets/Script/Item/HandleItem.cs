using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleItem : MonoBehaviour
{
    ItemHandle ih;

    public GameObject hadnle;

    void Start()
    {
        GameObject gameObject = new GameObject("ItemHandle");
        gameObject.AddComponent<ItemHandle>();
        ih = gameObject.GetComponent<ItemHandle>();
    }

    void Update()
    {
        ih.CheckToDestroyItem(hadnle, ContainerController.handle);
    }

    public void HandleUse()
    {
        ih.ItemPress(5);
    }
}
