using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cog : MonoBehaviour
{
    public Animator animator;
    private float lastPlay;

    // Update is called once per frame
    void Update()
    {
        if(Time.time - lastPlay >= 3)
        {
            lastPlay = Time.time;
            animator.Play("Cog_Animation");
        }
        
    }
}
