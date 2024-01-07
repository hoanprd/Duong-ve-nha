using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeKeyItem : MonoBehaviour
{
    ItemHandle ih;

    public GameObject homeKey;

    void Start()
    {
        GameObject gameObject = new GameObject("ItemHandle");
        gameObject.AddComponent<ItemHandle>();
        ih = gameObject.GetComponent<ItemHandle>();
    }

    void Update()
    {
        ih.CheckToDestroyItem(homeKey, ContainerController.homeKey);
    }

    public void HomeKeyUse()
    {
        ih.ItemPress(11);
    }
}
