using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightItem : MonoBehaviour
{
    ItemHandle ih;

    public GameObject flashLight;

    void Start()
    {
        GameObject gameObject = new GameObject("ItemHandle");
        gameObject.AddComponent<ItemHandle>();
        ih = gameObject.GetComponent<ItemHandle>();
    }

    void Update()
    {
        ih.CheckToDestroyItem(flashLight, ContainerController.flashLight);
    }

    public void FlashLightUse()
    {
        ih.ItemPress(6);
    }
}
