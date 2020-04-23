using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject[] weaponInventory = new GameObject[3];
    public GameObject[] itemInventory = new GameObject[2];
    public GameObject currentWeapon = null;
    public GameObject currentItem = null;
    public Transform player;
    
    public void AddItem(GameObject item)
    {
        string weaponType = item.GetComponent<InteractionObject>().type.ToString();
        if (weaponType == "Pistol" || weaponType == "Shotgun" || weaponType == "Rifle" || weaponType == "MachineGun")
        {
            if (SearchWeaponInventory(item))
            {
                for (int x = 0; x < weaponInventory.Length; x++)
                {
                    if (weaponInventory[x] == null)
                    {
                        weaponInventory[x] = item;
                        currentWeapon = item;
                        Debug.Log(item.name + " was Added");
                        break;
                    }
                }
            }
        }
        else
        {
            if (SearchItemInventory(item))
            {
                for (int x = 0; x < itemInventory.Length; x++)
                {
                    if (itemInventory[x] == null)
                    {
                        itemInventory[x] = item;
                        currentItem = item;
                        Debug.Log(item.name + " was Added");
                        break;
                    }
                }
            }
        }
    }
    
    public void DropWeapon()
    {
        if(currentWeapon)
        {
            for(int x = 0; x < weaponInventory.Length; x++)
            {
                if(currentWeapon == weaponInventory[x])
                {
                    weaponInventory[x] = null;
                    currentWeapon.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
                    currentWeapon.SetActive(true);
                    break;
                }
            }
        }
    }

    public void DropItem()
    {
        if (currentItem)
        {
            for (int x = 0; x < itemInventory.Length; x++)
            {
                if (currentItem == itemInventory[x])
                {
                    itemInventory[x] = null;
                    GameObject droppedItem = Instantiate(currentItem, player.position, player.rotation);
                    currentItem.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
                    currentItem.SetActive(true);
                    break;
                }
            }
        }
    }

    public bool SearchWeaponInventory(GameObject item)
    {
        for(int x = 0; x < weaponInventory.Length; x++)
        {
            if(weaponInventory[x] == item)
            {
                return false;
            }
        }
        return true;
    }

    public bool SearchItemInventory(GameObject item)
    {
        for (int x = 0; x < itemInventory.Length; x++)
        {
            if (itemInventory[x] == item)
            {
                return false;
            }
        }
        return true;
    }

    public void Update()
    {
        if (Input.GetButtonDown("1"))
        {
            if (weaponInventory[0])
            {
                currentWeapon = weaponInventory[0];
            }
        }
        else if(Input.GetButtonDown("2"))
        {
            if (weaponInventory[1])
            {
                currentWeapon = weaponInventory[1];
            }
        }
        else if (Input.GetButtonDown("3"))
        {
            if (weaponInventory[2])
            {
                currentWeapon = weaponInventory[2];
            }
        }
        if (Input.GetButtonDown("4"))
        {
            if (itemInventory[0])
            {
                currentItem = itemInventory[0];
            }
        }
        else if (Input.GetButtonDown("5"))
        {
            if (itemInventory[1])
            {
                currentItem = itemInventory[1];
            }
        }
        if (Input.GetButtonDown("r"))
        {
            DropWeapon();
        }
        if (Input.GetButtonDown("t"))
        {
            DropItem();
        }
    }
}
