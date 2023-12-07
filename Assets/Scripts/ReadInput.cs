using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ReadInput : MonoBehaviour
{
    public TMP_InputField inputA;
    public CannonScript cannonScript;

    private void Start()
    {
        inputA.onValueChanged.AddListener(OnInputValueChanged);
    }

    private void OnInputValueChanged(string value)
    {
        // When the player is editing the input field
        float a;
        if (float.TryParse(value, out a))
        {
            cannonScript.SetParameters(a);
        }
    }
}


