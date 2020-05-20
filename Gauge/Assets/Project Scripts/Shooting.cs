using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public Animator animator;
    public GameObject Pistol_Bullet;
    public GameObject ShotGun_Bullet;
    public GameObject Rifle_Bullet;
    public GameObject MachineGun_Bullet;
    public GameObject weapon;

    public float bulletForce = 20f;
    private float fireRate;
    private float nextFire = -1f;

    [SerializeField] private AudioClip pistolSound;
    [SerializeField] private AudioClip shotGunSound;
    [SerializeField] private AudioClip rifleSound;
    [SerializeField] private AudioClip machineGunSound;

    void Update()
    {
        weapon = GetComponent<Inventory>().currentWeapon;
        if (weapon)
        {
            string weaponType = weapon.GetComponent<InteractionObject>().type.ToString();
            if (nextFire > 0)
            {
                nextFire -= Time.deltaTime;
                return;
            }
            if (weaponType == "Pistol")
            {
                fireRate = 0.5f;
                if (Input.GetButtonDown("Fire1"))
                {
                    ShootPistol();
                    AudioManager.Instance.PlaySFX(pistolSound);
                }
            }
            else if (weaponType == "Shotgun")
            {
                fireRate = 1.5f;
                if (Input.GetButtonDown("Fire1"))
                {
                    ShootShotgun();
                    AudioManager.Instance.PlaySFX(shotGunSound);
                }
            }
            else if (weaponType == "Rifle")
            {
                fireRate = 2f;
                if (Input.GetButtonDown("Fire1"))
                {
                    ShootRifle();
                    AudioManager.Instance.PlaySFX(rifleSound);
                }
            }
            else if (weaponType == "MachineGun")
            {
                fireRate = 0.1f;
                if (Input.GetButton("Fire1"))
                {
                    ShootMachineGun();
                    AudioManager.Instance.PlaySFX(machineGunSound);
                }
            }
        }
    }

    public void ShootPistol()
    {
        GameObject bullet1 = Instantiate(Pistol_Bullet, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet1.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        nextFire = fireRate;
    }

    public void ShootMachineGun()
    {
        GameObject bullet1 = Instantiate(MachineGun_Bullet, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet1.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        nextFire = fireRate;
    }

    public void ShootRifle()
    {
        GameObject bullet1 = Instantiate(Rifle_Bullet, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet1.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        nextFire = fireRate;
    }

    public void ShootShotgun()
    {
        GameObject bullet1 = Instantiate(ShotGun_Bullet, firePoint.position, firePoint.rotation);
        GameObject bullet2 = Instantiate(ShotGun_Bullet, firePoint.position, firePoint.rotation);
        GameObject bullet3 = Instantiate(ShotGun_Bullet, firePoint.position, firePoint.rotation);
        Rigidbody2D rb1 = bullet1.GetComponent<Rigidbody2D>();
        Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();
        Rigidbody2D rb3 = bullet3.GetComponent<Rigidbody2D>();
        rb1.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        firePoint.transform.eulerAngles = new Vector3(firePoint.transform.eulerAngles.x, firePoint.transform.eulerAngles.y, firePoint.transform.eulerAngles.z + 15);
        rb2.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        firePoint.transform.eulerAngles = new Vector3(firePoint.transform.eulerAngles.x, firePoint.transform.eulerAngles.y, firePoint.transform.eulerAngles.z - 30);
        rb3.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        firePoint.transform.eulerAngles = new Vector3(firePoint.transform.eulerAngles.x, firePoint.transform.eulerAngles.y, firePoint.transform.eulerAngles.z + 15);
        nextFire = fireRate;
    }
}
