using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleTextVisibility : MonoBehaviour {
    public void HideText () {
        GetComponent<MeshRenderer>().enabled = false;
    }

    public void ShowText () {
        GetComponent<MeshRenderer>().enabled = true;
    }
}
