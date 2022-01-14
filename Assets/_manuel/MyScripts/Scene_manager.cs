using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Scene_manager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject boardMenu;
    public GameObject connectButton;
    public GameObject disconnectButton;


    public void StartGame(){
        SceneManager.LoadScene("base_level_scene");
        staticPorts.gameStarted = true;
    }
    public void DebugScene(){
        SceneManager.LoadScene("SSVEPDebugTool");
    }
    public void MultiplayerGame(){
        SceneManager.LoadScene("multiplayer_level");
    }
    public void TrainingScene(){
        SceneManager.LoadScene("trainingScene");
    }
    public void QuitGame(){
        staticPorts.gameStarted = false;
        Application.Quit();
    }

    public void ChangeMenu(){
        if(mainMenu.active == true){
            mainMenu.SetActive(false);
            
            boardMenu.SetActive(true);

            if(staticPorts.statusON==true){
                connectButton.SetActive(false);
                disconnectButton.SetActive(true);
            }

        }else if(mainMenu.active == false){
            mainMenu.SetActive(true);
            boardMenu.SetActive(false);
        }
    }
}
