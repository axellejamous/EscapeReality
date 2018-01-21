using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using VRTK;

public class KeypadScript : MonoBehaviour
{

    protected GameObject safedoor;
    public string password = "125";
    protected StringBuilder keypad_input;
    protected int character_max;
    AudioSource keypad_audio;
    AudioSource safedoor_audio;
    protected TextMesh keypad_text;

    void Awake ()
    {
        character_max = password.Length;
        safedoor = GameObject.Find("Kluis_Deur");
        keypad_input = new StringBuilder("");
        keypad_audio = GetComponent<AudioSource>();
        safedoor_audio = safedoor.GetComponent<AudioSource>();
        keypad_text = GameObject.Find("Keypad_Text").GetComponent<TextMesh>();
    }
	
    public void SelectButton (GameObject button)
    {
        switch (button.name)
            {
                case "Button_1":
                    AppendPassword("1");
                    break;

                case "Button_2":
                    AppendPassword("2");
                    break;

                case "Button_3":
                    AppendPassword("3");
                    break;

                case "Button_4":
                    AppendPassword("4");
                    break;

                case "Button_5":
                    AppendPassword("5");
                    break;

                case "Button_6":
                    AppendPassword("6");
                    break;

                case "Button_7":
                    AppendPassword("7");
                    break;

                case "Button_8":
                    AppendPassword("8");
                    break;

                case "Button_9":
                    AppendPassword("9");
                    break;

                default:
                    Debug.Log("Default reached, problem with button switch");
                    break;
            }
    }

    public void AppendPassword (string input)
    {
        if (keypad_input.Length < character_max)
        {
            keypad_input.Append(input);           
            Debug.Log("Huidig wachtwoord: " + keypad_input);

            if (keypad_input.ToString() == password)
            {
                Debug.Log("Kluis open!");
                safedoor_audio.Play();
                Destroy(safedoor);
                keypad_input.Remove(0, character_max);
                keypad_input.Append("SUCCESS");
            }
        }
        else
        {
            keypad_input.Remove(0, character_max); //verwijdert huidige string in input stringbuilder
            keypad_audio.Play();
            Debug.Log("Max input length reached");
        }
        keypad_text.text = keypad_input.ToString();
    }
}
