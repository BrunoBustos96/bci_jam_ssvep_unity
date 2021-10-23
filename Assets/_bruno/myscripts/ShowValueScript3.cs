using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ShowValueScript3 : MonoBehaviour
{

    TextMeshProUGUI valueText;

    // Start is called before the first frame update
    void Start()
    {
        valueText = GetComponent<TextMeshProUGUI> ();
    }

    // Update is called once per frame
    public void textUpdate(float value)
    {
        FlickerBallScript.cycleHz = value;
        //valueText.text = Convert.ToString(value);
        print(value);
        valueText.text = Mathf.RoundToInt(value) + " Hz";
    }
}