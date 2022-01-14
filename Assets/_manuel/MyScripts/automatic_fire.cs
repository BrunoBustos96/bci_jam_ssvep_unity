using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class automatic_fire : MonoBehaviour
{
    private GameObject player;
    public int enemyNumber;
 

    void Start(){
        player = GameObject.FindWithTag("Player");
    }

    private void Update() {

        var inputValue = Input.inputString;
        
        if (Input.inputString == ""){
            //If input value is EMPTY, the game automatically tries to use the SSVEP signal to shoot
            print("No Keyboard Input");
            inputValue = SignalFiltering.enemySelected;
        }
        
        print("Input "+inputValue);
        if (inputValue == enemyNumber.ToString()){
            faceEnemy();
            //Input.inputString == null;
        }

    }
    private void OnMouseDown() {
        print("clicked!");
        faceEnemy();
        player_asteroids.shooting = false;

    }




     void faceEnemy()
    {
        if (player_asteroids.playerIsAlive == false)
            return;
      

        // transform.position = Vector2.MoveTowards(transform.position, player.transform.position, angularSpeed * Time.deltaTime);
        player.transform.up = -1* (player.transform.position - transform.position);
        // player.transform.up = Vector2.MoveTowards(transform.position, player.transform.position, angularSpeed * Time.deltaTime);
        player_asteroids.shooting = true; //Shoot
        //return;
        //player_asteroids.shooting = false;
    }


 

}



