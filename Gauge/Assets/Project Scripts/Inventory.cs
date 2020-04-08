using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject[] inventory = new GameObject[5];

    void Start()
    {
        inventory[0] = GameObject.Find("Pistol");
    }
    
    public void AddItem(GameObject item)
    {
        if (SearchInventory(item))
        {
            for (int x = 0; x < inventory.Length; x++)
            {
                if (inventory[x] == null)
                {
                    inventory[x] = item;
                    Debug.Log(item.name + " was Added");
                    break;
                }
            }
        }
    }

    public bool SearchInventory(GameObject item)
    {
        for(int x = 0; x < inventory.Length; x++)
        {
            if(inventory[x] == item)
            {
                return false;
            }
        }
        return true;
    }
}
