using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject[] weaponInventory = new GameObject[3];
    public GameObject[] itemInventory = new GameObject[2];
    public GameObject currentWeapon = null;
    public GameObject currentItem = null;
    public Transform player;
    public SpriteRenderer[] weaponsr;
    public SpriteRenderer[] itemsr;
    public Image[] imageWeapon;
    public Image[] imageItem;
    public Sprite[] weaponSprites;
    public Sprite[] itemSprites;
   
    void Start()
    {
    }

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
                        if (weaponType == "Pistol")
                        {
                            weaponsr[x].sprite = weaponSprites[0];
                        }
                        else if (weaponType == "Shotgun")
                        {
                            weaponsr[x].sprite = weaponSprites[1];
                        }
                        else if (weaponType == "MachineGun")
                        {
                            weaponsr[x].sprite = weaponSprites[2];
                        }
                        else if (weaponType == "Rifle")
                        {
                            weaponsr[x].sprite = weaponSprites[3];
                        }
                        imageWeapon[x].enabled = true;
                        currentWeapon = item;
                        Debug.Log(item.name + " was Added");
                        for(int i = 0; i < weaponInventory.Length; i++)
                        {
                            if(i != x)
                            {
                                imageWeapon[i].enabled = false;
                            }
                        }
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
                        if (weaponType == "Health")
                        {
                            itemsr[x].sprite = itemSprites[0];
                        }
                        else if (weaponType == "Stamina")
                        {
                            itemsr[x].sprite = itemSprites[1];
                        }
                        else if (weaponType == "Key")
                        {
                            itemsr[x].sprite = itemSprites[2];
                        }
                        imageItem[x].enabled = true;
                        itemInventory[x] = item;
                        currentItem = item;
                        Debug.Log(item.name + " was Added");
                        for (int i = 0; i < itemInventory.Length; i++)
                        {
                            if (i != x)
                            {
                                imageItem[i].enabled = false;
                            }
                        }
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
                    imageWeapon[x].enabled = false;
                    weaponsr[x].sprite = null;                
                    weaponInventory[x] = null;
                    currentWeapon.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
                    currentWeapon.SetActive(true);
                    currentWeapon = null;
                    break;
                }
            }
            for (int x = 0; x < weaponInventory.Length; x++)
            {
                if(weaponInventory[x] != null)
                {
                    imageWeapon[x].enabled = true;
                    currentWeapon = weaponInventory[x];
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
                    imageItem[x].enabled = false;
                    itemsr[x].sprite = null;
                    itemInventory[x] = null;
                    GameObject droppedItem = Instantiate(currentItem, player.position, player.rotation);
                    currentItem.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
                    currentItem.SetActive(true);
                    currentItem = null;
                    break;
                }
            }
            for (int x = 0; x < itemInventory.Length; x++)
            {
                if (itemInventory[x] != null)
                {
                    imageItem[x].enabled = true;
                    currentItem = itemInventory[x];
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
                imageWeapon[0].enabled = true;
                imageWeapon[1].enabled = false;
                imageWeapon[2].enabled = false;
            }
        }
        else if(Input.GetButtonDown("2"))
        {
            if (weaponInventory[1])
            {
                currentWeapon = weaponInventory[1];
                imageWeapon[0].enabled = false;
                imageWeapon[1].enabled = true;
                imageWeapon[2].enabled = false;
            }
        }
        else if (Input.GetButtonDown("3"))
        {
            if (weaponInventory[2])
            {
                currentWeapon = weaponInventory[2];
                imageWeapon[0].enabled = false;
                imageWeapon[1].enabled = false;
                imageWeapon[2].enabled = true;
            }
        }
        if (Input.GetButtonDown("4"))
        {
            if (itemInventory[0])
            {
                currentItem = itemInventory[0];
                imageItem[0].enabled = true;
                imageItem[1].enabled = false;
            }
        }
        else if (Input.GetButtonDown("5"))
        {
            if (itemInventory[1])
            {
                currentItem = itemInventory[1];
                imageItem[0].enabled = false;
                imageItem[1].enabled = true;
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
