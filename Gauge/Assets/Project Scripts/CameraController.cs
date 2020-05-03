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
        if (player.activeSelf)
        {
            transform.position = player.transform.position + offset;
        }
        else if (riflePlayer.activeSelf)
        {
            transform.position = riflePlayer.transform.position + offset;
        }
        else if (pistolPlayer.activeSelf)
        {
            transform.position = pistolPlayer.transform.position + offset;
        }
        else if (shotgunPlayer.activeSelf)
        {
            transform.position = shotgunPlayer.transform.position + offset;
        }
        else if (machinegunPlayer.activeSelf)
        {
            transform.position = machinegunPlayer.transform.position + offset;
        }
    }

    void Update()
    {

    }
}
