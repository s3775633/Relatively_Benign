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
    public SpriteRenderer weaponsr1;
    public SpriteRenderer weaponsr2;
    public SpriteRenderer weaponsr3;
    public SpriteRenderer itemsr1;
    public SpriteRenderer itemsr2;
    public Sprite[] weaponSprites;
    public Sprite[] itemSprites;
   

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
                        if(x == 0)
                        {
                            if(weaponType == "Pistol")
                            {
                                weaponsr1.sprite = weaponSprites[0];
                            }
                            else if (weaponType == "Shotgun")
                            {
                                weaponsr1.sprite = weaponSprites[1];
                            }
                            else if (weaponType == "MachineGun")
                            {
                                weaponsr1.sprite = weaponSprites[2];
                            }
                            else if (weaponType == "Rifle")
                            {
                                weaponsr1.sprite = weaponSprites[3];
                            }
                        }
                        else if (x == 1)
                        {
                            if (weaponType == "Pistol")
                            {
                                weaponsr2.sprite = weaponSprites[0];
                            }
                            else if (weaponType == "Shotgun")
                            {
                                weaponsr2.sprite = weaponSprites[1];
                            }
                            else if (weaponType == "MachineGun")
                            {
                                weaponsr2.sprite = weaponSprites[2];
                            }
                            else if (weaponType == "Rifle")
                            {
                                weaponsr2.sprite = weaponSprites[3];
                            }
                        }
                        else if (x == 2)
                        {
                            if (weaponType == "Pistol")
                            {
                                weaponsr3.sprite = weaponSprites[0];
                            }
                            else if (weaponType == "Shotgun")
                            {
                                weaponsr3.sprite = weaponSprites[1];
                            }
                            else if (weaponType == "MachineGun")
                            {
                                weaponsr3.sprite = weaponSprites[2];
                            }
                            else if (weaponType == "Rifle")
                            {
                                weaponsr3.sprite = weaponSprites[3];
                            }
                        }
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
                        if (x == 0)
                        {
                            if (weaponType == "Health")
                            {
                                itemsr1.sprite = itemSprites[0];
                            }
                            else if (weaponType == "Stamina")
                            {
                                itemsr1.sprite = itemSprites[1];
                            }
                            else if (weaponType == "Key")
                            {
                                itemsr1.sprite = itemSprites[2];
                            }
                        }
                        else if (x == 1)
                        {
                            if (weaponType == "Health")
                            {
                                itemsr2.sprite = itemSprites[0];
                            }
                            else if (weaponType == "Stamina")
                            {
                                itemsr2.sprite = itemSprites[1];
                            }
                            else if (weaponType == "Key")
                            {
                                itemsr2.sprite = itemSprites[2];
                            }
                        }
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
                    if(x == 0)
                    {
                        weaponsr1.sprite = null;
                    }
                    else if (x == 1)
                    {
                        weaponsr2.sprite = null;
                    }
                    else if (x == 2)
                    {
                        weaponsr3.sprite = null;
                    }
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
                    if (x == 0)
                    {
                        itemsr1.sprite = null;
                    }
                    else if (x == 1)
                    {
                        itemsr2.sprite = null;
                    }
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
