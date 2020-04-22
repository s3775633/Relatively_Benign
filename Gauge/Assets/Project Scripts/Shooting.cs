using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject Pistol_Bullet;
    public GameObject ShotGun_Bullet;
    public GameObject Rifle_Bullet;
    public GameObject MachineGun_Bullet;
    public GameObject weapon;

    public float bulletForce = 20f;
    private float fireRate;
    private float nextFire = -1f;

    void Update()
    {
        weapon = GetComponent<Inventory>().currentWeapon;
        if (weapon)
        {
            if (nextFire > 0)
            {
                nextFire -= Time.deltaTime;
                return;
            }
            if (weapon.name == "Pistol")
            {
                fireRate = 0.5f;
                if (Input.GetButtonDown("Fire1"))
                {
                    ShootPistol();
                }
            }
            else if (weapon.name == "Shotgun")
            {
                fireRate = 1.5f;
                if (Input.GetButtonDown("Fire1"))
                {
                    ShootShotgun();
                }
            }
            else if (weapon.name == "Rifle")
            {
                fireRate = 2f;
                if (Input.GetButtonDown("Fire1"))
                {
                    ShootRifle();
                }
            }
            else if (weapon.name == "Machine Gun")
            {
                fireRate = 0.1f;
                if (Input.GetButton("Fire1"))
                {
                    ShootMachineGun();
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
