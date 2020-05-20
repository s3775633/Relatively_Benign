using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Keyboard : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape")){
			SceneManager.LoadScene("MainMenu");
		}
		
		else if (Input.GetKey("p")){
			SceneManager.LoadScene("Main Scene");
		}
    }
}
