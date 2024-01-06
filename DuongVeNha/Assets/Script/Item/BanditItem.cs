using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditItem : MonoBehaviour
{
    ItemHandle ih;

    public GameObject bandit;

    void Start()
    {
        GameObject gameObject = new GameObject("ItemHandle");
        gameObject.AddComponent<ItemHandle>();
        ih = gameObject.GetComponent<ItemHandle>();
    }

    void Update()
    {
        ih.CheckToDestroyItem(bandit, ContainerController.bandit);
    }

    public void BanditUse()
    {
        ih.ItemPress(2);
    }
}
