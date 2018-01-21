using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBoxScript : MonoBehaviour {

    protected GameObject target;

    private void OnTriggerEnter(Collider other)
    {
        target = GameObject.Find("Deur");

        if (other.CompareTag("bal"))
        {
            Debug.Log("trigger voor gooipuzzel is opgelost");
            Destroy(target);
            Debug.Log(target);
        }
    }
}
