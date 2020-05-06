using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap_flame : MonoBehaviour
{
    public Collider2D trap_file_collider;
    public AudioSource trap_fire_audio;
    public GameObject trigger;
    public Animator animator;
    public GameObject player;
    Player player_health;
    TrapTrigger trigger_script;
    public bool activated;
    public float timeleft;
    // Start is called before the first frame update
    void Start()
    {
        trigger_script = trigger.GetComponent<TrapTrigger>();
        player_health = player.GetComponent<Player>();
        trap_file_collider = this.GetComponent<Collider2D> ();
        trap_fire_audio = this.GetComponent<AudioSource>();
    }
    
    // Update is called once per frame
    void Update()
    {
        timeleft -= Time.deltaTime;
        if (timeleft <= 0)
        {
            TrapOff();
            animator.SetBool("active", false);
            activated = false;
        }

        if (trigger_script.activated == true && activated == false)
        {
            TrapOn();
        }
        else if (trigger_script == true && activated == true)
        {
            //insert code to keep the trap activated. 
        }


    }

    public void TrapOn()
    {
        trap_file_collider.enabled = true;
        trap_fire_audio.Play();
        activated = true;
        timeleft = 3.0f;
        animator.SetBool("active", true);
    }

    public void TrapOff()
    {
        trap_file_collider.enabled = false;
        trap_fire_audio.Stop();
        activated = false;
        animator.SetBool("active", false);
    }

    void OnTriggerStay2D(Collider2D player)
    {
        player_health.DamagePlayer(1);
    }
}
