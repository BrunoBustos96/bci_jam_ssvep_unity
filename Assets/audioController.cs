
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioController : MonoBehaviour
{
    public GameObject audioBtnOn;
    public GameObject audioBtnOff;
    // Start is called before the first frame update
    void Start()
    {
        SetSoundState();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void ToggleSound(){
        if(PlayerPrefs.GetInt("Muted",0) == 0){
            PlayerPrefs.SetInt("Muted",1);
        }
        else{
            PlayerPrefs.SetInt("Muted", 0);
        }
        SetSoundState();
    }

    private void SetSoundState(){

        if(PlayerPrefs.GetInt("Muted", 0) == 0){
        AudioListener.volume = 1;
        audioBtnOn.SetActive(true);
        audioBtnOff.SetActive(false);
        }
        else{
        AudioListener.volume = 0;
        audioBtnOn.SetActive(false);
        audioBtnOff.SetActive(true);

        }
    }
 
}
