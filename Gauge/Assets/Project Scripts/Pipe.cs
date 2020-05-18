using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
	public string imagename;
    // Start is called before the first frame update
    void Start()
    {
       imagename = GetComponent<SpriteRenderer>().sprite.name; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
