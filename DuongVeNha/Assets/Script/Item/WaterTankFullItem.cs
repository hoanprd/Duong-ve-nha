using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTankFullItem : MonoBehaviour
{
    ItemHandle ih;

    public GameObject waterTankFull;

    void Start()
    {
        GameObject gameObject = new GameObject("ItemHandle");
        gameObject.AddComponent<ItemHandle>();
        ih = gameObject.GetComponent<ItemHandle>();
    }

    void Update()
    {
        ih.CheckToDestroyItem(waterTankFull, ContainerController.waterTankFull);
    }

    public void WaterTankFullUse()
    {
        ih.ItemPress(8);
    }
}
