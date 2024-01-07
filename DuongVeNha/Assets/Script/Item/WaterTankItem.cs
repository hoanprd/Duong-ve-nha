using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTankItem : MonoBehaviour
{
    ItemHandle ih;

    public GameObject waterTank;

    void Start()
    {
        GameObject gameObject = new GameObject("ItemHandle");
        gameObject.AddComponent<ItemHandle>();
        ih = gameObject.GetComponent<ItemHandle>();
    }

    void Update()
    {
        ih.CheckToDestroyItem(waterTank, ContainerController.waterTank);
    }

    public void WaterTankUse()
    {
        ih.ItemPress(7);
    }
}
