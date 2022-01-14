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
    public static bool multiplayerLvl;

    public static int currentLvlEnemies;

    // Start is called before the first frame update
    void Start()
    {
        // enemiesLvl_1 = 3;
        currentLvlEnemies = enemiesInLvl;
        if(currentLvl == 4){
            multiplayerLvl = true;
            print("MUltiplayer Level");
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        if(player_asteroids.playerIsAlive == false){
            StartCoroutine(GameOverCoroutine());
        }
        else if(currentLvlEnemies == 0){
         StartCoroutine(GameWinCoroutine());
        }
        else if (currentLvlEnemies == 0 && player_asteroids.playerIsAlive == false){
            StartCoroutine(GameOverCoroutine());
        }
        
    }

    IEnumerator GameOverCoroutine(){
             if(gameController.multiplayerLvl == true){
                string s = player_asteroids.winMultiplayer;
                text.text = s;

                text.gameObject.SetActive(true);
                yield return new WaitForSeconds(3f);
                BackToMenu();
             }

        text.text = "You Lose!";
        text.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        BackToMenu();

    }

    IEnumerator GameWinCoroutine(){

            // text.text = "You Win!";
            text.text = "Level Cleared!";
            text.gameObject.SetActive(true);
            yield return new WaitForSeconds(3f);
            // yield return new WaitForSeconds(3f);
            if(currentLvl == 3 || currentLvl ==4)
            {
                BackToMenu();
            }
            else{
            
            string s = string.Format("level_0{0}", currentLvl+1);
            SceneManager.LoadScene(s);
            }

    }

    void BackToMenu(){
        staticPorts.gameStarted = false;
        SceneManager.LoadScene("barracuda_menu");
    }
    
    //GameOver - You Lose Screen, wait for secs, show main menu
    //GameWin - You Win!, wait for secs, Level {} Cleared!, next level
}
