using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class gameController : MonoBehaviour
{
    public TextMeshProUGUI text;
    public static int enemiesLvl_1;
    public static int currentLvl;

    // Start is called before the first frame update
    void Start()
    {
        enemiesLvl_1 = 3;
       
    }

    // Update is called once per frame
    void Update()
    {
        if(player_asteroids.playerIsAlive == false){
            StartCoroutine(GameOverCoroutine());
        }
        if(enemiesLvl_1 == 0){
         StartCoroutine(GameWinCoroutine());
        }
        
    }

    IEnumerator GameOverCoroutine(){
        text.text = "You Lose!";
        text.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("menu_asteroids");

    }

    IEnumerator GameWinCoroutine(){

            text.text = "You Win!";
            text.gameObject.SetActive(true);
            yield return new WaitForSeconds(3f);
            text.text = "Level Cleared!";
            yield return new WaitForSeconds(3f);
            SceneManager.LoadScene("menu_asteroids");

    }


    //GameOver - You Lose Screen, wait for secs, show main menu
    //GameWin - You Win!, wait for secs, Level {} Cleared!, next level
}
