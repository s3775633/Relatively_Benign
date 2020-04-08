
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public GameObject currentObject = null;
    public InteractionObject currentInterObjScript = null;
    public Inventory inventory;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Interactive_Object"))
        {
            Debug.Log(other.name);
            currentObject = other.gameObject;
            currentInterObjScript = currentObject.GetComponent<InteractionObject>();
        }
        if (currentObject)
        {
            if (currentInterObjScript.inventory)
            {
                inventory.AddItem(currentObject);
            }
            currentObject.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        if (currentObject == GameObject.Find("Shotgun"))
        {
            Debug.Log("Current Weapon is Shotgun");
        }
    }

    void Update()
    {

    }
}
