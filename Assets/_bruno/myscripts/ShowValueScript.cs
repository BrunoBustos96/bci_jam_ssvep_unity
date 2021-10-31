using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ShowValueScript : MonoBehaviour
{

    TextMeshProUGUI valueText;

    // Start is called before the first frame update
    void Start()
    {
        valueText = GetComponent<TextMeshProUGUI> ();
        print(valueText.text);
    }

    // Update is called once per frame
    public void textUpdate(float value)
    {
        staticPorts.ssvep_threshold = value;
        //valueText.text = Convert.ToString(value);
        print(value.ToString("0.00"));
        valueText.text = value.ToString("0.00");
        
    }

    /*
    public static void enemyTextUpdate(int value){
        value.Text.text = value.ToString();
    }
    */
}
