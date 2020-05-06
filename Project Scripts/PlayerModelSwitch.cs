using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModelSwitch : MonoBehaviour
{
    private GameObject currentWeapon;
    public Transform PlayerPistol;
    public Transform PlayerRifle;
    public Transform PlayerUnarmed;
    public Transform PlayerShotgun;
    public Transform PlayerMachinegun;
    public Transform currentPlayer;
    private GameObject newWeapon;

    // Update is called once per frame
    void Update()
    {
        currentWeapon = GetComponent<Inventory>().currentWeapon;
        if(currentWeapon && newWeapon != currentWeapon)
        {
            string weaponType = currentWeapon.GetComponent<InteractionObject>().type.ToString();
            Debug.Log(weaponType);
            if(weaponType == "Pistol")
            {
                Debug.Log("Pistol");
                ChangeModel(PlayerPistol, currentPlayer);
                PlayerUnarmed.gameObject.SetActive(false);
                PlayerPistol.gameObject.SetActive(true);
                PlayerRifle.gameObject.SetActive(false);
                PlayerShotgun.gameObject.SetActive(false);
                PlayerMachinegun.gameObject.SetActive(false);
            }
            if (weaponType == "Rifle")
            {
                Debug.Log("Rifle");
                ChangeModel(PlayerRifle, currentPlayer);
                PlayerShotgun.gameObject.SetActive(false);
                PlayerUnarmed.gameObject.SetActive(false);
                PlayerPistol.gameObject.SetActive(false);
                PlayerRifle.gameObject.SetActive(true);
                PlayerMachinegun.gameObject.SetActive(false);
            }
            if (weaponType == "Shotgun")
            {
                Debug.Log("Shotgun");
                ChangeModel(PlayerShotgun, currentPlayer);
                PlayerShotgun.gameObject.SetActive(true);
                PlayerUnarmed.gameObject.SetActive(false);
                PlayerPistol.gameObject.SetActive(false);
                PlayerRifle.gameObject.SetActive(false);
                PlayerMachinegun.gameObject.SetActive(false);
            }
            if (weaponType == "MachineGun")
            {
                Debug.Log("Machine");
                ChangeModel(PlayerMachinegun, currentPlayer);
                PlayerShotgun.gameObject.SetActive(false);
                PlayerUnarmed.gameObject.SetActive(false);
                PlayerPistol.gameObject.SetActive(false);
                PlayerRifle.gameObject.SetActive(false);
                PlayerMachinegun.gameObject.SetActive(true);
            }
            newWeapon = currentWeapon;
        }
        if(!currentWeapon && newWeapon != currentWeapon)
        {
            Debug.Log("Unarmed");
            ChangeModel(PlayerUnarmed, currentPlayer);
            PlayerUnarmed.gameObject.SetActive(true);
            PlayerPistol.gameObject.SetActive(false);
            PlayerRifle.gameObject.SetActive(false);
            PlayerShotgun.gameObject.SetActive(false);
            PlayerMachinegun.gameObject.SetActive(false);
            newWeapon = null;
        }
    }

    public void ChangeModel(Transform playerNew, Transform playerCurrent)
    {
        playerNew.position = playerCurrent.position;
        playerNew.rotation = playerCurrent.rotation;
        playerNew.GetComponent<Inventory>().currentWeapon = currentWeapon;
        playerNew.GetComponent<Inventory>().currentItem = playerCurrent.GetComponent<Inventory>().currentItem;
        playerNew.GetComponent<InteractionObject>().type = playerCurrent.GetComponent<InteractionObject>().type;
        playerNew.GetComponent<Inventory>().weaponInventory = playerCurrent.GetComponent<Inventory>().weaponInventory;
        playerNew.GetComponent<Inventory>().itemInventory = playerCurrent.GetComponent<Inventory>().itemInventory;
        playerNew.GetComponent<Inventory>().weaponsr = playerCurrent.GetComponent<Inventory>().weaponsr;
        playerNew.GetComponent<Inventory>().itemsr = playerCurrent.GetComponent<Inventory>().itemsr;
        playerNew.GetComponent<Inventory>().imageWeapon = playerCurrent.GetComponent<Inventory>().imageWeapon;
        playerNew.GetComponent<Inventory>().imageItem = playerCurrent.GetComponent<Inventory>().imageItem;
        playerNew.GetComponent<Inventory>().weaponSprites = playerCurrent.GetComponent<Inventory>().weaponSprites;
        playerNew.GetComponent<Inventory>().itemSprites = playerCurrent.GetComponent<Inventory>().itemSprites;
        playerNew.GetComponent<Consumables>().itemsr = playerCurrent.GetComponent<Consumables>().itemsr;
        playerNew.GetComponent<Consumables>().imageItem = playerCurrent.GetComponent<Consumables>().imageItem;  
        playerNew.GetComponent<StaminaGauge>().needleGauge = playerCurrent.GetComponent<StaminaGauge>().needleGauge;
        playerNew.GetComponent<Player_Movement>().stamina = playerCurrent.GetComponent<Player_Movement>().stamina;
        playerNew.GetComponent<Player_Movement>().timer = playerCurrent.GetComponent<Player_Movement>().timer;
        playerNew.GetComponent<Player>().healthBar = playerCurrent.GetComponent<Player>().healthBar;
        playerNew.GetComponent<Player>().health = playerCurrent.GetComponent<Player>().health;
        playerNew.GetComponent<Shooting>().Pistol_Bullet = playerCurrent.GetComponent<Shooting>().Pistol_Bullet;
        playerNew.GetComponent<Shooting>().ShotGun_Bullet = playerCurrent.GetComponent<Shooting>().ShotGun_Bullet;
        playerNew.GetComponent<Shooting>().Rifle_Bullet = playerCurrent.GetComponent<Shooting>().Rifle_Bullet;
        playerNew.GetComponent<Shooting>().MachineGun_Bullet = playerCurrent.GetComponent<Shooting>().MachineGun_Bullet;
    }
}
