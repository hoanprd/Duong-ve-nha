using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glass2Item : MonoBehaviour
{
    ItemHandle ih;

    public GameObject glass2;

    void Start()
    {
        GameObject gameObject = new GameObject("ItemHandle");
        gameObject.AddComponent<ItemHandle>();
        ih = gameObject.GetComponent<ItemHandle>();
    }

    void Update()
    {
        ih.CheckToDestroyItem(glass2, ContainerController.glass2);
    }

    public void Glass2Use()
    {
        ih.ItemPress(1);
    }
}
