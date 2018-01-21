using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour {

    protected Rigidbody rigidBody;
    protected bool originalKinematicState;
    protected Transform originalParent;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();

        originalParent = transform.parent;
        originalKinematicState = rigidBody.isKinematic;
    }

    public void Pickup (ViveControllerInput controller)
    {
        rigidBody.isKinematic = true;

        transform.SetParent(controller.gameObject.transform);
    }

    public void Release(ViveControllerInput controller)
    {
        if (transform.parent == controller.gameObject.transform)
        {
            rigidBody.isKinematic = originalKinematicState;

            if (originalParent != controller.gameObject.transform)
            {
                transform.SetParent(originalParent);
            }
            else
            {
                transform.SetParent(null);
            }

            rigidBody.velocity = controller.device.velocity;
            rigidBody.angularVelocity = controller.device.angularVelocity;
        }
    }
}
