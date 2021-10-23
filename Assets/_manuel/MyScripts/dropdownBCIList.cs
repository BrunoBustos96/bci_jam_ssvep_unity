using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using brainflow;
using System;

public class dropdownBCIList : MonoBehaviour
{

    public TMP_Dropdown dropdown;

    // Start is called before the first frame update
    void Start()
    {
         instantiateButton();
        // foreach (var eeg in Enum.GetNames(typeof(BoardIds)))
        // {
        //     print(eeg);
        // }
    }

public void OnClick()
    {
            staticPorts.connect = true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

     void instantiateButton()
    {   
        // var dropdown = transform.GetComponent<Dropdown>();

        dropdown.options.Clear();
    


         foreach (var eeg in Enum.GetNames(typeof(BoardIds)))
        {
            // print(eeg);
             dropdown.options.Add(new TMP_Dropdown.OptionData() { text = eeg});
        }
           DropdownItemSelected(dropdown);
           dropdown.onValueChanged.AddListener(delegate {DropdownItemSelected(dropdown);});

        // if (staticPorts.ports_names.Length > 0)
        // {
            
        //     foreach (string port in staticPorts.ports_names)
        //     {
        //         // GameObject button = (GameObject)Instantiate(buttonPrefab);
        //         // button.transform.SetParent(panelToAttachButtonsTo.transform, false);//Setting button parent- set worldPositionStays to false as a second parameter to SetParent.
        //         // button.GetComponent<Button>().onClick.AddListener(OnClick);//Setting what button does when clicked
        //         // //Next line assumes button has child with text as first gameobject like button created from GameObject->UI->Button
        //         // button.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = port;//Changing text
        //         // items.Add(port);
        //         dropdown.options.Add(new TMP_Dropdown.OptionData() { text = port});
        //     }

        //     DropdownItemSelected(dropdown);
        //    dropdown.onValueChanged.AddListener(delegate {DropdownItemSelected(dropdown);});
        // }

    }

     void DropdownItemSelected(TMP_Dropdown dropdown)
        {
            int index = dropdown.value;

            dropdown.itemText.text =  dropdown.options[index].text;
            staticPorts.boardIdSelected = (int)index;
            // staticPorts.selected_port = dropdown.options[index].text; //get port on button
            print("Selected Board:"+staticPorts.boardIdSelected);
        // staticPorts.synthetic = true;

            // textBox.text = dropdown.options[index].text;
        }




}
