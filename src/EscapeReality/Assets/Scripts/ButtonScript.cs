using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using VRTK;

public class ButtonScript : VRTK_InteractableObject
{
    protected GameObject keypad;
    protected AudioSource button_audio;

    protected override void Awake()
    {
        base.Awake();

        keypad = GameObject.Find("Keypad");
        button_audio = GetComponent<AudioSource>();
    }

    public override void StopUsing(VRTK_InteractUse previousUsingObject = null)
    {
        base.StopUsing(previousUsingObject);

        var keypadLogic = keypad.GetComponent<KeypadScript>();
        button_audio.Play();
        keypadLogic.SelectButton(gameObject);
    }

    public override void StartUsing(VRTK_InteractUse currentUsingObject = null)
    {
        base.StartUsing(currentUsingObject);
    }
}
