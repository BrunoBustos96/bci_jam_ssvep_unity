using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class dropdownComPorts : MonoBehaviour
{
    // public Dropdown dropdown;

    public TMP_Dropdown dropdown;

    // public TextMeshProUGUI textBox;

    void Start()//Creates a button and sets it up
    {
       instantiateButton();
    }

    public void OnClick()
    {
        staticPorts.connect = true;
        
    }

    void instantiateButton()
    {   
        // var dropdown = transform.GetComponent<Dropdown>();

        dropdown.options.Clear();


        if (staticPorts.ports_names.Length > 0)
        {
            
            foreach (string port in staticPorts.ports_names)
            {
                // GameObject button = (GameObject)Instantiate(buttonPrefab);
                // button.transform.SetParent(panelToAttachButtonsTo.transform, false);//Setting button parent- set worldPositionStays to false as a second parameter to SetParent.
                // button.GetComponent<Button>().onClick.AddListener(OnClick);//Setting what button does when clicked
                // //Next line assumes button has child with text as first gameobject like button created from GameObject->UI->Button
                // button.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = port;//Changing text
                // items.Add(port);
                dropdown.options.Add(new TMP_Dropdown.OptionData() { text = port});
            }

            DropdownItemSelected(dropdown);
           dropdown.onValueChanged.AddListener(delegate {DropdownItemSelected(dropdown);});
        }

    }


    void DropdownItemSelected(TMP_Dropdown dropdown)
        {
            int index = dropdown.value;
            dropdown.itemText.text =  dropdown.options[index].text;
            staticPorts.selected_port = dropdown.options[index].text; //get port on button
            print("Selected Port:"+staticPorts.selected_port);
            // textBox.text = dropdown.options[index].text;
        }

    // Update is called once per frame
    void Update()
    {
        
    }
}
