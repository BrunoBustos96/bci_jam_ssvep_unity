using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class gameController : MonoBehaviour
{
    public TextMeshProUGUI text;
    public int currentLvl;
    public int enemiesInLvl;

    public static int currentLvlEnemies;

    // Start is called before the first frame update
    void Start()
    {
        // enemiesLvl_1 = 3;
        currentLvlEnemies = enemiesInLvl;
       
    }

    // Update is called once per frame
    void Update()
    {
        if(player_asteroids.playerIsAlive == false){
            StartCoroutine(GameOverCoroutine());
        }
        if(currentLvlEnemies == 0){
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

            // text.text = "You Win!";
            text.text = "Level Cleared!";
            text.gameObject.SetActive(true);
            yield return new WaitForSeconds(3f);
            // yield return new WaitForSeconds(3f);
            if(currentLvl == 3)
            {
                 SceneManager.LoadScene("menu_asteroids");
            }
            else{
            string s = string.Format("level_0{0}", currentLvl+1);
            SceneManager.LoadScene(s);
            }

    }


    //GameOver - You Lose Screen, wait for secs, show main menu
    //GameWin - You Win!, wait for secs, Level {} Cleared!, next level
}
