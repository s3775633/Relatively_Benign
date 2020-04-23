using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour
{
    public bool inventory;
    public bool weapon;
    public enum itemType
    {
        Pistol,
        Shotgun,
        MachineGun,
        Rifle,
        Key,
        Health,
    }
    public itemType type;
}
