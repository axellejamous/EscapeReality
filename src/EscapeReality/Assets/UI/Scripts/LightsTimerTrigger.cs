using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsTimerTrigger : MonoBehaviour {
    public bool IsDark = false;

    private GameObject[] allLights;
    private float time = 0.0f;
    private float secondTimer = 0.0f;

    private ToggleTextVisibility toggleDarkText;

    void Start () {
        // Create array of lights 
        allLights = GameObject.FindGameObjectsWithTag("riddleLights");

        GameObject fltD = GameObject.Find("darkText");
        toggleDarkText = (ToggleTextVisibility)fltD.GetComponent(typeof(ToggleTextVisibility));

        StartCoroutine(FlickerLights());
    }

    IEnumerator FlickerLights()
    {
        while (true)
        {
            yield return new WaitForSeconds(90);
            LightsOff();
            Debug.Log("Lights off");
            yield return new WaitForSeconds(20);
            LightsOn();
            Debug.Log("Lights back on");
        }
    }

    void LightsOff()
    {
        IsDark = true;
        foreach (GameObject i in allLights)
        {
            i.SetActive(false);
        }

        toggleDarkText.ShowText();
    }

    void LightsOn()
    {
        IsDark = false;
        foreach (GameObject i in allLights)
        {
            i.SetActive(true);
        }

        toggleDarkText.HideText();
    }
}
