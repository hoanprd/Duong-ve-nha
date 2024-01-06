using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glass1Item : MonoBehaviour
{
    ItemHandle ih;

    public GameObject glass1;

    void Start()
    {
        GameObject gameObject = new GameObject("ItemHandle");
        gameObject.AddComponent<ItemHandle>();
        ih = gameObject.GetComponent<ItemHandle>();
    }

    void Update()
    {
        ih.CheckToDestroyItem(glass1, ContainerController.glass1);
    }

    public void Glass1Use()
    {
        ih.ItemPress(0);
    }
}
