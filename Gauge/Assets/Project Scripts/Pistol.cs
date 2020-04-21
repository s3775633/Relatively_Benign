using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol
{
    private string weaponName;
    private int damage;
    private float speed;

    public Pistol()
    {
        weaponName = "Pistol";
        damage = 20;
        speed = 20f;
    }

    public string getName()
    {
        return weaponName;
    }

    public int getDamage()
    {
        return damage;
    }

    public float getSpeed()
    {
        return speed;
    }
}
