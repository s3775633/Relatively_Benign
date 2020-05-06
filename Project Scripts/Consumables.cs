using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Consumables : MonoBehaviour
{
    private GameObject item;
    public SpriteRenderer[] itemsr;
    public Image[] imageItem;

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
                    itemsr[x].sprite = null;
                    imageItem[x].enabled = false;
                    Destroy(item);
                    break;
                }
            }
        }
        for (int x = 0; x < inventory.Length; x++)
        {
            if (inventory[x] != null)
            {
                imageItem[x].enabled = true;
                item = inventory[x];
                break;
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
        GetComponent<Player_Movement>().stamina = 2;
        GameObject[] inventory = GetComponent<Inventory>().itemInventory;
        for (int x = 0; x < inventory.Length; x++)
        {
            if (inventory[x])
            {
                if (inventory[x].name == item.name)
                {
                    inventory[x] = null;
                    itemsr[x].sprite = null;
                    imageItem[x].enabled = false;
                    Destroy(item);
                    break;
                }
            }
        }
        for (int x = 0; x < inventory.Length; x++)
        {
            if (inventory[x] != null)
            {
                imageItem[x].enabled = true;
                item = inventory[x];
                break;
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
