using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassFullItem : MonoBehaviour
{
    ItemHandle ih;

    public GameObject glassFull;

    void Start()
    {
        GameObject gameObject = new GameObject("ItemHandle");
        gameObject.AddComponent<ItemHandle>();
        ih = gameObject.GetComponent<ItemHandle>();
    }

    void Update()
    {
        ih.CheckToDestroyItem(glassFull, ContainerController.glassFull);
    }

    public void GlassFullUse()
    {
        ih.ItemPress(4);
    }
}
