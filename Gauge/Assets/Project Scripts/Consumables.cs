using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumables : MonoBehaviour
{
    private GameObject item;

    void Update()
    {
        item = GetComponent<Inventory>().currentItem;
        if (item)
        {
            string itemType = item.GetComponent<InteractionObject>().type.ToString();
            if (itemType == "Health")
            {
                if (Input.GetButtonDown("f"))
                {
                    UseHealth(item);
                }
            }
            else if (itemType == "Stamina")
            {
                if (Input.GetButtonDown("f"))
                {
                    UseStamina(item);
                }
            }
        }
    }

    public void UseHealth(GameObject item)
    {
        if (GetComponent<Player>().health + 100 > 300)
        {
            GetComponent<Player>().health = 300;
        }
        else
        {
            GetComponent<Player>().health += 100;
        }
        GameObject[] inventory = GetComponent<Inventory>().itemInventory;
        for(int x = 0; x < inventory.Length; x++)
        {
            if (inventory[x])
            {
                if (inventory[x].name == item.name)
                {
                    inventory[x] = null;
                    break;
                }
            }
        }
        GetComponent<Inventory>().currentItem = null;
        for (int x = 0; x < inventory.Length; x++)
        {
            if (inventory[x] != null)
            {
                GetComponent<Inventory>().currentItem = inventory[x];
                break;
            }
        }
    }

    public void UseStamina(GameObject item)
    {
        GetComponent<Player_Movement>().stamina = 200;
        GameObject[] inventory = GetComponent<Inventory>().itemInventory;
        for (int x = 0; x < inventory.Length; x++)
        {
            if (inventory[x])
            {
                if (inventory[x].name == item.name)
                {
                    inventory[x] = null;
                    break;
                }
            }
        }
        GetComponent<Inventory>().currentItem = null;
        for (int x = 0; x < inventory.Length; x++)
        {
            if (inventory[x] != null)
            {
                GetComponent<Inventory>().currentItem = inventory[x];
                break;
            }
        }
    }
}
