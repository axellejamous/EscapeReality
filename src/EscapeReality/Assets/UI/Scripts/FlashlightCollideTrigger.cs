using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightCollideTrigger : MonoBehaviour {

    private ToggleTextVisibility toggleRiddleText;
    private LightsTimerTrigger lightsTriggerScript;

    void Start()
    {
        GameObject flt = GameObject.Find("flashlightText");
        toggleRiddleText = (ToggleTextVisibility)flt.GetComponent(typeof(ToggleTextVisibility));

        GameObject lightsTrigObj = GameObject.Find("lightsTriggerObject");
        lightsTriggerScript = lightsTrigObj.GetComponent<LightsTimerTrigger>();
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Object entered trigger");

        if (lightsTriggerScript.IsDark)
        {
            // Show text if entering text collider
            if (other.gameObject.tag == "flashlightColTrigger")
            {
                Debug.Log("Flashlight triggered: show code.");
                // Call text script's show function
                toggleRiddleText.ShowText();
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (lightsTriggerScript.IsDark)
        {
            // Show text if staying in text collider
            if (other.gameObject.tag == "flashlightColTrigger")
            {
                toggleRiddleText.ShowText();
                //Debug.Log("It's dark and im inside the trigger");
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Object left trigger");

        if (lightsTriggerScript.IsDark)
        {
            // Hide text if leaving text collider
            if (other.gameObject.tag == "flashlightColTrigger")
            {
                Debug.Log("Flashlight exited: hide code.");
                toggleRiddleText.HideText();
            }
        }
        else
        {
            toggleRiddleText.HideText(); // hide regardless of dark or light if outside of trigger
        }
    }
}
