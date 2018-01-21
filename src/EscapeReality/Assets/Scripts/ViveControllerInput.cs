using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ViveControllerInput : MonoBehaviour {

    protected List<InteractableObject> heldObjects;

    protected SteamVR_TrackedObject trackedObject;

    public SteamVR_Controller.Device device
    {
        get
        {
            return SteamVR_Controller.Input((int)trackedObject.index);
        }
    }

    private void Awake()
    {
        trackedObject = GetComponent<SteamVR_TrackedObject>();
        heldObjects = new List<InteractableObject>();
    }

    private void OnTriggerStay(Collider other)
    {
        InteractableObject interactable = other.GetComponent<InteractableObject>();

        if (interactable != null)
        {
            if (device.GetPressDown(EVRButtonId.k_EButton_SteamVR_Trigger))
            {
                interactable.Pickup(this);
                heldObjects.Add(interactable);
            }
        }
    }

    private void Update()
    {
        if (heldObjects.Count > 0)
        {
            if (device.GetPressUp(EVRButtonId.k_EButton_SteamVR_Trigger))
            {
                for (int i = 0; i < heldObjects.Count; i++)
                {
                    heldObjects[i].Release(this);
                }
                heldObjects = new List<InteractableObject>();
            }
        }
    }
}
