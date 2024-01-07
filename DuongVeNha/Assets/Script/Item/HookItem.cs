using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookItem : MonoBehaviour
{
    ItemHandle ih;

    public GameObject hook;

    void Start()
    {
        GameObject gameObject = new GameObject("ItemHandle");
        gameObject.AddComponent<ItemHandle>();
        ih = gameObject.GetComponent<ItemHandle>();
    }

    void Update()
    {
        ih.CheckToDestroyItem(hook, ContainerController.hook);
    }

    public void HookUse()
    {
        ih.ItemPress(9);
    }
}
