using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_manager : MonoBehaviour
{
   public void StartGame(){
       SceneManager.LoadScene("base_level_scene");
   }
    public void DebugScene(){
       SceneManager.LoadScene("SSVEPDebugTool");
   }
 public void MultiplayerGame(){
       SceneManager.LoadScene("multiplayer_level");
   }
   public void QuitGame(){
       Application.Quit();
   }
}
