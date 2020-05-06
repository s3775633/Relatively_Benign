using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTrigger : MonoBehaviour
{
    // set the collision variable
    public Collider2D triggered;
    public bool activated;
 

    // Start is called before the first frame update
    void Start()
    {
        triggered = this.GetComponent<Collider2D>();
        activated = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        activated = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        activated = false;
    }
}