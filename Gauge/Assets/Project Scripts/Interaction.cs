
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public GameObject currentObject = null;
    public InteractionObject currentInterObjScript = null;
    public Inventory inventory;
    bool inTrigger = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name != "Ranged_Enemy_Bullet(Clone)")
        {
            bool weapon = other.GetComponent<InteractionObject>().weapon;
            bool add = false;
            if (weapon)
            {
                GameObject[] weaponInventory = GetComponent<Inventory>().weaponInventory;
                for (int x = 0; x < weaponInventory.Length; x++)
                {
                    if (weaponInventory[x] == null)
                    {
                        add = true;
                        break;
                    }
                }
                for (int x = 0; x < weaponInventory.Length; x++)
                {
                    if (weaponInventory[x] != null)
                    {
                        if (weaponInventory[x].GetComponent<InteractionObject>().type == other.GetComponent<InteractionObject>().type)
                        {
                            add = false;
                            break;
                        }
                    }
                }
            }
            else
            {
                GameObject[] itemInventory = GetComponent<Inventory>().itemInventory;
                for (int x = 0; x < itemInventory.Length; x++)
                {
                    if (itemInventory[x] == null)
                    {
                        add = true;
                        break;
                    }
                }
            }
            if (add)
            {
                if (other.CompareTag("Interactive_Object"))
                {
                    currentObject = other.gameObject;
                    currentInterObjScript = currentObject.GetComponent<InteractionObject>();
                }
                inTrigger = true;
            }
            else
            {
                inTrigger = false;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        currentInterObjScript = null;
        currentObject = null;
    }

    void Update()
    {
        if (inTrigger && Input.GetButtonDown("e"))
        {
            if (currentObject)
            {
                if (currentInterObjScript.inventory)
                {
                    inventory.AddItem(currentObject);
                }
                currentObject.SetActive(false);
            }
        }
    }
}
