using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemHandle : MonoBehaviour
{
    public void ItemPress(int itemIndex)
    {
        if (itemIndex == 0)
        {
            //glass1
        }
        else if (itemIndex == 1)
        {
            //glass2
        }
        else if (itemIndex == 2)
        {
            if (ContainerController.glass1 > 0 && ContainerController.glass2 > 0)
            {
                MainController.banditUse = true;
            }
        }
        else if (itemIndex == 3)
        {
            MainController.secretMapUse = true;
        }
        else if (itemIndex == 4)
        {
            //glassFull
        }
        else if (itemIndex == 5)
        {
            //handle
        }
    }

    public void CheckToDestroyItem(GameObject gameObject, int quanity)
    {
        if (quanity <= 0)
        {
            Destroy(gameObject);
        }
    }
}
