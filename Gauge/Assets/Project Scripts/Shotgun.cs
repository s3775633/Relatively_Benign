using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun
{
    private string weaponName;
    private int damage;
    private float speed;

    public Shotgun()
    {
        weaponName = "Shotgun";
        damage = 40;
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
