using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyFloor4Item : MonoBehaviour
{
    ItemHandle ih;

    public GameObject keyFloor4;

    void Start()
    {
        GameObject gameObject = new GameObject("ItemHandle");
        gameObject.AddComponent<ItemHandle>();
        ih = gameObject.GetComponent<ItemHandle>();
    }

    void Update()
    {
        ih.CheckToDestroyItem(keyFloor4, ContainerController.keyFloor4);
    }

    public void KeyFloor4Use()
    {
        ih.ItemPress(10);
    }
}
