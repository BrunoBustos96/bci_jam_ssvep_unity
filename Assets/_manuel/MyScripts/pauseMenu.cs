using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public GameObject pauseMenuGUI;

    public GameObject signal_filtering;
    public static bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenuGUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            if(isPaused)
            {
                ResumeGame();
            }
            else{
                PauseGame();
            }
        }
    }


    public void PauseGame(){
        pauseMenuGUI.SetActive(true);
        signal_filtering.SetActive(false);
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void ResumeGame()
    {
        pauseMenuGUI.SetActive(false);
        signal_filtering.SetActive(true);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void BackToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("barracuda_menu");
    }
}
