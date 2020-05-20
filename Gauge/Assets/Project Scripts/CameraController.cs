using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public GameObject riflePlayer;
    public GameObject pistolPlayer;
    public GameObject shotgunPlayer;
    public GameObject machinegunPlayer;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
		player = GameObject.Find("Player");
		riflePlayer = GameObject.Find("RiflePlayer");
		pistolPlayer = GameObject.Find("Player_Pistol");
		shotgunPlayer = GameObject.Find("ShotgunPlayer");
		machinegunPlayer = GameObject.Find("MachinegunPlayer");
	
        if (player != null)
        {
            transform.position = player.transform.position + offset;
        }
        else if (riflePlayer != null)
        {
            transform.position = riflePlayer.transform.position + offset;
        }
        else if (pistolPlayer != null)
        {
            transform.position = pistolPlayer.transform.position + offset;
        }
        else if (shotgunPlayer != null)
        {
            transform.position = shotgunPlayer.transform.position + offset;
        }
        else if (machinegunPlayer != null)
        {
            transform.position = machinegunPlayer.transform.position + offset;
        }
    }

    void Update()
    {

    }
}
