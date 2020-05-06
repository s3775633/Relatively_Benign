using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaGauge : MonoBehaviour { 

    public Transform needleGauge;
    private float maxAngle = 270;
    private float minAngle = 90;

    private float maxStamina = 2;
    public float currentStamina;

    // Update is called once per frame
    void Update()
    {
        currentStamina = GetComponent<Player_Movement>().stamina;
        needleGauge.eulerAngles = new Vector3(0, 0, GetGaugeRotation());
    }

    public float GetGaugeRotation()
    {
        float totalAngle = maxAngle - minAngle;
        float normalizedStamina = currentStamina / maxStamina;
        return minAngle - normalizedStamina * totalAngle;
    }
}
