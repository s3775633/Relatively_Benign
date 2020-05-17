using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrap : MonoBehaviour
{
    public Collider2D trap_file_collider;
    public AudioSource trap_fire_audio;
    public GameObject trigger;
    public Animator animator;
    private int trapDamage = 1;

    public Transform player;
    public GameObject playerUnarmed;
    public GameObject playerPistol;
    public GameObject playerRifle;
    public GameObject playerShotgun;
    public GameObject playerMachine;


    TrapTrigger trigger_script;
    public bool running;
    public float timeleft;

    // Start is called before the first frame upadate
    void Start()
    {
        trigger_script = trigger.GetComponent<TrapTrigger>();

        trap_file_collider = this.GetComponent<Collider2D>();
        animator = this.GetComponent<Animator>();
        trap_fire_audio = this.GetComponent<AudioSource>();
        animator.SetBool("active", false);
        Debug.Log("Start has been called");

        playerUnarmed = GameObject.Find("Player");
        Debug.Log("Line 1 called");
        playerPistol = GameObject.Find("Player_Pistol");
        Debug.Log("Line 2 called");
        playerRifle = GameObject.Find("RiflePlayer");
        Debug.Log("Line 3 called");
        playerShotgun = GameObject.Find("ShotgunPlayer");
        playerMachine = GameObject.Find("MachinegunPlayer");
        player = GameObject.Find("Player").transform;
    }
    
    // Update is called once per frame
    void Update()
    {
        timeleft -= Time.deltaTime;
              

        if (trigger_script.activated == true && running == false)
        {
            TrapOn();
        }
        else if (trigger_script.activated == true && running == true)
        {
            timeleft = 4.0f;
            //insert code to keep the trap activated. 
        }

        if (timeleft <= 0)
        {
            TrapOff();
        }

        if (playerUnarmed.activeSelf)
        {
            player = playerUnarmed.transform;
        }
        else if (playerPistol.activeSelf)
        {
            player = playerPistol.transform;
        }
        else if (playerRifle.activeSelf)
        {
            player = playerRifle.transform;
        }
        else if (playerShotgun.activeSelf)
        {
            player = playerShotgun.transform;
        }
        else if (playerMachine.activeSelf)
        {
            player = playerMachine.transform;
        }

    }

    public void TrapOn()
    {
        trap_file_collider.enabled = true;
        trap_fire_audio.Play();
        running = true;
        timeleft = 4.0f;
        animator.SetBool("active", true);
    }

    public void TrapOff()
    {
        trap_file_collider.enabled = false;
        trap_fire_audio.Stop();
        running = false;
        animator.SetBool("active", false);
        timeleft = 0;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            DamagePlayer();
        }
    }

    void DamagePlayer()
    {
        Player player = FindObjectOfType<Player>();
        if (player != null)
        {
            player.DamagePlayer(trapDamage);
        }
    }
}

