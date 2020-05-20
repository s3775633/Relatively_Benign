using UnityEngine;
using UnityEngine.SceneManagement;

public class Interaction : MonoBehaviour
{
    public GameObject currentObject = null;
    public InteractionObject currentInterObjScript = null;
    public Inventory inventory;
    bool inTrigger = false;
	bool doorTrigger = false;
	GameObject door = null;
	bool pipeCircTrigger = false;

    void OnTriggerEnter2D(Collider2D other)
    {
		if (other.CompareTag("FallingFloor")){
			if (other.GetComponent<FallingFloor>().isDone()){
				Destroy(gameObject);
				return;
			}
		}
		
		else if (other.CompareTag("Door")){
			if (other.GetComponent<Door>().locked){
				doorTrigger = true;
				door = other.gameObject;
			}
		}
		
		else if (other.name.Equals("Pipe circuit 1 panel")){
			pipeCircTrigger = true;
		}
		
        else if (other.GetComponent<InteractionObject>() != null)
        {
            bool add = false;
            if (other.GetComponent<InteractionObject>().weapon)
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
                if (other.CompareTag("Interactive_Object") ||
					other.CompareTag("Key"))
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
		doorTrigger = false;
		pipeCircTrigger = false;
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
		
		// check if the player is at a door. Also check if is holding a key.
		// If so, open the door if the user presss "f" and 
		// delete the key from the inventory.
		else if (doorTrigger && Input.GetKeyDown("f")){
			Inventory inv = GetComponent<Inventory>();
			for (int i = 0; i < inv.itemInventory.Length; i++){
				if (inv.itemInventory[i] != null){
					if (inv.itemInventory[i].CompareTag("Key")){
						inv.imageItem[i].enabled = false;
						inv.itemsr[i].sprite = null;
						inv.itemInventory[i] = null;
						inv.currentItem = null;
						door.GetComponent<Door>().openDoor();
					}
				}
			}
		}
		
		else if (pipeCircTrigger && Input.GetKeyDown("e")){
			// to be coded
		}
    }
}
