using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTrigger : MonoBehaviour
{
    // set the collision variable
    public Collider2D triggered;
    public Animator animator;
    public bool activated;
 

    // Start is called before the first frame update
    void Start()
    {
        triggered = this.GetComponent<Collider2D>();
        animator = this.GetComponent<Animator>();
        activated = false;
    }



    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            activated = true;
            animator.SetBool("triggered", true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            activated = false;
            animator.SetBool("triggered", false);
        }
    }
}