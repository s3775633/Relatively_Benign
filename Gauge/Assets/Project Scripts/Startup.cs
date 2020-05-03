using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Startup : MonoBehaviour
{
    private GameObject unarmedPlayer;
    private GameObject pistolPlayer;
    private GameObject shotgunPlayer;
    private GameObject riflePlayer;
    private GameObject machinePlayer;
    public Image[] imageWeapon;
    public Image[] imageItem;
    // Start is called before the first frame update
    void Start()
    {    
        unarmedPlayer = GameObject.Find("Player");
        pistolPlayer = GameObject.Find("Player_Pistol");
        shotgunPlayer = GameObject.Find("ShotgunPlayer");
        riflePlayer = GameObject.Find("RiflePlayer");
        machinePlayer = GameObject.Find("MachinegunPlayer");

        pistolPlayer.SetActive(false);
        shotgunPlayer.SetActive(false);
        riflePlayer.SetActive(false);
        machinePlayer.SetActive(false);
        imageWeapon[0].enabled = false;
        imageWeapon[1].enabled = false;
        imageWeapon[2].enabled = false;
        imageItem[0].enabled = false;
        imageItem[1].enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
