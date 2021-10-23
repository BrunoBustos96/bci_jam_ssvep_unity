using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class createButtons : MonoBehaviour
{
    public GameObject buttonPrefab;
    public GameObject panelToAttachButtonsTo;
    void Start()//Creates a button and sets it up
    {
       instantiateButton();
    }
    public void OnClick()
    {
        staticPorts.selected_port = EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text; //get port on button
        print("Selected Port:"+staticPorts.selected_port);
        staticPorts.connect = true;

        // staticPorts.selected_port = 
    }

    void instantiateButton()
    {   
        if (staticPorts.ports_names.Length > 0)
        {
            
            foreach (string port in staticPorts.ports_names)
            {
                GameObject button = (GameObject)Instantiate(buttonPrefab);
                button.transform.SetParent(panelToAttachButtonsTo.transform, false);//Setting button parent- set worldPositionStays to false as a second parameter to SetParent.
                button.GetComponent<Button>().onClick.AddListener(OnClick);//Setting what button does when clicked
                //Next line assumes button has child with text as first gameobject like button created from GameObject->UI->Button
                button.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = port;//Changing text
            }
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
